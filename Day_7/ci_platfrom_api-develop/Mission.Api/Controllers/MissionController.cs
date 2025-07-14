using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Mission.Entity.Entities;
using Mission.Entity.Models.CommonModels;
using Mission.Entity.Models.MissionModels;
using Mission.Service.IServices;
using System;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Mission.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionController(IMissionService missionService, IWebHostEnvironment hostingEnvironment) : ControllerBase
    {
        ResponseResult result = new ResponseResult();
        private readonly IWebHostEnvironment _hostingEnvironment = hostingEnvironment;
        private readonly IMissionService _missionService = missionService;

        #region Mission
        [HttpGet]
        [Route("GetMissionThemeList")]
        [Authorize]
        public ResponseResult GetMissionThemeList()
        {
            try
            {
                result.Data = _missionService.GetMissionThemeList();
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }
        [HttpGet]
        [Route("GetMissionSkillList")]
        [Authorize]
        public ResponseResult GetMissionSkillList()
        {
            try
            {
                result.Data = _missionService.GetMissionSkillList();
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }
        [HttpGet]
        [Route("MissionList")]
        [Authorize]
        public ResponseResult MissionList()
        {
            try
            {
                result.Data = _missionService.MissionList();
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }

        [HttpPost]
        [Route("AddMission")]
        [Authorize]
        public ResponseResult AddMission(AddMissionRequestModel model)
        {
            try
            {
                if (model.EndDate < model.StartDate) throw new Exception("Selected End Date must be greater than Start Date");

                if (model.RegistrationDeadLine > model.StartDate) throw new Exception("Select Registration DeadLine must be less than Start Date");

                result.Data = _missionService.AddMission(model);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }

        [HttpGet]
        [Route("MissionDetailById/{id}")]
        [Authorize]
        public ResponseResult MissionDetailById(int id)
        {
            try
            {
                result.Data = _missionService.MissionDetailById(id);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }

        [HttpPost]
        [Route("UpdateMission")]
        [Authorize]
        public ResponseResult UpdateMission(UpdateMissionRequestModel model)
        {
            try
            {
                if (model.EndDate < model.StartDate) throw new Exception("Selected End Date must be greater than Start Date");

                if (model.RegistrationDeadLine > model.StartDate) throw new Exception("Select Registration DeadLine must be less than Start Date");

                result.Data = _missionService.UpdateMission(model);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }

        [HttpDelete]
        [Route("DeleteMission/{id}")]
        [Authorize]
        public ResponseResult DeleteMission(int id)
        {
            try
            {
                result.Data = _missionService.DeleteMission(id);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }

        [HttpPost]
        [Route("UploadImage")]
        public async Task<IActionResult> UploadImage([FromForm] UploadFileRequestModel upload)
        {
            string filePath = "";
            string fullPath = "";
            var files = Request.Form.Files;
            if (files != null && files.Count > 0)
            {
                foreach (var file in files)
                {
                    string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    filePath = Path.Combine("UploadMissionImage", upload.ModuleName);
                    string fileRootPath = Path.Combine(_hostingEnvironment.WebRootPath, "UploadMissionImage", upload.ModuleName);

                    if (!Directory.Exists(fileRootPath))
                    {
                        Directory.CreateDirectory(fileRootPath);
                    }

                    string name = Path.GetFileNameWithoutExtension(fileName);
                    string extension = Path.GetExtension(fileName);
                    string fullFileName = name + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + extension;
                    fullPath = Path.Combine(filePath, fullFileName);
                    string fullRootPath = Path.Combine(fileRootPath, fullFileName);
                    using (var stream = new FileStream(fullRootPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
            }
            return Ok(new { success = true, Data = fullPath });
        }

        #endregion

        #region MissionApplication

        [HttpGet]
        [Route("MissionApplicationList")]
        [Authorize]
        public ResponseResult MissionApplicationList()
        {
            try
            {
                result.Data = _missionService.MissionApplicationList();
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }

        [HttpPost]
        [Route("MissionApplicationDelete")]
        [Authorize]
        public ResponseResult MissionApplicationDelete(MissionApplication missionApplication)
        {
            try
            {
                result.Data = _missionService.MissionApplicationDelete(missionApplication.Id);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("MissionApplicationApprove")]
        [Authorize]
        public ResponseResult MissionApplicationApprove(MissionApplication missionApplication)
        {
            try
            {
                result.Data = _missionService.MissionApplicationApprove(missionApplication.Id);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }

        #endregion
    }
}
