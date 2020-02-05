# ASP.NET_pratice

***
## Example1: ASP.NET MVC Receive data by GET or POST
`練習1:試著用GET或POST的方法，將前端的表單資料送到後端`

* Example1's content
  * 1.練習用GET方法接收前端傳來的表單資料
  * 2.練習用POST方法接收前端傳來的表單資料
  	* a.利用表單控制元件的id取得資料
  	* b.利用表單控制元件的value取得資料

* Example1's project structure
  * Controllers
  	* HomeController.cs (將資料傳到表單，定義GET,POST如何接收資料的方法)
  * Model
  	* Student.cs (定義Student類別，裡面有id,name,score共三個屬性，初始與帶有三個參數的constructor，以及ToStrung方法)
  * View
  	* index.cshtml (一開始使用者看到的表單頁面)
  	* Transcripts.cshtml (經由GET POST方法接收資料後，將資料呈現出來的頁面)

