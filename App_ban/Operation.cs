using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_ban
{
   public class Operation
    {
        public DateTime dateTime;
        public String description;
        public float somme;
        public Operation(String des,float som)
        {
            dateTime = DateTime.Now;
            description = des;
            somme = som;

        }
        public String toString()
        {
            return this.dateTime.ToString() + "    " + this.description+"     "+this.somme;
        }
    }
}
