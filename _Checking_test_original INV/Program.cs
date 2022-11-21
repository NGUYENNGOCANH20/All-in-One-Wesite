using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;
using System.IO;

namespace _Checking_test_original_INV
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Scm Checking :");
                string Scmid = Console.ReadLine();
                PriceSCM priceSCM = new PriceSCM(Scmid);
                Console.WriteLine("Original Checking ';' :");
                string[] Origin = Console.ReadLine().Split(';');
                Read_connect read_ = new Read_connect(Scmid, Origin);
                Console.ReadKey();
                Console.WriteLine("----------------------------------");
            }
            
        }
    }
    public class PriceSCM
    {
        public class scmprice
        {
            public string idscm { get; set; }
            public string link { get; set; }
            public string pricevalue { get; set; }
            public scmprice(string id, string link, string price)
            {
                this.idscm = id;
                this.link = link;
                this.pricevalue = price;
            }

        }
        public scmprice listdata;
        public static readonly SqlConnection connection = new SqlConnection("workstation id=UserId2577.mssql.somee.com;packet size=4096;user id=ADMIN2577_SQLLogin_1;pwd=jugte43irc;data source=UserId2577.mssql.somee.com;persist security info=False;initial catalog=UserId2577");
        public PriceSCM(string Scmid)
        {
            SqlCommand sqlCommand = new SqlCommand($"select * from [SCM price] WHERE [Scmid] = {Scmid};", connection);
            connection.Open();
            var adata = sqlCommand.ExecuteReader();
            if (adata.HasRows)
            {
                while (adata.Read())
                {
                    listdata=new scmprice(adata.GetValue(0).ToString(), adata.GetValue(1).ToString(), adata.GetValue(2).ToString());
                }
            }
            connection.Close();
        }
    }
    public class Read_connect
    {
        public Read_connect(string Scmid, string[] orignalid)
        {
            PriceSCM priceSCM = new PriceSCM(Scmid);
            OriginalINV original = new OriginalINV(orignalid);
            if(double.Parse(priceSCM.listdata.pricevalue) == original.total_price)
            {
                Console.WriteLine($"{Scmid} _ {string.Join("/",orignalid)} _ Price is OK");
            }
            else
            {
                Console.WriteLine($"Mismacth price SCM # {Scmid} : {priceSCM.listdata.pricevalue} _ Shipment # {string.Join("/", orignalid)} original price : {original.total_price}");
            }
            
        }
        
    }
    public class OriginalINV
    {
        public double total_price = 0;
        public OriginalINV(string[] shipmentinScm)
        {
            foreach(string iten in Lsfile(shipmentinScm))
            {
                total_price = total_price + Readfileori(iten);
            }
        }
        public static string[] Lsfile(string[] shipmentinScm)
        {
            List<string> li = new List<string>();
            foreach(var vl in shipmentinScm)
            {
                var kcheck = from item in Directory.GetFiles(Directory.GetCurrentDirectory())
                             where item.Contains(vl)select item;
                li.Add(kcheck.First());
            }
            return li.ToArray();
        }
        public static double Readfileori(string file)
        {
            List<double> listc = new List<double>();
            using (PdfDocument document = PdfDocument.Open(file))
            {
                foreach (Page page in document.GetPages())
                {
                    var arrayvalue = page.GetWords().ToArray();
                    var the_price = from itemvalue in arrayvalue where itemvalue.ToString().Contains(".") && itemvalue.ToString().Split('.').GetLength(0)==2 select itemvalue.ToString();
                    foreach(var item in the_price)
                    {
                        try
                        {
                            listc.Add(double.Parse(item));
                        }
                        catch (Exception) { }
                    }
                    
                }
                
            }
            return listc.ToArray().Max();
        }
    }
}
