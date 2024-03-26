using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class VisitorCount
    {
        public int Id { get; set; }
        public string IPAddress { get; set; }
        public int Count { get; set; }
        public DateTime LastVisit { get; set; }
    }

}
