using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Build_IT_Reports
{
    class Program
    {
        public static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            Document document = new Document();
            Section section = document.AddSection();
            section.AddParagraph("Hello, World!");

            section.AddParagraph();

            Paragraph paragraph = section.AddParagraph();
            paragraph.Format.Font.Color = Color.FromCmyk(100, 30, 20, 50);
            paragraph.AddFormattedText("Hello, World!", TextFormat.Underline);

            FormattedText ft = paragraph.AddFormattedText("Small text",TextFormat.Bold);
            ft.Font.Size = 6;

            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(false);
            pdfRenderer.Document = document;
            pdfRenderer.RenderDocument();

            string filename = "HelloWorld.pdf";
            pdfRenderer.PdfDocument.Save(filename);
            Process.Start(filename);
        }
    }
}
