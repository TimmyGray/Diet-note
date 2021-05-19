using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diet_note
{
    class Edgeelements
    {
      public int Id { get; set; }
       public string Carbohydrates { get; set; }
      public string Proteins { get; set; }
      public string Fats { get; set; }
       public string Calloriesedge { get; set; }
       public int Numbereats { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User user  { get; set; }
       
    }
}
