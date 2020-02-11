using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Use dataContractJsonSerializer need to add "System.Runtime.Serialization", and include the following.
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO; // Use MemoryStream  need to include it.

namespace DCJsonSerializer_ex
{  
    [DataContract]
    public class Student
    {   
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Age { get; set; }
        [DataMember]
        public string Sex { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student stu = new Student()
            {
                ID = 1,
                Name = "張飛",
                Age = 3500,
                Sex = "男"
            };

            // Create a DataContractJsonSerializer's object.
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Student));

            // Start serialization.
            MemoryStream msObj = new MemoryStream(); // Create a support area which is memory's datastream.
            js.WriteObject(msObj, stu); // Write the serialized data to datastream.
            msObj.Position = 0; // Read data in datastream that set the position 0.
            StreamReader sr = new StreamReader(msObj, Encoding.UTF8);
            string json = sr.ReadToEnd();
            sr.Close();
            msObj.Close();
            Console.WriteLine("序列化: " + json);


            // Start deserialization.
            string toDes = json;
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(toDes)))
            {
                DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(Student));
                Student model = (Student)deserializer.ReadObject(ms); // deserialization by ReadObject.
                Console.WriteLine("反序列化: ");
                Console.WriteLine("ID = " + model.ID);
                Console.WriteLine("Name = " + model.Name);
                Console.WriteLine("Age = " + model.Age);
                Console.WriteLine("Sex = " + model.Sex);
            }
            Console.ReadKey(); // stop the console clossing when it display the result.
        }
    }
}
