using System;
using System.ComponentModel;
using Stimulsoft.Base.Serializing;
using Stimulsoft.Report;
using Stimulsoft.Report.Dictionary;

namespace ReportDesignerExample
{
    public class GReportDataSource : StiUserSource, IGReportDataSource
    {

        #region Custom datasource properties

        private string _datasourceName;
        private string _filter;
        private string _keyField;

        #endregion


        #region DataAdapter

        /// <summary>
        /// Gets the data adapter.
        /// </summary>
        /// <returns></returns>
        public override StiDataAdapterService GetDataAdapter()
        {
            var svc = StiOptions.Services.DataAdapters.Find(x => x is GReportAdapterService);
            return svc;
        }

        /// <summary>
        /// Gets the adapter service name
        /// </summary>
        protected override string DataAdapterType
        {
            get
            {
                return typeof(GReportAdapterService).FullName;
            }
        }

        /// <inheritdoc />
        public override string GetCategoryName()
        {
            return "Custom";
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GReportDataSource"/> class.
        /// </summary>
        public GReportDataSource()
        {
            this.Alias = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GReportDataSource"/> class.
        /// </summary>
        /// <param name="nameInSource">name in data datasource</param>
        /// <param name="name">the name</param>
        public GReportDataSource(string nameInSource, string name)
            : base(nameInSource, name)
        {
            this.Alias = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GReportDataSource"/> class.
        /// </summary>
        /// <param name="nameInSource">name in data datasource</param>
        /// <param name="name">the name</param>
        /// <param name="alias">alias usage is overriden, this alias is not used</param>
        public GReportDataSource(string nameInSource, string name, string alias)
            : base(nameInSource, name, string.Empty)
        {
            this.Alias = alias;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GReportDataSource" /> class.
        /// </summary>
        /// <param name="nameInSource">name in data datasource</param>
        /// <param name="name">the name</param>
        /// <param name="alias">alias usage is overriden, this alias is not used</param>
        /// <param name="key">The key of the database object.</param>
        public GReportDataSource(string nameInSource, string name, string alias, string key)
            : base(nameInSource, name, string.Empty, key)
        {
            this.Alias = alias;
        }



        #endregion

        #region Implementation of IGReportDataSource

        /// <inheritdoc />
        [Browsable(false)]
        public string DatasourceInformationAsString
        {
            get { return String.Format("{0}", SourceTablename); }
        }

        #endregion

        #region Convert helpers for legacy (alias-based) configurations

        private void ConvertAliasToProperties()
        {
            // check if the alias could be a custom config alias (for old datasources)
            if ((Alias.Length > 0) && (Alias.Contains(";")))
            {
                _datasourceName = GetTableName();
                _filter = GetFilter();
                _keyField = GetKeyField();
                Alias = String.Empty; // clear alias after conversion
            }
        }

        private string GetTableName()
        {
            return GetValueFromAlias(0);
        }

        private string GetFilter()
        {
            return GetValueFromAlias(1);
        }

        private string GetKeyField()
        {
            string keyFieldName = GetValueFromAlias(2);

            // backwards compability: in old reports, if key field not filled, use object id
            return string.IsNullOrEmpty(keyFieldName) ? "id" : keyFieldName;
        }

        private string GetValueFromAlias(int index)
        {
            string[] splittedAlias = this.Alias.Split(';');

            if (splittedAlias.Length <= index)
                return string.Empty;

            return splittedAlias[index];
        }

        #endregion

        /// <summary>
        /// Gets the source tablename.
        /// </summary>
        /// <value>
        /// The source tablename.
        /// </value>
        [StiSerializable]
        public string SourceTablename
        {
            get
            {
                ConvertAliasToProperties(); // convert legacy configuration
                return _datasourceName;
            }
            internal set { _datasourceName = value; }
        }

        /// <summary>
        /// Gets the filter.
        /// </summary>
        /// <value>
        /// The filter.
        /// </value>
        [StiSerializable]
        public string Filter
        {
            get
            {
                ConvertAliasToProperties(); // convert legacy configuration
                return _filter;
            }
            internal set { _filter = value; }
        }

        /// <summary>
        /// Gets the key field.
        /// </summary>
        /// <value>
        /// The key field.
        /// </value>
        [StiSerializable]
        public string KeyField
        {
            get
            {
                ConvertAliasToProperties(); // convert legacy configuration
                return _keyField;
            }
            internal set { _keyField = value; }
        }
    }
}