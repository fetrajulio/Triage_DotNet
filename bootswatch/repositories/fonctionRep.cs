using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bootswatch.Models;
using MySql.Data;
using MySql.Web;

namespace bootswatch.repositories
{
    public class fonctionRep
    {
        EtudiantDBContext BaseDD = new EtudiantDBContext();


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