using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kursach_YaP.Models
{
    public class Discipline
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        public virtual List<Topic> Topics { get; set; }

        public Discipline Enter()
        {
            string str = this.Description;
            str.Replace("\n","<br>");
            this.Description = str;
            return this;
        }
    }
}