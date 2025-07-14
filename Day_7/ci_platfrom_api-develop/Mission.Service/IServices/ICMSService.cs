using Mission.Entity.Models.CMSModels;
using System.Collections.Generic;

namespace Mission.Service.IServices
{
    public interface ICMSService
    {
        List<CMSResponseModel> CMSList();

        CMSResponseModel CMSDetailById(int id);

        string AddCMS(AddCMSRequestModel model);

        string UpdateCMS(UpdateCMSRequestModel model);

        string DeleteCMS(int id);
    }
}
