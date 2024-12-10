using Microsoft.EntityFrameworkCore;
using Students.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Infra.Data.Sql
{
    public static class QueryRepository
    {
        public static void Add()
        {

            var context = ContextFactory.GetSqlContext();
            context.Set<Course>().Add(new Course
            {
                Title = "math",
                Description = "math is so funny",
                Price = 2000,
                Tags = new List<Tag>
   {
       new Tag
       {
           Title="mathematic",
       },
       new Tag
       {
           Title = "math is sience",
       }

   },
                Discount = new Discount
                {
                    Title = "spring",
                    Price = 20
                },
                Comments = new List<Comment>
   {
       new Comment
       {
           Title= "what a course",
           Text= "wowwwwww",
           Date=DateTime.UtcNow
       }
   },
                CourseTeachers = new List<CourseTecher>
    {
        new CourseTecher
   {
            SortOrder=1,
            Teacher = new Teacher
            {
                FirstName = "shahnaz",
                LastName= "ahmadi",

            }

   },
        new CourseTecher
        {
            SortOrder = 2,
            Teacher = new Teacher
            {
                FirstName = "ali",
                LastName ="ahnadi"
            }

        }
    }

            });
            context.SaveChanges();
        }
        public static void ReadEagerLoading()
        {
            var context = ContextFactory.GetSqlContext();

            var res = context.Set<Course>()
                  .Include(c => c.Comments.Where(cm => cm.Text != null)).Include(c => c.CourseTeachers).ThenInclude(t => t.Teacher)
                  .Include(c => c.Discount)
                  .Include(c => c.Tags);
            var resString = res.ToQueryString();
            var resList = res.ToList();


        }
        public static void ReadExplicitLoad()
        {
            var context = ContextFactory.GetSqlContext();
            var course = context.Set<Course>().FirstAsync();
            var discount = context.Entry(course).Reference("Discount").LoadAsync();
            var tafs = context.Entry(course).Collection("Tags").LoadAsync();
        }
        public static void SelectLoading()
        {
            var context = ContextFactory.GetSqlContext();
            var res = context.Set<Course>().Select(c => new
            {
                c.Title,
                c.Description,
               tags= c.Tags.Select(t=>new
                {
                    t.Title
                }).ToList(),

            });
        }
        public static void RelationShipSimple()
        {
            var context = ContextFactory.GetSqlContext();
            var courses = context.Set<Course>().AsNoTracking().ToList();
            var discounts = context.Set<Discount>().AsNoTracking().ToList();
        }
        public static void RelationShipNormal()
        {
            var context = ContextFactory.GetSqlContext();
            var courses = context.Set<Course>().ToList();
            var discounts = context.Set<Discount>().ToList();
        }
    }
}
