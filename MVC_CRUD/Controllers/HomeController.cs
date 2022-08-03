using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_CRUD.Models;
namespace MVC_CRUD.Controllers
{
    public class HomeController : Controller
    {
        dbPersonEntities db = new dbPersonEntities();

        public ActionResult Index()
        {
            var PersonList = db.Person.OrderBy(m => m.pId).ToList();
            return View(PersonList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string pName, int pAge, DateTime pBirthday)
        {
            Person person = new Person();
            person.pName = pName;
            person.pAge = pAge;
            person.pBirthday = pBirthday;
            db.Person.Add(person);
            db.SaveChanges();
            return RedirectToAction("Index");

        }


        public ActionResult Delete(int? id)
        {
            var person = db.Person.Where(m => m.pId == id).FirstOrDefault();
            db.Person.Remove(person);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var person = db.Person.Where(m => m.pId == id).FirstOrDefault();
            
            return View(person);
        }

        [HttpPost]
        public ActionResult Edit(Person person)
        {
            var personList = db.Person.Where(m => m.pId == person.pId).FirstOrDefault();

            personList.pName = person.pName;
            personList.pAge = person.pAge;
            personList.pBirthday = person.pBirthday;
            db.SaveChanges();
            return RedirectToAction("Index");
        }





















        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}