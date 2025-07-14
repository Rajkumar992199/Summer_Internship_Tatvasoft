using Mission.Entity.Models.CommonModels;
using System.Collections.Generic;

namespace Mission.Repository.IRepositories
{
    public interface ICommonRepository
    {
        List<DropDownResponseModel> CountryList();

        List<DropDownResponseModel> CityList(int countryId);

        List<DropDownResponseModel> MissionCountryList();

        List<DropDownResponseModel> MissionCityList();

        List<DropDownResponseModel> MissionThemeList();

        List<DropDownResponseModel> MissionSkillList();

        List<DropDownResponseModel> MissionTitleList();

        string ContactUs(AddContactUsRequestModel model);

        public string AddUserSkill(AddUserSkillRequestModel model);

        List<DropDownResponseModel> GetUserSkill(int userId);
    }
}
