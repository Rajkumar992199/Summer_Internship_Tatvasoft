using Mission.Entity;
using Microsoft.EntityFrameworkCore;
using Mission.Entity.Entities;
using Mission.Entity.Models.CommonModels;
using Mission.Entity.Models.MissionModels;
using Mission.Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace Mission.Repository.Repositories
{
    public class MissionRepository(MissionDbContext cIDbContext) : IMissionRepository
    {
        private readonly MissionDbContext _cIDbContext = cIDbContext;

        public List<DropDownResponseModel> GetMissionThemeList()
        {
            List<DropDownResponseModel> missionthemeList = _cIDbContext.MissionTheme
                .Where(mt => mt.Status == "active" && !mt.IsDeleted)
                .Select(mt => new DropDownResponseModel(mt.Id, mt.ThemeName))
                .ToList();

            return missionthemeList;
        }

        public List<DropDownResponseModel> GetMissionSkillList()
        {
            List<DropDownResponseModel> missionskillList = _cIDbContext.MissionSkill
                .Where(mt => mt.Status == "active" && !mt.IsDeleted)
                .Select(mt => new DropDownResponseModel(mt.Id, mt.SkillName))
                .ToList();

            return missionskillList;
        }

        public List<MissionResponseModel> MissionList()
        {
            List<MissionResponseModel> missions = _cIDbContext.Missions
                .Where(m => !m.IsDeleted && !m.MissionTheme.IsDeleted)
                .Select(m => new MissionResponseModel()
                {
                    Id = m.Id,
                    CityId = m.CityId,
                    CityName = m.City.CityName,
                    CountryId = m.CountryId,
                    CountryName = m.Country.CountryName,
                    MissionTitle = m.MissionTitle,
                    MissionDescription = m.MissionDescription,
                    MissionOrganisationName = m.MissionOrganisationName,
                    MissionOrganisationDetail = m.MissionOrganisationDetail,
                    MissionType = m.MissionType,
                    TotalSheets = m.TotalSheets,
                    RegistrationDeadLine = m.RegistrationDeadLine,
                    MissionThemeId = m.MissionThemeId,
                    MissionImages = m.MissionImages,
                    MissionDocuments = m.MissionDocuments,
                    MissionVideoUrl = m.MissionVideoUrl,
                    MissionAvailability = m.MissionAvailability,
                    StartDate = m.StartDate,
                    EndDate = m.EndDate,
                    MissionThemeName = m.MissionTheme.ThemeName
                })
                .ToList();

            return missions;
        }

        public string AddMission(AddMissionRequestModel model)
        {
            var missionExist = _cIDbContext.Missions.Any(m => m.MissionTitle.ToLower() == model.MissionTitle.ToLower()
                && m.CityId == model.CityId
                && m.StartDate.Date == model.StartDate.Date
                && m.EndDate.Date == model.EndDate.Date
                && !m.IsDeleted);

            if (missionExist) throw new Exception("Mission Already Exist.");

            var newMission = new Missions()
            {
                MissionTitle = model.MissionTitle,
                MissionDescription = model.MissionDescription,
                MissionOrganisationName = model.MissionOrganisationName,
                MissionOrganisationDetail = model.MissionOrganisationDetail,
                CountryId = model.CountryId,
                CityId = model.CityId,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                MissionType = model.MissionType,
                TotalSheets = model.TotalSheets,
                RegistrationDeadLine = model.RegistrationDeadLine,
                MissionThemeId = model.MissionThemeId,
                MissionSkillId = model.MissionSkillId,
                MissionImages = model.MissionImages,
                MissionDocuments = model.MissionDocuments,
                MissionAvailability = model.MissionAvailability,
                MissionVideoUrl = model.MissionVideoUrl,
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = null,
                IsDeleted = false
            };

            _cIDbContext.Missions.Add(newMission);
            _cIDbContext.SaveChanges();

            return "Save Mission Detail Successfully..";
        }

        public MissionResponseModel MissionDetailById(int id)
        {
            var mission = _cIDbContext.Missions
                .Where(m => m.Id == id && !m.IsDeleted)
                .Select(m => new MissionResponseModel()
                {
                    Id = m.Id,
                    CityId = m.CityId,
                    CityName = m.City.CityName,
                    CountryId = m.CountryId,
                    CountryName = m.Country.CountryName,
                    MissionTitle = m.MissionTitle,
                    MissionDescription = m.MissionDescription,
                    MissionOrganisationName = m.MissionOrganisationName,
                    MissionOrganisationDetail = m.MissionOrganisationDetail,
                    MissionType = m.MissionType,
                    TotalSheets = m.TotalSheets,
                    RegistrationDeadLine = m.RegistrationDeadLine,
                    MissionThemeId = m.MissionThemeId,
                    MissionImages = m.MissionImages,
                    MissionDocuments = m.MissionDocuments,
                    MissionVideoUrl = m.MissionVideoUrl,
                    MissionAvailability = m.MissionAvailability,
                    StartDate = m.StartDate,
                    EndDate = m.EndDate,
                    MissionThemeName = m.MissionTheme.ThemeName
                })
                .FirstOrDefault() ?? throw new Exception("Mission not found.");

            return mission;
        }

        public string UpdateMission(UpdateMissionRequestModel model)
        {
            var missionExist = _cIDbContext.Missions.Any(m => m.Id != model.Id
                && m.MissionTitle.ToLower() == model.MissionTitle.ToLower()
                && m.CityId == model.CityId
                && m.StartDate.Date == model.StartDate.Date
                && m.EndDate.Date == model.EndDate.Date
                && !m.IsDeleted);

            if (missionExist) throw new Exception("Mission Already Exist.");

            var missionToUpdate = _cIDbContext.Missions.Where(m => m.Id == model.Id && !m.IsDeleted).FirstOrDefault() ?? throw new Exception("Mission not found.");

            missionToUpdate.Id = model.Id;
            missionToUpdate.MissionTitle = model.MissionTitle;
            missionToUpdate.MissionDescription = model.MissionDescription;
            missionToUpdate.MissionOrganisationName = model.MissionOrganisationName;
            missionToUpdate.MissionOrganisationDetail = model.MissionOrganisationDetail;
            missionToUpdate.CountryId = model.CountryId;
            missionToUpdate.CityId = model.CityId;
            missionToUpdate.StartDate = model.StartDate;
            missionToUpdate.EndDate = model.EndDate;
            missionToUpdate.MissionType = model.MissionType;
            missionToUpdate.TotalSheets = model.TotalSheets;
            missionToUpdate.RegistrationDeadLine = model.RegistrationDeadLine;
            missionToUpdate.MissionThemeId = model.MissionThemeId;
            missionToUpdate.MissionSkillId = model.MissionSkillId;
            missionToUpdate.MissionImages = model.MissionImages;
            missionToUpdate.MissionDocuments = model.MissionDocuments;
            missionToUpdate.MissionAvailability = model.MissionAvailability;
            missionToUpdate.MissionVideoUrl = model.MissionVideoUrl;
            missionToUpdate.ModifiedDate = DateTime.UtcNow;

            _cIDbContext.Missions.Update(missionToUpdate);
            _cIDbContext.SaveChanges();

            return "Update Mission Detail Successfully..";
        }

        public string DeleteMission(int id)
        {
            var mission = _cIDbContext.Missions.Where(m => m.Id == id).ExecuteUpdate(m => m.SetProperty(property => property.IsDeleted, true));

            return "Delete Mission Detail Successfully.";
        }

        public List<MissionApplicationResponseModel> MissionApplicationList()
        {
            var missionApplicationList = _cIDbContext.MissionApplication
                .Where(ma => !ma.IsDeleted && !ma.Mission.IsDeleted && !ma.User.IsDeleted)
                .Select(ma => new MissionApplicationResponseModel()
                {
                    Id = ma.Id,
                    MissionId = ma.MissionId,
                    MissionTitle = ma.Mission.MissionTitle,
                    MissionTheme = ma.Mission.MissionTheme.ThemeName,
                    UserId = ma.User.Id,
                    UserName = $"{ma.User.FirstName} {ma.User.LastName}",
                    UserImage = ma.User.UserDetail != null ? ma.User.UserDetail.UserImage : string.Empty,
                    AppliedDate = ma.AppliedDate,
                    Status = ma.Status,
                    Sheet = ma.Sheet
                })
                .ToList();

            return missionApplicationList;
        }

        public string MissionApplicationDelete(int id)
        {
            _cIDbContext.MissionApplication
               .Where(ma => ma.Id == id)
               .ExecuteUpdate(ma => ma.SetProperty(property => property.IsDeleted, true));

            return "Success";
        }

        public string MissionApplicationApprove(int id)
        {
            var updatedRecordsCount = _cIDbContext.MissionApplication
                .Where(m => m.Id == id)
                .ExecuteUpdate(m => m.SetProperty(property => property.Status, true));

            return updatedRecordsCount > 0 ? "Mission is approved" : "Mission is not approved";
        }

        public List<MissionDetailResponseModel> ClientSideMissionList(int userId)
        {
            var clientSideMissionlist = _cIDbContext.Missions
                .Where(m => !m.IsDeleted)
                .OrderBy(m => m.CreatedDate)
                .Select(m => new MissionDetailResponseModel()
                {
                    Id = m.Id,
                    MissionTitle = m.MissionTitle,
                    MissionDescription = m.MissionDescription,
                    MissionOrganisationName = m.MissionOrganisationName,
                    MissionOrganisationDetail = m.MissionOrganisationDetail,
                    CountryId = m.CountryId,
                    CityId = m.CityId,
                    StartDate = m.StartDate,
                    EndDate = m.EndDate,
                    MissionType = m.MissionType,
                    TotalSheets = m.TotalSheets,
                    RegistrationDeadLine = m.RegistrationDeadLine,
                    MissionThemeId = m.MissionThemeId,
                    MissionSkillId = m.MissionSkillId,
                    MissionImages = m.MissionImages,
                    MissionDocuments = m.MissionDocuments,
                    MissionAvailability = m.MissionAvailability,
                    MissionVideoUrl = m.MissionVideoUrl,
                    CountryName = m.Country.CountryName,
                    CityName = m.City.CityName,
                    MissionThemeName = m.MissionTheme.ThemeName,
                    MissionSkillName = string.Join(",", _cIDbContext.MissionSkill
                        .Where(ms => m.MissionSkillId.Contains(ms.Id.ToString()))
                        .Select(ms => ms.SkillName)
                        .ToList()),
                    MissionStatus = m.RegistrationDeadLine < DateTime.Now.AddDays(-1) ? "Closed" : "Available",
                    MissionApplyStatus = m.MissionApplications.Any(ma => ma.UserId == userId) ? "Applied" : "Apply",
                    MissionApproveStatus = m.MissionApplications.Any(ma => ma.UserId == userId && ma.Status == true) ? "Approved" : "Applied",
                    MissionDateStatus = m.EndDate <= DateTime.Now.AddDays(-1) ? "MissionEnd" : "MissionRunning",
                    MissionDeadLineStatus = m.RegistrationDeadLine <= DateTime.Now.AddDays(-1) ? "Closed" : "Running",
                    MissionFavouriteStatus = m.MissionFavourites.Any(mf => mf.UserId == userId) ? "1" : "0",
                    Rating = m.MissionRatings.Where(mr => mr.UserId == userId).Select(mr => mr.Rating).FirstOrDefault() ?? 0,
                })
                .ToList();

            return clientSideMissionlist;
        }

        public List<MissionDetailResponseModel> MissionClientList(MissionDetailRequestModel model)
        {
            var clientSideMissionQuery = _cIDbContext.Missions.Where(m => !m.IsDeleted);

            switch (model.SortestValue)
            {
                case "Newest":
                    clientSideMissionQuery.OrderByDescending(m => m.CreatedDate);
                    break;
                case "Lowest available seats":
                    clientSideMissionQuery.OrderBy(m => m.TotalSheets);
                    break;
                case "Highest available seats":
                    clientSideMissionQuery.OrderBy(m => m.TotalSheets);
                    break;
                case "My favourites":
                    clientSideMissionQuery.OrderByDescending(m => m.MissionFavourites.Count).ThenBy(m => m.Id);
                    break;
                case "Registration deadline":
                    clientSideMissionQuery.OrderBy(m => m.RegistrationDeadLine);
                    break;
                case "Oldest":
                default:
                    clientSideMissionQuery.OrderByDescending(m => m.CreatedDate);
                    break;
            };

            var clientSideMissionList = clientSideMissionQuery
                .Select(m => new MissionDetailResponseModel()
                {
                    Id = m.Id,
                    MissionTitle = m.MissionTitle,
                    MissionDescription = m.MissionDescription,
                    MissionOrganisationName = m.MissionOrganisationName,
                    MissionOrganisationDetail = m.MissionOrganisationDetail,
                    CountryId = m.CountryId,
                    CityId = m.CityId,
                    StartDate = m.StartDate,
                    EndDate = m.EndDate,
                    MissionType = m.MissionType,
                    TotalSheets = m.TotalSheets,
                    RegistrationDeadLine = m.RegistrationDeadLine,
                    MissionThemeId = m.MissionThemeId,
                    MissionSkillId = m.MissionSkillId,
                    MissionImages = m.MissionImages,
                    MissionDocuments = m.MissionDocuments,
                    MissionAvailability = m.MissionAvailability,
                    MissionVideoUrl = m.MissionVideoUrl,
                    CountryName = m.Country.CountryName,
                    CityName = m.City.CityName,
                    MissionThemeName = m.MissionTheme.ThemeName,
                    MissionSkillName = string.Join(",", _cIDbContext.MissionSkill
                        .Where(ms => m.MissionSkillId.Contains(ms.Id.ToString()))
                        .Select(ms => ms.SkillName)
                        .ToList()),
                    MissionStatus = m.RegistrationDeadLine < DateTime.Now.AddDays(-1) ? "Closed" : "Available",
                    MissionApplyStatus = m.MissionApplications.Any(ma => ma.UserId == model.UserId) ? "Applied" : "Apply",
                    MissionApproveStatus = m.MissionApplications.Any(ma => ma.UserId == model.UserId && ma.Status == true) ? "Approved" : "Applied",
                    MissionDateStatus = m.EndDate <= DateTime.Now.AddDays(-1) ? "MissionEnd" : "MissionRunning",
                    MissionDeadLineStatus = m.RegistrationDeadLine <= DateTime.Now.AddDays(-1) ? "Closed" : "Running",
                    MissionFavouriteStatus = m.MissionFavourites.Any(mf => mf.UserId == model.UserId) ? "1" : "0",
                    Rating = m.MissionRatings.Where(mr => mr.UserId == model.UserId).Select(mr => mr.Rating).FirstOrDefault() ?? 0,
                })
                .ToList();

            return clientSideMissionList;
        }

        public string ApplyMission(AddMissionApplicationRequestModel model)
        {
            using var transaction = _cIDbContext.Database.BeginTransaction();

            try
            {
                var mission = _cIDbContext.Missions
                    .Where(m => m.Id == model.MissionId && !m.IsDeleted)
                    .FirstOrDefault() ?? throw new Exception("Mission not found");

                if (mission.TotalSheets == 0) throw new Exception("Mission housefull");

                if (mission.TotalSheets < model.Sheet) throw new Exception("Not available seats");

                var newApplication = new MissionApplication()
                {
                    MissionId = model.MissionId,
                    UserId = model.UserId,
                    AppliedDate = model.AppliedDate,
                    Status = model.Status,
                    Sheet = model.Sheet,
                    CreatedDate = DateTime.UtcNow,
                    ModifiedDate = null,
                    IsDeleted = false
                };

                _cIDbContext.MissionApplication.Add(newApplication);
                _cIDbContext.SaveChanges();

                mission.TotalSheets -= model.Sheet;

                _cIDbContext.Missions.Update(mission);
                _cIDbContext.SaveChanges();

                transaction.Commit();

                return "Mission Apply Successfully..";
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public MissionDetailResponseModel MissionDetailByMissionId(MissionDetailRequestModel model)
        {
            var missionDetail = _cIDbContext.Missions
                .Where(m => m.Id == model.MissionId && !m.IsDeleted)
                .Select(m => new MissionDetailResponseModel()
                {
                    Id = m.Id,
                    MissionTitle = m.MissionTitle,
                    MissionDescription = m.MissionDescription,
                    MissionOrganisationName = m.MissionOrganisationName,
                    MissionOrganisationDetail = m.MissionOrganisationDetail,
                    CountryId = m.CountryId,
                    CityId = m.CityId,
                    StartDate = m.StartDate,
                    EndDate = m.EndDate,
                    MissionType = m.MissionType,
                    TotalSheets = m.TotalSheets,
                    RegistrationDeadLine = m.RegistrationDeadLine,
                    MissionThemeId = m.MissionThemeId,
                    MissionSkillId = m.MissionSkillId,
                    MissionImages = m.MissionImages,
                    MissionDocuments = m.MissionDocuments,
                    MissionAvailability = m.MissionAvailability,
                    MissionVideoUrl = m.MissionVideoUrl,
                    CountryName = m.Country.CountryName,
                    CityName = m.City.CityName,
                    MissionThemeName = m.MissionTheme.ThemeName,
                    MissionSkillName = string.Join(",", _cIDbContext.MissionSkill
                        .Where(ms => m.MissionSkillId.Contains(ms.Id.ToString()))
                        .Select(ms => ms.SkillName)
                        .ToList()),
                    MissionStatus = m.RegistrationDeadLine < DateTime.Now.AddDays(-1) ? "Closed" : "Available",
                    MissionApplyStatus = m.MissionApplications.Any(ma => ma.UserId == model.UserId) ? "Applied" : "Apply",
                    MissionApproveStatus = m.MissionApplications.Any(ma => ma.UserId == model.UserId && ma.Status == true) ? "Approved" : "Applied",
                    MissionDateStatus = m.EndDate <= DateTime.Now.AddDays(-1) ? "MissionEnd" : "MissionRunning",
                    MissionDeadLineStatus = m.RegistrationDeadLine <= DateTime.Now.AddDays(-1) ? "Closed" : "Running",
                    MissionFavouriteStatus = m.MissionFavourites.Any(mf => mf.UserId == model.UserId) ? "1" : "0",
                    Rating = m.MissionRatings.Where(mr => mr.UserId == model.UserId).Select(mr => mr.Rating).FirstOrDefault() ?? 0,
                })
                .FirstOrDefault() ?? throw new Exception("Mission not found.");

            return missionDetail;
        }

        public string AddMissionComment(AddMissionCommentRequestModel model)
        {
            var newMissionComment = new MissionComment()
            {
                MissionId = model.MissionId,
                UserId = model.UserId,
                CommentDescription = model.CommentDescription,
                CommentDate = model.CommentDate
            };

            _cIDbContext.MissionComment.Add(newMissionComment);
            _cIDbContext.SaveChanges();

            return "Add Comment Successfully..";
        }

        public List<MissionCommentResponseModel> MissionCommentListByMissionId(int missionId)
        {
            var missionCommentList = _cIDbContext.MissionComment
                 .Where(mc => mc.MissionId == missionId && !mc.IsDeleted && !mc.Mission.IsDeleted)
                 .OrderBy(mc => mc.CreatedDate)
                 .Select(mc => new MissionCommentResponseModel()
                 {
                     Id = mc.Id,
                     MissionId = mc.MissionId,
                     UserId = mc.UserId,
                     CommentDescription = mc.CommentDescription,
                     CommentDate = mc.CommentDate,
                     UserFullName = $"{mc.User.FirstName} {mc.User.LastName}",
                     UserImage = mc.User.UserDetail != null ? mc.User.UserDetail.UserImage : string.Empty
                 })
                 .ToList();

            return missionCommentList;
        }

        public string AddMissionFavourite(AddRemoveMissionFavouriteRequestModel model)
        {
            var newMissionFavourite = new MissionFavourites()
            {
                MissionId = model.MissionId,
                UserId = model.UserId
            };

            _cIDbContext.MissionFavourites.Add(newMissionFavourite);
            _cIDbContext.SaveChanges();

            return "Mission Favourite Successfully..";
        }

        public string RemoveMissionFavourite(AddRemoveMissionFavouriteRequestModel model)
        {
            _cIDbContext.MissionFavourites.Where(mf => mf.MissionId == model.MissionId && mf.UserId == model.UserId).ExecuteDelete();

            return "Mission UnFavourite Successfully..";
        }

        public string MissionRating(MissionRatingRequestModel model)
        {
            var existingMissionRating = _cIDbContext.MissionRating
                .FirstOrDefault(mr => mr.UserId == model.UserId
                    && mr.MissionId == model.MissionId
                    && !mr.IsDeleted);

            if (existingMissionRating != null)
            {
                existingMissionRating.Rating = model.Rating;

                _cIDbContext.MissionRating.Update(existingMissionRating);
                _cIDbContext.SaveChanges();

                return "Mission Rating Updated Successfully..";
            }

            var newMissionRating = new MissionRating()
            {
                UserId = model.UserId,
                MissionId = model.MissionId,
                Rating = model.Rating
            };

            _cIDbContext.MissionRating.Add(newMissionRating);

            return "Mission Rating Added Successfully..";
        }

        public List<RecentVolunteerResponseModel> RecentVolunteerList(MissionApplication model)
        {
            var recentList = _cIDbContext.MissionApplication
                .Where(ma => ma.MissionId == model.MissionId
                    && ma.UserId != model.UserId
                    && !ma.IsDeleted
                    && !ma.User.IsDeleted
                    && ma.User.UserDetail != null
                    && !ma.User.UserDetail.IsDeleted)
                .Select(ma => new RecentVolunteerResponseModel()
                {
                    Id = ma.Id,
                    MissionId = ma.MissionId,
                    UserId = ma.UserId,
                    UserImage = ma.User.UserDetail != null ? ma.User.UserDetail.UserImage : string.Empty,
                    UserName = $"{ma.User.FirstName} {ma.User.LastName}"
                })
                .ToList();

            return recentList;
        }

        public List<UserShareInviteResponseModel> GetUserList(int userId)
        {
            var userList = _cIDbContext.User
                .Where(u => u.Id != userId
                    && !u.IsDeleted
                    && u.UserType == "user"
                    && u.UserDetail != null
                    && !u.UserDetail.IsDeleted)
                .Select(u => new UserShareInviteResponseModel()
                {
                    Id = u.Id,
                    UserFullName = u.FirstName + " " + u.LastName,
                    EmailAddress = u.EmailAddress,
                })
                .ToList();

            return userList;
        }
    }
}
