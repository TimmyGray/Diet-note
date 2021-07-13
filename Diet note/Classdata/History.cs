using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Diet_note
{
    class History:CheckClass
    {
        int countofeat;
        int id;
        string carbohydrates;
        string proteins;
        string fats;
        string callories;

        public int Id
        {
            get { return id; }
            set { id = Checked(value); }
        }
        public DateTime Date { get; set; }
        public int Countofeat
        {
            get { return countofeat; }
            set { if (value == 0)countofeat = value;countofeat = Checked(value); }
        }
        public string CarboHydrates
        {
            get {return carbohydrates; }
            set {carbohydrates = Checked(value); }
        }
        public string Proteins
        {
            get {return proteins; }
            set {proteins = Checked(value); }
        }
        public string Fats
        {
            get { return fats; }
            set {fats=Checked(value); } 
        }
        public string Callories
        {
            get { return callories; }
            set {callories=Checked(value); }
        }
        public string Foodname { get; set; }
        public bool Firsttime { get; set; }


        public int UserId { get; set; }
        public User user { get; set; }

        
       
        
    }
}
