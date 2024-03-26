using System.Collections.Generic;

namespace Core.Entities
{
   public class research : EntityBase
    {
        public string ResearchName { get; set; }
        public string Discription { get; set; }
        public string year { get; set; }
        public string link { get; set; }
        public int reads { get; set; }

        public int Comments { get; set; }

        public string owner { get; set; }
        public string owner2 { get; set; }
        public string Author3 { get; set; }


        public ICollection<Comments> comments { get; set; }


    }
}
