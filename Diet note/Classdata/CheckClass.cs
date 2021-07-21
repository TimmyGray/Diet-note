using System;
using System.Collections.Generic;
using System.Text;

namespace Diet_note
{
  abstract class CheckClass
  {
       protected virtual string Checked(string value)
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
        protected virtual int Checked(int value)
        {
            if (value <= 0)
                throw new ArgumentException("Должно быть положительное значеие");
            return value;
        }


  }

}
