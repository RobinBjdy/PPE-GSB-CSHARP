using Classe.Technique;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using test.unit.testDate;

namespace Gestion_Clôture
{
    class Program
    {
        static void Main()
        {
            
            if (testDate.dateGoTests() == 0)
            {
                if (GestionDate.Entre(1, 10))
                {
                    BddMySql.bddMySql = BddMySql.GetInstance();
                    BddMySql.ClotureFraisDuMois(GestionDate.getMoisPrecedent());                 
                }
                else if (DateTime.Now.Day == 20)
                {
                    BddMySql.bddMySql = BddMySql.GetInstance();
                    BddMySql.MajFicheValidéeToRb(GestionDate.getMoisPrecedent());                    
                }
            }
           
        }
   
    }
}
