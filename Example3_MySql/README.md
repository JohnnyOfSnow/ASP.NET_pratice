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

★MariaDB是原MySQL團隊製作的非商業使用資料庫。
★MariaDB安裝中會有Modify password for database user 'root'，請務必記住這裡設定的密碼。
★結束上面對root密碼的設定後，會有設定TCP port的內容，預設是3306，請確定這個port有沒有被其他應用程式占用。

``確認port的方法：在命令提示字元視窗，輸入netstat -ano``

**安裝完成後，請在命令提示字元視窗，一一鍵入下列命令，確認有沒有安裝成功**

``1.利用cd指令，將所在位置移動到MariaDB的bin資料夾，例如：cd D:\MariaDB\bin``

``2.輸入mysql -u root -p``

``3.輸入root的密碼(剛剛安裝中輸入的)``

``4.出現Welcome字，表示安裝成功``


#### Step2: 下載HeidiSQL並且安裝

★HeidiSQL讓我們能夠不透過Command，以GUI介面操作資料庫。

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

#### Step3: Visual Studio 2019 設定

**★1.下載Visual Studio 2019缺少的組件**

★因為連接資料庫需要有對應的組件，而Visual Studio 2019裡面還沒有，故得先下載並安裝下面提到的兩個組件

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

 

