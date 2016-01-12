using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using System.Runtime.InteropServices;
public class TSCLIB_DLL
{
    [DllImport("TSCLIB.dll", EntryPoint = "about")]
    public static extern int about();

    [DllImport("TSCLIB.dll", EntryPoint = "openport")]
    public static extern int openport(string printername);

    [DllImport("TSCLIB.dll", EntryPoint = "barcode")]
    public static extern int barcode(string x, string y, string type,
                string height, string readable, string rotation,
                string narrow, string wide, string code);

    [DllImport("TSCLIB.dll", EntryPoint = "clearbuffer")]
    public static extern int clearbuffer();

    [DllImport("TSCLIB.dll", EntryPoint = "closeport")]
    public static extern int closeport();

    [DllImport("TSCLIB.dll", EntryPoint = "downloadpcx")]
    public static extern int downloadpcx(string filename, string image_name);

    [DllImport("TSCLIB.dll", EntryPoint = "formfeed")]
    public static extern int formfeed();

    [DllImport("TSCLIB.dll", EntryPoint = "nobackfeed")]
    public static extern int nobackfeed();

    [DllImport("TSCLIB.dll", EntryPoint = "printerfont")]
    public static extern int printerfont(string x, string y, string fonttype,
                    string rotation, string xmul, string ymul,
                    string text);

    [DllImport("TSCLIB.dll", EntryPoint = "printlabel")]
    public static extern int printlabel(string set, string copy);

    [DllImport("TSCLIB.dll", EntryPoint = "sendcommand")]
    public static extern int sendcommand(string printercommand);

    [DllImport("TSCLIB.dll", EntryPoint = "setup")]
    public static extern int setup(string width, string height,
              string speed, string density,
              string sensor, string vertical,
              string offset);

    [DllImport("TSCLIB.dll", EntryPoint = "windowsfont")]
    public static extern int windowsfont(int x, int y, int fontheight,
                    int rotation, int fontstyle, int fontunderline,
                    string szFaceName, string content);

}

namespace ASP.NET_in_VCsharp_2008
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "msg", "alert('Hello TSCLIB.DLL')", true);
            //TSCLIB_DLL.about();                                                                 //Show the DLL version
            TSCLIB_DLL.openport("TSC TTP-243 Plus");                                           //Open specified printer driver
            TSCLIB_DLL.setup("52", "28.5", "4", "5", "0", "0", "0");
            /* 
             * width    設定標籤寬度   單位mm
             * height   設定標籤高度   單位mm
             * speed    設定列印速度   單位sec 間距1~10
             * density  設定列印濃度   單位    間距0~15
             * sensor   設定使用感應器類別 0 表示使用垂直間距感測器(gap sensor) 1 表示使用黑標感測器(black mark sensor)
             * vertical 字串型別，設定gap/black mark 垂直間距高度，單位:mm
             * offset   字串型別，設定gap/black mark 偏移距離，單位: mm，此參數若使用一般標籤時設為0
             */
            TSCLIB_DLL.clearbuffer();                                                           //Clear image buffer
            TSCLIB_DLL.barcode("80", "60", "128", "90", "1", "0", "4", "4", "3680302001393");
            /* 
             * x        字串型別，條碼X方向起始點，以點(point)表示。
             * y        字串型別，條碼Y方向起始點，以點(point)表示。
             * type     字串型別
             * height   字串型別，設定條碼高度，高度以點來表示。
             * readable 字串型別，設定是否列印條碼碼文 0: 不列印碼文 1: 列印碼文
             * rotation 字串型別，設定條碼旋轉角度
             * narrow   字串型別，設定條碼窄bar 比例因子，請參考TSPL使用手冊(也會調整條滿寬度)
             * wide     字串型別，設定條碼寬bar 比例因子，請參考TSPL使用手冊(也會調整條滿寬度)
             * code     要列印的條碼
             */
            TSCLIB_DLL.printerfont("100", "200", "4", "0", "1", "2", "Bg04-11");
            /* 
             * x:        字串型別，文字X方向起始點，以點(point)表示。
             * y:        字串型別，文字Y方向起始點，以點(point)表示。
             * fonttype: 字串型別，內建字型名稱，共12種。1~5
             * rotaiton: 字串型別，設定文字旋轉角度
             * xmul:     字串型別，設定文字X方向放大倍率，1~8
             * ymul:     字串型別，設定文字y方向放大倍率，1~8
             * text:     字串型別，列印文字內容
             * 
             */
            TSCLIB_DLL.windowsfont(50, 270, 30, 0, 0, 0, "標楷體", "MPU-6050三軸加速度傳感器-送排針");
            /* 
             * x:        整數型別，文字X方向起始點，以點(point)表示。
             * y:        整數型別，文字y方向起始點，以點(point)表示。
             * fonthigrt:整數型別，字體高度，以點(point)表示。
             * rotation :整數型別，旋轉角度，逆時鐘方向旋轉
             * fontstyle:整數型別，字體外形 0-> 標準(Normal)1-> 斜體(Italic)2-> 粗體(Bold)3-> 粗斜體(Bold and Italic)
             * fontline :整數型別，底線0-> 無底線1-> 加底線
             * szface   :字串型別，字體名稱。如: Arial, Times new Roman, 細名體, 標楷體
             * content  :字串型別，列印文字內容。
             */
            //TSCLIB_DLL.downloadpcx("C:\\ASP.NET_in_VCsharp_2008\\ASP.NET_in_VCsharp_2008\\UL.PCX", "UL.PCX");                                         //Download PCX file into printer
            //TSCLIB_DLL.downloadpcx("UL.PCX", "UL.PCX");                                         //Download PCX file into printer
            //TSCLIB_DLL.sendcommand("PUTPCX 100,400,\"UL.PCX\"");                                //Drawing PCX graphic
            TSCLIB_DLL.printlabel("1", "1");                                                    //set: 字串型別，設定列印標籤式數(set)copy: 字串型別，設定列印標籤份數(copy)
            TSCLIB_DLL.closeport();                     
        }
    }
}
