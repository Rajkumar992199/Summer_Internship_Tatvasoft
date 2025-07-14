using Mission.Entity.Entities;
using Mission.Entity.Models.CommonModels;
using Mission.Entity.Models.MissionModels;
using Mission.Repository.IRepositories;
using Mission.Service.IServices;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace Mission.Service.Services
{
    public class MissionService(IMissionRepository missionRepository) : IMissionService
    {
        private readonly IMissionRepository _missionRepository = missionRepository;

        public List<DropDownResponseModel> GetMissionThemeList()
        {
            return _missionRepository.GetMissionThemeList();
        }

        public List<DropDownResponseModel> GetMissionSkillList()
        {
            return _missionRepository.GetMissionSkillList();
        }

        public List<MissionResponseModel> MissionList()
        {
            return _missionRepository.MissionList();
        }

        public string AddMission(AddMissionRequestModel model)
        {
            return _missionRepository.AddMission(model);
        }

        public MissionResponseModel MissionDetailById(int id)
        {
            return _missionRepository.MissionDetailById(id);
        }

        public string UpdateMission(UpdateMissionRequestModel model)
        {
            return _missionRepository.UpdateMission(model);
        }

        public string DeleteMission(int id)
        {
            return _missionRepository.DeleteMission(id);
        }

        public List<MissionApplicationResponseModel> MissionApplicationList()
        {
            return _missionRepository.MissionApplicationList();
        }

        public string MissionApplicationDelete(int id)
        {
            return _missionRepository.MissionApplicationDelete(id);
        }

        public string MissionApplicationApprove(int id)
        {
            return _missionRepository.MissionApplicationApprove(id);
        }

        public List<MissionDetailResponseModel> ClientSideMissionList(int userId)
        {
            return _missionRepository.ClientSideMissionList(userId);
        }

        public List<MissionDetailResponseModel> MissionClientList(MissionDetailRequestModel model)
        {
            return _missionRepository.MissionClientList(model);
        }

        public string ApplyMission(AddMissionApplicationRequestModel model)
        {
            return _missionRepository.ApplyMission(model);
        }

        public MissionDetailResponseModel MissionDetailByMissionId(MissionDetailRequestModel model)
        {
            return _missionRepository.MissionDetailByMissionId(model);
        }

        public string AddMissionComment(AddMissionCommentRequestModel model)
        {
            return _missionRepository.AddMissionComment(model);
        }

        public List<MissionCommentResponseModel> MissionCommentListByMissionId(int missionId)
        {
            return _missionRepository.MissionCommentListByMissionId(missionId);
        }

        public string AddMissionFavourite(AddRemoveMissionFavouriteRequestModel model)
        {
            return _missionRepository.AddMissionFavourite(model);
        }

        public string RemoveMissionFavourite(AddRemoveMissionFavouriteRequestModel model)
        {
            return _missionRepository.RemoveMissionFavourite(model);
        }

        public string MissionRating(MissionRatingRequestModel model)
        {
            return _missionRepository.MissionRating(model);
        }

        public List<RecentVolunteerResponseModel> RecentVolunteerList(MissionApplication missionApplication)
        {
            return _missionRepository.RecentVolunteerList(missionApplication);
        }

        public List<UserShareInviteResponseModel> GetUserList(int userId)
        {
            return _missionRepository.GetUserList(userId);
        }

        public string SendInviteMissionMail(List<MissionShareInviteRequestModel> user)
        {
            foreach (var item in user)
            {
                string callbackurl = item.BaseUrl + "/volunteeringMission/" + item.MissionId;
                string mailTo = item.EmailAddress;
                string userName = item.UserFullName;
                string emailBody = "Hi " + userName + ",<br/><br/> Click the link below to suggest mission link <br/><br/> " + callbackurl;
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient();
                mail.From = new MailAddress(item.MissionShareUserEmailAddress);
                mail.To.Add(mailTo);
                mail.Subject = "Invite Mission Link";
                mail.Body = emailBody;
                mail.IsBodyHtml = true;
                SmtpServer.UseDefaultCredentials = false;
                NetworkCredential NetworkCred = new NetworkCredential(item.MissionShareUserEmailAddress, "yourpassword");
                SmtpServer.Credentials = NetworkCred;
                SmtpServer.EnableSsl = true;
                SmtpServer.Port = 587;
                SmtpServer.Host = "smtp.gmail.com";
                SmtpServer.Send(mail);
            }

            return "Mission Invite Successfully";
        }
    }
}
