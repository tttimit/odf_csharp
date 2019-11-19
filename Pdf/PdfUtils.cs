
using iText.Forms;
using iText.Forms.Fields;
using iText.Kernel.Pdf;
using System;
using System.Collections.Generic;

namespace Pdf
{

    class PdfUtils
    {
        public static void getPdfAcroFormFields()
        {
            string src = @"C:\Users\zhangly\source\repos\Pdf\Pdf\33.pdf";
            //string src = @"C:\Users\zhangly\source\repos\Pdf\Pdf\1022.pdf";
            string dest = @"C:\Users\zhangly\source\repos\Pdf\Pdf\out.pdf";

            PdfReader reader = new PdfReader(src);
            reader.SetUnethicalReading(true);
            PdfWriter writer = new PdfWriter(dest);
            PdfDocument pdfDoc = new PdfDocument(reader, writer);
            PdfAcroForm form = PdfAcroForm.GetAcroForm(pdfDoc, true);
           
            IDictionary<string, PdfFormField> fields = form.GetFormFields();
            Console.WriteLine("length of {0}", fields.Count);
            foreach (var key in fields.Keys)
            {
                PdfFormField value;
                if(fields.TryGetValue(key, out value))
                {
                    Console.WriteLine("{0}={1}", key, value);
                } 
                else
                {
                    Console.WriteLine("{0} without value", key);
                }   

            }

        }

        Dictionary<String, PdfFormField> data = new Dictionary<String, PdfFormField>
        {
        };


    }
}
