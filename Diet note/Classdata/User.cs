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
        int id;
        public int Id
        {
            get { return id; }
            set { if (value <= 0) throw new ArgumentException();id = value; }
        }
        public string Name { get; set; }
        
        public Edgeelements Edges { get; set; }
        public List<History> Histories { get; set; }

       
        

         
    }
}
