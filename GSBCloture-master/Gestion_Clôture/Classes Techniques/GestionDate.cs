using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classe.Technique
{
    /// <summary>
    /// Classe qui permet de gérer les dates
    /// </summary>
    abstract class GestionDate
    {
        /// <summary>
        /// Fonction qui permet de récuperer le mois precedent d'une date passer en paramettre
        /// </summary>
        /// <param name="date">La date à passer en parametre</param>
        /// <returns>Retourne le mois precedent cette date</returns>
        public static string getMoisPrecedent(DateTime date)
        {
            if ((date.Month - 1) < 10 && (date.Month-1)>0)
            {
                return "0" + (date.Month - 1).ToString();
            }
            else if ((date.Month - 1) == 0)
            {
                return "12";
            }
            else
            {
                return (date.Month - 1).ToString();
            }
        }
        /// <summary>
        /// Fonction qui permet de récuperer le mois precedent de la date courrante
        /// </summary>
        /// <returns>Retourne le mois precedent la date courrant </returns>
        public static string getMoisPrecedent()
        {
            return getMoisPrecedent(DateTime.Now);
        }
        /// <summary>
        /// Fonction qui permet de récuperer le mois suivant de la date passer en parametre
        /// </summary>
        /// <param name="date">La date passée en parametre</param>
        /// <returns>Retourne le mois suivant</returns>
        public static string getMoisSuivant(DateTime date)
        {
            if ((date.Month + 1) < 10)
            {
                return "0" + (date.Month + 1).ToString();
            }
            else if ((date.Month + 1) == 13)
            {
                return "01";
            }
            else
            {
                return (date.Month + 1).ToString();
            }
        }
        /// <summary>
        /// Foncton qui permet de récuperer le mois de la date courrante
        /// </summary>
        /// <returns>Retourne la mois suivant la date courrante</returns>
        public static string getMoisSuivant()
        {
            return getMoisSuivant(DateTime.Now);
        }

        /// <summary>
        /// Fonction permet de savoir si la date passer en parametre est dans l'intervalle
        /// </summary>
        /// <param name="numJour1">L numéro du jour</param>
        /// <param name="numJour2">Le numéro du jour</param>
        /// <param name="date">La date</param>
        /// <returns>Retourne vrai si la date est dans l'intervalle</returns>
        public static bool Entre(int numJour1, int numJour2, DateTime date)
        {
            try
            {
                if ((numJour1 < 31 && numJour2 < 31) && numJour1 < numJour2)
                {
                    return numJour1 < date.Day && date.Day < numJour2;
                }
                else if (numJour2 < numJour1)
                {
                    return numJour2 < date.Day && date.Day < numJour1;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }
        /// <summary>
        /// Fonction qui permet de savoir si la date courrante est dans un intervalle donné
        /// </summary>
        /// <param name="numJour1">La première date passer en parametre</param>
        /// <param name="numJour2">La deuxième date passer en parametre</param>
        /// <returns>Retourne vrai si la date courrante est dans l'intervalle</returns>
        public static bool Entre(int numJour1,int numJour2)
        {
           return Entre(numJour1, numJour2, DateTime.Now);
        }
        

    }
}
