# ASP.NET_pratice

***
## Example3: MySQL database(use MariaDB)
## 練習3: 試著用支援MySQL很高的MariaDB，寫出能讀資料庫或寫入資料庫的程式
***

* **練習內容**
  * 1.建立能夠撰寫資料庫程式的環境
  * 2.練習連接資料庫，利用程式將資料加入資料庫
  * 3.練習連接資料庫，利用程式讀取資料庫裡的資料


***
### 1.建立能夠撰寫資料庫程式的環境
***

#### Step1: 下載MariaDB並且安裝

-->MariaDB是原MySQL團隊製作的非商業使用資料庫。

-->MariaDB安裝中會有Modify password for database user 'root'，請務必記住這裡設定的密碼。

-->結束上面對root密碼的設定後，會有設定TCP port的內容，預設是3306，請確定這個port有沒有被其他應用程式占用。

``確認port的方法：在命令提示字元視窗，輸入netstat -ano``

**安裝完成後，請在命令提示字元視窗，一一鍵入下列命令，確認有沒有安裝成功**

``1.利用cd指令，將所在位置移動到MariaDB的bin資料夾，例如：cd D:\MariaDB\bin``

``2.輸入mysql -u root -p``

``3.輸入root的密碼(剛剛安裝中輸入的)``

``4.出現Welcome字，表示安裝成功``

***
#### Step2: 下載HeidiSQL並且安裝
***

-->HeidiSQL讓我們能夠不透過Command，以GUI介面操作資料庫。

**★1.連線**

![image](https://github.com/JohnnyOfSnow/ASP.NET_pratice/blob/master/Example3_MySql/image/HeidiSQL_1.jpg)

``輸入身分、身分密碼以及port之後，按下打開``

**★2.建立資料庫**

![image](https://github.com/JohnnyOfSnow/ASP.NET_pratice/blob/master/Example3_MySql/image/HeidiSQL_2.jpg)

![image](https://github.com/JohnnyOfSnow/ASP.NET_pratice/blob/master/Example3_MySql/image/HeidiSQL_3.jpg)

**★3.建立欄列**

![image](https://github.com/JohnnyOfSnow/ASP.NET_pratice/blob/master/Example3_MySql/image/HeidiSQL_4.jpg)

![image](https://github.com/JohnnyOfSnow/ASP.NET_pratice/blob/master/Example3_MySql/image/HeidiSQL_5.jpg)

``以上我們完成在MariaDB建立名為mvctest的資料庫，裡面有名為city的table，table內每一筆資料有id,City兩個值``

***
#### Step3: Visual Studio 2019 設定
***

**★1.下載Visual Studio 2019缺少的組件**

-->因為連接資料庫需要有對應的組件，而Visual Studio 2019裡面還沒有，故得先下載並安裝下面提到的兩個組件

``搜尋mysql for visual studio 2019，下載mysql-for-visualstudio-1.2.9.msi``

``搜尋mysql connector，下載 mysql-connector-net-8.0.19.msi``

**★2.專案加入Mysql.data的參照**

![image](https://github.com/JohnnyOfSnow/ASP.NET_pratice/blob/master/Example3_MySql/image/VS2019SQL.jpg)

``沒有裝剛剛說的那兩個組件，這裡就會找不到Mysql.data``

**★3.專案要有使用MySQL的using 陳述式**

HomeController.cs

使用程式語言:C#

```C#
using MySql.Data.MySqlClient; 
using System.Data;
```

``至此，這個專案便完成撰寫資料庫程式的環境，緊接著，我們要練習用程式的方式將資料寫進資料庫中``

***
###2.練習連接資料庫，利用程式將資料加入資料庫
*** 

HomeController.cs

使用程式語言:C#

```C#
public class HomeController : Controller
{
    /**
     *  Though it is public on website, so I have to eliminate the password.
     *  
     *  If you try to build this project, you should give the password value that you set in database. 
     * 
     */
    string connectString = "server=127.0.0.1;port=3306;user id=root;" +
                            "password=****;database=mvctest;charset=utf8;";
    MySqlConnection conn = new MySqlConnection();
    public ActionResult Index()
    {
        conn.ConnectionString = connectString;
        if(conn.State != ConnectionState.Open) // If database is connecting, you shouldn't connect it.
            conn.Open();
        string sql = @"INSERT INTO `city` (`Id`, `City`) VALUES
                       ('0', '基隆市'),
                       ('1', '台北市'),
                       ('2', '新北市'),
                       ('3', '桃園市'),
                       ('4', '新竹市'),
                       ('5', '新竹縣'),
                       ('6', '宜蘭縣'),
                       ('7', '苗栗縣'),
                       ('8', '台中市'),
                       ('9', '彰化縣'),
                       ('A', '南投縣'),
                       ('B', '雲林縣'),
                       ('C', '嘉義市'),
                       ('D', '嘉義縣'),
                       ('E', '台南市'),
                       ('F', '高雄市'),
                       ('G', '屏東縣'),
                       ('H', '澎湖縣'),
                       ('I', '花蓮縣'),
                       ('J', '台東縣'),
                       ('K', '金門縣'),
                       ('L', '連江縣');
";
        MySqlCommand cmd = new MySqlCommand(sql, conn);

        /**
         *  Insert, Revise, Delete data in database,
         *  when it is fail the "ExecuteNonQuery()" will return 0.
         */
        int index = cmd.ExecuteNonQuery();  
        bool success = false;
        if (index > 0)
            success = true;
        else
            success = false;
        ViewBag.Success = success; // Show the result in index.cshtml.
        conn.Clone(); // Close the database connection.
        return View();
    }

}
```

**一一講解上述程式碼**

``變數connectString傳入連接資料庫時需要的內容，server位置(這裡用localhost)、port號碼、使用者(這裡用root)、使用者密碼(root密碼)、資料庫名稱、字元``

```C#
string connectString = "server=127.0.0.1;port=3306;user id=root;" +
                            "password=****;database=mvctest;charset=utf8;";
MySqlConnection conn = new MySqlConnection();
```

``將connectString傳給conn準備連接資料庫，下面if判斷式，要是資料庫已經連接，就不可以連接``

```C#
conn.ConnectionString = connectString;
if(conn.State != ConnectionState.Open) 
  conn.Open();
```

``使用sql加入資料的語法，INSERT INTO `table名稱` (`欄位名`, `欄位名`) VALUES``

``每一筆資料依照(`欄位名`, `欄位名`)的格式，例如：('0', '基隆市')，多筆資料用,隔開，最後一筆資料後方分號``

``最後將這些資料與連線方式給MySqlCommand產生的物件cmd處理``

```C#
string sql = @"INSERT INTO `city` (`Id`, `City`) VALUES
                       ('0', '基隆市'),
                       ('K', '金門縣'),
                       ('L', '連江縣');
";
MySqlCommand cmd = new MySqlCommand(sql, conn);
```

``這一塊是檢查資料有沒有寫進資料庫，如果失敗，ExecuteNonQuery()會回傳0，因而在底下的if判斷式，success會被設為false``

``ViewBag.Success = success; 可以用ViewBag的方法，將success的值帶到前端畫面顯示``

```C#
int index = cmd.ExecuteNonQuery();  
    bool success = false;
    if (index > 0)
        success = true;
    else
        success = false;
    ViewBag.Success = success; // Show the result in index.cshtml.
    conn.Clone(); // Close the database connection.
    return View();

```
