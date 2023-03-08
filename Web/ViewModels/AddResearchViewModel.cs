using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels
{
    public class AddResearchViewModel
    {
        public Guid Id { get; set; }
        public string ResearchName { get; set; }
        public string Discription { get; set; }
        public int year { get; set; }
        public string link { get; set; }
    }
}
