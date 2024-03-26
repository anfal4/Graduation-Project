using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels
{
    public class VisitorCountViewModel
    {
        public int Id { get; set; }
        public string IPAddress { get; set; }
        public int Count { get; set; }
        public DateTime LastVisit { get; set; }
    }
}
