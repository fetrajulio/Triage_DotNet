using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MySql.Data;
using MySql.Web;
using System.ComponentModel.DataAnnotations;
namespace bootswatch.Models
{
    public class Etudiant
    {
        [Key]
        public int Id_Et { get; set; }
        public string Nom_Et { get; set; }
        public string Classe { get; set; }
        public int Age_et { get; set; }

    }

    public class EtudiantDBContext : DbContext {
        public DbSet<Etudiant> Etudiants { get; set; }
    }
}