using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Kursach_YaP.Models
{
    public class Topic
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public int? DisciplineId { get; set; }
        public virtual Discipline Discipline { get; set; }

        public virtual List<Axiom> Axioms { get; set; }
        public virtual List<Lemma> Lemmes { get; set; }
        public virtual List<Theorem> Theorems { get; set; }
        public virtual List<Professor> Professors { get; set; }
        public virtual List<Task> Tasks { get; set; }
        public virtual List<Formula> Formuls { get; set; }
        public virtual List<Text> Texts { get; set; }
    }
}