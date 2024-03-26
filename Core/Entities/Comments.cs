﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
     public class Comments : EntityBase
    {
        
            public string Text { get; set; }
            public string Author { get; set; }
            public DateTime DatePosted { get; set; }
            public Guid ResearchId { get; set; } // Foreign key
            public research Research { get; set; } // Navigation property
        
    }
}
