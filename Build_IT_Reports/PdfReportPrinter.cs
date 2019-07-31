//using Build_IT_Reports.Interfaces;
//using Build_IT_Reports.Models;
using Build_IT_Reports.Models;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.DocumentObjectModel.Tables;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml;
using System.Xml.XPath;

namespace Build_IT_Reports
{
    public class PdfReportPrinter //: IReportPrinter
    {
        private Document _document;
       private TextFrame _dataFrame;
        private Report _report;

        public PdfReportPrinter(Report report)
        {
            _report = report;
        }

        public Document CreateDocument()
        {
            _document = new Document();
            _document.Info.Title = _report.Title;
            _document.Info.Subject = _report.Document;
            _document.Info.Author = _report.Author;

            DefineStyles();
            CreatePage();
            FillContent();

            return _document;
        }

        void DefineStyles()
        {
            var style = _document.Styles["Normal"];
            // Because all styles are derived from Normal, the next line changes the 
            // font of the whole document. Or, more exactly, it changes the font of
            // all styles and paragraphs that do not redefine the font.
            style.Font.Name = "Segoe UI";

            style = _document.Styles[StyleNames.Header];
            style.ParagraphFormat.AddTabStop("16cm", TabAlignment.Right);

            style = _document.Styles[StyleNames.Footer];
            style.ParagraphFormat.AddTabStop("8cm", TabAlignment.Center);

            // Create a new style called Table based on style Normal.
            style = _document.Styles.AddStyle("Table", "Normal");
            style.Font.Name = "Segoe UI Semilight";
            style.Font.Size = 9;

            // Create a new style called Title based on style Normal.
            style = _document.Styles.AddStyle("Title", "Normal");
            style.Font.Name = "Segoe UI Semibold";
            style.Font.Size = 9;

            // Create a new style called Reference based on style Normal.
            style = _document.Styles.AddStyle("Reference", "Normal");
            style.ParagraphFormat.SpaceBefore = "5mm";
            style.ParagraphFormat.SpaceAfter = "5mm";
            style.ParagraphFormat.TabStops.AddTabStop("16cm", TabAlignment.Right);
        }

        void CreatePage()
        {
            // Each MigraDoc document needs at least one section.
            var section = _document.AddSection();

            // Define the page setup. We use an image in the header, therefore the
            // default top margin is too small for our invoice.
            section.PageSetup = _document.DefaultPageSetup.Clone();
            // We increase the TopMargin to prevent the document body from overlapping the page header.
            // We have an image of 3.5 cm height in the header.
            // The default position for the header is 1.25 cm.
            // We add 0.5 cm spacing between header image and body and get 5.25 cm.
            // Default value is 2.5 cm.
            section.PageSetup.TopMargin = "5.25cm";

            //// Put the logo in the header.
            //var image = section.Headers.Primary.AddImage("../../../../assets/images/MigraDoc.png");
            //image.Height = "3.5cm";
            //image.LockAspectRatio = true;
            //image.RelativeVertical = RelativeVertical.Line;
            //image.RelativeHorizontal = RelativeHorizontal.Margin;
            //image.Top = ShapePosition.Top;
            //image.Left = ShapePosition.Right;
            //image.WrapFormat.Style = WrapStyle.Through;

            // Create the footer.
            var paragraph = section.Footers.Primary.AddParagraph();
            paragraph.AddText("Build IT");
            paragraph.AddDateField("dd.MM.yyyy");
            paragraph.Format.Font.Size = 9;
            paragraph.Format.Alignment = ParagraphAlignment.Center;

            // Create the text frame for the address.
            _dataFrame = section.AddTextFrame();
            _dataFrame.Height = "3.0cm";
            _dataFrame.Width = "7.0cm";
            _dataFrame.Left = ShapePosition.Right;
            _dataFrame.RelativeHorizontal = RelativeHorizontal.Margin;
            _dataFrame.Top = "5.0cm";
            _dataFrame.RelativeVertical = RelativeVertical.Page;

            // Show the sender in the address frame.
            paragraph = _dataFrame.AddParagraph("Build IT");
            paragraph.Format.Font.Size = 7;
            paragraph.Format.Font.Bold = true;
            paragraph.Format.SpaceAfter = 3;

            // Add the print date field.
            paragraph = section.AddParagraph();
            // We use an empty paragraph to move the first text line below the address field.
            paragraph.Format.LineSpacing = "5.25cm";
            paragraph.Format.LineSpacingRule = LineSpacingRule.Exactly;
            // And now the paragraph with text.
            paragraph = section.AddParagraph();
            paragraph.Format.SpaceBefore = 0;
            paragraph.Style = "Reference";
            paragraph.AddFormattedText("Data", TextFormat.Bold);

           
        }

        /// <summary>
        /// Creates the dynamic parts of the invoice.
        /// </summary>
        void FillContent()
        {
            var paragraph = _dataFrame.AddParagraph();
            paragraph.AddText("name/singleName");
            paragraph.AddLineBreak();
            paragraph.AddText("address/line1");
            paragraph.AddLineBreak();
            paragraph.AddText("address/postalCode"+ " " + "address/city");
        }
        
        // Some pre-defined colors...
#if true
        // ... in RGB.
        readonly static Color TableBorder = new Color(81, 125, 192);
        readonly static Color TableBlue = new Color(235, 240, 249);
        readonly static Color TableGray = new Color(242, 242, 242);
#else
        // ... in CMYK.
        readonly static Color TableBorder = Color.FromCmyk(100, 50, 0, 30);
        readonly static Color TableBlue = Color.FromCmyk(0, 80, 50, 30);
        readonly static Color TableGray = Color.FromCmyk(30, 0, 0, 0, 100);
#endif
    }

    //public interface IPdfReportSettings
    //{
    //    #region Properties

    //    XFont TitleFont { get; }
    //    XFont HeaderFont { get; }
    //    XFont TextFont { get; }

    //    #endregion // Properties
    //}

    //public class PdfReportSettings : IPdfReportSettings
    //{
    //    #region Properties

    //    public XFont TitleFont { get; } = new XFont("Verdana", 20, XFontStyle.Bold);
    //    public XFont HeaderFont { get; } = new XFont("Verdana", 16, XFontStyle.BoldItalic);
    //    public XFont TextFont { get; } = new XFont("Verdana", 12, XFontStyle.Regular);

    //    #endregion // Properties
    //}
}
