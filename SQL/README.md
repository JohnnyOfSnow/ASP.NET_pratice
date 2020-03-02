# ASP.NET_pratice

***
## SQL
## SQL: 練習用命令提示字元，熟悉SQL指令
***

* **練習內容**
  * 1.什麼是資料庫
  * 2.什麼是關聯資料庫
  * 3.什麼是SQL，和資料庫的關係是什麼
  * 4.練習用SQL指令操作資料庫
    * 4-a 登入
    * 4-b 查詢所有的資料庫、表、列
    * 4-c 查詢特定的資料庫有哪些表，特定的表有哪些列
    * 4-d 顯示特定
    * 4-e 登出

***
### 1.什麼是資料庫
***

**資料庫(Database)**就像是電腦世界的倉庫，可以存放檔案與資料的地方，使用者可以對它做新增、查詢、擷取以及刪除等動作。

有一天，資料愈來愈多讓資料庫難以直覺控管時，人們開發了**資料庫管理系統**來解決這個問題。

資料庫管理系統(Database Management System)，根據人們對資料庫的要求不同，各自擁有不同的分類方式，像是支援的電腦類型不同可分為伺服器群集、行動電話，又或者是查詢的語言不同可分為SQL、XQuery。


***
### 2.什麼是關聯資料庫
***

關聯資料庫(Relational Database, RDB)建立於關聯模型，關聯模型講的是實體(Entities)與關聯性(Relationships)，例如西瓜和香蕉擁有水果的關聯性，將這些生活看的見的物品轉換成電腦世界的資料，然後存放的資料庫就稱為關聯資料庫。

實體(Entities)就是生活中我們對物品的稱呼，例如：西瓜、時鐘，實體型態(Entity Type)就是對實體的總稱，例如：產品、學號、地方。

實體型態也稱為實體實例(Entity Instance)，將這些實體實例集合起來，就稱為實體集合(Entity Set)，也就是一個關聯表(Relation Table)。

存放這些關聯表的資料庫就是關聯式資料庫。

![image](https://github.com/JohnnyOfSnow/ASP.NET_pratice/blob/master/SQL/image/RDB.jpg)

***

我們知道要建立關聯資料庫，需要有關聯模型，而關聯模型可以透過實體關聯圖(Entity-Relationship Diagram, ERD)表達，底下我們試著畫看看。

![image](https://github.com/JohnnyOfSnow/ASP.NET_pratice/blob/master/SQL/image/ERD.jpg)

關聯表的每一行(column)稱為屬性(Attribute)，每一列(row)稱為值組(Tuple)。

用橢圓形表示出現在關聯表的屬性，若是屬性的值不只一個(例如：地址有縣市名、鄉鎮市名、路名、里名...)就用雙橢圓，用長方形表示關聯表的名字，

``之後再補概念資料庫設計（Conceptual Database Design）、邏輯資料庫設計（Logical Database Design）實體資料庫設計（Physical Database Design）的步驟與圖示``

***
### 3.什麼是SQL，和資料庫的關係是什麼
***

SQL用來管理關聯資料庫，因此，SQL可以對資料庫進行資料插入、查詢、更新和刪除，資料庫模式建立和修改，以及資料存取控制，因此，SQL有它規定的指令集，像是SELECT, DELETE, WHERE等，實務上，我們用來安插在程式碼或是在命令提示字元下達指令，對資料庫進行操作。

***
### 4.練習用SQL指令操作資料庫
***

``這裡用的資料庫是MariaDB，不用MS-SQL的原因是``

``操作介面使用命令提示字元``

``指令不分英文大小寫``


**4-a 登入**

指令：mysql -u 登入者 -p

``注意命令提示字元當下的路徑，要在資料庫的安裝位置下的bin資料夾``

``剛開始練習，-u 一定是root，後續可增加別的使用者``

``成功之後會看到password: ，一開始使用的人，請輸入安裝時資料庫時設置的密碼，否則請依剛剛鍵入的使用者名稱輸入對應的密碼``


**4-b 查詢所有的資料庫、表、行**

指令：show databases/tables;

指令：show columns from 表名稱;

``查資料庫就寫databases，查表就寫tables，上面的/只是示意可以填得值，後面記得要分號``

``沒有show columns;``


**4-c 查詢特定的資料庫有哪些表，特定的表有哪些行**

指令：show * from 資料庫名稱;

指令：show * from 表名稱;

``*表示全部，from表示來自，後面接資料庫名稱就是指底下的所有表，同理，後面接表名稱就是指底下的所有行``

**4-d 顯示特定**

指令：select 行名稱 from 表名稱;

``只顯示指定的表中的某一行``

**4-e 登出**

指令：exit

``使用完後要記得登出資料庫，以防他人盜用``