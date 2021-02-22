using PagedList;
using school_Management.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_Management.Models
{
    public class sutudentList
    {
        public IPagedList<Students> List { set; get; }

    }
}