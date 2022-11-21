using System.Collections.Immutable;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Text.RegularExpressions;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;

namespace All_in_One_Wesite.Models
{
	public class DataModel
	{
        public static readonly SqlConnection connection = new SqlConnection("workstation id=UserId2577.mssql.somee.com;packet size=4096;user id=ADMIN2577_SQLLogin_1;pwd=jugte43irc;data source=UserId2577.mssql.somee.com;persist security info=False;initial catalog=UserId2577");
        public List<int> saletotal = new List<int>();
        public List<KeyValuePair<string,List<int>>> datasts = new List<KeyValuePair<string,List<int>>>();
        public DataModel()
        {
            SqlCommand command = new SqlCommand("select * FROM [Sale];",connection);
            connection.Open();
            var data = command.ExecuteReader();
            if (data.HasRows)
            {
                while (data.Read())
                {
                    saletotal.Add(data.GetInt32(0));
                    saletotal.Add(data.GetInt32(1));
                    saletotal.Add(data.GetInt32(2));
                }
            }
            connection.Close();
            command = new SqlCommand("select * FROM [Sts];", connection);
            connection.Open();
            data = command.ExecuteReader();
            if (data.HasRows)
            {
                while (data.Read())
                {
                    datasts.Add(new KeyValuePair<string, List<int>>(data.GetValue(0).ToString(), new List<int> { data.GetInt32(1), data.GetInt32(2), data.GetInt32(3) }));
                }
            }
            connection.Close();
        }
        public static DataSet dataReadertable(string[] tablename)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet datas = new DataSet();
            foreach (var item in tablename)
            {
                connection.Open();
                adapter.TableMappings.Add("Table", item);
                adapter.SelectCommand = new SqlCommand($"select * FROM [{item}];", connection);
                adapter.Fill(datas);
                connection.Close();
            }
            return datas;
        }
        public static int dataReadsum(string columns)
        {
            connection.Open();
            SqlCommand command = new SqlCommand($"SELECT {columns} FROM [BookingOntime];", connection);
            var data = command.ExecuteReader();
            int total = 0;
            while (data.Read())
            {
                int getout = 0;
                int.TryParse((string?)data.GetValue(0), out getout);
                total = total+ getout;
            }
            connection.Close();
            return total;
        }
        public static string username { get; set; }
        public static string password { get; set; }
        public static bool Paslogin { get; set; }
        
    }
    public class httpscmdata
    {
        public string ID { get; set; }
        public string Link { get; set; }
        public httpscmdata(string iD, string link)
        {
            this.ID = iD;
            this.Link = link;
        }
    }
    public interface IMain
    {
        string uri_main { get; set; }
        HttpClient client { get; set; }
        HttpClientHandler handler { get; set; }
        CookieContainer cookieContainer { get; set; }
        object Data_input { get; set; }
        object Data_output { get; set; }
    }
    public interface I_Runmain
    {
        void SendMethor();
        void GetInf();
    }
    public abstract class Class_TT_http : IMain, I_Runmain
    {
        public string Type_class;
        public HttpClient client { get; set; }
        public HttpClientHandler handler { get; set; }
        public CookieContainer cookieContainer { get; set; }
        public object Data_input { get; set; }
        public object Data_output { get; set; }
        public string uri_main { get; set; }
        public abstract void GetInf();
        public abstract void Login();
        public void SendMethor()
        {
            dynamic sender = Data_input;
            if (sender.Value == null)
            {
                var mgs = new HttpRequestMessage(HttpMethod.Get, new Uri(sender.Key));
                var Req = client.SendAsync(mgs).Result;
                Req.EnsureSuccessStatusCode();
                Data_output = Req.Content.ReadAsStringAsync().Result;
            }
            else
            {
                var mgs = new HttpRequestMessage(HttpMethod.Post, new Uri(sender.Key));
                mgs.Content = new FormUrlEncodedContent(sender.Value);
                var Req = client.SendAsync(mgs).Result;
                Req.EnsureSuccessStatusCode();
                Console.WriteLine("Send data status #" + Req.StatusCode.ToString());
                Data_output = Req.Content.ReadAsStringAsync().Result;
            }
        }
        public void downloadfile()
        {
            dynamic sender = Data_input;
            var mgs = new HttpRequestMessage(HttpMethod.Get, new Uri(sender.Key));
            var Req = client.SendAsync(mgs).Result;
            Req.EnsureSuccessStatusCode();
            Data_output = Req.Content.ReadAsByteArrayAsync().Result;
        }
        public void GetInf(Action action)
        {
            Task t = Task.Run(action);
            t.Wait();
        }

    }
    public class Scmvhttp : Class_TT_http
    {
        public static string sesionid { get; set; }
        public string dataviewBU { get; set; }
        public List<httpscmdata> listdata { get; set; }
        public Scmvhttp()
        {
            uri_main = "https://spanx.ngcxpress.com";
            cookieContainer = new CookieContainer();
            handler = new HttpClientHandler();
            handler.CookieContainer = cookieContainer;
            client = new HttpClient(handler);
            client.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/104.0.0.0 Safari/537.36");
            client.DefaultRequestHeaders.Add("accept", "*/*");
            if (cookieContainer.Count == 0)
            {
                Login();
            }
            GetInf();
            dataviewBU = _BUview();
        }
        public override void GetInf()
        {
            listdata = new List<httpscmdata>();
            var mgs = new HttpRequestMessage(HttpMethod.Get, new Uri($"{uri_main}/pages/aspx/{sesionid}/moduleview.aspx?ViewID=6087&table=shipment&module=8"));
            var Req = client.SendAsync(mgs).Result;
            Req.EnsureSuccessStatusCode();
            var Data = Req.Content.ReadAsStringAsync().Result.Split('<');
            int idsm = 0;
            IEnumerable<string> Shipment_number = from lineshipment in Data where (lineshipment.Contains("td") && lineshipment.Contains("title=") && int.TryParse(lineshipment.Split('\'')[1], out idsm) && int.Parse(lineshipment.Split('\'')[1]) == int.Parse(lineshipment.Split('>')[1])) select lineshipment;
            IEnumerable<string> list_key_Scm = from lineshipment in Data where (lineshipment.Contains("id_key") && lineshipment.Contains("View Record")) select lineshipment;
            for (int i = 0; i < Shipment_number.Count(); i++)
            {
                listdata.Add(new httpscmdata(Shipment_number.ToArray()[i].Split('\'')[1], uri_main + list_key_Scm.ToArray()[i].Split('\"')[1]));
            }
            Thread t = new Thread(() =>
            {
                string stringcm = "drop table [Scm Price];\r\nCREATE TABLE [Scm Price] (\r\n    [Scmid] int,\r\n    [linkCI] text,\r\n    [price] text\r\n);";
                foreach (var item in listdata)
                {
                    string id = item.Link.Split('=')[2];
                    string sesion = item.Link.Split('/')[5];
                    string link_e_ci = $"https://Spanx.ngcxpress.com/pages/aspx/{sesion}/SSRSDashboard.aspx?id_optionmenu=292&idShipment={id}&printCDF=1&printSetStyle=1&drilldown=true";
                    mgs = new HttpRequestMessage(HttpMethod.Get, new Uri(link_e_ci));
                    Req = client.SendAsync(mgs).Result;
                    Req.EnsureSuccessStatusCode();
                    byte[] datafile = Req.Content.ReadAsByteArrayAsync().Result;
                    using (PdfDocument document = PdfDocument.Open(datafile))
                    {
                        string shipmentScm = "";
                        double sum_price = 0;
                        foreach (Page page in document.GetPages())
                        {
                            var arrayvalue = page.GetWords().ToImmutableArray().ToArray();
                            for(int i  = 0; i< arrayvalue.GetLength(0); i++)
                            {
                                if (arrayvalue[i].Text == "Shipment")
                                {
                                    shipmentScm = arrayvalue[i + 2].Text;
                                    break;
                                }
                            }
                            var the_price = from itemvalue in page.GetWords().ToImmutableArray().ToArray() where itemvalue.ToString().Contains("$") select itemvalue.ToString().Substring(1, itemvalue.ToString().Length-1);
                            try
                            {
                                string prstring = the_price.Last();
                                sum_price = double.Parse(string.Join("", prstring.Split(',')));
                            }
                            catch (Exception) { }
                            
                        }
                        Console.WriteLine($"{shipmentScm} _ {sum_price}");
                        Console.WriteLine($"---------------------------------");
                        stringcm = stringcm + $"insert into [Scm Price] ([Scmid], [linkCI], [price]) values ({shipmentScm},'{link_e_ci}', '{sum_price}');";
                    }
                }
                while(stringcm.Split(';').GetLength(0)-3!= listdata.Count)
                {
                    Thread.Sleep(1000);
                }
                SqlConnection connection = DataModel.connection;
                connection.Open();
                SqlCommand command = new SqlCommand(stringcm, connection);
                command.ExecuteNonQuery();
                connection.Close();
            });
            t.Start();
        }
        public string _BUview()
        {
            var req = client.SendAsync(new HttpRequestMessage(HttpMethod.Get, new Uri($"https://spanx.ngcxpress.com/pages/aspx/{sesionid}/moduleview.aspx?ViewID=6147&table=productionorder&module=4"))).Result;
            return req.Content.ReadAsStringAsync().Result;
        }
        public override void Login()
        {
            Data_input = new KeyValuePair<string, object>(uri_main, null);
            SendMethor();
            dynamic Outputvalue = Data_output;
            string Data = Outputvalue.ToString();
            var logon = from runline in Data.Split('<').ToList() where runline.Contains("logon") select runline;
            sesionid = logon.ToArray()[2].Split('\"')[1].Split('/')[3];
            string linelogin = logon.ToArray()[1].Split('\"')[5];
            var hiden_value = from runline in Data.Split('<').ToList() where runline.Contains("hidden") select runline;
            Console.WriteLine(uri_main + linelogin.Substring(1, linelogin.Length - 1));
            Console.WriteLine(sesionid);
            var list = new List<KeyValuePair<string, string>>();
            foreach (var item in hiden_value)
            {
                list.Add(new KeyValuePair<string, string>(item.Split('\"')[5], item.Split('\"')[7]));
            }
            list.Add(new KeyValuePair<string, string>("user", "DELTASEAMFREE"));
            list.Add(new KeyValuePair<string, string>("password", "Santoni23"));
            Data_input = new KeyValuePair<string, object>(uri_main + linelogin.Substring(1, linelogin.Length - 1), list);
            SendMethor();
            Thread.Sleep(TimeSpan.FromSeconds(3));
        }
    }
    public class topdata
    {
        public string idurl { get; set; }
        public string[] vstring { get; set; }
        public topdata(string idurl, string[] vstring)
        {
            this.idurl = idurl;
            this.vstring = vstring;
        }
    }
    public class Topsystem : Class_TT_http
    {
        public static List<topdata> list100 { get; set; }
        public Topsystem()
        {
            list100 = new List<topdata>();
            uri_main = "https://v15.topocean.com/WebBooking/BookingList.asp";
            cookieContainer = new CookieContainer();
            handler = new HttpClientHandler();
            handler.CookieContainer = cookieContainer;
            client = new HttpClient(handler);
            client.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/104.0.0.0 Safari/537.36");
            client.DefaultRequestHeaders.Add("accept", "*/*");
            if (cookieContainer.Count == 0)
            {
                Login();
            }
            GetInf();
        }
        public override void GetInf()
        {
            Data_input = new KeyValuePair<string, object>(uri_main, null);
            SendMethor();
            string oputstring = ((dynamic)Data_output).ToString();
            var idbk = from line in oputstring.Split('<') where line.Contains("BookingDetail.asp") select Regex.Replace(line, "&nbsp;", "");
            var linqdetail = from line in oputstring.Split('<') where line.Contains("td>") && !line.Contains("/td") && !line.Contains("\n") select Regex.Replace(line, "&nbsp;", "");
            int iv = 0; int jk = 0;
            List<string> list = new List<string>();
            foreach (var item in linqdetail)
            {
                if (iv % 18 == 0 && iv != 0)
                {
                    if (jk < 100)
                    {
                        list100.Add(new topdata(idbk.ToArray()[jk], list.ToArray()));
                        list = new List<string>();
                        jk++;
                    }
                }
                list.Add(item.Split('>')[1]);
                iv++;
            }
        }
        public override void Login()
        {
            Data_input = new KeyValuePair<string, object>(uri_main, null);
            SendMethor();
            //tao Http_get 
            dynamic Outputvalue = Data_output;
            //tao bien dong tham chieu toi Data get
            string Data = Outputvalue.ToString();
            var hiden_value = from runline in Data.Split('<').ToList() where runline.Contains("hidden") && !runline.Contains("STYLE") select runline;
            var list = new List<KeyValuePair<string, string>>();
            foreach (var item in hiden_value)
            {
                Console.WriteLine(item.Split('\"')[3] + ":" + item.Split('\"')[5]);
                list.Add(new KeyValuePair<string, string>(item.Split('\"')[3], item.Split('\"')[5]));
            }
            list.Add(new KeyValuePair<string, string>("txtLoginName", "spanx_deltavnm"));
            list.Add(new KeyValuePair<string, string>("txtPassword", "QST+-3+tD9"));
            Data_input = new KeyValuePair<string, object>(Regex.Replace(uri_main, "/BookingList.asp", "/SysLogin.asp"), list);
            SendMethor();
        }
    }
}
