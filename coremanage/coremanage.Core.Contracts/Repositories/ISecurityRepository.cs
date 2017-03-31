﻿using coremanage.Data.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace coremanage.Core.Contracts.Repositories
{
    public interface ISecurityRepository
    {
        Task<ProfileModel> UserProfileGet(string userName, int companyId);
        Task UserProfileGetRolesClaims(ProfileModel model);
    }
}