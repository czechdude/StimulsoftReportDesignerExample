using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using ReportDesignerExample.Forms;
using Stimulsoft.Report.Dictionary;

namespace ReportDesignerExample
{
    public class GReportAdapterService : StiUserAdapterService
    {
        private readonly ReportDesigner _reportMetadata;
        private Dictionary<string,DataTable> _dataTable = new Dictionary<string, DataTable>();


        /// <summary>
        /// Initializes a new instance of the <see cref="GReportAdapterService"/> class.
        /// </summary>
        /// <param name="reportMetadata">
        /// The Custom report reference
        /// </param>
        public GReportAdapterService(ReportDesigner reportMetadata)
        {
            this._reportMetadata = reportMetadata;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GReportAdapterService"/> class.
        /// </summary>
        public GReportAdapterService()
        {
            throw new NotImplementedException("Invalid call of GReportAdapterService!");
        }

        /// <summary>
        /// Gets the datasource service name.
        /// </summary>
        public override string ServiceName
        {
            get
            {
                return "GReportAdapterService";
            }
        }

        /// <summary>
        /// Returns a list of the possible datasources in the connection
        /// </summary>
        /// <returns></returns>
        public IList<string> GetDatasetList()
        {
            return new List<string>() { "first", "second" };
        }

        public DataTable CreateMockedDataTable(GReportDataSource customDataSource)
        {
            
            if (_dataTable.ContainsKey(customDataSource.Name))
                return _dataTable[customDataSource.Name];
            
            // create the .net dataset
            var dataTable = new DataTable(customDataSource.Name);

            dataTable.Columns.Add("id", typeof(int));
            dataTable.Columns.Add("name", typeof(string));

            var dataRow = dataTable.NewRow();
            dataRow["id"] = 1;
            dataRow["name"] = "First";
            dataTable.Rows.Add(dataRow);
            var dataRow2 = dataTable.NewRow();
            dataRow2["id"] = 2;
            dataRow2["name"] = "Second";
            dataTable.Rows.Add(dataRow2);
            dataTable.AcceptChanges();

            _dataTable.Add(customDataSource.Name, dataTable);

            return dataTable;
        }

        /// <summary>
        /// This method is invoked each time when the 
        /// stimulsoft datasource needs the data.
        /// </summary>
        /// <param name="dictionary">The dictionary.</param>
        /// <param name="dataSource">The data source.</param>
        /// <param name="loadData">The load data.</param>
        public override void ConnectDataSourceToData(StiDictionary dictionary, StiDataSource dataSource, bool loadData)
        {
            if (!loadData)
            {
                return;
            }

            GReportDataSource reportDataSource = dataSource as GReportDataSource;
            if (reportDataSource == null)
            {
                return;
            }
            dataSource.DataTable = CreateMockedDataTable(reportDataSource);
        }

        /// <summary>
        /// Get type of datasource
        /// </summary>
        /// <returns>type of datasource</returns>
        public override Type GetDataSourceType()
        {
            return typeof(GReportDataSource);
        }

        /// <summary>
        /// Invokes the table property page when editing the datasource
        /// </summary>
        /// <param name="dictionary">
        /// The dictionary.
        /// </param>
        /// <param name="dataSource">
        /// The data source.
        /// </param>
        /// <returns>
        /// Always true
        /// </returns>
        public override bool Edit(StiDictionary dictionary, StiDataSource dataSource)
        {
            var customDatasource = (GReportDataSource)dataSource;
            var previousName = customDatasource.Name;
            var prevTablename = customDatasource.SourceTablename;
            var prevFilter = customDatasource.Filter;
            var prevKeyField = customDatasource.KeyField;

            using (var form = new GReportFormTableProperties(dictionary, customDatasource, false))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // change datasource name, if not equal to old name
                    if (!previousName.Equals(form.DatasourceName, StringComparison.InvariantCultureIgnoreCase))
                    {
                        customDatasource.Name = form.DatasourceName;
                    }

                    if (!prevKeyField.Equals(form.KeyField, StringComparison.InvariantCultureIgnoreCase))
                    {
                        customDatasource.KeyField = form.KeyField;
                    }

                    if (!prevFilter.Equals(form.Filter, StringComparison.InvariantCultureIgnoreCase))
                    {
                        customDatasource.Filter = form.Filter;
                    }

                    // update datasource (or add, if not there yet)
                    if (dictionary.DataSources.Contains(form.DatasourceName))
                    {
                        dictionary.DataSources[form.DatasourceName] = customDatasource;
                    }
                    else
                    {
                        dictionary.DataSources.Add(customDatasource);
                    }

                    // if data-table name part of the alias has changed, attempt to reload the columns
                    if (!prevTablename.Equals(form.SourceTablename, StringComparison.InvariantCultureIgnoreCase))
                    {
                        customDatasource.SourceTablename = form.SourceTablename;
                        UpdateColumnDefinition(customDatasource);
                    }
                    return true;
                }
                return false;
            }
        }

        private void UpdateColumnDefinition(GReportDataSource customDatasource)
        {
            DataTable table = CreateMockedDataTable(customDatasource);
            ClearSourceColumns(customDatasource);
            foreach (DataColumn column in table.Columns)
            {
                var stiColumn = new StiDataColumn(column.ColumnName, column.DataType);
                customDatasource.Columns.Add(stiColumn);
            }
        }

        private static void ClearSourceColumns(GReportDataSource customDatasource)
        {
            for (int index = customDatasource.Columns.Count - 1; index >= 0; index--)
            {
                StiDataColumn column = customDatasource.Columns[index];
                if (column.GetType() != typeof(StiCalcDataColumn))
                    customDatasource.Columns.Remove(column);
            }
        }

        /// <summary>
        /// Invokes the table property page when creating the datasource
        /// </summary>
        /// <param name="dictionary"> The dictionary. </param>
        /// <param name="dataSource"> The data source. </param>
        /// <returns> Always true </returns>
        public override bool New(StiDictionary dictionary, StiDataSource dataSource)
        {
            var customDatasource = (GReportDataSource)dataSource;

            using (var form = new GReportFormTableProperties(dictionary, customDatasource, true))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    customDatasource.Name = form.DatasourceName;
                    customDatasource.SourceTablename = form.SourceTablename;
                    customDatasource.KeyField = form.KeyField;
                    customDatasource.Filter = form.Filter;
                    customDatasource.NameInSource = form.SourceTablename;

                    // update datasource (or add, if not there yet)
                    if (dictionary.DataSources.Contains(form.DatasourceName))
                    {
                        dictionary.DataSources[form.DatasourceName] = customDatasource;
                    }
                    else
                    {
                        dictionary.DataSources.Add(customDatasource);
                    }

                    UpdateColumnDefinition(customDatasource);
                    return true;
                }
                return false;
            }
        }

    }
}