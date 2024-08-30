using System;
using System.IO;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Syncfusion.Pdf;
using Syncfusion.XlsIO;
using Syncfusion.DocIORenderer;
using Syncfusion.XlsIORenderer;

namespace DocumentConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            ConvertDocxToPdf("файл.docx", "файл.pdf");
        }

        static void ConvertDocxToPdf(string inputFilePath, string outputFilePath)
        {
            using (FileStream inputStream = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read))
            {
                WordDocument document = new WordDocument(inputStream, FormatType.Docx);

                DocIORenderer docRenderer = new DocIORenderer();
                using (PdfDocument pdfDocument = docRenderer.ConvertToPDF(document))
                {
                    using (FileStream outputStream = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write))
                    {
                        pdfDocument.Save(outputStream);
                    }
                }
            }
        }
                
    }
}
