using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Core.Domain
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public int? ParentId { get; set; }
        public List<Employee> Children { get; set; } = [];
    }
}
