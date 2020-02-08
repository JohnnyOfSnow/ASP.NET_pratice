using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace objectOrientedPratice
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            message.Text += "一般方法示範區<br>";
            NoStaticClass noStaticClass = new NoStaticClass(); // Create a object by NoStaticClass.
            noStaticClass.ID = 1; // Declare noStaticClass's property(ID) to 1.
            int NoStaticClassID = noStaticClass.ID;
            message.Text += NoStaticClassID + "<br>";
            noStaticClass.Method();
            message.Text += noStaticClass.ID + "<br><hr>";

            message.Text += "類別方法示範區<br>";
            StaticClass.ID = 2; // Static class don't instantiate an object.
            int StaticClassID = StaticClass.ID;
            message.Text += StaticClassID + "<br>";
            StaticClass.Method(); // Static class's method can directly invoke.
            message.Text += StaticClass.ID + "<br><hr>";

            message.Text += "建構式方法示範區<br>";
            ConstructorClass constructorClass = new ConstructorClass(3);
            int constructorClassID = constructorClass.ID;
            message.Text += constructorClassID + "<br><hr>";

            message.Text += "父類別(AMath)方法示範區<br>";
            AMath aMath = new AMath();
            int a = 2;
            int b = 3;
            int aMathMax = aMath.getMax(a, b);
            message.Text += aMathMax + "<br><tr>";

            // Overloading test program
            message.Text += "子類別(BMath)方法示範區<br>";
            BMath bMath = new BMath();
            int c = 2;
            int d = 3;
            int[] f = {1,3,5,7,9};
            int bMathMax_a = bMath.getMax(c, d);
            int bMathMax_b = bMath.getMax(f);
            message.Text += "父類別定義的getMax方法，丟入兩整數<br>";
            message.Text += bMathMax_a + "<br><hr>";
            message.Text += "子類別定義的getMax方法，丟入一整數陣列<br>";
            message.Text += bMathMax_b + "<br><hr>";



        }
    }
}