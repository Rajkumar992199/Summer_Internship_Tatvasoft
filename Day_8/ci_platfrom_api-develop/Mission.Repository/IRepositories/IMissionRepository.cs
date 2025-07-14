using Mission.Entity.Entities;
using Mission.Entity.Models.CommonModels;
using Mission.Entity.Models.MissionModels;
using System.Collections.Generic;

namespace Mission.Repository.IRepositories
{
    public interface IMissionRepository
    {
        List<DropDownResponseModel> GetMissionThemeList();

        List<DropDownResponseModel> GetMissionSkillList();

        List<MissionResponseModel> MissionList();

        string AddMission(AddMissionRequestModel model);

        MissionResponseModel MissionDetailById(int id);

        string UpdateMission(UpdateMissionRequestModel model);

        string DeleteMission(int id);

        List<MissionApplicationResponseModel> MissionApplicationList();

        string MissionApplicationDelete(int id);

        string MissionApplicationApprove(int id);

        List<MissionDetailResponseModel> ClientSideMissionList(int userId);

        List<MissionDetailResponseModel> MissionClientList(MissionDetailRequestModel model);
        string ApplyMission(AddMissionApplicationRequestModel model);

        MissionDetailResponseModel MissionDetailByMissionId(MissionDetailRequestModel model);

        string AddMissionComment(AddMissionCommentRequestModel model);

        List<MissionCommentResponseModel> MissionCommentListByMissionId(int missionId);

        string AddMissionFavourite(AddRemoveMissionFavouriteRequestModel model);

        string RemoveMissionFavourite(AddRemoveMissionFavouriteRequestModel model);

        string MissionRating(MissionRatingRequestModel model);

        List<RecentVolunteerResponseModel> RecentVolunteerList(MissionApplication model);

        List<UserShareInviteResponseModel> GetUserList(int userId);
    }
}
