using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels
{
    public class HomeViewModel
    {
        public List<admin> admin { get; set; }
        public List<research> researches { get; set; }

    }
}
