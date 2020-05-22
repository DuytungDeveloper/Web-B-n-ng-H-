﻿using System;
using System.Collections.Generic;

namespace ECommerce.Model.EFModel
{
    public partial class UserRoles
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }

        public virtual Roles Role { get; set; }
        public virtual Users User { get; set; }
    }
}
