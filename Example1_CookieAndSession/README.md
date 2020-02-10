# ASP.NET_pratice

***
## Example1: Use Session or Cookie to save the user's data.
## 練習1: 練習用Session Cookie留存使用者造訪網站時的資料
***

![image](https://github.com/JohnnyOfSnow/ASP.NET_pratice/blob/master/Example1_CookieAndSession/image/eh44l-tujj0.gif)

* **練習內容**
  * 1.練習用Session留存使用者造訪網站時的資料
  * 2.練習用Cookie留存使用者造訪網站時的資料


* **練習的專案架構**

* `Session`
    * index.aspx (給使用者輸入年齡並送出的頁面)
    * index.aspx.cs (要寫建立Session 方法，然後將結果用Response寫出)

* `Cookie`
  * `Page1`
  	* page1.aspx (給使用者看的登入畫面)
    * page1.aspx.cs (要寫建立Cookie 方法，並跳轉到Page2)
  * `Page2(顯示有沒有登入的畫面)`
  	* page2.aspx (顯示有沒有登入的畫面)
    * page2.aspx.cs (將Cookie的內容印出來，還要能跳轉到Page1)

***
### 1.練習用Session留存使用者造訪網站時的資料
***

-->index.aspx

使用程式語言:HTML5

```html
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label Text="How old are you?" runat="server"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID="AgeTextBox" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="Submit"  text="submit" OnClick="Submit_Click" runat="server" />
            <asp:Button ID="ShowButton" text="show" OnClick="ShowButoon_Click" runat="server" />
        </div>
    </form>
</body>

```

-->index.aspx.cs

使用程式語言:C#

```C#
public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void Submit_Click(object sender, EventArgs args)
    {
        Session["age"] = AgeTextBox.Text;
        AgeTextBox.Text = "";
    }

    protected void ShowButoon_Click(object sender, EventArgs args)
    {
        if(Session["age"] != null) // Session exist
        {
            Response.Write("You are " + Session["age"] + "years old.<br/>");
            Response.Write("Session ID: " + Session.SessionID.ToString() + "<br/>");
            Response.Write("Timeout: " + Session.Timeout.ToString() + "<br/>");
        }
        else
        {
            Response.Write("Session not exist!");
        }
    }
}
```

`Session有時間限制，可以透過Session.Timeout.ToString() 印出時間`

`設定Session時間限制，可以在Web.config檔案中加入下面的內容`

```html
<configuration>
  <system.web>
    <sessionState timeout="2"></sessionState>
  </system.web>
</configuration>
```

`timeout="2" 表示兩分鐘`


***
### 2.練習用Cookie留存使用者造訪網站時的資料
***

page1.aspx(登入畫面)

使用程式語言:HTML5

```html
<div class="wrapper">
    <div class="content">
        <form id="form1" runat="server">
            <div>
                <asp:Label ID="Login_Hint" Text="Please enter your account and password" class="label_style" runat="server"></asp:Label>
            </div>
            <div>
                <asp:Label ID="Account_Hint" Text="Name: " runat="server"></asp:Label>
                <br />
                <asp:TextBox ID="AccountText" class="textbox_style" type="text" placeholder="your name..." runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="Password_Hint" Text="Password: " runat="server"></asp:Label>
                <br />
                <asp:TextBox ID="PasswordText" class="textbox_style" type="text" placeholder="your account..." runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="submit" Text="submit" class="button_style loginBtn" OnClick="SubmitButton_Click" runat="server" />
                <asp:Button ID="Enter_HomePage" Text="Enter HomePage" class="button_style EnterHomePageBtn" OnClick="EnterHomePageButton_Click" runat="server" />
            </div>
        </form>
    </div>
</div>
```

page2.aspx(顯示有沒有登入的畫面)

使用程式語言:HTML5

```html
<div class="wrapper">
    <div class="content">
         <form id="form2" runat="server">
            <div>
                 <asp:Label ID="Welcome_Hint" class="label_style" runat="server"></asp:Label>
            </div>
            <div>
                 <asp:Button ID="logout_Btn" Text="logout" class="button_style logoutBtn" OnClick="LogoutButton_Click" runat="server" />
            </div>
        </form>
    </div>
</div>
```

page1.aspx.cs(要寫建立Cookie 方法，並跳轉到Page2)

使用程式語言:C#

```C#
 public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {    
    }

    protected void SubmitButton_Click(object sender, EventArgs args)
    {
        // Set Cookie's data.
        Response.Cookies["userinfo"]["account"] = Server.UrlEncode(AccountText.Text);
        Response.Cookies["userinfo"]["password"] = PasswordText.Text;
        Response.Cookies["userinfo"].Expires = DateTime.Now.AddDays(1);

        Response.Redirect("page2.aspx"); // jump to home page.

    }

    protected void EnterHomePageButton_Click(object sender, EventArgs args)
    {
        Response.Redirect("page2.aspx"); // jump to home page.
    }
}
```

page2.aspx.cs (將Cookie的內容印出來，還要能跳轉到Page1)

使用程式語言:C#

```C#
protected void Page_Load(object sender, EventArgs e)
{
    LoginCheck();
}

private void LoginCheck()
{
    if (Request.Cookies["userinfo"] != null) // Cookies is exist.
    {
        if(Request.Cookies["userinfo"]["account"] == "")
        {
            Welcome_Hint.Text = "You don't login !!!";
            logout_Btn.Text = "Return to login page.";
        }
        else
        {
            Welcome_Hint.Text = "Welcome " + Server.UrlDecode(Request.Cookies["userinfo"]["account"]) + " !!!";
        }
        
    }
    else
    {
        Welcome_Hint.Text = "You don't login !!!";
        logout_Btn.Text = "Return to login page.";
    }
}

protected void LogoutButton_Click(object sender, EventArgs args)
{
    Response.Cookies["userinfo"].Expires = DateTime.Now.AddDays(-1);
    Response.Redirect("page1.aspx"); // jump to login page.
}
```