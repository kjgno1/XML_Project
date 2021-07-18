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
