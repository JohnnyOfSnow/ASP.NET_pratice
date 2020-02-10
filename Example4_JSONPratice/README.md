# ASP.NET_pratice

***
## Example 4: JSON's serialization and deserialization in C#.
## 練習4: 練習C#裡將JSON序列化或反序列化的一些方法

![image](https://github.com/JohnnyOfSnow/ASP.NET_pratice/blob/master/Example4_JSONPratice/image/jss_result.jpg)

* **練習內容**
  * 1.了解什麼是JSON、序列化、反序列化
  * 2.練習一些JSON的序列化與反序列化的方法
    * a. JavaScriptSerializer類
    * b.
    * c.

***
### 1.了解什麼是JSON、序列化、反序列化
***

**JSON**

JSON (JavaScript Object Notation) is a lightweight data-interchange format. It is easy for humans to read and write and easy for machines to parse and generate. JSON is a text format that is completely language independent.

JSON是javascript的物件表示法，是一種簡單輕量的資料交換格式，我們可以輕易的讀取和讀寫它，而且易於機器轉化與產生，JSON是完全獨立於任何語言。

JSON實質上為字串，可以用陣列[]、物件{}的方式讀取與寫入。

**序列化(Serialization)**

將物件轉換成可保存或是可傳輸的形式(資料)，使用時機為物件需要封送、遠端服務與網路資料流時

**反序列化or還原序列化(Deserialization)**

將資料轉換成物件，使用時機為物件直接儲存到資料庫時。

**以下練習序列化與反序列化的程式，執行時是用Command，因而創建專案的時候請選下圖的這個，而不是前面練習的MVC專案**

![image](https://github.com/JohnnyOfSnow/ASP.NET_pratice/blob/master/Example4_JSONPratice/image/connamdProject.jpg)

**然後專案的參照裡加入System.Web.Extensions**

![image](https://github.com/JohnnyOfSnow/ASP.NET_pratice/blob/master/Example4_JSONPratice/image/extensionLocate.jpg)

***
### 2.練習一些JSON的序列化與反序列化的方法
### a. JavaScriptSerializer類
***

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

``建立JavaScriptSerializer的物件，並且用Serialize方法，序列化由Student類別產生的stu物件``

``用Console.WriteLine()，將結果顯示在Command上``

```C#
// Create a JavaScriptSerializer's object named jss.
JavaScriptSerializer jss = new JavaScriptSerializer();

//Serialization
string jsonData = jss.Serialize(stu);
Console.WriteLine("序列化: " + jsonData);
```

``這是JavaScriptSerializer反序列化的第一個方法，取資料用(物件.屬性)的方法``

```C#
//Deserialization method 1 (model)
string desJson = jsonData;
Student model = jss.Deserialize<Student>(desJson);
string message = string.Format("ID={0}, Name={1}, Age={2}, Sex={3}", model.ID, model.Name, model.Age, model.Sex);
```

``這是JavaScriptSerializer反序列化的第二個方法(動態)，取資料用(物件["索引"])的方法``

```C#
//Deserialization method 2 (dynamic)
dynamic dyModel = jss.Deserialize<dynamic>(desJson);
string dyMessage = string.Format("ID={0}, Name={1}, Age={2}, Sex={3}", dyModel["ID"], dyModel["Name"], dyModel["Age"], dyModel["Sex"]);
```

