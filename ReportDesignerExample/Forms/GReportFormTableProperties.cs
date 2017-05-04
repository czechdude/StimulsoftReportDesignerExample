using System;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Windows.Forms;


using Stimulsoft.Report.Dictionary;

namespace ReportDesignerExample.Forms
{
	/// <summary>
	/// This form shws the datasource properties dialog
	/// </summary>
	public partial class GReportFormTableProperties : Form
	{
        /// <summary>
        /// Holds the name of the datasource as entered by the user. This property gets set when the user 
        /// clicks Ok
        /// </summary>
        public string DatasourceName { get; private set; }
        /// <summary>
        /// Holds the selected table datasource. This property gets generated once the user 
        /// clicks Ok
        /// </summary>
        public string SourceTablename { get; private set; }
		/// <summary>
		/// Gets the filter.
		/// </summary>
		/// <value>
		/// The filter.
		/// </value>
        public string Filter { get; private set; }
		/// <summary>
		/// Gets the key field.
		/// </summary>
		/// <value>
		/// The key field.
		/// </value>
        public string KeyField { get; private set; }

		private readonly GReportDataSource _dataSource;
        private DataTable _dataTable;
        
		/// <summary>
		/// Initializes a new instance of the <see cref="GReportFormTableProperties"/> class.
		/// </summary>
		/// <param name="rptDatasources"> The dictionary </param>
		/// <param name="dataSource"> the data source </param>
		/// <param name="isNew"> specify if a new datasource should be created </param>
		public GReportFormTableProperties(StiDictionary rptDatasources, GReportDataSource dataSource, bool isNew)
		{
			this.InitializeComponent();
			this.Localize();
            DialogResult = DialogResult.Cancel;
			Cursor.Current = Cursors.WaitCursor;

			this._dataSource = dataSource;

			GReportAdapterService adapter = this._dataSource.GetDataAdapter() as GReportAdapterService;
			foreach (string ds in adapter.GetDatasetList())
			{
                datasourceList.Items.Add(ds);
			}

			if (isNew)
			{
				this.datasourceList.SelectedItem = -1;
				this.txtSourceName.Text = this._dataSource.Name;
			}
			else
			{
				this.txtSourceName.Text = this._dataSource.Name;

				string tableName = this._dataSource.SourceTablename;
                string keyField = this._dataSource.KeyField;
                
                // add where clause
			    this.txtWhere.Text = this._dataSource.Filter;

				// select table name fromcombobox
				foreach (var item in this.datasourceList.Items)
				{
					if (item.ToString().Equals(tableName, StringComparison.InvariantCultureIgnoreCase))
					{
						this.datasourceList.SelectedItem = item;
						break;
					}
				}
                if(this.datasourceList.SelectedItem == null)
                {
                    this.datasourceList.Text = tableName;
                }

                // apply key field
                foreach (var item in this.keyFieldList.Items)
                {
                    if (item.ToString().Equals(keyField, StringComparison.InvariantCultureIgnoreCase))
                    {
                        this.keyFieldList.SelectedItem = item;
                        break;
                    }
                }
                if (this.keyFieldList.SelectedItem == null)
                {
                    this.keyFieldList.Text = keyField;
                }

			}
			Cursor.Current = Cursors.Default;
		}

		private void Localize()
		{
			this.btnOk.Text = "Ok";
            this.btnCancel.Text = "Cancel";
			this.Text = "DatasourceDialogTitle";
			this.lblWhere.Text = "Filter";
            this.btnReadTable.Text = "ReadTableContent";
			this.lblTableName.Text = "Tablename";
			this.lblDatasourceName.Text = "DatasourceName";
			this.lblKeyField.Text = "KeyField";
		}

		private void ApplyValues()
		{

		    this.Filter = this.txtWhere.Text;
		    this.KeyField = this.keyFieldList.Text;
            this.DatasourceName = this.txtSourceName.Text;
            this.SourceTablename = this.datasourceList.Text;
		}

	    private void DoneButtonClicked(object sender, EventArgs e)
		{
			this.ApplyValues();
            DialogResult = DialogResult.OK;
			this.Close();
		}

		private void ReadTableButtonClicked(object sender, EventArgs e)
		{
            ApplyValues();
		    ReadTable();
		}

	    private void ReadTable(bool readContent = true)
	    {
            if (string.IsNullOrEmpty(this.datasourceList.Text))
            {
                MessageBox.Show("WarnNoTablenameSpecified");
                return;
            }

            this.ApplyValues();

            var adapter = this._dataSource.GetDataAdapter() as GReportAdapterService;

            if (adapter == null)
            {
                return;
            }

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                try
                {
                    // Create temporary datasource
                    var source = new GReportDataSource(datasourceList.Text, "temporaryDS")
                    {
                        KeyField = this.keyFieldList.Text,
                        Filter = this.txtWhere.Text,
                        SourceTablename = this.datasourceList.Text,
                    };
                    // Load table
                    this.keyFieldList.Items.Clear();

                    if (readContent)
                    {
                        _dataTable = adapter.CreateMockedDataTable(source);

                        // switch off autosizing (it's extremly slow and causes all cell values to be read
                        // even in virtual grid mode.
                        gridDataPreview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                        gridDataPreview.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                        gridDataPreview.ColumnCount = _dataTable.Columns.Count;
                        gridDataPreview.RowCount = _dataTable.Rows.Count;
                        
                        // create col headers
                        for (int colIndex = 0; colIndex < _dataTable.Columns.Count; colIndex++)
                        {
                            gridDataPreview.Columns[colIndex].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                            gridDataPreview.Columns[colIndex].HeaderText = _dataTable.Columns[colIndex].ColumnName;
                        }
                    }
                    else
                    {
                        _dataTable = adapter.CreateMockedDataTable(source);
                    }
                    foreach (DataColumn column in _dataTable.Columns)
                    {
                        this.keyFieldList.Items.Add(column.ColumnName);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("WarnNoDataRetrieved",e.Message,MessageBoxButtons.OK,MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
	    }

	    private void ReadColumns(bool readContent = false)
		{
           ReadTable(false);
		}

		private void GReportFormTablePropertiesLoad(object sender, EventArgs e)
		{
			if (this._dataSource.Alias.StartsWith("DataSource") || this._dataSource.Alias.StartsWith("SourceDe")
				|| this._dataSource.Alias.StartsWith("OrigineDati") || this._dataSource.Alias.StartsWith("Datenquelle"))
			{
				this._dataSource.Alias = string.Empty;
			}
		}

		private void datasourceList_SelectedIndexChanged(object sender, EventArgs e)
		{
		    keyFieldList.Text = string.Empty; 
			ReadColumns();
		    if (_dataTable != null)
		    {
		        if (FindColumnByName(_dataTable, "id") != null)
		            keyFieldList.Text = "id";
                
            }
        }

	    private DataColumn FindColumnByName(DataTable table, string columnName)
	    {
            if ((table == null) || (string.IsNullOrWhiteSpace(columnName)))
                return null;

	        foreach (DataColumn column in table.Columns)
	        {
	            if (string.Equals(columnName, column.ColumnName, StringComparison.OrdinalIgnoreCase))
	                return column;
	        }
            return null;
	    }

        private void BtnCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridDataPreview_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (_dataTable != null)
            {
                e.Value = _dataTable.Rows[e.RowIndex][e.ColumnIndex];
            }
        }
	}
}