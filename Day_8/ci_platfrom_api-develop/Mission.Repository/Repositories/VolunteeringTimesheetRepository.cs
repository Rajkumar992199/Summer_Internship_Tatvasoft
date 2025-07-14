using Mission.Entity;
using Microsoft.EntityFrameworkCore;
using Mission.Entity.Entities;
using Mission.Entity.Models.CommonModels;
using Mission.Entity.Models.VolunteeringTimesheetModels;
using Mission.Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Mission.Repository.Repositories
{
    public class VolunteeringTimesheetRepository(MissionDbContext cIDbContext) : IVolunteeringTimesheetRepository
    {
        private readonly MissionDbContext _cIDbContext = cIDbContext;

        #region Volunteeting Hours

        public List<VolunteeringHoursResponseModel> GetVolunteeringHoursList(int userId)
        {
            var volunteeringHoursList = _cIDbContext.VolunteeringHours
                .Where(vh => vh.UserId == userId
                    && !vh.IsDeleted
                    && !vh.Mission.IsDeleted
                    && !vh.User.IsDeleted)
                .Select(vh => new VolunteeringHoursResponseModel()
                {
                    Id = vh.Id,
                    UserId = vh.UserId,
                    MissionId = vh.MissionId,
                    MissionName = vh.Mission.MissionTitle,
                    DateVolunteered = vh.DateVolunteered,
                    Hours = vh.Hours,
                    Minutes = vh.Minutes,
                    Message = vh.Message
                })
                .ToList();

            return volunteeringHoursList;
        }

        public VolunteeringHoursResponseModel GetVolunteeringHoursListById(int id)
        {
            var volunteeringHours = _cIDbContext.VolunteeringHours
                .Where(vh => vh.Id == id
                    && !vh.IsDeleted
                    && !vh.Mission.IsDeleted
                    && !vh.User.IsDeleted)
                .Select(vh => new VolunteeringHoursResponseModel()
                {
                    Id = vh.Id,
                    UserId = vh.UserId,
                    MissionId = vh.MissionId,
                    MissionName = vh.Mission.MissionTitle,
                    DateVolunteered = vh.DateVolunteered,
                    Hours = vh.Hours,
                    Minutes = vh.Minutes,
                    Message = vh.Message
                })
                .FirstOrDefault() ?? throw new Exception("Volunteering Hours details not found.");

            return volunteeringHours;
        }

        public string AddVolunteeringHours(AddVolunteeringHoursRequestModel model)
        {
            var newVolunteeingHours = new VolunteeringHours()
            {
                UserId = model.UserId,
                MissionId = model.MissionId,
                DateVolunteered = model.DateVolunteered.Date,
                Hours = model.Hours,
                Minutes = model.Minutes,
                Message = model.Message,
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = null,
                IsDeleted = false
            };

            _cIDbContext.VolunteeringHours.Add(newVolunteeingHours);
            _cIDbContext.SaveChanges();

            return "Save Detail Successfully..";
        }

        public List<DropDownResponseModel> VolunteeringMissionList(int userId)
        {
            var missionTitleList = _cIDbContext.Missions
                    .Where(m => !m.IsDeleted && m.MissionApplications.Any(ma => ma.Status && ma.UserId == userId))
                    .Select(m => new DropDownResponseModel(m.Id, m.MissionTitle))
                    .ToList();

            return missionTitleList;
        }

        public string UpdateVolunteeringHours(UpdateVolunteeringHoursRequestModel model)
        {
            var volunteeringHoursToUpdate = _cIDbContext.VolunteeringHours
                .Where(vh => vh.Id == model.Id)
                .FirstOrDefault() ?? throw new Exception("Volunteering Hours details not found.");

            volunteeringHoursToUpdate.UserId = model.UserId;
            volunteeringHoursToUpdate.MissionId = model.MissionId;
            volunteeringHoursToUpdate.DateVolunteered = model.DateVolunteered;
            volunteeringHoursToUpdate.Hours = model.Hours;
            volunteeringHoursToUpdate.Minutes = model.Minutes;
            volunteeringHoursToUpdate.Message = model.Message;
            volunteeringHoursToUpdate.ModifiedDate = DateTime.UtcNow;

            _cIDbContext.VolunteeringHours.Update(volunteeringHoursToUpdate);
            _cIDbContext.SaveChanges();

            return "Update Detail Successfully..";
        }

        public string DeleteVolunteeringHours(int id)
        {
            _cIDbContext.VolunteeringHours
                .Where(vh => vh.Id == id)
                .ExecuteUpdate(vh => vh.SetProperty(property => property.IsDeleted, true));

            return "Delete Detail Successfully..";
        }

        #endregion

        #region Volunteeting Goals

        public List<VolunteeringGoalsResponseModel> GetVolunteeringGoalsList(int userId)
        {
            var volunteeringGoals = _cIDbContext.VolunteeringGoals
                .Where(vg => vg.UserId == userId
                    && !vg.IsDeleted
                    && !vg.Mission.IsDeleted
                    && !vg.User.IsDeleted)
                .Select(vg => new VolunteeringGoalsResponseModel()
                {
                    Id = vg.Id,
                    UserId = vg.UserId,
                    MissionId = vg.MissionId,
                    MissionName = vg.Mission.MissionTitle,
                    Date = vg.Date,
                    Action = vg.Action,
                    Message = vg.Message
                })
                .ToList();

            return volunteeringGoals;
        }

        public VolunteeringGoalsResponseModel GetVolunteeringGoalsListById(int id)
        {
            var volunteeringGoals = _cIDbContext.VolunteeringGoals
                .Where(vg => vg.Id == id
                    && !vg.IsDeleted
                    && !vg.Mission.IsDeleted
                    && !vg.User.IsDeleted)
                .Select(vg => new VolunteeringGoalsResponseModel()
                {
                    Id = vg.Id,
                    UserId = vg.UserId,
                    MissionId = vg.MissionId,
                    MissionName = vg.Mission.MissionTitle,
                    Date = vg.Date,
                    Action = vg.Action,
                    Message = vg.Message
                })
                .FirstOrDefault() ?? throw new Exception("Volunteering Goals details not found.");

            return volunteeringGoals;
        }

        public string AddVolunteeringGoals(AddVolunteeringGoalsRequestModel model)
        {
            var newVolunteeingGoals = new VolunteeringGoals()
            {
                UserId = model.UserId,
                MissionId = model.MissionId,
                Date = model.Date.Date,
                Action = model.Action,
                Message = model.Message,
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = null,
                IsDeleted = false
            };

            _cIDbContext.VolunteeringGoals.Add(newVolunteeingGoals);
            _cIDbContext.SaveChanges();

            return "Save Detail Successfully..";
        }

        public string UpdateVolunteeringGoals(UpdateVolunteeringGoalsRequestModel model)
        {
            var volunteeringGoalsToUpdate = _cIDbContext.VolunteeringGoals
                .Where(vh => vh.Id == model.Id)
                .FirstOrDefault() ?? throw new Exception("Volunteering Goals details not found.");

            volunteeringGoalsToUpdate.UserId = model.UserId;
            volunteeringGoalsToUpdate.MissionId = model.MissionId;
            volunteeringGoalsToUpdate.Date = model.Date;
            volunteeringGoalsToUpdate.Action = model.Action;
            volunteeringGoalsToUpdate.Message = model.Message;
            volunteeringGoalsToUpdate.ModifiedDate = DateTime.UtcNow;

            _cIDbContext.VolunteeringGoals.Update(volunteeringGoalsToUpdate);
            _cIDbContext.SaveChanges();

            return "Update Detail Successfully..";
        }

        public string DeleteVolunteeringGoals(int id)
        {
            _cIDbContext.VolunteeringGoals
                .Where(vh => vh.Id == id)
                .ExecuteUpdate(vh => vh.SetProperty(property => property.IsDeleted, true));

            return "Delete Detail Successfully..";
        }

        #endregion
    }
}
