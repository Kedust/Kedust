using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using Kedust.Services.DTO;
using Kedust.UI.PrinterService.Helpers;

namespace Kedust.UI.PrinterService.TicketDefinitions
{
    public class OrderTicket
    {
        private Font FontTable = new Font("Arial", 15);
        private Font FontOrderLines = new Font("Arial", 10);
        private Font FontOrderLinesHeader = new Font("Arial", 10, FontStyle.Bold);

        public void Print(string printerName, OrderForPrinting order)
        {
            PrinterSettings printer = new PrinterSettings
            {
                PrinterName = printerName
            };
            using PrintDocument printDoc = new PrintDocument();
            printDoc.PrinterSettings = printer;
            printDoc.DefaultPageSettings.PaperSize = printDoc.PrinterSettings.PaperSizes[6];
            printDoc.PrintPage += (_, eventArgs) => OnPrintDocOnPrintPage(eventArgs, order);
            printDoc.Print();
        }

        private void OnPrintDocOnPrintPage(PrintPageEventArgs eventArgs, OrderForPrinting order)
        {
            if (eventArgs.Graphics == null) return;

            var padding = eventArgs.Graphics.MeasureString("00000", FontOrderLines);

            PrintDocumentWrapper wrapper = new PrintDocumentWrapper(eventArgs);
            //header
            Assembly myAssembly = Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream("Kedust.UI.PrinterService.img.kedust-full.jpg");
            Image image = Image.FromStream(myStream);
            var size = image.ResizeImage(75, wrapper.Width);
            wrapper
                .PrintImage(image, PrintDocumentWrapper.Alignment.Middle, size.width, size.height)
                .NewLine(10)
                //type ticket
                .PrintText("Bestelling", FontTable, PrintDocumentWrapper.Alignment.Middle)
                .NewLine()
                //table
                .PrintText(order.Table.Description, FontTable, PrintDocumentWrapper.Alignment.Middle)
                .NewLine()
                //time
                .PrintText(order.TimeOrderPlaced.ToString("g"), FontOrderLines, PrintDocumentWrapper.Alignment.Middle)
                .NewLine()
                //title
                .PrintText("#", FontOrderLinesHeader)
                .PrintText("Item", FontOrderLinesHeader, padding: padding.Width)
                .PrintText("Prijs", FontOrderLinesHeader, PrintDocumentWrapper.Alignment.Right)
                .NewLine()
                .PrintLine();

            order.OrderItems.ForEach(oi =>
            {
                wrapper
                    .PrintText(oi.Amount.ToString(), FontOrderLines)
                    .PrintText(oi.Name, FontOrderLines, padding: padding.Width)
                    .PrintText(oi.Price.ToString(CultureInfo.InvariantCulture), FontOrderLines,
                        PrintDocumentWrapper.Alignment.Right)
                    .NewLine();
            });

            wrapper
                .PrintLine()
                .PrintText("Totaal", FontOrderLinesHeader)
                .PrintText(text: order.OrderItems.Sum(x => x.Price * x.Amount).ToString(CultureInfo.InvariantCulture),
                    FontOrderLinesHeader,
                    PrintDocumentWrapper.Alignment.Right)
                .NewLine(20)
                .PrintText("Dankuwel!", FontOrderLinesHeader, PrintDocumentWrapper.Alignment.Middle);
        }
    }
}