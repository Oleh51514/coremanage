﻿using System;
using System.Collections.Generic;
using System.Text;

namespace coremanage.Data.Models.Models
{
    public class RoleModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int CompanyId { get; set; }

        public int RoleType { get; set; }
    }
}