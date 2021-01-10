using Classe.Technique;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.unit.testDate
{
    class testDate
    {
      
        public static int dateGoTests()
        {
            int nb = 0;
            if (GestionDate.getMoisPrecedent(new DateTime(1991, 10, 12)) != "09")
            {
                nb++;
            }
            if(GestionDate.getMoisSuivant(new DateTime(1991, 11, 9)) != "12")
            {
                nb++;
            }
            if(!GestionDate.Entre(1, 6, new DateTime(2001, 1, 5)))
            {
                nb++;
            }
            if(GestionDate.Entre(20, 30, new DateTime(2001, 1, 5)))
            {
                nb++;
            }

            return nb; 
        }
    }
}
