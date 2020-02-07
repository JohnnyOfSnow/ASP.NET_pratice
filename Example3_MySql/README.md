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

Step1: 下載MariaDB並且安裝

**MariaDB是原MySQL團隊製作的非商業使用資料庫**

**MariaDB安裝中會有Modify password for database user 'root'，請務必記住這裡設定的密碼**

**結束上面對root密碼的設定後，會有設定TCP port的內容，預設是3306，請確定這個port有沒有被其他應用程式占用**

``確認port的方法：在命令提示字元視窗，輸入netstat -ano``

**安裝完成後，請在命令提示字元視窗，一一鍵入下列命令，確認有沒有安裝成功**

``1.利用cd指令，將所在位置移動到MariaDB的bin資料夾，例如：cd D:\MariaDB\bin``
``2.輸入mysql -u root -p``
``3.輸入root的密碼(剛剛安裝中輸入的)``
``4.出現Welcome字，表示安裝成功``


Step2 :下載HeidiSQL並且安裝
`HeidiSQL讓我們能夠不透過Command，以GUI介面進行資料庫的操作`




