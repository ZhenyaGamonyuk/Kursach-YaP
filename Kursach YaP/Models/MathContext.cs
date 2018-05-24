using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Kursach_YaP.Models;

namespace Kursach_YaP.Models
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class MathContext : DbContext
    {
        public MathContext(): base("conn")
        { }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Lemma> Lemmes { get; set; }
        public DbSet<Axiom> Axioms { get; set; }
        public DbSet<Theorem> Theorems { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Formula> Formuls { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Text> Texts { get; set; }
    }
}