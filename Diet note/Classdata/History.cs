using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Diet_note
{
    class History
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Countofeat{ get; set; }
        public string CarboHydrates { get; set; }
        public string Proteins { get; set; }
        public string Fats { get; set; }
        public string Callories { get; set; }
        public string Foodname { get; set; }
        public bool firsttime { get; set; }


        public int UserId { get; set; }
        public User user { get; set; }

        
       
        
    }
}
