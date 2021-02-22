using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_Management.database
{
    public class Students
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [InverseProperty("Students")]
        public classroom classroom { get; set; }
        public Teachers teacher {
            get { return classroom.Teacher; }
        }
        //public classroom Class = classroom;
    }
}
