using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bootswatch.Models;
using MySql.Data;
using MySql.Web;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace bootswatch.repositories
{
    public class fonctionRep
    {
        EtudiantDBContext BaseDD = new EtudiantDBContext();
        protected MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["default"].ConnectionString);
        public Etudiant[] getAll() {
            
            string sqlQr = "SELECT * from Etudiant";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sqlQr, con);
            MySqlDataReader r = cmd.ExecuteReader();
            Etudiant[] etds = new Etudiant[r.FieldCount];
            if (!r.HasRows) {
                r.Close();
                con.Close();
                return null;
            }
            while (r.Read()) {
                Etudiant et = new Etudiant();
                et.Id_Et = int.Parse(r["Id_Et"].ToString());
                et.Nom_Et = r["Nom_Et"].ToString();
                et.Classe = r["Classe"].ToString();
                et.Age_et = int.Parse(r["Age_et"].ToString());
                
                etds[et.Id_Et]=et;
            }
            con.Close();
            return etds;
        } 
        public Etudiant getEtByNom(string nom) {
            Etudiant[] table = BaseDD.Etudiants.ToArray();
            Etudiant res=new Etudiant();
            foreach (Etudiant et in table) {
                if (et.Nom_Et == nom)
                    res = et;
                else  if (et.Classe == nom)
                    res = et;
            }
            return res;
        }
        public Etudiant[] Trier()
        {
            Etudiant[] table = BaseDD.Etudiants.ToArray();
            Etudiant temp=new Etudiant();
            foreach (Etudiant e in table) {
                foreach (Etudiant f in table) {
                    if (e.Age_et < f.Age_et) {

                        temp.Age_et = e.Age_et;
                        temp.Id_Et = e.Id_Et;
                        temp.Classe = e.Classe;
                        temp.Nom_Et = e.Nom_Et;

                        e.Age_et = f.Age_et;
                        e.Classe = f.Classe;
                        e.Id_Et = f.Id_Et;
                        e.Nom_Et = f.Nom_Et;

                        f.Nom_Et = temp.Nom_Et;
                        f.Id_Et = temp.Id_Et;
                        f.Classe = temp.Classe;
                        f.Age_et = temp.Age_et;
                    }
                }
            }
            return table;
        }
        
    }
}