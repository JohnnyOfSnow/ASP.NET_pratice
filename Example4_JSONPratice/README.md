# ASP.NET_pratice

***
## Example 4: JSON's serialization and deserialization in C#.
## 練習4: 練習C#裡將JSON序列化或反序列化的一些方法

![image](https://github.com/JohnnyOfSnow/ASP.NET_pratice/blob/master/Example4_JSONPratice/image/jss_result.jpg)

* **練習內容**
  * 1.了解什麼是JSON、序列化、反序列化
  * 2.練習一些JSON的序列化與反序列化的方法
    * a. JavaScriptSerializer類
    * b. DataContractJsonSerializer類
    * c. JSON.NET類

***
### 1.了解什麼是JSON、序列化、反序列化
***

**JSON**

JSON (JavaScript Object Notation) is a lightweight data-interchange format. It is easy for humans to read and write and easy for machines to parse and generate. JSON is a text format that is completely language independent.

JSON是javascript的物件表示法，是一種簡單輕量的資料交換格式，我們可以輕易的讀取和讀寫它，而且易於機器轉化與產生，JSON是完全獨立於任何語言。

JSON實質上為字串，可以用陣列[]、物件{}的方式讀取與寫入。

***

**序列化(Serialization)**

將物件轉換成可保存或是可傳輸的形式(資料)，使用時機為物件需要封送、遠端服務與網路資料流時

***

**反序列化or還原序列化(Deserialization)**

將資料轉換成物件，使用時機為物件直接儲存到資料庫時。

***

**以下練習序列化與反序列化的程式，執行時是用Command，因而創建專案的時候請選下圖的這個，而不是前面練習的MVC專案**

![image](https://github.com/JohnnyOfSnow/ASP.NET_pratice/blob/master/Example4_JSONPratice/image/connamdProject.jpg)

***
### 2.練習一些JSON的序列化與反序列化的方法
### a. JavaScriptSerializer類
***

**先在專案的參照裡加入System.Web.Extensions**

![image](https://github.com/JohnnyOfSnow/ASP.NET_pratice/blob/master/Example4_JSONPratice/image/extensionLocate.jpg)

**Program.cs**

使用程式語言:C#

```C#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace JavaScriptSerializer_ex
{
    class Student  
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
            string desJson = jsonData;
            //Student model = jss.Deserialize<Student>(desJson);
            //string message = string.Format("ID={0}, Name={1}, Age={2}, Sex={3}", model.ID, model.Name, model.Age, model.Sex);

            dynamic dyModel = jss.Deserialize<dynamic>(desJson);
            string dyMessage = string.Format("ID={0}, Name={1}, Age={2}, Sex={3}",
                                            dyModel["ID"], dyModel["Name"], dyModel["Age"], dyModel["Sex"]);

            Console.WriteLine("動態的反序列化: " + dyMessage);

            Console.ReadKey(); // Avoid console closing when program is running done.
        }
    }
}
```

**一一講解上述程式碼**

``引用JavaScriptSerializer``

```C#
using System.Web.Script.Serialization;
```

``定義Student類別，裡面有四個屬性``

```C#
class Student  
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Sex { get; set; }
}
```

***

``建立JavaScriptSerializer的物件，並且用Serialize方法，序列化由Student類別產生的stu物件``

``用Console.WriteLine()，將結果顯示在Command上``

```C#
// Create a JavaScriptSerializer's object named jss.
JavaScriptSerializer jss = new JavaScriptSerializer();

//Serialization
string jsonData = jss.Serialize(stu);
Console.WriteLine("序列化: " + jsonData);
```

***

``這是JavaScriptSerializer反序列化的第一個方法，取資料用(物件.屬性)的方法``

```C#
//Deserialization method 1 (model)
string desJson = jsonData;
Student model = jss.Deserialize<Student>(desJson);
string message = string.Format("ID={0}, Name={1}, Age={2}, Sex={3}", model.ID, model.Name, model.Age, model.Sex);
```

***

``這是JavaScriptSerializer反序列化的第二個方法(動態)，取資料用(物件["索引"])的方法``

```C#
//Deserialization method 2 (dynamic)
dynamic dyModel = jss.Deserialize<dynamic>(desJson);
string dyMessage = string.Format("ID={0}, Name={1}, Age={2}, Sex={3}", dyModel["ID"], dyModel["Name"], dyModel["Age"], dyModel["Sex"]);
```

***
### 2.練習一些JSON的序列化與反序列化的方法
### b. DataContractJsonSerializer類
***

**先在專案的參照裡加入System.Web.Extensions**

![image](https://github.com/JohnnyOfSnow/ASP.NET_pratice/blob/master/Example4_JSONPratice/image/runtimeLocate.jpg)

***

**Program.cs**

使用程式語言:C#

```C#
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
```

**一一講解上述程式碼**

``引用DataContractJsonSerializer``

```C#
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
```

***

``定義Student類別要在上方寫上[DataContract]，每一個屬性上方加上[DataMember]``

```C#
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
```

***

**序列化**

``建立DataContractJsonSerializer物件js，還有資料流(MemoryStream)物件msObj``

``要使用MemoryStream，需要引用 using System.IO;``

``js.WriteObject(msObj, stu); 將序列化的資料寫到資料流``

``msObj.Position = 0; 從0的位置讀取資料流``

``記得要把讀資料流的sr以及資料流msObj關閉``

```C#
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
```

***

**反序列化**

``MemoryStream(Encoding.Unicode.GetBytes(toDes) 將toDes中的所有字元編碼成位元組序列``

``DataContractJsonSerializer(typeof(Student)) 將上述的位元組序列進行反序列化成物件``

``取得物件的資料，用物件.屬性，例如：model.ID``

```C#
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
```

***
### 2.練習一些JSON的序列化與反序列化的方法
### c. JSON.NET類
***

**先在專案安裝Nuget Newtonsoft.Json**

![image](https://github.com/JohnnyOfSnow/ASP.NET_pratice/blob/master/Example4_JSONPratice/image/JSONNET_1.jpg)

![image](https://github.com/JohnnyOfSnow/ASP.NET_pratice/blob/master/Example4_JSONPratice/image/JSONNET_2.jpg)

***

**Program.cs**

使用程式語言:C#

```C#
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
```

**一一講解上述程式碼**

``引用JSON.NET``

```C#
using Newtonsoft.Json;
```

***

``建立裝有Student物件的list，並且加入兩筆資料``

```C#
List<Student> listStudent = new List<Student>()
{
    new Student(){ ID=1, Name="香菇", Age=200, Sex="男"},
    new Student(){ ID=2, Name="綠菇菇", Age=250, Sex="女"}
};
```

***

**序列化**

``JsonConvert.SerializeObjec(資料)``

```C#
// Newtonsoft.Json serialization
string jsonData = JsonConvert.SerializeObject(listStudent);
Console.WriteLine("序列化: " + jsonData);

```

***

**反序列化**

``JsonConvert.DeserializeObject<資料形式>(json資料)，因為我們把json弄成Student的形式，故資料形式會是Student``

``取得物件的資料，用物件.屬性，例如：model.ID，這裡的物件是desJsonStu``

```C#
// Newtonsoft.Json deserialization
string json = @"{'Name': 'C#', 'Age': '80', 'Sex': '女', 'ID': '20'}";
Student desJsonStu = JsonConvert.DeserializeObject<Student>(json);

Console.WriteLine(string.Format("反序列化: ID={0}, Name={1}, Age={2}, Sex={3}",desJsonStu.ID, desJsonStu.Name, desJsonStu.Age, desJsonStu.Sex));
```