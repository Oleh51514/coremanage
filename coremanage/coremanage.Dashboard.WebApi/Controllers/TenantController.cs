﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using coremanage.Core.Services.Interfaces.Entities;
using coremanage.Dashboard.WebApi.Models.Tenant;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace coremanage.Dashboard.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Tenant")]
    //[Authorize]
    public class TenantController : Controller
    {
        private readonly ITenantService _tenantService;
        public TenantController(ITenantService tenantService)
        {
            _tenantService = tenantService;
        }

        [HttpGet]
        [Route("Create")]
        public async Task<IActionResult> GetTenantCreate()
        {
            var tenantCreate = new TenantCreateViewModel();
            tenantCreate.TenantList = new List<TenantViewModel>
            {
                new TenantViewModel { Id = 1, Name = "tenant_1"},
                new TenantViewModel { Id = 2, Name = "tenant_2"},
                new TenantViewModel { Id = 3, Name = "tenant_3"},
                new TenantViewModel { Id = 4, Name = "tenant_4"},
                new TenantViewModel { Id = 5, Name = "tenant_5"}
            };


            

            return new JsonResult(tenantCreate);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> PostTenantCreate([FromBody] TenantCreateViewModel model)
        {
            var tenantCreate = new TenantCreateViewModel();
            return new JsonResult(model);
        }


        [HttpGet]
        [Route("Update")]
        public async Task<IActionResult> GetTenantUpdate()
        {
            var tenantUpdate = new TenantUpdateViewModel();
            tenantUpdate.Name = "GetName";
            tenantUpdate.Description = "GetDescription";
            tenantUpdate.ParentId = 2;
            tenantUpdate.TenantList = new List<TenantViewModel>
            {
                new TenantViewModel { Id = 1, Name = "tenant_update_1"},
                new TenantViewModel { Id = 2, Name = "tenant_update_2"},
                new TenantViewModel { Id = 3, Name = "tenant_update_3"},
                new TenantViewModel { Id = 4, Name = "tenant_update_4"},
                new TenantViewModel { Id = 5, Name = "tenant_update_5"}
            };

            return new JsonResult(tenantUpdate);
        }

        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> PostTenantUpdate([FromBody] TenantUpdateViewModel model)
        {
            var tenantUpdate= new TenantUpdateViewModel();
            return new JsonResult(model);
        }


        [HttpGet]
        [Route("TreeNode/{tenantName}")]
        public async Task<IActionResult> TreeNodeAsync(int tenantName)
        {
            var tenantList = new List<TenantViewModel>();
            var result = await _tenantService.GetAllByParentName(tenantName);
            tenantList = result.Select(c => new TenantViewModel {
                    Id = c.Id,
                    Name = c.Name
                }).ToList();
            

            //for (int i = 0; i < 3; i++)
            //{
            //    var rand = random.Next(0, 1000);
            //    fff.Add(new
            //    {
            //        id = rand,
            //        label = "Lazy_Node_" + rand,
            //        data = "Node 0",
            //        expandedIcon = "fa-folder-open",
            //        collapsedIcon = "fa-folder",
            //        leaf = false,
            //        selectable = true
            //    });
            //}

            return new JsonResult(tenantList);
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var values = _tenantService.GetAll();
            var values2 = _tenantService.Get(1);
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
