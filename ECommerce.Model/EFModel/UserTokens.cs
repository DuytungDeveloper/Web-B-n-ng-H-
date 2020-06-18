using System;
using System.Collections.Generic;

namespace ECommerce.Model.EFModel
{
    public partial class UserTokens
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string LoginProvider { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
