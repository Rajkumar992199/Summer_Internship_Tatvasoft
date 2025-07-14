using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Mission.Entity.Entities;
using Mission.Entity.Models.CommonModels;
using Mission.Service.IServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Mission.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController(ICommonService commonService, IWebHostEnvironment hostingEnvironment) : ControllerBase
    {
        private readonly ICommonService _commonService = commonService;
        private readonly IWebHostEnvironment _hostingEnvironment = hostingEnvironment;
        ResponseResult result = new ResponseResult();

        [HttpGet]
        [Route("CountryList")]
        [Authorize]
        public ResponseResult CountryList()
        {
            try
            {
                result.Data = _commonService.CountryList();
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
        [Route("CityList/{countryId}")]
        [Authorize]
        public ResponseResult CityList(int countryId)
        {
            try
            {
                result.Data = _commonService.CityList(countryId);
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
        [Route("MissionCountryList")]
        public ResponseResult MissionCountryList()
        {
            try
            {
                result.Data = _commonService.MissionCountryList();
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
        [Route("MissionCityList")]
        public ResponseResult MissionCityList()
        {
            try
            {
                result.Data = _commonService.MissionCityList();
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
        [Route("MissionThemeList")]
        public ResponseResult MissionThemeList()
        {
            try
            {
                result.Data = _commonService.MissionThemeList();
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
        [Route("MissionSkillList")]
        public ResponseResult MissionSkillList()
        {
            try
            {
                result.Data = _commonService.MissionSkillList();
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
        [Route("MissionTitleList")]
        public ResponseResult MissionTitleList()
        {
            try
            {
                result.Data = _commonService.MissionTitleList();
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
        [Authorize]
        public async Task<IActionResult> UploadImage([FromForm] UploadFileRequestModel upload)
        {
            string filePath = "";
            string fullPath = "";
            List<string> fileList = new List<string>();
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
                    fileList.Add(fullPath);
                }
            }
            return Ok(new { success = true, Data = fileList });
        }

        [HttpPost]
        [Route("ContactUs")]
        [Authorize]
        public ResponseResult ContactUs(AddContactUsRequestModel model)
        {
            try
            {
                result.Data = _commonService.ContactUs(model);
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
        [Route("AddUserSkill")]
        [Authorize]
        public ResponseResult AddUserSkill(AddUserSkillRequestModel model)
        {
            try
            {
                result.Data = _commonService.AddUserSkill(model);
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
        [Route("GetUserSkill/{userId}")]
        [Authorize]
        public ResponseResult GetUserSkill(int userId)
        {
            try
            {
                result.Data = _commonService.GetUserSkill(userId);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}
