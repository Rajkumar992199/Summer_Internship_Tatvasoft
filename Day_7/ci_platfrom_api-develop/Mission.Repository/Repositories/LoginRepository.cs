using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Mission.Entity.Entities;
using Mission.Entity.Models.LoginModels;
using Mission.Repository.IRepositories;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Mission.Repository.Repositories
{
    public class LoginRepository(MissionDbContext cIDbContext) : ILoginRepository
    {
        private readonly MissionDbContext _cIDbContext = cIDbContext;

        public async Task<string> Register(RegisterUserRequestModel model, string webRootPath)
        {
            var userExists = _cIDbContext.User.Any(u => u.EmailAddress.ToLower() == model.EmailAddress.ToLower() && !u.IsDeleted);

            if (userExists) throw new Exception("Email Address Already Exist.");

            string imagePath = await SaveImageAsync(model.ProfileImage, "Images", webRootPath);

            var newUser = new User()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                EmailAddress = model.EmailAddress,
                Password = model.Password,
                UserType = model.UserType,
                UserImage = imagePath,
                CreatedDate = DateTime.UtcNow,
            };

            _cIDbContext.User.Add(newUser);
            _cIDbContext.SaveChanges();

            return "Account Created Successfully..";
        }

        public LoginUserResponseModel LoginUser(LoginUserRequestModel model)
        {
            var existingUser = _cIDbContext.User
                .FirstOrDefault(u => u.EmailAddress.ToLower() == model.EmailAddress.ToLower() && !u.IsDeleted);

            if (existingUser == null)
            {
                return new LoginUserResponseModel() { Message = "Email Address Not Found." };
            }
            if (existingUser.Password != model.Password)
            {
                return new LoginUserResponseModel() { Message = "Incorrect Password." };
            }

            return new LoginUserResponseModel
            {
                Id = existingUser.Id,
                FirstName = existingUser.FirstName ?? string.Empty,
                LastName = existingUser.LastName ?? string.Empty,
                PhoneNumber = existingUser.PhoneNumber,
                EmailAddress = existingUser.EmailAddress,
                UserType = existingUser.UserType,
                UserImage = existingUser.UserImage != null ? existingUser.UserImage : string.Empty,
                Message = "Login Successfully"
            };
        }

        public async Task<string> ForgotPassword(ForgotPasswordRequestModel model, int userId)
        {
            var newForgotPassword = new ForgotPassword()
            {
                Id = Guid.NewGuid().ToString(),
                UserId = userId,
                RequestDateTime = DateTime.Now
            };

            await _cIDbContext.ForgotPassword.AddAsync(newForgotPassword);
            await _cIDbContext.SaveChangesAsync();

            return newForgotPassword.Id;
        }

        public async Task<string> ResetPassword(ResetPasswordRequestModel model)
        {
            var data = await _cIDbContext.ForgotPassword.Where(c => c.Id == model.Uid).FirstOrDefaultAsync();

            if (data == null) return "Failure";

            var userData = await _cIDbContext.User.Where(c => c.Id == data.UserId).FirstOrDefaultAsync();

            if (userData == null) return "Failure";

            using var transaction = await _cIDbContext.Database.BeginTransactionAsync();
            try
            {
                userData.Password = model.Password;

                _cIDbContext.User.Update(userData);
                _cIDbContext.ForgotPassword.Remove(data);

                await _cIDbContext.SaveChangesAsync();
                await transaction.CommitAsync();

                return "Success";
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public string ChangePassword(ChangePasswordRequestModel model)
        {
            if (model.NewPassword != model.ConfirmPassword) throw new Exception("Password and Confirm Password not matched.");

            var user = _cIDbContext.User.FirstOrDefault(u => u.Id == model.UserId && !u.IsDeleted) ?? throw new Exception("User Not Found.");

            if (user.Password != model.OldPassword) throw new Exception("Old Password is Incorrect.");

            user.Password = model.NewPassword;
            user.ModifiedDate = DateTime.UtcNow;

            _cIDbContext.User.Update(user);
            _cIDbContext.SaveChanges();

            return "Password Changed Successfully..";
        }

        public UserResponseModel LoginUserDetailById(int id)
        {
            var userDetail = _cIDbContext.User
                .Where(u => u.Id == id && !u.IsDeleted)
                .Select(user => new UserResponseModel()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber,
                    EmailAddress = user.EmailAddress,
                    UserType = user.UserType,
                    ProfileImage = user.UserImage,
                })
                .FirstOrDefault() ?? throw new Exception("User not found.");

            return userDetail;
        }

        public async Task<string> UpdateUser(UserRequestModel model, string webRootPath)
        {
            var userExists = _cIDbContext.User
                .Any(u => u.EmailAddress.ToLower() == model.EmailAddress.ToLower() && u.Id != model.Id && !u.IsDeleted);

            if (userExists) throw new Exception("Email Address Already Exist.");

            var existingUserDetail = _cIDbContext.User.Where(u => u.Id == model.Id && !u.IsDeleted).FirstOrDefault() ?? throw new Exception("User not found.");

            string finalImagePath = existingUserDetail.UserImage;

            if (model.ProfileImage != null && !string.IsNullOrEmpty(existingUserDetail.UserImage))
            {
                string oldImageFullPath = Path.Combine(webRootPath, existingUserDetail.UserImage.Replace("/", Path.DirectorySeparatorChar.ToString()));
                if (File.Exists(oldImageFullPath))
                {
                    File.Delete(oldImageFullPath);
                }
            }
            string imagePath = await SaveImageAsync(model.ProfileImage, "Images", webRootPath);

            if (existingUserDetail != null)
            {
                existingUserDetail.FirstName = model.FirstName;
                existingUserDetail.LastName = model.LastName;
                existingUserDetail.PhoneNumber = model.PhoneNumber;
                existingUserDetail.EmailAddress = model.EmailAddress;
                existingUserDetail.ModifiedDate = DateTime.UtcNow;
                existingUserDetail.UserImage = imagePath;
                _cIDbContext.User.Update(existingUserDetail);
            }

            _cIDbContext.SaveChanges();

            return "User Updated Successfully..";
        }

        public UserDetailResponseModel GetUserProfileDetailById(int userId)
        {
            var userDetail = _cIDbContext.UserDetail
                .Where(ud => ud.UserId == userId && !ud.IsDeleted)
                .Select(ud => new UserDetailResponseModel()
                {
                    Id = ud.Id,
                    UserId = ud.UserId,
                    Name = ud.Name,
                    Surname = ud.Surname,
                    EmployeeId = ud.EmployeeId,
                    Manager = ud.Manager,
                    Title = ud.Title,
                    Department = ud.Department,
                    MyProfile = ud.MyProfile,
                    WhyIVolunteer = ud.WhyIVolunteer,
                    CountryId = ud.CountryId,
                    CityId = ud.CityId,
                    Availability = ud.Availability,
                    LinkedInUrl = ud.LinkedInUrl,
                    MySkills = ud.MySkills,
                    UserImage = ud.UserImage,
                })
                .FirstOrDefault() ?? throw new Exception("User detail not found.");

            return userDetail;
        }

        public string LoginUserProfileUpdate(AddUpdateUserDetailRequestModel model)
        {
            using var transaction = _cIDbContext.Database.BeginTransaction();
            try
            {
                var user = _cIDbContext.User.FirstOrDefault(u => u.Id == model.UserId) ?? throw new Exception("User not found.");

                var existingUserDetail = _cIDbContext.UserDetail
                    .Where(ud => ud.UserId == model.UserId && !ud.IsDeleted)
                    .FirstOrDefault();

                if (existingUserDetail != null)
                {
                    existingUserDetail.Name = model.Name;
                    existingUserDetail.Surname = model.Surname;
                    existingUserDetail.EmployeeId = model.EmployeeId;
                    existingUserDetail.Manager = model.Manager;
                    existingUserDetail.Title = model.Title;
                    existingUserDetail.Department = model.Department;
                    existingUserDetail.MyProfile = model.MyProfile;
                    existingUserDetail.WhyIVolunteer = model.WhyIVolunteer;
                    existingUserDetail.CountryId = model.CountryId;
                    existingUserDetail.CityId = model.CityId;
                    existingUserDetail.Availability = model.Availability;
                    existingUserDetail.LinkedInUrl = model.LinkedInUrl;
                    existingUserDetail.MySkills = model.MySkills;
                    existingUserDetail.UserImage = model.UserImage;
                    existingUserDetail.Status = model.Status;
                    existingUserDetail.ModifiedDate = DateTime.UtcNow;

                    _cIDbContext.UserDetail.Update(existingUserDetail);
                }
                else
                {
                    var newUserDetail = new UserDetail()
                    {
                        UserId = model.UserId,
                        Name = model.Name,
                        Surname = model.Surname,
                        EmployeeId = model.EmployeeId,
                        Manager = model.Manager,
                        Title = model.Title,
                        Department = model.Department,
                        MyProfile = model.MyProfile,
                        WhyIVolunteer = model.WhyIVolunteer,
                        CountryId = model.CountryId,
                        CityId = model.CityId,
                        Availability = model.Availability,
                        LinkedInUrl = model.LinkedInUrl,
                        MySkills = model.MySkills,
                        UserImage = model.UserImage,
                        Status = model.Status,
                        CreatedDate = DateTime.UtcNow,
                        ModifiedDate = null,
                        IsDeleted = false
                    };

                    _cIDbContext.UserDetail.Add(newUserDetail);
                }

                user.FirstName = model.Name;
                user.LastName = model.Surname;

                _cIDbContext.User.Update(user);
                _cIDbContext.SaveChanges();

                transaction.Commit();

                return "Account Updated Successfully...";
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }

        public async Task<UserRequestModel> GetUserByEmail(string email)
        {
            return await _cIDbContext.User
                .Where(c => c.EmailAddress.ToLower() == email.ToLower())
                .Select(user => new UserRequestModel()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber,
                    EmailAddress = user.EmailAddress,
                    UserType = user.UserType,
                }).FirstOrDefaultAsync();
        }


        /// <summary>
        /// Saves the image to the specified folder and returns the relative path.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="folderName"></param>
        /// <param name="webRootPath"></param>
        /// <returns>The relative path of the saved image.</returns>
        private async Task<string> SaveImageAsync(IFormFile file, string folderName, string webRootPath)
        {
            if (file == null || file.Length == 0) return null;

            string uploadsFolder = Path.Combine(webRootPath, folderName);
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            string fileExtension = Path.GetExtension(file.FileName);
            string fileName = $"{Path.GetFileNameWithoutExtension(file.FileName)}_{DateTime.UtcNow:yyyyMMddHHmmss}{fileExtension}";
            string fullPath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Path.Combine(folderName, fileName).Replace("\\", "/");
        }

    }
}
