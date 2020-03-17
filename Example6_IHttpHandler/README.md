# ASP.NET_pratice

***
## Example6: IHttpHandler
## 練習6: 用自訂的類別實作IHttpHandler
***

* **練習內容**
  * 練習實作IHttpHandler，自訂HTTP處理常式，將結果印在count頁面

* **練習的專案架構**
  * `App_Start`
    * RouteConfig.cs(新增 home/count 路由)
  * `Controllers`
  	* HomeController.cs
  * `Model`
    * CountHttpHandler.cs (自訂HTTP處理常式，以同步處理HTTPWeb要求)
  	* CountRouteHandler.cs (處理 home/count 路由的請求)
  * `View`
  	* count.cshtml (目標請求頁面)

* **實作步驟**
  * Step0: 新增count.cshtml
  * Step1: 完成 HomeController.cs 
  * Step2: 完成 RouteConfig.cs 
  * Step3: 完成 CountRouteHandler.cs
  * Step4: 完成 CountHttpHandler.cs

***
### Step0: 新增count.cshtml

***
### Step1: 完成 HomeController.cs

`加入count頁面的ActionResult`

```C#
public ActionResult Count()
{  
    return View();
}
```

***
### Step2: 完成 HomeController.cs

`RouteConfig.cs 新增 home/count 路由`

```C#
public static void RegisterRoutes(RouteCollection routes)
{
    routes.Add(new Route("home/count", new CountRouteHandler()));

    routes.MapRoute(
        name: "Default",
        url: "{controller}/{action}/{id}",
        defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
    );
}
```

>使用routes.Add增加路由，裡面的兩個參數分別為route和IRouteHandler

>route指定home/count，IRouteHandler由於是介面，這裡打算建立CountRouteHandler類別實作它

***
### Step3: 完成 CountRouteHandler.cs

```C#
public class CountRouteHandler : IRouteHandler
{
    public IHttpHandler GetHttpHandler(RequestContext requestContext)
    {
        return new CountHttpHandler(requestContext);
    }
}
```

>實作介面用(:IRouteHandler)，然後要把這個介面裡的方法(GetHttpHandler(RequestContext))寫出來。

>這裡，因為路由到home/count是希望請求count頁面，因此，return的內容即是處理Http常式的IHttpHandler，而我們想要自訂處理Http常式的內容，因此，建立了CountHttpHandler這個類別

***
### Step4: 完成 CountHttpHandler.cs

```C#
public class CountHttpHandler : IHttpHandler
{
    private RequestContext _requestContext;

    public CountHttpHandler(RequestContext requestContext)
    {
        _requestContext = requestContext;
    }
    public void ProcessRequest(HttpContext context)
    {
        gCountRequest++;
        context.Response.ContentType = "text/html";
        context.Response.Write("==================<br/>");
        context.Response.Write("Hello World<br/>");
        context.Response.Write("==================<br/>");
        context.Response.End();
    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}
```
>CountHttpHandler實做IHttpHandler，因此CountHttpHandler : IHttpHandler

>IHttpHandler介面有屬性IsReusable，以及ProcessRequest(HttpContext)方法

>ProcessRequest裡面我們可以HTTP處理常式，這裡打算要印出Hello World