# ASP.NET_pratice

***
## Example2: ASP.NET MVC Receive data by GET or POST
## 練習2:試著用GET或POST的方法，將前端的表單資料送到後端
***

![image](https://github.com/JohnnyOfSnow/ASP.NET_pratice/blob/master/Example2_PassingDataByGETorPOST/image/irn7p-jwnhj.gif)

* **練習內容**
  * 1.練習用GET方法接收前端傳來的表單資料
  * 2.練習用POST方法接收前端傳來的表單資料
  	* a.利用表單控制元件的id取得資料
  	* b.利用表單控制元件的value取得資料


* **練習的專案架構**
  * `Controllers`
  	* HomeController.cs (將資料傳到表單，定義GET,POST如何接收資料的方法)
  * `Model`
  	* Student.cs (定義Student類別，裡面有id,name,score共三個屬性，初始與帶有三個參數的constructor，以及ToStrung方法)
  * `View`
  	* index.cshtml (一開始使用者看到的表單頁面)
  	* Transcripts.cshtml (經由GET POST方法接收資料後，將資料呈現出來的頁面)


* **實作步驟**
  * Step1: 完成Student類別
  * Step2: 完成index.cshtml
  * Step3: 完成Transcripts.cshtml
  * Step4: 完成HomeController.cs
  * Step5: 分別完成(總共三個專案)
    * Step5-a : GET方法實作
    * Step5-b : POST方法實作，並且利用id值接收資料
    * Step5-c : POST方法實作，並且利用Model接收資料


***
### Step1: 完成Student類別(在Model建立Student類別，並完成下列程式碼撰寫)

使用程式語言:C#

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

***
### Step2: 完成index.cshtml(在Views/Home)

使用程式語言:Razor、HTML5

```html
@{
    ViewBag.Title = "Home Page"; // 等同於 <title>Home Page</title>
    Layout = null; // 不使用專案內建的layout，有興趣的人可以不寫這行看看會發生什麼事
}


@model MVCTest_ReceiveDataByGET.Models.Student // 引用專案Model裡的類別

@Styles.Render("~/Content/css")
@Scripts.Render("~/bundles/modernizr")


<!--
 底下建立表單
-->

<form style="margin-left: 10px;" method="get" action="/Home/Transcripts">

    <div class="form-group">
        <label for="stdentId_Label">學號</label>
        <input type="text" class="form-control" id="studentId" name="id"
               placeholder="請輸入學號..." aria-describedby="studentId_Help" value="@Model.id" />
        <small id="studentId_Help" class="font-text text-muted">請輸入學號</small>
    </div>

    <div class="form-group">
        <label for="name_Label">姓名</label>
        <input type="text" class="form-control" id="studentName" name="name"
               placeholder="請輸入姓名..." aria-describedby="name_Help" value="@Model.name" />
        <small id="name_Help" class="font-text text-muted">請輸入姓名</small>

    </div>

    <div class="form-group">
        <label for="score_Label">分數</label>
        <input type="text" class="form-control" id="studentScore" name="score"
               placeholder="請輸入分數..." aria-describedby="score_Help" value="@Model.score" />
        <small id="score_Help" class="font-text text-muted">請輸入分數</small>

    </div>

    <button type="submit" class="btn btn-primary">確定</button>
</form>
```

***
### Step3: 完成Transcripts.cshtml(在Views/Home)

使用程式語言:Razor、HTML5

```html
@{ 
    ViewBag.Title = "Transcripts";
    Layout = null;
}

@model MVCTest_ReceiveDataByPOST.Models.Student // 引用專案Model裡的類別

@Styles.Render("~/Content/css")
@Scripts.Render("~/bundles/modernizr")


<div class="form-group">
    <label>學號</label>
    <label>@Model.id</label>
</div>

<div class="form-group">
    <label>姓名</label>
    <label>@Model.name</label>
</div>

<div class="form-group">
    <label>分數</label>
    <label>@Model.score</label>
</div>
```

***
### Step4: 完成HomeController.cs(/Controllers)

使用程式語言:C#

```C#

public ActionResult Index()
{         
    Student data = new Student("U10715302", "小明", 99);            
    return View(data);              
}        
```

`## 在Index()方法，利用Student類別建立data物件，並且給予初始值，最後將物件傳至index.cshtml`

***
### Step5-a : GET方法實作(/Controllers/HomeController.cs)

使用程式語言:C#

```C#
/**
*  When user submit form's data, the following method is triggered. 
* 
*  Compare the every control element's name property to pass the parameter,
*  So, you should have id, name, score's name property definition (index.cshtml).
* 
*/
public ActionResult Transcripts(string id, string name, int score)
{
    Student data = new Student(id, name, score);
    return View(data);
}    
```

`注意這裡的(string id, string name, int score) 三個參數要有對應的表單控制元件name值`


***
### Step5-b : POST方法實作，並且利用id值接收資料(/Controllers/HomeController.cs)

使用程式語言:C#

```C#
/**
* 
*  [HttpPost] should be put in methode header's upper that it talks MVC we use POST to receive data.
* 
*  Parameter "FormCollection post" can let us use id property which is defined in form. 
* 
*/   
[HttpPost]
public ActionResult Transcripts(FormCollection post)
{
    string id = post["studentId"]; // Had defined an id "studentId" in index.cshtml.
    string name = post["name"]; // Had defined an id "name" in index.cshtml.
    int score = Convert.ToInt32(post["score"]); // string to integer
    Student data = new Student(id, name, score);
    return View(data);
}    
```

`因為用POST方法，所以在方法的上面標註[HttpPost]`

`這裡我們用控制元件的id傳資料，所以id,name,score三個值要有對應的控制元件id`

***
### Step5-c : POST方法實作，並且利用Model接收資料(/Controllers/HomeController.cs)

使用程式語言:C#

```C#

/**
 *  To receive data by Model, frontend's control element of value should have @Model.(...). 
 * 
 *  If you use POST method passing data, you should add [HttpPost] in the method header's upper
 */

[HttpPost]
public ActionResult Transcripts(Student model)
{
    string id = model.id; // frontend control element  <input type="text"value="@Model.id" /> 
    string name = model.name; // frontend control element <input type="text"value="@Model.name" /> 
    int score = model.score; // frontend control element  <input type="text"value="@Model.score" /> 
    Student data = new Student(id, name, score);
    return View(data); // Go to Transcripts.cshtml
}     
```

`因為用POST方法，所以在方法的上面標註[HttpPost]`

`這裡我們用Model接收資料,前端的控制元件value需要有 @model.id, @model.name, @model.score對應`

