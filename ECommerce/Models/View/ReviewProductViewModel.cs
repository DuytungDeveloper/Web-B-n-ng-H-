using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models.View
{
    public class ReviewProductViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ApplicationUserId { get; set; }
        public string Message { get; set; }
        public float Point { get; set; }
        public DateTime DateCreate { get; set; } = new DateTime();
    }
}
