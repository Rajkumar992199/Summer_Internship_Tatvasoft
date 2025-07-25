﻿using Mission.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission.Repositories.IRepositories
{
    public interface ILoginRepository
    {
        LoginUserResponseModel LoginUser(LoginUserRequestModel model);
        UserResponseModel LoginUserDetailById(int id);
        Task<string> RegisterUser(RegisterUserRequestModel registerUserRequest);
    }
}
