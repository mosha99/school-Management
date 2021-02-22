using school_Management.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_Management.Models
{
    public class serch
    {
        public List<Students> student { get; set; }
        public List<Teachers> teachers { get; set; }
        public List<classroom> classroom { get; set; }

    }
}