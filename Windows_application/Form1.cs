using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows_application
{
	public partial class Form : System.Windows.Forms.Form
	{
		public Form()
		{
			InitializeComponent();
		}

		private void Form_Load(object sender, EventArgs e)
		{
			SqlConnection connection = new SqlConnection("workstation id=UserId2577.mssql.somee.com;packet size=4096;user id=ADMIN2577_SQLLogin_1;pwd=jugte43irc;data source=UserId2577.mssql.somee.com;persist security info=False;initial catalog=UserId2577");
			connection.Open();
			SqlDataAdapter adapter1 = new SqlDataAdapter("select * FROM [User name];", connection);
            SqlDataAdapter adapter2 = new SqlDataAdapter("select * FROM [Shipment SCM];", connection);
			SqlDataAdapter adapter3 = new SqlDataAdapter("select * FROM [Sale];",connection);
            SqlDataAdapter adapter4 = new SqlDataAdapter("select * FROM [Sts];", connection);
            connection.Close();
            adapter2.Fill(this.dataSet3.Shipment_SCM);
            adapter3.Fill(this.dataSet2.Sale);
            adapter1.Fill(this.dataSet1.User_name);
			adapter4.Fill(this.dataSet4.Sts);
			
				
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
		{
			try
			{
				this.shipment_SCMTableAdapter.Fill(this.dataSet3.Shipment_SCM);
			}
			catch (System.Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message);
			}

		}

		private void fillByToolStripButton1_Click(object sender, EventArgs e)
		{
			try
			{
				this.user_nameTableAdapter.Fill(this.dataSet1.User_name);
			}
			catch (System.Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message);
			}

		}

		private void button1_Click(object sender, EventArgs e)
		{
            SqlConnection connection = new SqlConnection("workstation id=UserId2577.mssql.somee.com;packet size=4096;user id=ADMIN2577_SQLLogin_1;pwd=jugte43irc;data source=UserId2577.mssql.somee.com;persist security info=False;initial catalog=UserId2577");
            connection.Open();
			string querry = textBox1.Text;
			SqlCommand command = new SqlCommand(querry, connection);
			try
			{
                command.ExecuteNonQuery();
            }
			catch (Exception) {
				MessageBox.Show("Can't execute querry");
			}
			finally
			{
                connection.Close();
            }
			
        }
	}
}
