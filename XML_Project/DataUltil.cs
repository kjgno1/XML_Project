using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XML_Project
{
    class DataUltil
    {
        XmlDocument xmlDocument;
        XmlElement xmlElement;
        string fileName;

        public DataUltil()
        {
            fileName = "Student.xml";
            xmlDocument = new XmlDocument();
            if (!File.Exists(fileName))
            {
                XmlElement course = xmlDocument.CreateElement("cource");
                xmlDocument.AppendChild(course);
                xmlDocument.Save(fileName);
            }
            xmlDocument.Load(fileName);
            xmlElement = xmlDocument.DocumentElement;
        }

        public void Add(Student s)
        {
            XmlElement student = xmlDocument.CreateElement("student");
            student.SetAttribute("sid", s.sid);
            XmlElement name = xmlDocument.CreateElement("name");
            name.InnerText = s.name;
            XmlElement age = xmlDocument.CreateElement("age");
            age.InnerText = s.age;
            XmlElement addr = xmlDocument.CreateElement("addr");
            addr.InnerText = s.addr;

            student.AppendChild(name);
            student.AppendChild(age);
            student.AppendChild(addr);
            xmlElement.AppendChild(student);
            xmlDocument.Save(fileName);

        }

        public bool Update(Student s)
        {
            XmlNode node = xmlElement.SelectSingleNode("student[@sid='" + s.sid + "']");
            if (node != null)
            {
                XmlElement student = xmlDocument.CreateElement("student");
                student.SetAttribute("sid", s.sid);
                XmlElement name = xmlDocument.CreateElement("name");
                name.InnerText = s.name;
                XmlElement age = xmlDocument.CreateElement("age");
                age.InnerText = s.age;
                XmlElement addr = xmlDocument.CreateElement("addr");
                addr.InnerText = s.addr;

                student.AppendChild(name);
                student.AppendChild(age);
                student.AppendChild(addr);
                xmlElement.ReplaceChild(student, node);
                xmlDocument.Save(fileName);
                return true;
            }
            return false;
        }

        public bool Delete(string sid)
        {
            XmlNode node = xmlElement.SelectSingleNode("student[@sid='" + sid + "']");
            if (node != null)
            {
                xmlElement.RemoveChild(node);
                xmlDocument.Save(fileName);
                return true;
            }
            return false;
        }

        public List<Student> FindById(string id)
        {
            XmlNode node = xmlElement.SelectSingleNode("student[@sid='" + id + "']");
            List<Student> students = new List<Student>();
            if (node != null)
            {
                Student student = new Student();
                student.sid = node.Attributes[0].InnerText;
                student.name = node.SelectSingleNode("name").InnerText;
                student.age = node.SelectSingleNode("age").InnerText;
                student.addr = node.SelectSingleNode("addr").InnerText;
                students.Add(student);
            }
            return students;
        }
        public List<Student> FindByCity(string addr)
        {
            XmlNodeList nodes = xmlElement.SelectNodes("student[addr='" + addr + "']");
            List<Student> students = new List<Student>();
            foreach (XmlNode node in nodes)
            {
                if (node != null) { 
                Student student = new Student();
                student.sid = node.Attributes[0].InnerText;
                student.name = node.SelectSingleNode("name").InnerText;
                student.age = node.SelectSingleNode("age").InnerText;
                student.addr = node.SelectSingleNode("addr").InnerText;
                students.Add(student);
                }
            }
            return students;
        }


        public List<Student> getAllStudent()
        {
            XmlNodeList xmlNodeList = xmlElement.SelectNodes("student");
            List<Student> students = new List<Student>();

            foreach (XmlNode item in xmlNodeList)
            {
                Student student = new Student();
                student.sid = item.Attributes[0].InnerText;
                student.name = item.SelectSingleNode("name").InnerText;
                student.age = item.SelectSingleNode("age").InnerText;
                student.addr = item.SelectSingleNode("addr").InnerText;
                students.Add(student);
                

            }
            return students;
        }

    }
}
