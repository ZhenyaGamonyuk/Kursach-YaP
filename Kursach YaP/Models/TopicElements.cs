using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kursach_YaP.Models
{
    public class TopicElements
    {
        public Text Text { get; set; }
        public Theorem Theorem { get; set; }
        public Axiom Axiom { get; set; }
        public Topic Topic { get; set; }
        public Task Task { get; set; }
        public Professor Professor { get; set; }
        public Lemma Lemma { get; set; }
        public Formula Formula { get; set; }
        public int TopicId { get; set; }
    }
}