using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Core.Domain
{
    public class Parent
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Child0> Childs0 { get; set; } = [];
        public List<Child1> Childs1{ get; set; }= [];
        public List<Child2> Childs2{ get; set; } = [];
        public List<Child3> Childs3 { get; set; } = [];
    }
    public class Child0
    {
        public int Id { get; set; }
        public string Title { get; set; }

    }
    public class Child1
    {
        public int Id { get; set; }
        public string Title { get; set; }

    }
    public class Child2
    {
        public int Id { get; set; }
        public string Title { get; set; }

    }
    public class Child3
    {
        public int Id { get; set; }
        public string Title { get; set; }

    }

}
