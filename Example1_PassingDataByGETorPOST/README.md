# ASP.NET_pratice

***
## 學習目錄
* Example1: ASP.NET MVC Receive data by GET or POST
* 

***
## Example1: ASP.NET MVC Receive data by GET or POST
`## 練習1:試著用GET或POST的方法，將前端的表單資料送到後端`

* **Example1's content**
  * 1.練習用GET方法接收前端傳來的表單資料
  * 2.練習用POST方法接收前端傳來的表單資料
  	* a.利用表單控制元件的id取得資料
  	* b.利用表單控制元件的value取得資料

* **Example1's project structure**
  * Controllers
  	* HomeController.cs (將資料傳到表單，定義GET,POST如何接收資料的方法)
  * Model
  	* Student.cs (定義Student類別，裡面有id,name,score共三個屬性，初始與帶有三個參數的constructor，以及ToStrung方法)
  * View
  	* index.cshtml (一開始使用者看到的表單頁面)
  	* Transcripts.cshtml (經由GET POST方法接收資料後，將資料呈現出來的頁面)

* **Example1 實作**

1.在Model資料夾建立Student類別並且完成它
`## 使用程式語言:C#`

```C#
	public class Student
    {
        public string id { get; set; }
        public string name { get; set; }
        public int score { get; set; }

        public Student()
        {
            id = string.Empty;
            name = string.Empty;
            score = 0;
        }

        public Student(string _id, string _name, int _score)
        {
            id = _id;
            name = _name;
            score = _score;
        }

        public override string ToString()
        {
            return $"學號: " + id + "姓名: " + name + "分數: " + score;
        }
    }
```
2.完成在View資料夾的index.cshtml
`## 使用程式語言:Razor、HTML5`

```html
@{
    ViewBag.Title = "Home Page";
    Layout = null;
}


@model MVCTest_ReceiveDataByGET.Models.Student

@Styles.Render("~/Content/css")
@Scripts.Render("~/bundles/modernizr")

    <form style="margin-left: 10px;" method="get" action="/Home/Transcripts">
        <div class="form-group">
            <label for="stdentId_Label">學號</label>

            <!--
                Need to have a control element that it's name property defined as id.
            -->
            <input type="text" class="form-control" id="studentId" name="id"
                   placeholder="請輸入學號..." aria-describedby="studentId_Help" value="@Model.id" />
            <small id="studentId_Help" class="font-text text-muted">請輸入學號</small>

        </div>

        <div class="form-group">
            <label for="name_Label">姓名</label>

            <!--
                Need to have a control element that it's name property defined as name.
            -->
            <input type="text" class="form-control" id="studentName" name="name"
                   placeholder="請輸入姓名..." aria-describedby="name_Help" value="@Model.name" />
            <small id="name_Help" class="font-text text-muted">請輸入姓名</small>

        </div>

        <div class="form-group">
            <label for="score_Label">分數</label>

            <!--
                Need to have a control element that it's name property defined as score.
            -->
            <input type="text" class="form-control" id="studentScore" name="score"
                   placeholder="請輸入分數..." aria-describedby="score_Help" value="@Model.score" />
            <small id="score_Help" class="font-text text-muted">請輸入分數</small>

        </div>

        <!--
            Click submit button will invoke "Transcripts" method defined in HomeController.cs.
        -->
        <button type="submit" class="btn btn-primary">確定</button>

    </form>



```
