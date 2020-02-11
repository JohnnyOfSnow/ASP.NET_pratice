using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json; // Remember to include Newtonsoft.Json;

namespace JSON_NET_ex
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> listStudent = new List<Student>()
            {
                new Student(){ ID=1, Name="香菇", Age=200, Sex="男"},
                new Student(){ ID=2, Name="綠菇菇", Age=250, Sex="女"}
            };

            // Newtonsoft.Json serialization
            string jsonData = JsonConvert.SerializeObject(listStudent);
            Console.WriteLine("序列化: " + jsonData);


            // Newtonsoft.Json deserialization
            string json = @"{'Name': 'C#', 'Age': '80', 'Sex': '女', 'ID': '20'}";
            Student desJsonStu = JsonConvert.DeserializeObject<Student>(json);

            Console.WriteLine(string.Format("反序列化: ID={0}, Name={1}, Age={2}, Sex={3}",
                                            desJsonStu.ID, desJsonStu.Name, desJsonStu.Age, desJsonStu.Sex));

            Console.ReadKey(); // stop the console clossing when it display the result.
        }
    }
}
