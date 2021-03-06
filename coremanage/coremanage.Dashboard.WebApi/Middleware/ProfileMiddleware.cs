﻿using coremanage.Core.Common.Context;
using coremanage.Core.Common.Types;
using IdentityModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace coremanage.Dashboard.WebApi.Middleware
{
    public class ProfileMiddleWare
    {
        private RequestDelegate next;

        public ProfileMiddleWare(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(
            //SignInManager<ApplicationUser> signInManager,
            //UserManager<ApplicationUser> userManager,
            HttpContext context
         )
        {
            if (context.User.Identity.IsAuthenticated)
            {
                this.SetNTContext(context);
            }

            // automatically logging in in the dev mode
            //else if (SiteSettings.IsEnvironment(SecurityConstants.DevEnvironment))
            //{
            //    ApplicationUser user = await userManager.FindByNameAsync(SecuritySettings.NootusProfileUserName);
            //    await signInManager.SignInAsync(user, false);
            //}

            await this.next(context);
        }

        public void SetNTContext(HttpContext context)
        {
            var claims = context.User.Claims;
            string companyId = context.Request.Headers[ExtJwtClaimTypes.TenantName];
            companyId = companyId ?? claims.Where(c => c.Type == ExtJwtClaimTypes.TenantName).Select(c => c.Value).FirstOrDefault();




            string userName = context.User.Identity.Name;
            string userId = claims.First(c => c.Type == JwtClaimTypes.Id).Value;
            string firstName = claims.First(c => c.Type == JwtClaimTypes.Name).Value;
            string lastName = claims.First(c => c.Type == JwtClaimTypes.FamilyName).Value;
            string tenantName = claims.First(c => c.Type == ExtJwtClaimTypes.TenantName).Value;
            int tenantId = Convert.ToInt32(claims.First(c => c.Type == ExtJwtClaimTypes.TenantId).Value);

            NTContextModel model = new NTContextModel()
            {
                UserId = userId,
                UserName = userName,
                FirstName = firstName,
                LastName = lastName,
                TenantId = tenantId,
                TenantName = tenantName,
            };

            // setting the Group CompanyId
            //model.GroupCompanyId = PageService.CompanyClaims[model.CompanyId]?.ParentCompanyId ?? model.CompanyId;

            NTContext.Context = model;
        }
    }
}
