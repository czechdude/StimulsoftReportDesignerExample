New @ 17.07.2019:

Dictionary does not renew the Datasource
 
https://forum.stimulsoft.com/viewtopic.php?f=8&t=38579

Example report is in ReportDesignerExample\examplereports\ReportDictionary.mrt
it contains columns 'id' and 'name'

The code DataTable mock has only 'id'

By loading the report, the dictionary should be refreshed and contain only 'id' but it does not happen.

Method to start debugging is ReportDesigner.LoadStiReport


OLD as of 17.07.2019:

Minimal working example of our implementation of Stimulsoft Report Designer with custom datasource.

Our deprecated mrt is in ReportDesignerExample\examplereports\Report.mrt
It is converted to uptodate mrt when opened and tried to be reloaded when opened into the Designer.
Backup when converted is created.

Conversion is done because of nonexistent custom database definition.

1) loading via recent files works and no missing database is shown
(event handler LoadedReportFromRecent)
2) loading via Browse is not working correctly as 1)
(event handler LoadedReport)

My sight aims to e.Processed  property. Which does not exist in 2)


PS: don't forget to reload the Report.mrt.bak back to Report.mrt on each load.

For any further info please write to this forum thread:

https://forum.stimulsoft.com/viewtopic.php?f=8&t=55391&sid=9c63a66baa41f8acba14b340b1b6e935

or contact petr.divis@geocom.ch directly

Thank you