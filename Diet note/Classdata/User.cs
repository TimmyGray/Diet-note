using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Diet_note
{
    class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public Edgeelements Edges { get; set; }
        public List<History> Histories { get; set; }

       
        

         
    }
}
