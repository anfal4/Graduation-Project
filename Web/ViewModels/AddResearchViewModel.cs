using Core.Entities;
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
        public string year { get; set; }
        public string link { get; set; }
        public int reads { get; set; }
        public int Comments { get; set; }
        public string owner { get; set; }
        public string owner2 { get; set; }
        public string Author3 { get; set; }

        public ICollection<Comments> comments { get; set; }
        public int CommentsCount { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
        public DateTime DatePosted { get; set; }



    }
}
