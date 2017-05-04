namespace ReportDesignerExample
{
    /// <summary>
    /// Marker interface to identify custom datasources.
    /// </summary>
    public interface IGReportDataSource
    {
        /// <summary>
        /// Get information about this datasource a string
        /// </summary>
        string DatasourceInformationAsString { get; }
    }
}