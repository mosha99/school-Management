//using ConsoleApplication1;
//using ConsoleApplication1.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using school_Management.database;
using school_Management.Models;

namespace school_Management.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        //data Data = new data();
        public ActionResult index()
        {
            serch model = new serch { classroom = data.getAllC(), student = data.getAllS(), teachers = data.getAllT() };
            return View(model);
        }
        public ActionResult Class()
        {
            var list = data.getAllC();
            classList List = new classList();
            List.list=list.ToPagedList(1, 10);
            return View(List);
        }
        public ActionResult Teacher()
        {
            var list = data.getAllT();
            teacherList List = new teacherList();
            List.List=list.ToPagedList(1, 10);
            return View(List);
        }
        public ActionResult student()
        {
            var list = data.getAllS();
            sutudentList List = new sutudentList();
            List.List = list.ToPagedList(1, 100);
            return View(List);
        }
        public ActionResult getstudent()
        {
            string id = Request.QueryString["id"];
            if ( id== null)
            {
                return Redirect("student");
            }
            var it = data.getStudents(Convert.ToInt16(id));
            if(it==null)
            {
                return Redirect("student");
            }
            return View(data.getStudents(Convert.ToInt16(id)));
        }
        public ActionResult getTeacher()
        {
            string id = Request.QueryString["id"];
            if (id == null)
            {
                return Redirect("Teacher");
            }
            var it = data.getTeachers(Convert.ToInt16(id));
            if (it == null)
            {
                return Redirect("Teacher");
            }
            return View(data.getTeachers(Convert.ToInt16(id)));
        }
        public ActionResult getClass()
        {
            string id = Request.QueryString["id"];
            if (id == null)
            {
                return Redirect("Class");
            }
            var it = data.getclassroom(Convert.ToInt16(id));
            if (it == null)
            {
                return Redirect("Class");
            }
            return View(data.getclassroom(Convert.ToInt16(id)));
        }
        [Route("Search")]
        public ActionResult Search()
        {
            string q = Request.QueryString["serch"];
            string all = Request.QueryString["all"];
            serch model = new serch { classroom = null, student = null, teachers = null };
            bool nu = false;
            if (q != null && q.Length > 2)
            {
                nu = true;
                model = data.Serch(q,true);
            }
            if (nu)
            {
                ViewBag.count = 0;
                ViewBag.count = model.teachers.Count() + model.student.Count() + model.classroom.Count();
            }
            return PartialView(model);

        }
        public ActionResult Searchs()
        {
            serch model = new serch { classroom = null, student = null, teachers = null };
            return View(model);
        }
        [HttpPost]
        public ActionResult Searchs(string serch)
        {
            serch model = new serch { classroom = null, student = null, teachers = null };
            if (serch != null)
            {
                model =data.Serch(serch);
            }
            return View(model);
        }
    }
} 