using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels
{
    public class CommentsViewModel
    {
        public string Text { get; set; }
        public string Author { get; set; }
        public DateTime DatePosted { get; set; }
        public Guid ResearchId { get; set; } // Foreign key
        public research Research { get; set; } // Navigation property

    }
}
