using System;
using System.Collections.Generic;
using System.Text;

namespace Diet_note
{
    public interface IActions
    {
        int ChangedID(int id);
        int ChangedCountOfEat(int countofeat);
    }
}
