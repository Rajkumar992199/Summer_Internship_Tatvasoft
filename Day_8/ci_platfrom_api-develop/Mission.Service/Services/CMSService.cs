using Mission.Entity.Models.CMSModels;
using Mission.Repository.IRepositories;
using Mission.Service.IServices;
using System.Collections.Generic;

namespace Mission.Service.Services
{
    public class CMSService(ICMSRepository cmsRepository) : ICMSService
    {
        private readonly ICMSRepository _cmsRepository = cmsRepository;

        public List<CMSResponseModel> CMSList()
        {
            return _cmsRepository.CMSList();
        }

        public CMSResponseModel CMSDetailById(int id)
        {
            return _cmsRepository.CMSDetailById(id);
        }

        public string AddCMS(AddCMSRequestModel model)
        {
            return _cmsRepository.AddCMS(model);
        }

        public string UpdateCMS(UpdateCMSRequestModel model)
        {
            return _cmsRepository.UpdateCMS(model);
        }

        public string DeleteCMS(int id)
        {
            return _cmsRepository.DeleteCMS(id);
        }
    }
}
