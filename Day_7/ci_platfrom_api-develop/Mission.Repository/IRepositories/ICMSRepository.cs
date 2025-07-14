using Mission.Entity.Models.CMSModels;
using System.Collections.Generic;

namespace Mission.Repository.IRepositories
{
    public interface ICMSRepository
    {
        List<CMSResponseModel> CMSList();

        CMSResponseModel CMSDetailById(int id);

        string AddCMS(AddCMSRequestModel model);

        string UpdateCMS(UpdateCMSRequestModel model);

        string DeleteCMS(int id);
    }
}
