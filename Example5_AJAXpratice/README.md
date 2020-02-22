# ASP.NET_pratice

***
## Example5: Ajax(Asynchronous JavaScript and XML) 
## 練習5: 練習用Ajax，回應使用者的操作
***

![image](https://github.com/JohnnyOfSnow/ASP.NET_pratice/blob/master/Example5_AJAXpratice/image/ajax_ex.gif)

* **練習內容**
  * 讀取mysql資料庫的資料，將之放在頁面上

* **練習的專案架構**
  * `Controllers`
  	* HomeController.cs (接受前端的POST要求，呼叫對應的Model將資料帶回前端)
  * `Model`
    * MyDatabase.cs (定義連接、讀取資料庫的方法)
  	* City.cs (定義City類別)
  	* Village.cs (定義Village類別)
  * `View`
  	* index.cshtml (給使用者看的網頁頁面)

* **實作步驟**
  * Step0: 事先在資料庫建立City與Village的Table，並把資料加入各Table
  * Step1: 完成City、Village類別
  * Step2: 完成MyDatabase類別
  * Step3: 完成HomeController.cs
  * Step4: 完成index.cshtml

***
### Step0: 事先在資料庫建立City與Village的Table，並把資料加入各Table

加入資料的方法，請參考[練習連接資料庫，利用程式將資料加入資料庫](https://github.com/JohnnyOfSnow/ASP.NET_pratice/tree/master/Example3_MySql)

***
### Step1: 完成City、Village類別(在Model建立City、Village類別，並完成下列程式碼撰寫)

使用程式語言:C#

**依照資料庫中City、Village兩Table，將各自的row成員定義成類別的屬性**

```C#
public class City
{
    public string Id { get; set; }
    public string CityName { get; set; }

    public City()
    {
        Id = string.Empty;
        CityName = string.Empty;
    }
}

```

```C#
public class Village
{
    public string CityId { get; set; }
    public string CityName { get; set; }
    public string VillageId { get; set; }
    public string VillageName { get; set; }

    public Village()
    {
        CityId = string.Empty;
        CityName = string.Empty;
        VillageId = string.Empty;
        VillageName = string.Empty;
    }
}
```

***
### Step2: 完成MyDatabase類別(在Model建立MyDatabase類別，並完成下列程式碼撰寫)

使用程式語言:C#

**MyDatabase類別要做連接資料庫與讀取資料庫兩件事，因此我們可以定義出四個方法**

``1. public void Connect() 帶入連線參數、確認資料庫是否已連線、連接資料庫``

``2. public void Disconnect() 斷掉與資料庫的連線``

``3. public List<City> GetCityList() 讀取city這個表的資料後，將結果以List<City>的型態回傳``

``4. public List<Village> GetVillageList(string id) 讀取village這個表的資料後，將結果以List<Village>的型態回傳``

```C#
public class MyDatabase
{
    public string connectString { get; set; }

    public MySqlConnection conn { get; set; }
    public List<City> GetCityList()
    {
        try
        {
            Connect();                   
            string sql = @" SELECT `Id`, `CityName` FROM `city`";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            List<City> list = new List<City>();

            using (MySqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    City city = new City();
                    city.Id = dr["Id"].ToString();
                    city.CityName = dr["CityName"].ToString();
                    list.Add(city);
                }
            }
            return list;
            
        }catch(Exception ex)
        {
            string error = ex.ToString();
            return null;
        }
        finally
        {
            Disconnect();

        }
    }

    public List<Village> GetVillageList(string id)
    {
        try
        {
            Connect();
            string sql = @" SELECT `CityId`,`VillageId`, `VillageName` FROM `Village`";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            List<Village> list = new List<Village>();

            int villageCount = 0;

            using (MySqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    if(id.Equals(dr["CityId"].ToString()))
                    {
                        Village data = new Village();
                        data.VillageId = dr["VillageId"].ToString();
                        data.VillageName = dr["VillageName"].ToString();
                        list.Add(data);
                    }       
                }
            }
            return list;

        }catch(Exception ex)
        {
            string error = ex.ToString();
            return null;
        }
        finally
        {
            Disconnect();
        }
    }

    public void Connect()
    {
        connectString = "server=127.0.0.1;port=3306;user id=root;password=****;database=mvctest;charset=utf8;";

        conn = new MySqlConnection();

        conn.ConnectionString = connectString;
        if (conn.State != ConnectionState.Open)
            conn.Open();
    }

    public void Disconnect()
    {
        conn.Close();
    }
}
```

***
### Step3: 完成HomeController.cs

使用程式語言:C#

**我們打算在頁面載入完畢時，縣市資料就要在下拉式選單(select)之中，然後選中了一筆下拉式選單的值時，隔壁的下拉式選單(鄉鎮市)就要出現該縣市有的鄉鎮市**

``public ActionResult Index() 建立MyDatabase物件，呼叫GetCityList()，使用ViewBag將資料帶到前端``

``public ActionResult Village(string id="") 呼叫GetVillageList(string id)，依照參數id取得對應的鄉鎮市資料，然後將資料打包成JSON傳回前端``

``上述會將資料打包成JSON傳回前端，是因為前端頁面我們要用JQuery Ajax的方式請求資料。``

``public ActionResult Village(string id="") 這個方法是接受前端POST的請求，記得在這個方法的上面一行加上[HttpPost]``

```C#
public class HomeController : Controller
{

    MyDatabase db = new MyDatabase();
    public ActionResult Index()
    {
        List<City> cityList = db.GetCityList();

        ViewBag.CityList = cityList;
        return View();
    } 

    [HttpPost]
    public ActionResult Village(string id="")
    {
        List<Village> villageList = db.GetVillageList(id);
        string result = "";
        if(villageList == null)
        {
            return Json(result);
        }
        else
        {
            result = JsonConvert.SerializeObject(villageList);
            return Json(result);
        }
    }
}
```

***
### Step4: 完成index.cshtml

使用程式語言:HTML5、Razor、Javascript

**刻出使用者看到的網頁頁面，並在城市的下拉式選單選中任一值時，透過JQuery Ajax發出POST請求，得到對應的鄉鎮式資料後，加入鄉鎮市的下拉式選單之中**

**這裡省略一部分html碼，只針對下拉式選單的部分說明**

```html
<div class="form-group">
	<label for="address">地址</label>
	<select id="city" name="city">
	    <option value="">全部</option>
	    @for(int i = 0; i < cityList.Count; i++)
	    {
	        <option value="@cityList[i].Id">@cityList[i].CityName</option>
	    }
	</select>
	<select id="village" name="village">
	    <option value="">請選擇縣市</option>
	</select>
	<input type="text" class="form-control" id="address" name="address" placeholder="請輸入地址" value="" />
</div>
```

``在select標籤之中，option就是下拉式選單的內容，所以，option是我們要加入資料的地方``

``要在option加入資料需要設定value，因此，我們可以利用資料庫的表中定義的id值作為value(@cityList[i].Id)，而名稱則是(@cityList[i].CityName)，利用for迴圈依序將資料一筆筆加入。``

**接著，我們要處理一選到某城市時，要有對應的鄉鎮市下拉式選單值產生**

```java
<script src="~/Scripts/jquery-3.4.1.min.js"></script>
<script>
    $("#city").change(function(){
        var value = $("#city").val();
        console.log(city);
        $.ajax({
            type: "Post",
            url: "../Home/Village?id=" + value,
            data: '{}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            success: function (data) {
                $("#village").empty();
                if (data == "") {
                    $("#village").append("<option value=''>請選擇縣市</option>");
                } else {
                    var json = JSON.parse(data);
                    $("#village").append("<option value=''>請選擇鄉鎮市</option>")
                    for (i = 0; i < json.length; i++){
                        $("#village").append("<option value = '" + json[i].VillageId + "'>" + json[i].VillageName + "</option>");
                    }
                }
            },
            failure: function (errorMsg) {
                $("#village").empty();
                $("#village").append("<option value=''>請選擇縣市</option>");
            }
        })
    });
</script>
```

**一一講解上述程式碼**

``使用Jquery記得要引用，而且要確定引用的Jquery之js檔路徑是否正確，然後JQuery程式碼前後用script標籤框起來``

``Jquery用$選取元件，#city是指id為city的元件，當它改變值(change)的時候，將它的值(.val())儲存起來``

```java
<script src="~/Scripts/jquery-3.4.1.min.js"></script>
<script>
$("#city").change(function(){
    var value = $("#city").val();
    console.log(city);
    // write your ajax request code
});
</script>
```

``$.ajax({}) 使用ajax請求``

``請求方式POST，呼叫的位置在../Home/Village?id= ，後面的value是城市的id，我們可以將它帶到後端``

``contentType是指發送到server的編碼，因為資料庫我們用utf-8``

``dataType是指server回傳的資料型態，這裡我們選json``

``async: false，因為我們要向server端請求資料後才繼續執行後續程式碼，而ajax的async預設為true，意思是它會在等待server回傳結果時，另外執行ajax的其他區塊，為了避免這個情況發生，於是我們將async設為false。``

``success: failure: 各自定義成功或失敗請求要做的事``

```java
$.ajax({
    type: "Post",
    url: "../Home/Village?id=" + value,
    data: '{}',
    contentType: "application/json; charset=utf-8",
    dataType: "json",
    async: false,
    success: // write some code when ajax request success.
    failure: // write some code when ajax request fail.
})
```

``server成功回傳有兩種情況，空的或是帶有資料``

``有資料的話，利用JSON.parse(data)，把一個JSON字串轉換成 JavaScript的物件``

``轉換成物件後，我們可以用 物件[索引值].索引名``


```java
success: function (data) {
    $("#village").empty();
    if (data == "") {
        $("#village").append("<option value=''>請選擇縣市</option>");
    } else {
        var json = JSON.parse(data);
        $("#village").append("<option value=''>請選擇鄉鎮市</option>")
        for (i = 0; i < json.length; i++){
            $("#village").append("<option value = '" + json[i].VillageId + "'>" + json[i].VillageName + "</option>");
        }
    }
},
failure: function (errorMsg) {
    $("#village").empty();
    $("#village").append("<option value=''>請選擇縣市</option>");
}
```