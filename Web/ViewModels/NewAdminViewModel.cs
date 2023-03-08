using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels
{
    public class NewAdminViewModel 
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string field { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public string about { get; set; }

        public IFormFile File { get; set; }
    }
}
