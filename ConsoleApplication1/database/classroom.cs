using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.database
{
    public class classroom
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [InverseProperty("classes")]
        public Teachers Teacher { get; set; }
        [InverseProperty("classroom")]
        public ICollection<Students> Students { get; set; }

    }
}
