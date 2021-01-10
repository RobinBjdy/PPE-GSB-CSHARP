using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Classe.Technique
{
    /// <summary>
    /// Classe qui permet l'accès à la base de donnée MySql pour la base de GSB
    /// </summary>
    class BddMySql
    {
        private static MySqlConnection cnMySql;
        private static MySqlCommand cmdMySql;
        private static MySqlTransaction tranSql;
        public static BddMySql bddMySql;

        /// <summary>
        /// Constructeur privé de la classe
        /// </summary>
        private BddMySql()
        {
            BddMySql.cnMySql = new MySqlConnection(String.Format(ConfigurationManager.AppSettings["connectionString"], ConfigurationManager.AppSettings["server"],
                ConfigurationManager.AppSettings["port"], ConfigurationManager.AppSettings["dataBase"], ConfigurationManager.AppSettings["login"], ConfigurationManager.AppSettings["pwd"]));
        }

        /// <summary>
        /// Fonction publique qui permet d'instancier la connexion à la base de donnée
        /// </summary>
        /// <returns></returns>
        public static BddMySql GetInstance()
        {
            if (BddMySql.bddMySql == null)
            {
                return BddMySql.bddMySql = new BddMySql();
            }
            return BddMySql.bddMySql;

        }

        /// <summary>
        /// Procédure qui permet d'ouvrir la connexion à la base
        /// </summary>
        private static void Open()
        {
            try
            {
                BddMySql.cnMySql.Open();
            }
            catch (MySqlException mex)
            {
                throw new Exception(mex.Message);
            }
        }

        /// <summary>
        /// Procédure qui permet de fermer la connexion à la base
        /// </summary>
        public static void Fermer()
        {
            try
            {
                BddMySql.cnMySql.Close();
            }
            catch (MySqlException mex)
            {
                throw new Exception(mex.Message);
            }
        }

        /// <summary>
        /// Fonction publique qui permet de cloturer les fiches de frais du mois
        /// </summary>
        /// <param name="dateCloture">La data de cloture à passer en parametre</param>
        /// <returns>Retourne le nombre de ligne qui on était affectées</returns>
        public static int ClotureFraisDuMois(string dateCloture)
        {
            try
            {
                dateCloture=DateTime.Now.Year.ToString()+dateCloture;
                BddMySql.Open();
                BddMySql.tranSql = BddMySql.cnMySql.BeginTransaction();
                string rqt = @"update fichefrais set idetat = 'CL' where mois= @mois";
                BddMySql.cmdMySql = new MySqlCommand(rqt, BddMySql.cnMySql);
                BddMySql.cmdMySql.Parameters.AddWithValue("@mois", dateCloture);
                return BddMySql.cmdMySql.ExecuteNonQuery();
            }
            catch(MySqlException moe)
            {
                BddMySql.tranSql.Rollback();
                throw new Exception("Impossible de mettre à jour les fiches de frais : "+moe.Message);
            }
            finally
            {
                BddMySql.tranSql.Commit();
                BddMySql.Fermer();
            }
        }

        /// <summary>
        /// Fonction qui permet de mettre à jour les fiches valider à l'était remboursé
        /// </summary>
        /// <param name="dateCloture"></param>
        /// <returns></returns>
        public static int MajFicheValidéeToRb(string dateCloture)
        {
            try
            {
                dateCloture = DateTime.Now.Year.ToString() + dateCloture;
                BddMySql.Open();
                BddMySql.tranSql = BddMySql.cnMySql.BeginTransaction();
                string rqt = @"update fichefrais set idetat = 'RB' where mois= @mois and idetat= @idEtat";
                BddMySql.cmdMySql = new MySqlCommand(rqt, BddMySql.cnMySql);
                BddMySql.cmdMySql.Parameters.AddWithValue("@mois", dateCloture);
                BddMySql.cmdMySql.Parameters.AddWithValue("@idEtat", "CL");
                return BddMySql.cmdMySql.ExecuteNonQuery();
            }
            catch (MySqlException moe)
            {
                BddMySql.tranSql.Rollback();
                throw new Exception("Impossible de mettre à jour les fiches de frais : " + moe.Message);
            }
            finally
            {
                BddMySql.tranSql.Commit();
                BddMySql.Fermer();
            }
        }
        

        
    }
}
