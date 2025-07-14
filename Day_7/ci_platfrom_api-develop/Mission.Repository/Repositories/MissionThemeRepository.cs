using Mission.Entity;
using Microsoft.EntityFrameworkCore;
using Mission.Entity.Entities;
using Mission.Entity.Models.MissionThemeModels;
using Mission.Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Mission.Repository.Repositories
{
    public class MissionThemeRepository(MissionDbContext cIDbContext) : IMissionThemeRepository
    {
        private readonly MissionDbContext _cIDbContext = cIDbContext;

        public List<MissionThemeResponseModel> GetMissionThemeList()
        {
            var missionThemeList = _cIDbContext.MissionTheme
                .Where(mt => !mt.IsDeleted)
                .Select(mt => new MissionThemeResponseModel()
                {
                    Id = mt.Id,
                    Status = mt.Status,
                    ThemeName = mt.ThemeName
                })
                .ToList();

            return missionThemeList;
        }

        public MissionThemeResponseModel GetMissionThemeById(int id)
        {
            var missionThemeDetail = _cIDbContext.MissionTheme
                .Where(mt => mt.Id == id && !mt.IsDeleted)
                .Select(mt => new MissionThemeResponseModel()
                {
                    Id = mt.Id,
                    Status = mt.Status,
                    ThemeName = mt.ThemeName
                })
                .FirstOrDefault() ?? throw new Exception("Mission Theme not found.");

            return missionThemeDetail;
        }

        public string AddMissionTheme(AddMissionThemeRequestModel model)
        {
            var themeAlreadyExists = _cIDbContext.MissionTheme.Any(mt => mt.ThemeName.ToLower() == model.ThemeName.ToLower() && !mt.IsDeleted);

            if (themeAlreadyExists) throw new Exception("Theme Name Already Exist.");

            var newTheme = new MissionTheme()
            {
                ThemeName = model.ThemeName,
                Status = model.Status,
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = null,
                IsDeleted = false
            };

            _cIDbContext.MissionTheme.Add(newTheme);
            _cIDbContext.SaveChanges();

            return "Save Theme Detail Successfully..";
        }

        public string UpdateMissionTheme(UpdateMissionThemeRequestModel model)
        {
            var themeToUpdate = _cIDbContext.MissionTheme.FirstOrDefault(mt => mt.Id == model.Id && !mt.IsDeleted) ?? throw new Exception("Mission Theme not found.");

            bool themeAlreadyExists = _cIDbContext.MissionTheme
                .Any(mt => mt.Id != model.Id
                    && mt.ThemeName.ToLower() == model.ThemeName.ToLower()
                    && !mt.IsDeleted);

            if (themeAlreadyExists) throw new Exception("Theme Name Already Exist.");

            themeToUpdate.ThemeName = model.ThemeName;
            themeToUpdate.Status = model.Status;
            themeToUpdate.ModifiedDate = DateTime.UtcNow;

            _cIDbContext.MissionTheme.Update(themeToUpdate);
            _cIDbContext.SaveChanges();

            return "Update Mission Theme Successfully..";
        }

        public string DeleteMissionTheme(int id)
        {
            _cIDbContext.MissionTheme
                .Where(mt => mt.Id == id)
                .ExecuteUpdate(mt => mt.SetProperty(property => property.IsDeleted, true));

            return "Delete Mission Theme Successfully..";
        }
    }
}
