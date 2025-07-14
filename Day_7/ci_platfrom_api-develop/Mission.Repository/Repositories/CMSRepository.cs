using Microsoft.EntityFrameworkCore;
using Mission.Entity.Entities;
using Mission.Entity.Models.CMSModels;
using Mission.Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Mission.Repository.Repositories
{
    public class CMSRepository(MissionDbContext cIDbContext) : ICMSRepository
    {
        private readonly MissionDbContext _cIDbContext = cIDbContext;

        public List<CMSResponseModel> CMSList()
        {
            var cmsList = _cIDbContext.CMS
                .Where(cms => !cms.IsDeleted)
                .Select(cms => new CMSResponseModel()
                {
                    Id = cms.Id,
                    Slug = cms.Slug,
                    Description = cms.Description,
                    Status = cms.Status,
                    Title = cms.Title
                })
                .ToList();

            return cmsList;
        }

        public CMSResponseModel CMSDetailById(int id)
        {
            var cmsDetail = _cIDbContext.CMS
                .Where(cms => cms.Id == id && !cms.IsDeleted)
                .Select(cms => new CMSResponseModel()
                {
                    Id = cms.Id,
                    Slug = cms.Slug,
                    Description = cms.Description,
                    Status = cms.Status,
                    Title = cms.Title
                })
                .FirstOrDefault() ?? throw new Exception("CMS not found.");

            return cmsDetail;
        }

        public string AddCMS(AddCMSRequestModel model)
        {
            var cmsAlreadyExist = _cIDbContext.CMS.Where(cms => cms.Title.ToLower() == model.Title.ToLower() && !cms.IsDeleted);

            if (cmsAlreadyExist != null) throw new Exception("Title already exist.");

            var newCms = new CMS()
            {
                Title = model.Title,
                Description = model.Description,
                Slug = model.Slug,
                Status = model.Status,
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = null,
                IsDeleted = false,
            };

            _cIDbContext.CMS.Add(newCms);
            _cIDbContext.SaveChanges();

            return "Save CMS Detail Successfully..";
        }

        public string UpdateCMS(UpdateCMSRequestModel model)
        {
            var cmsToUpdate = _cIDbContext.CMS.Where(cms => cms.Id == model.Id).FirstOrDefault() ?? throw new Exception("CMS not found.");

            var cmsAlreadyExist = _cIDbContext.CMS.Where(cms => cms.Id != cmsToUpdate.Id && cms.Title.ToLower() == model.Title.ToLower() && !cms.IsDeleted);

            if (cmsAlreadyExist != null) throw new Exception("Title already exist.");

            cmsToUpdate.Id = model.Id;
            cmsToUpdate.Title = model.Title;
            cmsToUpdate.Description = model.Description;
            cmsToUpdate.Slug = model.Slug;
            cmsToUpdate.Status = model.Status;
            cmsToUpdate.ModifiedDate = DateTime.UtcNow;

            _cIDbContext.CMS.Update(cmsToUpdate);
            _cIDbContext.SaveChanges();

            return "Update CMS Detail Successfully..";
        }

        public string DeleteCMS(int id)
        {
            _cIDbContext.CMS.Where(cms => cms.Id == id).ExecuteUpdate(cms => cms.SetProperty(property => property.IsDeleted, true));

            return "Delete CMS Detail Successfully..";
        }
    }
}
