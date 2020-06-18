using System;
using System.Collections.Generic;

namespace ECommerce.Model.EFModel
{
    public partial class UserLogins
    {
        public int Id { get; set; }
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string ProviderDisplayName { get; set; }
        public string UserId { get; set; }
        public int? Status { get; set; }
    }
}
