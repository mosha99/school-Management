using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.database
{
    public class Teachers
    {
        public int Id { get; set; }
        public string Name { set; get; }
        [InverseProperty("Teacher")]
        public virtual ICollection<classroom> classes { get; set; }
       

    }
}
