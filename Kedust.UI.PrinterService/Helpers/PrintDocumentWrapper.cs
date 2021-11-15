using System.Drawing;
using System.Drawing.Printing;

namespace Kedust.UI.PrinterService.Helpers
{
    public class PrintDocumentWrapper
    {
        public Graphics Graphics { get; }
        public float YOffset { get; set; }
        public float TempYOffset { get; set; }
        public float Width { get; }

        public PrintDocumentWrapper(PrintPageEventArgs printPageEventArgs)
        {
            Graphics = printPageEventArgs.Graphics;
            YOffset = 0;
            Width = printPageEventArgs.PageSettings.PrintableArea.Width;
        }
        
        public enum Alignment
        {
            Left = 1,
            Middle = 2,
            Right = 3
        }
    }
}