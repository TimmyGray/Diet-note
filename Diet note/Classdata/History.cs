using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Diet_note
{
    class History
    {
        int countofeat;
        public int Id { get; set; } 
        public DateTime Date { get; set; }
        public int Countofeat
        {
            get { return countofeat; }
            set { if (value >= 0) { countofeat = value; } else throw new ArgumentException("Число не может быть отрицательным"); }
        }
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
