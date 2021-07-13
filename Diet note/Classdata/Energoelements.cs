using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diet_note
{
   class Energoelements:CheckClass
    {
        string carbohydrates;
        string protein;
        string fats;
        string calories;
      public int EnergoelementsId { get; set; }
      public string Name { get; set; }
      public string Carbohydrates
        {
            get {return carbohydrates; }
            set { carbohydrates = Checked(value); } 
        }
      public string Protein
        {
            get {return protein; }
            set {protein = Checked(value); } 
        }
      public string Fats
        {
            get {return fats; }
            set {fats = Checked(value); }
        }
      public string Callories
        {
            get {return calories; }
            set { calories = Checked(value); }
        }
    }
}
