using System.Drawing;
using ReportDesignerExample.Properties;
using Stimulsoft.Base.Drawing;
using Stimulsoft.Base.Services;
using Stimulsoft.Report.Components;
using Stimulsoft.Report.Components.Design;

namespace ReportDesignerExample
{
    [StiServiceBitmap(typeof(GReportMapComponent), "ReportDesignerExample.Resources.MapComponent16.png")]
    [StiToolbox(true)]
    [StiContextTool(typeof(IStiShift))]
    [StiContextTool(typeof(IStiGrowToHeight))]
    [StiDesigner(typeof(MapComponentDesigner))]
    public class GReportMapComponent : StiView, IStiSuperToolTipLocalization
    {
        public GReportMapComponent() : this(RectangleD.Empty)
        {
        }

        public GReportMapComponent(RectangleD o) : base(o)
        {
        }

        public override byte[] GetImageFromSource()
        {
            var image = Image.FromFile("../../avatar.jpg");
            ImageConverter imageConverter = new ImageConverter();
            byte[] xByte = (byte[])imageConverter.ConvertTo(image, typeof(byte[]));
            return xByte;
        }
        /// <summary>
        /// Gets ToolboxPosition.
        /// </summary>
        public override int ToolboxPosition => 500;

        /// <summary>
        /// Gets LocalizedCategory.
        /// </summary>
        public override string LocalizedCategory => "Components";

        /// <summary>
        /// Gets LocalizedName.
        /// </summary>
        public override string LocalizedName => "GEONIS Map";

        public string SuperTooltipText => "ReportMapComponentTooltip";

        /// <inheritdoc />
        public Image SuperTooltipImage => Resources.MapComponent16;
    }
}