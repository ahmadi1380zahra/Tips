using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Students.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Infra.Data.Sql
{
    public static class CommandRepository
    {
        public static void CheckEntityState()
        {
            var context = ContextFactory.GetSqlContext();
            var teacher = new Teacher
            {
                FirstName = "zizi",
                LastName = "mewmew"
            };
            context.Add(teacher);
            Console.WriteLine($"teacher state: {context.Entry(teacher).State}");
            var course = context.Set<Course>().FirstOrDefault();
            Console.WriteLine($"before course change : {context.Entry(course!).State}");
            course!.Title = "new dummy title";
            Console.WriteLine($"after course change : {context.Entry(course).State}");
            var tag = new Tag
            {
                Title = "hi",
            };
            Console.WriteLine($"tag: {context.Entry(tag).State}");
            context.Remove(course);
            Console.WriteLine($"course state: {context.Entry(course).State}");

        }
        public static void CheckChangeTrackerView()
        {
            var context = ContextFactory.GetSqlContext();
            var teacher = new Teacher
            {
                FirstName = "zizi",
                LastName = "mewmew"
            };
            context.Add(teacher);
            Console.WriteLine($"teacher state befora save change: {context.ChangeTracker.DebugView.LongView}");
            var course = context.Set<Course>().FirstOrDefault();
            Console.WriteLine($"before course change : {context.ChangeTracker.DebugView.LongView}");
            course!.Title = "new dummy title";
            Console.WriteLine($"after course change : {context.ChangeTracker.DebugView.LongView}");
            context.ChangeTracker.DetectChanges();
            Console.WriteLine($"after course detect change : {context.ChangeTracker.DebugView.LongView}");

            var tag = new Tag
            {
                Title = "hi",
            };
            Console.WriteLine($"tag: {context.ChangeTracker.DebugView.LongView}");
            context.Remove(course);
            Console.WriteLine($"course state: {context.ChangeTracker.DebugView.LongView}");

        }
        public static void Add()
        {
            var course = new Course
            {
                Title = "titi",
                Description = "dd",
                Discount = new Discount
                {
                    Title = "dis",
                    Price = 100

                }
            };
            var context = ContextFactory.GetSqlContext();
            context.Add(course);
            Console.WriteLine("before save change: " + context.ChangeTracker.DebugView.LongView);
            context.SaveChanges();
            Console.WriteLine("after save change: " + context.ChangeTracker.DebugView.LongView);
        }
        public static void Update()
        {
            var context = ContextFactory.GetSqlContext();

            var res = context.Set<Course>().FirstOrDefault(c => c.Title == "mimi");
            res.Title = "lolo";
          //  context.Set<Course>().Update(res);

            context.SaveChanges();

        }
        public static void DisconnectUpdate()
        {
            var context = ContextFactory.GetSqlContext();
            var course = new Course
            {
                Id = 2,
                Title = "hihi math",
                Description = "dsd",
                Price = 100000
            };
            context.Set<Course>().Update(course);
            context.SaveChanges();

        }
        public static void GetAll()
        {
            var context = ContextFactory.GetSqlContext();
            var courses = context.Set<Course>().ToList();
            foreach (var course in courses)
            {
                Console.WriteLine(course.Id + "" + course.Title+""+course.Description);
            }
        }
        public static void SoftDelete()
        {
            var context = ContextFactory.GetSqlContext();
            foreach(var course in context.Set<Course>())
            {
                Console.WriteLine($"titile:{course.Title}");
            }
            var firstCourse = context.Set<Course>().FirstOrDefault();
            firstCourse.IsDelete = true;
            context.SaveChanges();
            foreach (var course in context.Set<Course>())
            {
                Console.WriteLine($"after soft delete titile:{course.Title}");
            }
        }
    }
}
