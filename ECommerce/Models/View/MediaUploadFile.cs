using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models.View
{
    public class MediaUploadFile
    {
        public string Name { get; set; }
        public IFormFile FileUpload { get; set; }
    }
}
