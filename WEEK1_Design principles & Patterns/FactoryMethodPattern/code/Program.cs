// File: Program.cs
using System;

namespace FactoryMethodPatternExample
{
    // 1. Document interface
    public interface IDocument
    {
        void Open();
    }

    // 2. Concrete document classes
    public class WordDocument : IDocument
    {
        public void Open()
        {
            Console.WriteLine("Opening a Word document.");
        }
    }

    public class PdfDocument : IDocument
    {
        public void Open()
        {
            Console.WriteLine("Opening a PDF document.");
        }
    }

    public class ExcelDocument : IDocument
    {
        public void Open()
        {
            Console.WriteLine("Opening an Excel document.");
        }
    }

    // 3. Abstract factory
    public abstract class DocumentFactory
    {
        public abstract IDocument CreateDocument();
    }

    // 4. Concrete factories
    public class WordDocumentFactory : DocumentFactory
    {
        public override IDocument CreateDocument()
        {
            return new WordDocument();
        }
    }

    public class PdfDocumentFactory : DocumentFactory
    {
        public override IDocument CreateDocument()
        {
            return new PdfDocument();
        }
    }

    public class ExcelDocumentFactory : DocumentFactory
    {
        public override IDocument CreateDocument()
        {
            return new ExcelDocument();
        }
    }

    // 5. Test the Factory Method Pattern
    class Program
    {
        static void Main(string[] args)
        {
            DocumentFactory wordFactory = new WordDocumentFactory();
            IDocument wordDoc = wordFactory.CreateDocument();
            wordDoc.Open();

            DocumentFactory pdfFactory = new PdfDocumentFactory();
            IDocument pdfDoc = pdfFactory.CreateDocument();
            pdfDoc.Open();

            DocumentFactory excelFactory = new ExcelDocumentFactory();
            IDocument excelDoc = excelFactory.CreateDocument();
            excelDoc.Open();
        }
    }
}
