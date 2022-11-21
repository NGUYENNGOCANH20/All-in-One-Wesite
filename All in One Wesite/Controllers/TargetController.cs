using All_in_One_Wesite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Office.Interop.Excel;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Net;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Action = System.Action;
using Range = Microsoft.Office.Interop.Excel.Range;
using System.IO.Compression;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using System.IO;
using Aspose.Cells;
using System.Reflection;

namespace All_in_One_Wesite.Controllers
{
    public class TargetController : Microsoft.AspNetCore.Mvc.Controller
    {
        public static readonly string _constring = "workstation id=UserId2577.mssql.somee.com;packet size=4096;user id=ADMIN2577_SQLLogin_1;pwd=jugte43irc;data source=UserId2577.mssql.somee.com;persist security info=False;initial catalog=UserId2577";
        public IActionResult Target()
        {
            Console.Write(Directory.GetCurrentDirectory());
            if (DataModel.Paslogin && (DataModel.username == "Log_Anh" || DataModel.username == "BU_Team"))
            {
                var data = DataModel.dataReadertable("BookingOntime".Split(';'));
                ViewData["Table"] = data.Tables["BookingOntime"];
                ViewData["total"] = DataModel.dataReadsum("total_quantity");
                return View();
            }
            else
            {
                return RedirectToRoute(new { controller = "Home", action = "UnAutherize" });
            }
        }
        
        //GET FILE ZIP
        [HttpGet]
        public ActionResult DownloadFileVGM()
        {
            string zipName = "VGM.zip";
            using (MemoryStream ms = new MemoryStream())
            {
                using (var zip = new ZipArchive(ms, ZipArchiveMode.Create, true))
                {
                    var vl = WriteVGMfile();
                    vl.ToList().ForEach(file =>
                    {
                        var entry = zip.CreateEntry(file.Key);
                        using (var fileStream = file.Value)
                        using (var entryStream = entry.Open())
                        {
                            fileStream.CopyTo(entryStream);
                        }
                    });
                }
                return File(ms.ToArray(), "application/zip", zipName);
            }

        }
        [HttpGet]
        public ActionResult DownloadFileSI()
        {
            string zipName = "SI.zip";
            using (MemoryStream ms = new MemoryStream())
            {
                using (var zip = new ZipArchive(ms, ZipArchiveMode.Create, true))
                {
                    var vl = WriteSIfile();
                    vl.ToList().ForEach(file =>
                    {
                        var entry = zip.CreateEntry(file.Key);
                        using (var fileStream = file.Value)
                        using (var entryStream = entry.Open())
                        {
                            fileStream.CopyTo(entryStream);
                        }
                    });
                }
                return File(ms.ToArray(), "application/zip", zipName);
            }
        }
        [HttpGet]
        public ActionResult DownloadFilePKL()
        {
            string zipName = "PKL Excel.zip";
            using (MemoryStream ms = new MemoryStream())
            {
                using (var zip = new ZipArchive(ms, ZipArchiveMode.Create, true))
                {
                    var vl = WritePKLfile();
                    vl.ToList().ForEach(file =>
                    {
                        var entry = zip.CreateEntry(file.Key);
                        using (var fileStream = file.Value)
                        using (var entryStream = entry.Open())
                        {
                            fileStream.CopyTo(entryStream);
                        }
                    });
                }
                return File(ms.ToArray(), "application/zip", zipName);
            }

        }

        //TYPE OF OBJ
        private struct PO_value
        {
            public string po;
            public string carton;
            public string Gw;
            public string cbm;
        }
        public class Item_value
        {
            public string DCIP;
            public string Po;
            public string vcpi;
            public string color;
            public string style;
            public string size;
            public string Carton;
            public string Dimensioncm
            {
                get
                {
                    string optu = "";
                    SqlConnection conn = new SqlConnection(_constring);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand($"Select [CM_DEMENTION] from [Dimension] Where [STYLE] Like '{style}';", conn);
                    var data = cmd.ExecuteReader();
                    if (data.HasRows)
                    {
                        while (data.Read())
                        {
                            optu = data.GetString(0);
                        }
                    }
                    conn.Close();
                    return optu;
                }
            }
            public string DimensionIn
            {
                get
                {
                    string optu = "";
                    SqlConnection conn = new SqlConnection(_constring);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand($"Select [IN_DEMENTION] from [Dimension] Where [STYLE] Like '{style}';", conn);
                    var data = cmd.ExecuteReader();
                    if (data.HasRows)
                    {
                        while (data.Read())
                        {
                            optu = data.GetString(0);
                        }
                    }
                    conn.Close();
                    return optu;
                }
            }
            public string Gw;
            public Item_value(string Dc, string po, string vcp, string cl, string st, string size, string totalcarton, string gw)
            {
                this.DCIP = Dc; this.Po = po; this.vcpi = vcp; this.color = cl; this.style = st; this.size = size; this.Carton = totalcarton; this.Gw = gw;
            }
        }
        //VOID OF STATIC METHOR
        private static List<string> GetStyleDCIP(string po)
        {
            SqlConnection connectionnew = new SqlConnection(_constring);
            connectionnew.Open();
            connectionnew.StatisticsEnabled = true;
            List<string> liststyle = new List<string>();
            var sqlitem = new SqlCommand($"Select [Style] From [{po}]", connectionnew);
            var Readeritem = sqlitem.ExecuteReader();
            if (Readeritem != null)
            {
                while (Readeritem.Read())
                {
                    if (!liststyle.Contains(Readeritem.GetValue(0).ToString()))
                    {
                        liststyle.Add(Readeritem.GetValue(0).ToString());
                    }
                }
            }
            connectionnew.Close();
            return liststyle;
        }
        private static List<string> GetlistitemDCIP(string po)
        {
            List<string> listitem = new List<string>();
            SqlConnection connectionPOtable = new SqlConnection(_constring);
            connectionPOtable.Open();
            SqlCommand sqlitem = new SqlCommand($"Select [BuyerItem] From [{po}]", connectionPOtable);
            var Readeritem = sqlitem.ExecuteReader();
            if (Readeritem.HasRows)
            {
                while (Readeritem.Read())
                {
                    listitem.Add(Readeritem.GetValue(0).ToString());
                }
            }
            connectionPOtable.Close();
            return listitem;
        }
        private static List<PO_value> CreatedPKL()
        {
            List<PO_value> itemlist = new List<PO_value>();
            SqlConnection connection = new SqlConnection(_constring);
            connection.Open();
            connection.StatisticsEnabled = true;
            SqlCommand come = new SqlCommand("Select [po_number],[total_packages],[total_gross_weight],[total_measurement] from [BookingOntime];", connection);
            var data = come.ExecuteReader();
            if (data.HasRows)
            {
                while (data.Read())
                {
                    PO_value item = new PO_value();
                    item.po = data.GetValue(0).ToString();
                    item.carton = data.GetValue(1).ToString();
                    item.Gw = data.GetValue(2).ToString();
                    item.cbm = data.GetValue(3).ToString();
                    itemlist.Add(item);
                }
            }
            connection.Close();
            return itemlist;
            
        }
        //=> GET_VALUE METHOR
        private static List<KeyValuePair<string, MemoryStream>> WritePKLfile()
        {
            if (!Directory.Exists(Directory.GetCurrentDirectory() + $"\\Models\\file_target\\PKL"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + $"\\Models\\file_target\\PKL");
            }
            List<KeyValuePair<string, MemoryStream>> listmenory = new List<KeyValuePair<string, MemoryStream>>();
            string PO; string totalcarton; string cbm; string Gw;
            foreach (var itemx in CreatedPKL())
            {
                PO = itemx.po; totalcarton = itemx.carton; cbm = itemx.cbm; Gw = itemx.Gw;
                List<Item_value> list = new List<Item_value>();
                SqlConnection conn = new SqlConnection(_constring);
                conn.Open();
                SqlCommand cmd = new SqlCommand($"Select [BuyerItem],[qtyin1carton],[Style],[Color],[Size],[Packages],[Gross] from [{PO}];", conn);
                var data = cmd.ExecuteReader();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        Item_value item = new Item_value(data.GetValue(0).ToString(), PO.Split('-')[1], data.GetValue(1).ToString(), data.GetValue(3).ToString(), data.GetValue(2).ToString(), data.GetValue(4).ToString(), data.GetValue(5).ToString(), data.GetValue(6).ToString());
                        list.Add(item);
                    }
                }
                conn.Close();
                var workbook = new Aspose.Cells.Workbook(Directory.GetCurrentDirectory() + $"\\Models\\file_target\\PLSample.xlsx");
                var rev = workbook.Worksheets[0];
                var reg = workbook.Worksheets[1];
                var reg3 = workbook.Worksheets[2];
                int i = 0;
                double TotalGw = 0;
                foreach (Item_value item in list)
                {
                    rev.Cells[15, 13].Value = $"PURCHASE ORDER # {item.Po}";
                    TotalGw = TotalGw + double.Parse(string.Join("", item.Gw.Split(',')));
                    Console.WriteLine(item.DCIP + "#" + double.Parse(string.Join("", item.Gw.Split(','))) / int.Parse(string.Join("", item.Carton.Split(','))));
                    reg.Cells[0, 0].Value = $"DPC ITEM # {item.DCIP}";
                    reg.Cells[1, 0].Value = $"PO# {item.Po}";
                    reg.Cells[2, 0].Value = $"VCP/SSP: {item.vcpi}/1";
                    reg.Cells[4, 0].Value = $"STYLE: {item.style}";
                    reg.Cells[5, 0].Value = $"COLOR : {item.color}";
                    reg.Cells[6, 0].Value = $"SIZE:{item.size}";
                    reg.Cells[0, 2].Value = $"{item.Carton}";
                    reg.Cells[0, 5].Value = $"{item.Dimensioncm}";
                    reg.Cells[1, 5].Value = $"{item.DimensionIn}";
                    reg.Cells[0, 15].Value = $"{Math.Round(double.Parse(string.Join("", item.Gw.Split(','))) / int.Parse(string.Join("", item.Carton.Split(','))),3)}";
                    reg.Cells[0, 13].Value = $"{Math.Round((double.Parse(string.Join("", item.Gw.Split(','))) / int.Parse(string.Join("", item.Carton.Split(',')))) - 0.41,3)}";
                    reg.Cells[0, 11].Value = $"{Math.Round((double.Parse(string.Join("", item.Gw.Split(','))) / int.Parse(string.Join("", item.Carton.Split(',')))) - 0.72,3)}";
                    var cutvalue = workbook.Worksheets.AddCopy(1);
                    rev.Cells.InsertCutCells(workbook.Worksheets[3].Cells.CreateRange(0, 9, false), 23+i*9, 0, ShiftType.Down);
                    workbook.Worksheets.RemoveAt(3);
                    i++;
                    
                }
                reg3.Cells[2, 0].Value = totalcarton;
                reg3.Cells[2, 2].Value = cbm;
                reg3.Cells[2, 14].Value = TotalGw;
                reg3.Cells[2, 11].Value = double.Parse(string.Join("", Gw.Split(','))) - 0.41 * double.Parse(string.Join("", totalcarton.Split(',')));
                reg3.Cells[2, 6].Value = double.Parse(string.Join("", Gw.Split(','))) - 0.72 * double.Parse(string.Join("", totalcarton.Split(',')));
                var cutvalue2 = workbook.Worksheets.AddCopy(2);
                rev.Cells.InsertCutCells(workbook.Worksheets[3].Cells.CreateRange(0, 9, false), 23 + i * 9, 0, ShiftType.Down);
                workbook.Worksheets.RemoveAt(3);
                listmenory.Add(new KeyValuePair<string, MemoryStream>($"PL _ PO# {PO.Split('-')[1]}.xls", new MemoryStream(workbook.SaveToStream().GetBuffer())));
            }
            return listmenory;
        }
        private static List<KeyValuePair<string, MemoryStream>> WriteVGMfile()
        {
            if (!Directory.Exists(Directory.GetCurrentDirectory() + $"\\Models\\file_target\\VGMfile"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + $"\\Models\\file_target\\VGMfile");
            }
            System.IO.File.Delete(Directory.GetCurrentDirectory() + "\\Models\\Vgm.zip");
            SqlConnection connection = new SqlConnection(_constring);
            connection.Open();
            connection.StatisticsEnabled = true;
            SqlCommand sql = new SqlCommand("Select [so_estimated_delivery_date],[so_confirmation_number],[po_number],[total_gross_weight] from [BookingOntime];", connection);
            var Reader = sql.ExecuteReader();
            List<KeyValuePair<string, MemoryStream>> list = new List<KeyValuePair<string, MemoryStream>>();
            if (Reader.HasRows)
            {
                var workbook = new Aspose.Cells.Workbook(Directory.GetCurrentDirectory() + "\\Models\\file_target\\VGM for + Maersk SCM SO#.xlsx");
                while (Reader.Read())
                {
                    workbook.Worksheets[0].Cells[5, 7].Value = Reader.GetValue(0);
                    workbook.Worksheets[0].Cells[13, 4].Value = Reader.GetValue(1);
                    workbook.Worksheets[0].Cells[13, 5].Value = Reader.GetValue(2);
                    workbook.Worksheets[0].Cells[13, 6].Value = Reader.GetValue(3);
                    list.Add(new KeyValuePair<string, MemoryStream>($"VGM for + Maersk SCM SO# {Reader.GetValue(1).ToString()} _ PO# {Reader.GetValue(2).ToString()}.xls", new MemoryStream(workbook.SaveToStream().GetBuffer())));
                }
            }
            connection.Close();
            return list;
        }
        private static List<KeyValuePair<string, MemoryStream>> WriteSIfile()
        {
            if (!Directory.Exists(Directory.GetCurrentDirectory() + $"\\Models\\file_target\\SI"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + $"\\Models\\file_target\\SI");
            }
            List<KeyValuePair<string, MemoryStream>> list = new List<KeyValuePair<string, MemoryStream>>();
            SqlConnection connection = new SqlConnection(_constring);
            connection.Open();
            connection.StatisticsEnabled = true;
            List<string[]> linesPO = new List<string[]>();
            SqlCommand sql = new SqlCommand("Select [so_confirmation_number],[po_number],[total_packages],[total_quantity] From [BookingOntime]", connection);
            var Reader = sql.ExecuteReader();
            if (Reader.HasRows)
            {
                while (Reader.Read())
                {
                    string[] valie = new string[4];
                    valie[0] = Reader.GetValue(0).ToString();
                    valie[1] = Reader.GetValue(1).ToString();
                    valie[2] = Reader.GetValue(2).ToString();
                    valie[3] = Reader.GetValue(3).ToString();
                    linesPO.Add(valie);
                }
            }
            connection.Close();
            foreach (var itemsum in linesPO)
            {
                string qty = "";
                string booking = "";
                string ponumber = "";
                string carton = "";
                string[] valie = itemsum;
                var workbook = new Aspose.Cells.Workbook(Directory.GetCurrentDirectory() + $"\\Models\\file_target\\SI + PO#CFS   SO#.xlsx");
                var range = workbook.Worksheets[0];
                if (!System.IO.File.Exists(Directory.GetCurrentDirectory() + $"\\Models\\file_target\\SI\\SI + PO# {valie[1]} CFS   SO# {valie[0]}.xlsx"))
                {
                    List<string> listitem = GetlistitemDCIP(valie[1]);
                    if (listitem.Count == 1)
                    {
                        SqlConnection connectionnew = new SqlConnection(_constring);
                        connectionnew.Open();
                        connectionnew.StatisticsEnabled = true;
                        var sqlitem = new SqlCommand($"Select [Quantity] From [{valie[1]}]", connectionnew);
                        var Readeritem = sqlitem.ExecuteReader();
                        if (Readeritem.HasRows)
                        {
                            while (Readeritem.Read())
                            {
                                qty = Readeritem.GetValue(0).ToString();
                            }
                        }
                        connectionnew.Close();
                    }
                    else
                    {
                        qty = valie[3];
                    }
                    range.Cells[3, 0].Value = valie[0];
                    range.Cells[3, 1].Value = valie[1];
                    range.Cells[5, 4].Value = valie[1];
                    carton = valie[2];
                    range.Cells[4, 4].Value = $"Qty {qty} EA _ {carton} cartons";
                    int i = 0;
                    foreach (var item in listitem)
                    {
                        range.Cells[6 + i, 4].Value = "DPCI# " + item;
                        i++;
                    }
                    List<string> liststyle = GetStyleDCIP(valie[1]);
                    range.Cells[8 + i, 4].Value = "90% Nylon, 10% Spandex,";
                    foreach (var item in liststyle)
                    {
                        switch (item)
                        {
                            case "9XZWR":
                                range.Cells[9 + i, 4].Value = item + " - HIPSTER PLUS";
                                break;
                            case "7GYM7":
                                range.Cells[9 + i, 4].Value = item + " - BIKINI";
                                break;
                            case "719WE":
                                range.Cells[9 + i, 4].Value = item + " - HIPSTER";
                                break;
                            case "7P8RM":
                                range.Cells[9 + i, 4].Value = item + " - THONG PLUS";
                                break;
                            case "1KEP3":
                                range.Cells[9 + i, 4].Value = item + " - THONG";
                                break;
                            case "PE345":
                                range.Cells[9 + i, 4].Value = item + " - HIPSTER PLUS TIE-DYE";
                                break;
                            case "R6K24":
                                range.Cells[9 + i, 4].Value = item + " - BOYSHORT";
                                break;
                            case "XP2Z8":
                                range.Cells[9 + i, 4].Value = item + " - BOYSHORT PLUS";
                                break;
                            default:
                                range.Cells[9 + i, 4].Value = item;
                                break;
                        }
                        i++;
                    }
                    list.Add(new KeyValuePair<string, MemoryStream>($"SI + PO# {valie[1]} CFS   SO# {valie[0]}.xls", new MemoryStream(workbook.SaveToStream().GetBuffer())));
                }
            }
            return list;
        }
    }
}
