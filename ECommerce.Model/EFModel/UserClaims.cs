﻿using System;
using System.Collections.Generic;

namespace ECommerce.Model.EFModel
{
    public partial class UserClaims
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public int? Status { get; set; }
    }
}
