using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Students.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Infra.Data.Sql
{
    public static class TipsAndTricks
    {
        public static void AddEmployee()
        {
            var context = ContextFactory.GetSqlContext();
            var employees = new Employee
            {
                FirstName = "1",
                LastName = "1",
                Children = new List<Employee>
                {
                    new Employee
                    {
                     FirstName = "1.1",
                     LastName = "1.1",
                    },
                      new Employee
                    {
                       FirstName = "1.2",
                       LastName = "1.2",
                       Children = new List<Employee> { new Employee
                       {
                       FirstName = "1.2.1",
                       LastName = "1.2.1",
                       Children = { new Employee
                       {
                       FirstName = "1.2.2",
                       LastName = "1.2.2",
                       } }
                       } }
                    },
                      new Employee
                    {
                       FirstName = "1.3",
                       LastName = "1.3",
                              Children = new List<Employee> { 
                                  new Employee
                       {
                       FirstName = "1.3.1",
                       LastName = "1.3.1",
                       } ,
                                     new Employee
                       {
                       FirstName = "1.3.2",
                       LastName = "1.3.2",
                       }

                              }
                    }
                }
            };
            context.Set<Employee>().Add(employees);
            context.SaveChanges();
        }
        public static void GetEmployees()
        {
            var context = ContextFactory.GetSqlContext();
          var employees=  context.Employees.Include(e=>e.Children).ToList();
        }
        public static void AddParent()
        {
            var context = ContextFactory.GetSqlContext();
            var parent = new Parent
            {
                Title = "Title"
            };
            for (int i = 0; i < 10; i++){
                parent.Childs1.Add(new Child1
                {
                    Title = $"child{i}",
                });
                parent.Childs0.Add(new Child0
                {
                    Title = $"child{i}",
                });
                parent.Childs2.Add(new Child2
                {
                    Title = $"child{i}",
                });
                parent.Childs3.Add(new Child3
                {
                    Title = $"child{i}",
                });
            
            }
            context.Parents.Add(parent);
            context.SaveChanges();
        }
        public static void GetParentWithChilds() {
            var context = ContextFactory.GetSqlContext();
            //var res = context.Parents.Where(p => p.Id == 5).Include(p => p.Childs0)
            //                .Include(p => p.Childs1).Include(p => p.Childs2)
            //                .Include(p => p.Childs3).AsQueryable();
            var res = context.Parents.Where(p => p.Id == 5).AsSplitQuery().Include(p => p.Childs0)
                          .Include(p => p.Childs1).Include(p => p.Childs2)
                          .Include(p => p.Childs3).AsQueryable();
            var resQueryString= res.ToQueryString();
            var parentWithChild = res.ToList();

        }
        public static void AddChildToParent()
        {
            var context = ContextFactory.GetSqlContext();
            var parent = context.Set<Parent>().FirstOrDefault(c => c.Id == 5);
            for (int i = 0; i < 100; i++)
            {
                parent.Childs1.Add(new Child1
                {
                    Title = $"child{i}",
                });
                parent.Childs0.Add(new Child0
                {
                    Title = $"child{i}",
                });
                parent.Childs2.Add(new Child2
                {
                    Title = $"child{i}",
                });
                parent.Childs3.Add(new Child3
                {
                    Title = $"child{i}",
                });
            }
            context.SaveChanges();

        }
    }
}
