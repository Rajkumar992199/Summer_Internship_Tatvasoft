using Mission.Entity.Entities;
using Mission.Entity.Models.CommonModels;
using Mission.Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Mission.Repository.Repositories
{
    public class CommonRepository(MissionDbContext cIDbContext) : ICommonRepository
    {
        private readonly MissionDbContext _cIDbContext = cIDbContext;

        public List<DropDownResponseModel> CountryList()
        {
            var countries = _cIDbContext.Country
                .OrderBy(c => c.CountryName)
                .Select(c => new DropDownResponseModel(c.Id, c.CountryName))
                .ToList();

            return countries;
        }

        public List<DropDownResponseModel> CityList(int countryId)
        {
            var cities = _cIDbContext.City
                .Where(c => c.CountryId == countryId)
                .OrderBy(c => c.CityName)
                .Select(c => new DropDownResponseModel(c.Id, c.CityName))
                .ToList();

            return cities;
        }

        public List<DropDownResponseModel> MissionCountryList()
        {
            var countries = _cIDbContext.Missions
                .Select(m => new DropDownResponseModel(m.CountryId, m.Country.CountryName))
                .Distinct()
                .ToList();

            return countries;
        }

        public List<DropDownResponseModel> MissionCityList()
        {
            var cities = _cIDbContext.Missions
                .Where(m => !m.IsDeleted)
                .Select(m => new DropDownResponseModel(m.CityId, m.City.CityName))
                .Distinct()
                .ToList();

            return cities;
        }

        public List<DropDownResponseModel> MissionThemeList()
        {
            var missionThemes = _cIDbContext.Missions
                .Where(m => !m.IsDeleted && !m.MissionTheme.IsDeleted)
                .Select(m => new DropDownResponseModel(m.MissionTheme.Id, m.MissionTheme.ThemeName))
                .Distinct()
                .ToList();

            return missionThemes;
        }

        public List<DropDownResponseModel> MissionSkillList()
        {
            var missionSkill = _cIDbContext.MissionSkill
                .Where(ms => !ms.IsDeleted)
                .Select(ms => new DropDownResponseModel(ms.Id, ms.SkillName))
                .ToList();

            return missionSkill;
        }

        public List<DropDownResponseModel> MissionTitleList()
        {
            var missionSkill = _cIDbContext.Missions
                .Where(m => !m.IsDeleted)
                .Select(m => new DropDownResponseModel(m.Id, m.MissionTitle))
                .ToList();

            return missionSkill;
        }

        public string ContactUs(AddContactUsRequestModel model)
        {
            var newContactUs = new ContactUs()
            {
                UserId = model.UserId,
                Name = model.Name,
                EmailAddress = model.EmailAddress,
                Subject = model.Subject,
                Message = model.Message,
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = null,
                IsDeleted = false
            };

            _cIDbContext.ContactUs.Add(newContactUs);
            _cIDbContext.SaveChanges();

            return "Add Contact Us Detail Successfully..";
        }

        public string AddUserSkill(AddUserSkillRequestModel model)
        {
            var existingSkill = _cIDbContext.UserSkills.FirstOrDefault(us => us.UserId == model.UserId && !us.IsDeleted);

            if (existingSkill != null)
            {
                existingSkill.Skill = model.Skill;
                existingSkill.ModifiedDate = DateTime.UtcNow;

                _cIDbContext.UserSkills.Update(existingSkill);
                _cIDbContext.SaveChanges();

                return "Skill Updated Successfully...";
            }
            else
            {
                var newSkill = new UserSkills()
                {
                    Skill = model.Skill,
                    UserId = model.UserId,
                    CreatedDate = DateTime.UtcNow,
                    ModifiedDate = null,
                    IsDeleted = false
                };

                _cIDbContext.UserSkills.Add(newSkill);
                _cIDbContext.SaveChanges();

                return "Skill Added Successfully..";
            }
        }

        public List<DropDownResponseModel> GetUserSkill(int userId)
        {
            var userSkills = _cIDbContext.UserSkills
                .Where(u => u.UserId == userId)
                .OrderBy(u => u.Id)
                .Select(u => new DropDownResponseModel(u.Id, u.Skill))
                .ToList();

            return userSkills;
        }
    }
}
