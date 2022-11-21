namespace Windows_application
{
	partial class Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.linkDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shipmentSCMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet3 = new Windows_application.DataSet3();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usernameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.passwordDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userNameBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new Windows_application.DataSet1();
            this.user_nameTableAdapter = new Windows_application.DataSet1TableAdapters.User_nameTableAdapter();
            this.shipment_SCMTableAdapter = new Windows_application.DataSet3TableAdapters.Shipment_SCMTableAdapter();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.targetDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spanxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wacoalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet2 = new Windows_application.DataSet2();
            this.saleTableAdapter = new Windows_application.DataSet2TableAdapters.SaleTableAdapter();
            this.tableAdapterManager1 = new Windows_application.DataSet2TableAdapters.TableAdapterManager();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.dataSet4 = new Windows_application.DataSet4();
            this.stsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.stsTableAdapter = new Windows_application.DataSet4TableAdapters.StsTableAdapter();
            this.brandDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyShipDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyBookingCfDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyPendingDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shipmentSCMBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userNameBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn1,
            this.linkDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.shipmentSCMBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(343, 200);
            this.dataGridView1.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn1
            // 
            this.idDataGridViewTextBoxColumn1.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn1.HeaderText = "id";
            this.idDataGridViewTextBoxColumn1.Name = "idDataGridViewTextBoxColumn1";
            this.idDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // linkDataGridViewTextBoxColumn
            // 
            this.linkDataGridViewTextBoxColumn.DataPropertyName = "link";
            this.linkDataGridViewTextBoxColumn.HeaderText = "link";
            this.linkDataGridViewTextBoxColumn.Name = "linkDataGridViewTextBoxColumn";
            this.linkDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // shipmentSCMBindingSource
            // 
            this.shipmentSCMBindingSource.DataMember = "Shipment SCM";
            this.shipmentSCMBindingSource.DataSource = this.dataSet3;
            // 
            // dataSet3
            // 
            this.dataSet3.DataSetName = "DataSet3";
            this.dataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.usernameDataGridViewTextBoxColumn,
            this.passwordDataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.userNameBindingSource;
            this.dataGridView2.Location = new System.Drawing.Point(376, 12);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(364, 200);
            this.dataGridView2.TabIndex = 1;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // usernameDataGridViewTextBoxColumn
            // 
            this.usernameDataGridViewTextBoxColumn.DataPropertyName = "Username";
            this.usernameDataGridViewTextBoxColumn.HeaderText = "Username";
            this.usernameDataGridViewTextBoxColumn.Name = "usernameDataGridViewTextBoxColumn";
            this.usernameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // passwordDataGridViewTextBoxColumn
            // 
            this.passwordDataGridViewTextBoxColumn.DataPropertyName = "Password";
            this.passwordDataGridViewTextBoxColumn.HeaderText = "Password";
            this.passwordDataGridViewTextBoxColumn.Name = "passwordDataGridViewTextBoxColumn";
            this.passwordDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // userNameBindingSource
            // 
            this.userNameBindingSource.DataMember = "User name";
            this.userNameBindingSource.DataSource = this.dataSet1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // user_nameTableAdapter
            // 
            this.user_nameTableAdapter.ClearBeforeFill = true;
            // 
            // shipment_SCMTableAdapter
            // 
            this.shipment_SCMTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView3
            // 
            this.dataGridView3.AutoGenerateColumns = false;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.targetDataGridViewTextBoxColumn,
            this.spanxDataGridViewTextBoxColumn,
            this.wacoalDataGridViewTextBoxColumn});
            this.dataGridView3.DataSource = this.saleBindingSource;
            this.dataGridView3.Location = new System.Drawing.Point(12, 232);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.Size = new System.Drawing.Size(343, 82);
            this.dataGridView3.TabIndex = 2;
            // 
            // targetDataGridViewTextBoxColumn
            // 
            this.targetDataGridViewTextBoxColumn.DataPropertyName = "Target";
            this.targetDataGridViewTextBoxColumn.HeaderText = "Target";
            this.targetDataGridViewTextBoxColumn.Name = "targetDataGridViewTextBoxColumn";
            this.targetDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // spanxDataGridViewTextBoxColumn
            // 
            this.spanxDataGridViewTextBoxColumn.DataPropertyName = "Spanx";
            this.spanxDataGridViewTextBoxColumn.HeaderText = "Spanx";
            this.spanxDataGridViewTextBoxColumn.Name = "spanxDataGridViewTextBoxColumn";
            this.spanxDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // wacoalDataGridViewTextBoxColumn
            // 
            this.wacoalDataGridViewTextBoxColumn.DataPropertyName = "Wacoal";
            this.wacoalDataGridViewTextBoxColumn.HeaderText = "Wacoal";
            this.wacoalDataGridViewTextBoxColumn.Name = "wacoalDataGridViewTextBoxColumn";
            this.wacoalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // saleBindingSource
            // 
            this.saleBindingSource.DataMember = "Sale";
            this.saleBindingSource.DataSource = this.dataSet2;
            // 
            // dataSet2
            // 
            this.dataSet2.DataSetName = "DataSet2";
            this.dataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // saleTableAdapter
            // 
            this.saleTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.SaleTableAdapter = this.saleTableAdapter;
            this.tableAdapterManager1.UpdateOrder = Windows_application.DataSet2TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(376, 232);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(364, 40);
            this.textBox1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(376, 278);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(364, 36);
            this.button1.TabIndex = 5;
            this.button1.Text = "Excure Querry";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView4
            // 
            this.dataGridView4.AutoGenerateColumns = false;
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.brandDataGridViewTextBoxColumn,
            this.qtyShipDataGridViewTextBoxColumn,
            this.qtyBookingCfDataGridViewTextBoxColumn,
            this.qtyPendingDataGridViewTextBoxColumn});
            this.dataGridView4.DataSource = this.stsBindingSource;
            this.dataGridView4.Location = new System.Drawing.Point(12, 335);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.ReadOnly = true;
            this.dataGridView4.Size = new System.Drawing.Size(445, 82);
            this.dataGridView4.TabIndex = 6;
            // 
            // dataSet4
            // 
            this.dataSet4.DataSetName = "DataSet4";
            this.dataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // stsBindingSource
            // 
            this.stsBindingSource.DataMember = "Sts";
            this.stsBindingSource.DataSource = this.dataSet4;
            // 
            // stsTableAdapter
            // 
            this.stsTableAdapter.ClearBeforeFill = true;
            // 
            // brandDataGridViewTextBoxColumn
            // 
            this.brandDataGridViewTextBoxColumn.DataPropertyName = "Brand";
            this.brandDataGridViewTextBoxColumn.HeaderText = "Brand";
            this.brandDataGridViewTextBoxColumn.Name = "brandDataGridViewTextBoxColumn";
            this.brandDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // qtyShipDataGridViewTextBoxColumn
            // 
            this.qtyShipDataGridViewTextBoxColumn.DataPropertyName = "Qty Ship";
            this.qtyShipDataGridViewTextBoxColumn.HeaderText = "Qty Ship";
            this.qtyShipDataGridViewTextBoxColumn.Name = "qtyShipDataGridViewTextBoxColumn";
            this.qtyShipDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // qtyBookingCfDataGridViewTextBoxColumn
            // 
            this.qtyBookingCfDataGridViewTextBoxColumn.DataPropertyName = "Qty BookingCf";
            this.qtyBookingCfDataGridViewTextBoxColumn.HeaderText = "Qty BookingCf";
            this.qtyBookingCfDataGridViewTextBoxColumn.Name = "qtyBookingCfDataGridViewTextBoxColumn";
            this.qtyBookingCfDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // qtyPendingDataGridViewTextBoxColumn
            // 
            this.qtyPendingDataGridViewTextBoxColumn.DataPropertyName = "Qty pending";
            this.qtyPendingDataGridViewTextBoxColumn.HeaderText = "Qty pending";
            this.qtyPendingDataGridViewTextBoxColumn.Name = "qtyPendingDataGridViewTextBoxColumn";
            this.qtyPendingDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 439);
            this.Controls.Add(this.dataGridView4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form";
            this.Load += new System.EventHandler(this.Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shipmentSCMBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userNameBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.DataGridView dataGridView2;
		private DataSet1 dataSet1;
		private System.Windows.Forms.BindingSource userNameBindingSource;
		private DataSet1TableAdapters.User_nameTableAdapter user_nameTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usernameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn passwordDataGridViewTextBoxColumn;
        private DataSet3 dataSet3;
        private System.Windows.Forms.BindingSource shipmentSCMBindingSource;
        private DataSet3TableAdapters.Shipment_SCMTableAdapter shipment_SCMTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn linkDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView dataGridView3;
        private DataSet2 dataSet2;
        private System.Windows.Forms.BindingSource saleBindingSource;
        private DataSet2TableAdapters.SaleTableAdapter saleTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn targetDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn spanxDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn wacoalDataGridViewTextBoxColumn;
        private DataSet2TableAdapters.TableAdapterManager tableAdapterManager1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView4;
        private DataSet4 dataSet4;
        private System.Windows.Forms.BindingSource stsBindingSource;
        private DataSet4TableAdapters.StsTableAdapter stsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn brandDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyShipDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyBookingCfDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyPendingDataGridViewTextBoxColumn;
    }
}

