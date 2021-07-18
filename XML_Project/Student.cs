using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML_Project
{
    class Student
    {
        public string sid { get; set; }
        public string name { get; set; }
        public string age { get; set; }
        public string addr { get; set; }

        public Student()
        {

        }
        public Student(String sid)
        {
            this.sid = sid;
        }
    }
}
