using ConsoleApplication1.database;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public  class data
    {
        static schoolContext Data = new schoolContext();
        public static void  make()
        {
            var s = Data.Students.Include("classroom").ToList();
            var s1 = Data.classroom.Include("Students").ToList();
            var s2 = Data.classroom.Include("Teacher").ToList();
            var s3 = Data.Students.Include("classroom").ToList();
            var s4 = Data.Teachers.Include("classes").ToList();
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
        public static IList<Students> getAllS()
        {
            make();
            return Data.Students.ToList();
        }
        public static IList<Teachers> getAllT()
        {
            make();
            return Data.Teachers.ToList();
        }
        public static IList<classroom> getAllC()
        {
            make();
            return Data.classroom.ToList();
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
    }
}
