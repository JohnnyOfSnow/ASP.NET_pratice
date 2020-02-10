using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace JavaScriptSerializer_ex
{
    class Student  // Define a class named Student that have four(ID, Name, Age, Sex) properties.
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
    }
    class Program
    {
        static void Main(string[] args) // Console will run this block.
        {
            Student stu = new Student() // Create an object by Student class.
            {
                ID = 1,
                Name = "孟子",
                Age = 3000,
                Sex = "男"
            };

            // Create a JavaScriptSerializer's object named jss.
            JavaScriptSerializer jss = new JavaScriptSerializer();

            //Serialization
            string jsonData = jss.Serialize(stu);
            Console.WriteLine("序列化: " + jsonData);

            //Deserialization method 1 (model)
            /*
             *  Notice: use object.property to get value.
             *  
             *  e.g. dyModel.ID
             */
            string desJson = jsonData;
            //Student model = jss.Deserialize<Student>(desJson);
            //string message = string.Format("ID={0}, Name={1}, Age={2}, Sex={3}", model.ID, model.Name, model.Age, model.Sex);


            //Deserialization method 2 (dynamic).
            /*
             *  Notice: Only use index to get value(not object.property)
             *  
             *  e.g. dyModel["ID"], not dyModel.ID
             */
            dynamic dyModel = jss.Deserialize<dynamic>(desJson);
            string dyMessage = string.Format("ID={0}, Name={1}, Age={2}, Sex={3}",
                                            dyModel["ID"], dyModel["Name"], dyModel["Age"], dyModel["Sex"]);

            Console.WriteLine("動態的反序列化: " + dyMessage);

            Console.ReadKey(); // Avoid console closing when program is running done.
        }
    }
}
