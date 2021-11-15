using System;
using System.Drawing;

namespace Kedust.UI.PrinterService.Helpers
{
    public static class PrintDocumentHelper
    {
        public static PrintDocumentWrapper NewLine(this PrintDocumentWrapper doc, float padding = 0)
        {
            doc.YOffset += doc.TempYOffset + padding;
            doc.TempYOffset = 0;
            return doc;
        }
        public static PrintDocumentWrapper PrintLine(this PrintDocumentWrapper doc)
        {
            doc.Graphics.DrawLine(new Pen(Color.Black), 0, doc.YOffset, doc.Width, doc.YOffset );
            doc.TempYOffset = Math.Max(5, doc.TempYOffset);
            return doc;
        }
        public static PrintDocumentWrapper PrintText(this PrintDocumentWrapper doc, string text, Font font,
            PrintDocumentWrapper.Alignment alignment = PrintDocumentWrapper.Alignment.Left, float padding = 0)
        {
            var fontSize = doc.Graphics.MeasureString(text, font);

            float x = 0;
            switch (alignment)
            {
                case PrintDocumentWrapper.Alignment.Left:
                    x = 0 + padding;
                    break;
                case PrintDocumentWrapper.Alignment.Middle:
                    x = doc.Width / 2 - fontSize.Width / 2;
                    break;
                case PrintDocumentWrapper.Alignment.Right:
                    x = doc.Width - fontSize.Width - padding;
                    break;
            }

            doc.Graphics.DrawString(text, font, new SolidBrush(Color.Black), x, doc.YOffset);
            doc.TempYOffset = Math.Max(doc.TempYOffset, fontSize.Height);
            return doc;
        }
        public static PrintDocumentWrapper PrintImage(this PrintDocumentWrapper doc, 
            Image img, PrintDocumentWrapper.Alignment alignment = PrintDocumentWrapper.Alignment.Left,
            float width = 0, float height = 0
        )
        {
            float x = 0;
            
            if (height == 0) height = img.Height;
            if (width == 0) width = img.Width;
            
            switch (alignment)
            {
                case PrintDocumentWrapper.Alignment.Left:
                    x = 0;
                    break;
                case PrintDocumentWrapper.Alignment.Middle:
                    x = doc.Width / 2 - width / 2f;
                    break;
                case PrintDocumentWrapper.Alignment.Right:
                    x = doc.Width - width;
                    break;
            }

            doc.Graphics.DrawImage(img, x , doc.YOffset, width, height);
            doc.TempYOffset = Math.Max(height, doc.TempYOffset);
            return doc;
        }

        public static (float height, float width) ResizeImage(this Image img, float maxHeight, float maxWidth)
        {
            float height = maxHeight;
            float width = Convert.ToInt32(img.Width * ((height * 1.0d) / img.Height));
            if (width > maxWidth)
            {
                width = maxWidth;
                height = Convert.ToInt32(img.Height * ((width * 1.0d) / img.Width));
            }
            return (height, width);
        }
    }
}