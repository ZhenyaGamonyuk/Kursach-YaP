using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kursach_YaP.Models
{
    public class Theorem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Descriprion { get; set; }
        [Required]
        public int Layout { get; set; }

        public int? TopicId { get; set; }
        public virtual Topic Topic { get; set; }
    }
}