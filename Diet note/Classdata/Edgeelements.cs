﻿using System;
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
        int id;
        string carbohydrates;
        string proteins;
        string fats;
        string calloriesedge;
        int numbereats;
        public int Id
      {
            get { return id; }
            set{id = Checked(value); }
      }
        
      public string Carbohydrates
      {
            get { return carbohydrates; }
            set {carbohydrates=Checked(value); }
      }
     
      public string Proteins
        {
            get { return proteins; }
            set { proteins = Checked(value); }
        }
        
      public string Fats 
        {
            get { return fats; }
            set { fats = Checked(value); }
        }
        
      public string Calloriesedge
        {
            get { return calloriesedge; }
            set { calloriesedge = Checked(value); }
        }

       
      public int Numbereats
        {
            get { return numbereats; }
            set { if (value == 0) numbereats = value;else numbereats = Checked(value); }
        }
        [ForeignKey("UserId")]
      public int UserId { get; set; }
      public User user  { get; set; }
        int Checked(int value)
        {
            if (value <= 0)
                throw new ArgumentException("Неправильное значение");
            return value;
        }
        string Checked(string value)
        {
            if (decimal.TryParse(value, out decimal result))
            {
                if (result < 0)
                {
                    throw new ArgumentException("Отрицательное значение");
                }
                return value;
            }
            else
                throw new Exception("Неправильное значение");
                
        }
    }
}
