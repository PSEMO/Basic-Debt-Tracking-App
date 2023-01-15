using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muhasebe_Defteri
{
    public class Person
    {
        public string Name;
        public float Ammount;
        public string Note;
 
        public Person(string name, float ammount, string note)
        {
            Name = name;
            Ammount = ammount;

            if(note == "" || note == " " || note == null || note == String.Empty)
            {
                Note = "Notsuz";
            }
            else
            {
                Note = note;
            }
        }

        //It will print in this format when I print a Person object.
        override public string ToString()
        {
            return Name + TextFormatHolder.NameEnd + Ammount + TextFormatHolder.DebtEnd;
        }
    }
}
