using school_Management.database;
using school_Management.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_Management
{
    public static class k
    {
        public static bool ferstTime ;
        public static DateTime TimeoutT;
        public static DateTime TimeoutS;
        public static DateTime TimeoutC;
    }
    public  class data
    {
        static schoolContext Data = new schoolContext();
        public static void  make()
        {
            if(k.ferstTime!=true)
            {
                k.ferstTime= true;
                var s = Data.Students.Include("classroom").ToList();
                var s1 = Data.classroom.Include("Students").ToList();
                var s2 = Data.classroom.Include("Teacher").ToList();
                var s3 = Data.Students.Include("classroom").ToList();
                var s4 = Data.Teachers.Include("classes").ToList();

            }
            
            
        }
        public static bool add(Students model)
        {
            try
            {
                Data.Students.Add(model);
                Data.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool add(Teachers model)
        {
            try
            {
                Data.Teachers.Add(model);
                Data.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool add(classroom model)
        {
            try
            {
                Data.classroom.Add(model);
                Data.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static List<Students> getAllS()
        {
            make();
            List<Students> x = new List<Students>();
            try
            {

                if (k.TimeoutS == null || k.TimeoutS < DateTime.Now)
                {
                    x = Data.Students.ToList();
                }
                k.TimeoutS = DateTime.Now.AddSeconds(0.1);
                return x;
            }
            catch
            {


                return x;
            }

        }
        public static List<Teachers> getAllT()
        {
            make();
            List<Teachers> x = new List<Teachers>();
            try
            {
                
                if (k.TimeoutT == null || k.TimeoutT < DateTime.Now)
                {
                    x = Data.Teachers.ToList();
                }
                k.TimeoutT = DateTime.Now.AddSeconds(0.1);
                return x;
            }
            catch
            {

                
                return x;
            }
            
            
            

        }
        public static List<classroom> getAllC()
        {
            make();
            List<classroom> x = new List<classroom>();
            try
            {

                if (k.TimeoutC == null || k.TimeoutC < DateTime.Now)
                {
                    x = Data.classroom.ToList();
                }
                k.TimeoutC = DateTime.Now.AddSeconds(0.1);
                return x;
            }
            catch
            {


                return x;
            }
        }
        public static Students getStudents(int id)
        {
            make();
            return Data.Students.FirstOrDefault(x => x.Id == id);
        }
        public static Teachers getTeachers(int id)
        {
            make();
            return Data.Teachers.FirstOrDefault(x => x.Id == id);
        }
        public static classroom getclassroom(int id)
        {
            make();
            return Data.classroom.FirstOrDefault(x => x.Id == id);
        }
        public static bool edit(Students model)
        {
            try
            {
                var Item = getStudents(model.Id);
                Item = model;
                Data.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool edit(Teachers model)
        {
            try
            {
                var Item = getTeachers(model.Id);
                Item = model;
                Data.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool edit(classroom model)
        {
            try
            {
                var Item = getclassroom(model.Id);
                Item = model;
                Data.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool removeStudents(int id)
        {
            try
            {
                var Item = getStudents(id);
                Data.Students.Remove(Item);
                Data.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool removeTeachers(int id)
        {
            try
            {
                var Item = getTeachers(id);
                Data.Teachers.Remove(Item);
                Data.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool removeclassroom(int id)
        {
            try
            {
                var Item = getclassroom(id);
                Data.classroom.Remove(Item);
                Data.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static serch Serch(string q ,bool ajax)
        {
            serch model = new serch { classroom = null, student = null, teachers = null };
            schoolContext Data = new schoolContext();

            List<classroom> x = new List<classroom>();
            List<Teachers> y = new List<Teachers>();
            List<Students> z = new List<Students>();
            try
            {
                z = Data.Students.ToList();
                y = Data.Teachers.ToList();
                x = Data.classroom.ToList();
            }
            catch
            {
                System.Threading.Thread.Sleep(100);
                z = Data.Students.ToList();
                y = Data.Teachers.ToList();
                x = Data.classroom.ToList();
            }


            List<Students> li1 = new List<Students>();
            model.student = z.Where(mn => mn.Name.Contains(q)).Take(3).ToList();
            model.teachers = y.Where(mn => mn.Name.Contains(q)).Take(3).ToList();
            model.classroom = x.Where(mn => mn.Name.Contains(q)).Take(3).ToList();
            return (model);

        }
        public static serch Serch(string q)
        {
            serch model = new serch { classroom = null, student = null, teachers = null };
            schoolContext Data = new schoolContext();

            List<classroom> x = new List<classroom>();
            List<Teachers> y = new List<Teachers>();
            List<Students> z = new List<Students>();
            try
            {
                z = Data.Students.ToList();
                y = Data.Teachers.ToList();
                x = Data.classroom.ToList();
            }
            catch
            {
                System.Threading.Thread.Sleep(100);
                z = Data.Students.ToList();
                y = Data.Teachers.ToList();
                x = Data.classroom.ToList();
            }


            List<Students> li1 = new List<Students>();
            model.student = z.Where(mn => mn.Name.Contains(q)).ToList();
            model.teachers = y.Where(mn => mn.Name.Contains(q)).ToList();
            model.classroom = x.Where(mn => mn.Name.Contains(q)).ToList();
            return (model);

        }
    }
}
