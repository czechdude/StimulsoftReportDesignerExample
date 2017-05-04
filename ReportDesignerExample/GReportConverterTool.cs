using System.IO;
using System.Xml;

namespace ReportDesignerExample
{
    public class GReportConverterTool
    {
        public static bool IsOldReport(string sourceFileName)
        {
            string xmlContent = File.ReadAllText(sourceFileName);

            if (!xmlContent.Contains("GReportDatabase"))
            {
                return false;
            }

            return true;
        }

        public static void Convert(string sourceFile)
        {
            File.Copy(sourceFile,sourceFile+".bak");
            XmlDocument doc = new XmlDocument();
            doc.Load(sourceFile);

            //remove databases
            XmlNodeList nodes = doc.SelectNodes("//Custom[@type='ReportDesignerExample.GReportDatabase']");
            for (int i = 0; i < nodes.Count; i++)
            {
                nodes[i].ParentNode.RemoveChild(nodes[i]);
            }

            //corect database count after removal
            XmlNode node = doc.SelectSingleNode("//Databases");
            if (!string.IsNullOrEmpty(node?.Attributes?["count"].Value))
            {
                node.Attributes["count"].Value = node.ChildNodes.Count.ToString();
                if (node.ChildNodes.Count == 0)
                {
                    node.ParentNode.RemoveChild(node);
                }
            }

            //change element value in datasources
            XmlNodeList dataSourceNodes = doc.SelectNodes("//DataSources/*[@type='ReportDesignerExample.GReportDataSource']");
            for (int i = 0; i < dataSourceNodes.Count; i++)
            {
                var nameInSource = dataSourceNodes[i].SelectSingleNode("NameInSource");
                var sourceTable = dataSourceNodes[i].SelectSingleNode("SourceTablename");
                if (nameInSource != null && sourceTable != null)
                {
                    nameInSource.InnerText = sourceTable.InnerText;
                }
            }

            doc.Save(sourceFile);
        }
    }
}