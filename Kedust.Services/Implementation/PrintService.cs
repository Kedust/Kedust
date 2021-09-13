using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Kedust.Data.Domain;
using Microsoft.Extensions.Configuration;

namespace Kedust.Services.Implementation
{
    public class PrintService : IPrintService
    {
        private const string FontTitle = "Cambria Math";
        private const int PageWidth = 280;

        private readonly PrinterConfiguration _printerConfig;
        public PrintService(IConfiguration configuration)
        {
            _printerConfig = new PrinterConfiguration();
            configuration.Bind("PrinterConfiguration", _printerConfig);
        }

        public Task PrintOrderTicket(Order order)
        {
            PrinterSettings printer = new PrinterSettings();
            printer.PrinterName = _printerConfig.PrinterName;

            if (printer.IsValid)
            {
                using (PrintDocument printDoc = new PrintDocument())
                {
                    printDoc.PrinterSettings = printer;
                    printDoc.PrintPage += (_, eventArgs) => OnPrintDocOnPrintPage(eventArgs, order);
                    printDoc.Print();
                }
            }

            return Task.CompletedTask;
        }

        private static void OnPrintDocOnPrintPage(PrintPageEventArgs eventArgs, Order order)
        {
            var g = eventArgs.Graphics;
            if (g == null) return;

            var yOffset = 0;

            //Image
            Image image = Image.FromFile(@"C:\Users\BerndDeBaere\Desktop\kedust-full.jpg");
            var size = ResizeImage(image, PageWidth, 100);
            PrintCenterAlignImage(image, g, yOffset, PageWidth, size.width, size.height);
            yOffset += size.height;

            //Blank space
            yOffset += 10;

            //Line
            g.DrawLine(Pens.Black, 0, yOffset, PageWidth, yOffset);

            //Blank space
            yOffset += 10;

            //Table
            yOffset += PrintHeader(order, g, yOffset);

            //Blank space
            yOffset += 10;

            g.DrawLine(Pens.Black, 0, yOffset, PageWidth, yOffset);

            yOffset += 10;

            foreach (var orderLine in order.OrderItems)
            {
                yOffset += PrintOrderLine(orderLine, g, yOffset);
            }


            g.DrawLine(Pens.Black, 0, yOffset, PageWidth, yOffset);
            yOffset += 10;

            yOffset += PrintTotalLine(order, g, yOffset);
        }

        private static int PrintOrderLine(OrderItem line, Graphics g, int offset)
        {
            var fontSize1 = g.MeasureString("00", new Font(FontTitle, 12));

            g.DrawString(line.Amount.ToString(), new Font(FontTitle, 12), new SolidBrush(Color.Black), 0, offset);

            g.DrawString(line.Choice.Name, new Font(FontTitle, 12), new SolidBrush(Color.Black), fontSize1.Width,
                offset);

            var fontSize2 = g.MeasureString($"{line.Amount * line.Choice.Price:0.00}", new Font(FontTitle, 12));
            g.DrawString($"{line.Amount * line.Choice.Price:0.00}", new Font(FontTitle, 12),
                new SolidBrush(Color.Black), PageWidth - fontSize2.Width, offset);

            return Convert.ToInt32(fontSize1.Height);
        }

        private static int PrintTotalLine(Order order, Graphics g, int offset)
        {
            g.DrawString("Totaal", new Font(FontTitle, 12, FontStyle.Bold), new SolidBrush(Color.Black), 0, offset);

            var fontSize2 = g.MeasureString($"{order.OrderItems.Sum(oi => oi.Amount * oi.Choice.Price):0.00}",
                new Font(FontTitle, 12, FontStyle.Bold));
            g.DrawString($"{order.OrderItems.Sum(oi => oi.Amount * oi.Choice.Price):0.00}",
                new Font(FontTitle, 12, FontStyle.Bold),
                new SolidBrush(Color.Black), PageWidth - fontSize2.Width, offset);

            return Convert.ToInt32(fontSize2.Height);
        }

        private static int PrintHeader(Order order, Graphics g, int offset)
        {
            var textSize1 = g.MeasureString("Tafel: " + order.Table.Description, new Font(FontTitle, 20));

            g.DrawString(
                "Tafel: " + order.Table.Description,
                new Font(FontTitle, 20),
                new SolidBrush(Color.Black),
                PageWidth / 2.0f - textSize1.Width / 2.0f,
                offset);

            var textSize2 = g.MeasureString(order.TimeOrderPlaced.ToString("dd-MM-yyyy HH:mm:ss"),
                new Font(FontTitle, 10));
            g.DrawString(
                order.TimeOrderPlaced.ToString("dd-MM-yyyy HH:mm:ss"),
                new Font(FontTitle, 10),
                new SolidBrush(Color.Black),
                PageWidth / 2.0f - textSize2.Width / 2.0f,
                offset + textSize1.Height);

            return Convert.ToInt32(textSize1.Height + textSize2.Height);
        }

        private static void PrintCenterAlignImage(Image img, Graphics g, int offset, int pageWidth, int width,
            int height)
        {
            g.DrawImage(img, Convert.ToInt32(pageWidth / 2.0d - width / 2.0d), offset, width, height);
        }

        private static (int width, int height) ResizeImage(Image image, int maxWidth, int maxHeight)
        {
            int height = maxHeight;
            int width = Convert.ToInt32(image.Width * ((height * 1.0d) / image.Height));
            if (width > maxWidth)
            {
                width = maxWidth;
                height = Convert.ToInt32(image.Height * ((width * 1.0d) / image.Width));
            }

            return (width, height);
        }
    }
}