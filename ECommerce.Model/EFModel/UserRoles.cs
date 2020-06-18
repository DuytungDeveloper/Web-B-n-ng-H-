using System;
using System.Collections.Generic;

namespace ECommerce.Model.EFModel
{
    public partial class UserRoles
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public int? Status { get; set; }
    }
}
