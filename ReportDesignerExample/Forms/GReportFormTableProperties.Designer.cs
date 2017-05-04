namespace ReportDesignerExample.Forms
{
	partial class GReportFormTableProperties
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
			if (disposing && (this.components != null))
			{
				this.components.Dispose();
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GReportFormTableProperties));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.keyFieldList = new System.Windows.Forms.ComboBox();
            this.datasourceList = new System.Windows.Forms.ComboBox();
            this.txtSourceName = new System.Windows.Forms.TextBox();
            this.lblDatasourceName = new System.Windows.Forms.Label();
            this.txtWhere = new System.Windows.Forms.TextBox();
            this.lblKeyField = new System.Windows.Forms.Label();
            this.lblTableName = new System.Windows.Forms.Label();
            this.lblWhere = new System.Windows.Forms.Label();
            this.btnReadTable = new System.Windows.Forms.Button();
            this.gridDataPreview = new System.Windows.Forms.DataGridView();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDataPreview)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.keyFieldList);
            this.groupBox1.Controls.Add(this.datasourceList);
            this.groupBox1.Controls.Add(this.txtSourceName);
            this.groupBox1.Controls.Add(this.lblDatasourceName);
            this.groupBox1.Controls.Add(this.txtWhere);
            this.groupBox1.Controls.Add(this.lblKeyField);
            this.groupBox1.Controls.Add(this.lblTableName);
            this.groupBox1.Controls.Add(this.lblWhere);
            this.groupBox1.Location = new System.Drawing.Point(12, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(522, 153);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // keyFieldList
            // 
            this.keyFieldList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.keyFieldList.FormattingEnabled = true;
            this.keyFieldList.Location = new System.Drawing.Point(152, 66);
            this.keyFieldList.Name = "keyFieldList";
            this.keyFieldList.Size = new System.Drawing.Size(364, 21);
            this.keyFieldList.TabIndex = 11;
            this.keyFieldList.Text = "id";
            // 
            // datasourceList
            // 
            this.datasourceList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datasourceList.FormattingEnabled = true;
            this.datasourceList.Location = new System.Drawing.Point(152, 38);
            this.datasourceList.Name = "datasourceList";
            this.datasourceList.Size = new System.Drawing.Size(364, 21);
            this.datasourceList.TabIndex = 1;
            this.datasourceList.SelectedIndexChanged += new System.EventHandler(this.datasourceList_SelectedIndexChanged);
            // 
            // txtSourceName
            // 
            this.txtSourceName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSourceName.Location = new System.Drawing.Point(152, 13);
            this.txtSourceName.Name = "txtSourceName";
            this.txtSourceName.Size = new System.Drawing.Size(364, 20);
            this.txtSourceName.TabIndex = 0;
            // 
            // lblDatasourceName
            // 
            this.lblDatasourceName.AutoSize = true;
            this.lblDatasourceName.Location = new System.Drawing.Point(6, 16);
            this.lblDatasourceName.Name = "lblDatasourceName";
            this.lblDatasourceName.Size = new System.Drawing.Size(93, 13);
            this.lblDatasourceName.TabIndex = 8;
            this.lblDatasourceName.Text = "Datasource name:";
            // 
            // txtWhere
            // 
            this.txtWhere.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWhere.Location = new System.Drawing.Point(152, 93);
            this.txtWhere.Multiline = true;
            this.txtWhere.Name = "txtWhere";
            this.txtWhere.Size = new System.Drawing.Size(364, 54);
            this.txtWhere.TabIndex = 10;
            // 
            // lblKeyField
            // 
            this.lblKeyField.AutoSize = true;
            this.lblKeyField.Location = new System.Drawing.Point(6, 69);
            this.lblKeyField.Name = "lblKeyField";
            this.lblKeyField.Size = new System.Drawing.Size(50, 13);
            this.lblKeyField.TabIndex = 2;
            this.lblKeyField.Text = "Key field:";
            // 
            // lblTableName
            // 
            this.lblTableName.AutoSize = true;
            this.lblTableName.Location = new System.Drawing.Point(6, 41);
            this.lblTableName.Name = "lblTableName";
            this.lblTableName.Size = new System.Drawing.Size(77, 13);
            this.lblTableName.TabIndex = 2;
            this.lblTableName.Text = "Table name:";
            // 
            // lblWhere
            // 
            this.lblWhere.AutoSize = true;
            this.lblWhere.Location = new System.Drawing.Point(6, 96);
            this.lblWhere.Name = "lblWhere";
            this.lblWhere.Size = new System.Drawing.Size(29, 13);
            this.lblWhere.TabIndex = 7;
            this.lblWhere.Text = "Filter";
            // 
            // btnReadTable
            // 
            this.btnReadTable.Location = new System.Drawing.Point(5, 10);
            this.btnReadTable.Name = "btnReadTable";
            this.btnReadTable.Size = new System.Drawing.Size(127, 23);
            this.btnReadTable.TabIndex = 3;
            this.btnReadTable.Text = "Load Table";
            this.btnReadTable.UseVisualStyleBackColor = true;
            this.btnReadTable.Click += new System.EventHandler(this.ReadTableButtonClicked);
            // 
            // gridDataPreview
            // 
            this.gridDataPreview.AllowUserToAddRows = false;
            this.gridDataPreview.AllowUserToDeleteRows = false;
            this.gridDataPreview.AllowUserToOrderColumns = true;
            this.gridDataPreview.AllowUserToResizeRows = false;
            this.gridDataPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridDataPreview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gridDataPreview.CausesValidation = false;
            this.gridDataPreview.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridDataPreview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridDataPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.NullValue = "<null>";
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridDataPreview.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridDataPreview.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridDataPreview.Location = new System.Drawing.Point(6, 35);
            this.gridDataPreview.MultiSelect = false;
            this.gridDataPreview.Name = "gridDataPreview";
            this.gridDataPreview.ReadOnly = true;
            this.gridDataPreview.RowHeadersVisible = false;
            this.gridDataPreview.RowTemplate.DefaultCellStyle.NullValue = "<null>";
            this.gridDataPreview.RowTemplate.Height = 17;
            this.gridDataPreview.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gridDataPreview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridDataPreview.ShowCellErrors = false;
            this.gridDataPreview.ShowEditingIcon = false;
            this.gridDataPreview.Size = new System.Drawing.Size(510, 129);
            this.gridDataPreview.TabIndex = 4;
            this.gridDataPreview.VirtualMode = true;
            this.gridDataPreview.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.gridDataPreview_CellValueNeeded);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(378, 340);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.DoneButtonClicked);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(459, 340);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnReadTable);
            this.groupBox2.Controls.Add(this.gridDataPreview);
            this.groupBox2.Location = new System.Drawing.Point(12, 164);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(522, 170);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            // 
            // GReportFormTableProperties
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(546, 373);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(562, 411);
            this.Name = "GReportFormTableProperties";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Custom Table";
            this.Load += new System.EventHandler(this.GReportFormTablePropertiesLoad);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDataPreview)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnReadTable;
		private System.Windows.Forms.DataGridView gridDataPreview;
        private System.Windows.Forms.Label lblTableName;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Label lblWhere;
		private System.Windows.Forms.TextBox txtWhere;
		private System.Windows.Forms.TextBox txtSourceName;
        private System.Windows.Forms.Label lblDatasourceName;
		private System.Windows.Forms.Label lblKeyField;
		private System.Windows.Forms.ComboBox datasourceList;
        private System.Windows.Forms.ComboBox keyFieldList;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox2;
	}
}