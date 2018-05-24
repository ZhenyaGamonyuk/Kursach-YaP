using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Kursach_YaP.Models
{
    public class Text
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        [Required]
        public string Plot { get; set; }
        [Required]
        public int Layout { get; set; }

        public int? TopicId { get; set; }
        public virtual Topic Topic { get; set; }
    }
}