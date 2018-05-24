using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Kursach_YaP.Models;

namespace Kursach_YaP.Controllers
{
    public class HomeController : Controller
    {
        MathContext db = new MathContext();
        public ActionResult Index()
        {
            IEnumerable<Discipline> disciplines = db.Disciplines;
            ViewBag.Disciplines = disciplines;
            return View();
        }
        public ActionResult Delete(int id, string h)
        {
            if (h == "text")
            {
                int? num = db.Texts.Find(id).TopicId;
                Text temp = db.Texts.Find(id);
                if (temp != null)
                {
                    db.Texts.Remove(temp);
                    db.SaveChanges();
                }
                return Redirect("/Home/Topic/" + num);
            }
            if (h == "theor")
            {
                int? num = db.Theorems.Find(id).TopicId;
                Theorem ther = db.Theorems.Find(id);
                if (ther != null)
                {
                    db.Theorems.Remove(ther);
                    db.SaveChanges();
                }
                return Redirect("/Home/Topic/" + num);
            }
            if (h == "axiom")
            {
                int? num = db.Axioms.Find(id).TopicId;
                Axiom ax = db.Axioms.Find(id);
                if (ax != null)
                {
                    db.Axioms.Remove(ax);
                    db.SaveChanges();
                }
                return Redirect("/Home/Topic/" + num);
            }
            if (h == "lemma")
            {
                int? num = db.Lemmes.Find(id).TopicId;
                Lemma lemm = db.Lemmes.Find(id);
                if (lemm != null)
                {
                    db.Lemmes.Remove(lemm);
                    db.SaveChanges();
                }
                return Redirect("/Home/Topic/" + num);
            }
            if (h == "sinc")
            {
                int? num = db.Professors.Find(id).TopicId;
                Professor prof = db.Professors.Find(id);
                if (prof != null)
                {
                    db.Professors.Remove(prof);
                    db.SaveChanges();
                }
                return Redirect("/Home/Topic/" + num);
            }
            if (h == "form")
            {
                int? num = db.Formuls.Find(id).TopicId;
                Formula form = db.Formuls.Find(id);
                if (form != null)
                {
                    db.Formuls.Remove(form);
                    db.SaveChanges();
                }
                return Redirect("/Home/Topic/" + num);
            }
            if (h == "task")
            {
                int? num = db.Tasks.Find(id).TopicId;
                Task task = db.Tasks.Find(id);
                if (task != null)
                {
                    db.Tasks.Remove(task);
                    db.SaveChanges();
                }
                return Redirect("/Home/Topic/" + num);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Discipline(int? id)
        {
            Discipline discipline = db.Disciplines.Find(id);
            if(discipline == null)
            {
                return HttpNotFound();
            }
            ViewBag.String = "<div>dfdfgdf</div>";
            return View(discipline);
        }
        [HttpPost]
        public ActionResult Discipline(Topic topic)
        {
            db.Topics.Add(topic);
            db.SaveChanges();
            return Redirect("/Home/Discipline/"+topic.DisciplineId);
        }
        [HttpGet]
        public ActionResult Edit(int? id, string h)
        {
            TopicElements topicElem = new TopicElements();
            ViewBag.Temp = h;
            if (h == "text")
            {
                Text text = db.Texts.Find(id);
                topicElem.Text = text;
                return View(topicElem);
            }
            if (h == "theor")
            {
                return View(topicElem);
            }
            if (h == "axiom")
            {
                return View(topicElem);
            }
            if (h == "lemma")
            {
                return View(topicElem);
            }
            if (h == "sinc")
            {
                return View(topicElem);
            }
            if (h == "form")
            {
                return View(topicElem);
            }
            if (h == "task")
            {
                return View(topicElem);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult Edit(TopicElements topicElem, HttpPostedFileBase image)
        {
            if (topicElem.Text != null)
            {
                db.Entry(topicElem.Text).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect("/Home/Topic/" + topicElem.Text.TopicId);
            }
            if (topicElem.Theorem != null)
            {
                db.Entry(topicElem.Theorem).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect("/Home/Topic/" + topicElem.Theorem.TopicId);
            }
            if (topicElem.Axiom != null)
            {
                db.Entry(topicElem.Axiom).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect("/Home/Topic/" + topicElem.Axiom.TopicId);
            }
            if (topicElem.Lemma != null)
            {
                db.Entry(topicElem.Lemma).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect("/Home/Topic/" + topicElem.Lemma.TopicId);
            }
            if (topicElem.Professor != null)
            {
                db.Entry(topicElem.Professor).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect("/Home/Topic/" + topicElem.Professor.TopicId);
            }
            if (topicElem.Formula != null)
            {
                if (image != null)
                {
                    topicElem.Formula.ImageMimeType = image.ContentType;
                    topicElem.Formula.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(topicElem.Formula.ImageData, 0, image.ContentLength);
                }
                db.Entry(topicElem.Formula).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect("/Home/Topic/" + topicElem.Formula.TopicId);
            }
            if (topicElem.Task != null)
            {
                if (image != null)
                {
                    topicElem.Task.ImageMimeType = image.ContentType;
                    topicElem.Task.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(topicElem.Task.ImageData, 0, image.ContentLength);
                }
                db.Entry(topicElem.Task).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect("/Home/Topic/" + topicElem.TopicId);
            }
            return Redirect("/Home/Topic/" + topicElem.TopicId);
        }
        public FileContentResult GetImage(int formId)
        {
            Formula form = db.Formuls.FirstOrDefault(g => g.Id == formId);
            if (form != null)
            {
                return File(form.ImageData, form.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
        [HttpGet]
        public ActionResult Add(int? id, string h)
        {
            Topic topic = db.Topics.Find(id);
            ViewBag.Url = "/Home/Topic/" + id;
            IQueryable<int> custQuery =
                (from ax in db.Axioms
                 where ax.TopicId  == id
                 select ax.Layout)
                .Concat
                (from ther in db.Theorems
                 where ther.TopicId == id
                 select ther.Layout)
                .Concat
                (from text in db.Texts
                 where text.TopicId == id
                 select text.Layout)
                 .Concat
                (from form in db.Formuls
                 where form.TopicId == id
                 select form.Layout)
                 .Concat
                (from lemm in db.Lemmes
                 where lemm.TopicId == id
                 select lemm.Layout)
                 .Concat
                (from prof in db.Professors
                 where prof.TopicId == id
                 select prof.Layout);
            if (custQuery.Count() != 0)
                ViewBag.Layout = custQuery.Max() + 1;
            else
                ViewBag.Layout = 0 + 1;
            TopicElements topicElem = new TopicElements();
            ViewBag.Temp = h;
            topicElem.Topic = topic;
            if (h == "text")
            {
                return View("Add", topicElem);
            }
            if (h == "theor")
            {
                return View("Add", topicElem);
            }
            if (h == "axiom")
            {
                return View("Add", topicElem);
            }
            if (h == "lemma")
            {
                return View("Add", topicElem);
            }
            if (h == "sinc")
            {
                return View("Add", topicElem);
            }
            if (h == "form")
            {
                return View("Add", topicElem);
            }
            if (h == "task")
            {
                return View("Add", topicElem);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult Add(TopicElements topicElem, HttpPostedFileBase image)
        {
            if (topicElem.Text != null)
            {
                db.Texts.Add(topicElem.Text);
                db.SaveChanges();
                return Redirect("/Home/Topic/" + topicElem.TopicId);
            }
            if (topicElem.Theorem != null)
            {
                db.Theorems.Add(topicElem.Theorem);
                db.SaveChanges();
                return Redirect("/Home/Topic/" + topicElem.TopicId);
            }
            if (topicElem.Axiom != null)
            {
                db.Axioms.Add(topicElem.Axiom);
                db.SaveChanges();
                return Redirect("/Home/Topic/" + topicElem.TopicId);
            }
            if (topicElem.Lemma != null)
            {
                db.Lemmes.Add(topicElem.Lemma);
                db.SaveChanges();
                return Redirect("/Home/Topic/" + topicElem.TopicId);
            }
            if (topicElem.Professor != null)
            {
                db.Professors.Add(topicElem.Professor);
                db.SaveChanges();
                return Redirect("/Home/Topic/" + topicElem.TopicId);
            }
            if (topicElem.Formula != null)
            {
                if (image != null)
                {
                    topicElem.Formula.ImageMimeType = image.ContentType;
                    topicElem.Formula.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(topicElem.Formula.ImageData, 0, image.ContentLength);
                }
                db.Formuls.Add(topicElem.Formula);
                db.SaveChanges();
                return Redirect("/Home/Topic/" + topicElem.TopicId);
            }
            if (topicElem.Task != null)
            {
                if (image != null)
                {
                    topicElem.Task.ImageMimeType = image.ContentType;
                    topicElem.Task.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(topicElem.Task.ImageData, 0, image.ContentLength);
                }
                db.Tasks.Add(topicElem.Task);
                db.SaveChanges();
                return Redirect("/Home/Topic/" + topicElem.TopicId);
            }
            return Redirect("/Home/Topic/" + topicElem.TopicId);
        }
        [HttpGet]
        public ActionResult TopicView(int? id)
        {
            var Topic = db.Topics.Include(t => t.Texts).FirstOrDefault(t => t.Id == id);
            @ViewBag.Url = "/Home/Discipline/" + id;
            return View(Topic);
        }
        [HttpGet]
        public ActionResult Topic(int? id)
        {
            var Topic = db.Topics.Include(t => t.Texts).FirstOrDefault(t => t.Id == id);
            @ViewBag.Url = "/Home/TopicView/" + id;
            return View(Topic);
        }
        [HttpPost]
        public ActionResult Topic(TopicElements topicElements)
        {
            db.Texts.Add(topicElements.Text);
            db.Theorems.Add(topicElements.Theorem);
            db.SaveChanges();
            return Redirect("/Home/Topic/" + topicElements.Text.TopicId);
        }
        [HttpPost]
        public ActionResult Index(Discipline discipline)
        {;
            db.Disciplines.Add(discipline);
            db.SaveChanges();
            return Redirect("/Home/Index");
        }
    }
}