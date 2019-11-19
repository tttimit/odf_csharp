
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
            string src = @"C:\Users\timit\Source\Repos\tttimit\pdf_csharp\Pdf\1022.pdf";
            string dest = @"C:\Users\timit\Source\Repos\tttimit\pdf_csharp\Pdf\Pdfout-1.pdf";

            PdfReader reader = new PdfReader(src);
            reader.SetUnethicalReading(true);
            PdfWriter writer = new PdfWriter(dest);
            PdfDocument pdfDoc = new PdfDocument(reader, writer);
            PdfAcroForm form = PdfAcroForm.GetAcroForm(pdfDoc, true);
           
            IDictionary<string, PdfFormField> fields = form.GetFormFields();//这样获取的是没有顺序的数据
            string[] relationsCheckBox = { "ap.marital nev mar", "ap.marital div", "ap.marital sep", "ap.marital def", "ap.marital wid", "ap.marital eng", "ap.marital mar"};
            String[] toggleBtn = { "ap.app", "ap.com dimia" };
            foreach (var key in fields.Keys)
            {
 
                PdfFormField value;
                if (fields.TryGetValue(key, out value))
                {
                    //Console.WriteLine("{0}={1}", key, value.GetValueAsString());
                    Console.WriteLine("{0}={1}", key, value);
                    //String[] states = fields[key].getAppearanceStates("checkbox");
                    //Console.WriteLine("value type {}", states);
                }
                else
                {
                    Console.WriteLine("{0} without value", key);
                }

            }
            //form.FlattenFields();
            pdfDoc.Close();
        }

        public static void WriteAcroForm(){
            string src = @"C:\Users\timit\Source\Repos\tttimit\pdf_csharp\Pdf\1022.pdf";
            string dest = @"C:\Users\timit\Source\Repos\tttimit\pdf_csharp\Pdf\Pdfout.pdf";
            

            PdfReader reader = new PdfReader(src);
            reader.SetUnethicalReading(true);
            PdfWriter writer = new PdfWriter(dest);
            PdfDocument pdfDoc = new PdfDocument(reader, writer);
            PdfAcroForm form = PdfAcroForm.GetAcroForm(pdfDoc, true);
           
            IDictionary<string, PdfFormField> fields = form.GetFormFields();//这样获取的是没有顺序的数据
            string[] relationsCheckBox = { "ap.marital nev mar", "ap.marital div", "ap.marital sep", "ap.marital def", "ap.marital wid", "ap.marital eng", "ap.marital mar"};
            String[] toggleBtn = { "ap.app", "ap.com dimia" };
            foreach (var key in fields.Keys)
            {
                string value;
                if (data.TryGetValue(key, out value))
                {
                    if (Array.IndexOf(relationsCheckBox, key) != -1)
                    {
                        //https://github.com/itext/itext7/blob/develop/forms/src/main/java/com/itextpdf/forms/fields/PdfFormField.java
                        fields[key].SetCheckType(1); // TYPE_CHECK = 1 
                        fields[key].RegenerateField();
                    }
                    fields[key].SetValue(value);                    
                }
                else //获取不到值，这里只有未选中的婚姻关系框
                {
                    fields[key].setValue("no");
                }
            }
             //form.FlattenFields();
            pdfDoc.Close();
            Console.WriteLine("Program ends");
        }

        static Dictionary<String, string> data = new Dictionary<String, string>
        {
            /*
             * 有几种特殊类型：
             * PdfFormField ：类似textarea类型
             * PdfTextFormField: 字符串，包括日期也是形如 06-Dec-1991 的字符串
             * PdfButtonFormField: 选择框，婚姻关系单选，其他地方根据需要设置yes或者no
             */
           {"ap.info dtl 1", "14-1-textarea1"},{"ap.new dtl 1", "14-1-new correct details"},{"ap.info dtl 2", "14-2-information which is no longer current"},{"ap.new dtl 2", "14-2-new corrent details"},{"ap.info dtl 3", "14-3-information which is no longer current"},{"ap.new dtl 3", "14-3-new correct details"},{"ap.name fam", "Zhang"},{"ap.name giv", "Lingyun"},{"ap.dob", "06-Dec-1991"},{"ap.birth town", "Baoji"},{"ap.birth cntry", "China"},
            {"ap.marital nev mar", "Yes"},// 婚姻关系栏，需要打勾的，设置为 Yes，其他的都必须设置为No，否则flatten之后都会默认打勾
            {"ap.marital div", ""},{"ap.marital sep", ""},{"ap.marital def", ""},{"ap.marital wid", ""},{"ap.pass no", "E57107687"},{"ap.pass cntry", "China"},{"ap.ident no", "610323199121561236"},{"ap.ident cntry", "China"},{"ap.cit", "China"},{"ap.resi str", "address-line-1"},{"ap.resi sub", "address-line-2"},{"ap.resi cntry", "address-line-3"},{"ap.resi pc", "712456"},{"ap.corresp str", "AS ABOVE"},{"ap.corresp sub", ""},{"ap.corresp cntry", ""},{"ap.corresp hap", ""},{"ap.file no", "client number-123456"},{"ap.marital mar", ""},{"ap.marital eng", ""},{"ap.visa dog", "15-Jan-2001"},{"ap.visa stay", "15-stay-period"},{"ap.visa cl", "15-visa-class"},{"ap.app doa", "26-Oct-2006"},{"ap.app ldge", "16-lodged-at"},{"ap.visa cl 1", "16-visa-class"},{"ap.dec 1", "19-Nov-2019"},{"ap.dec 2", "2-Dec-1991"},{"ap.dec 3", "3-DEC-1965"},{"ap.dec 4", "4-DEC-1659"},
            {"ap.app", "yes"},// 第4页 13 Do you have a parter...  这里是二选一，yes/no
            {"ap.app.1", ""},{"ap.app.2", ""},{"ap.off ph", "18902860005"},{"ap.after pn", "18902860005"},
            {"ap.com dimia", "yes"},//第3页 11 Do you agree to the de，这里是二选一, yes/no
            {"ap.com dimia.1", ""},{"ap.com dimia.2", ""},{"ap.fax ph", "fax-number"},{"ap.email", "timit.cloud@gmail.com"},{"ap.fax ac", "fax2"},{"ap.after ph ac", "a2"},{"ap.off ph ac", "a1"},{"ap.off ph cc", "86"},{"ap.after ph cc", "86"},{"ap.fax cc", "fax1"},{"m", ""},{"m.name fam 1", "Li"},{"m.name giv 1", "Si"},{"m.dob 1", "04-May-1995"},{"m.birth cntry 1", "China"},{"m.pass no 1", "E12345678"},{"m.cit 1", "China"},{"m.resi str 1", "  applicant-1-address  1"},{"m.resi sub 1", "  applicant-1-address 2"},{"m.resi cntry 1", "  applicant-1-address 3"},{"m.resi pc 1", "app1-post"},{"m.name fam 2", "Wang"},{"m.name giv 2", "Wu"},{"m.dob 2", "25-May-1992"},{"m.birth cntry 2", "China"},{"m.pass no 2", "E25041992"},{"m.cit 2", "China"},{"m.resi str 2", "application2-add-1"},{"m.resi sub 2", "application2-add-2"},{"m.resi cntry 2", "application2-add-3"},{"m.resi pc 2", "app2-post"},{"m.name fam 3", "Ju"},{"m.name giv 3", "Qi"},{"m.dob 3", "15-Jul-1997"},{"m.birth cntry 3", "China"},{"m.pass no 3", "E12345532"},{"m.cit 3", "USA"},{"m.resi str 3", "applicant-3-add-1"},{"m.resi sub 3", "applicant-3-add-2"},{"m.resi cntry 3", "applicant-3-add-3"},{"m.resi pc 3", "app3-post"}
        };
    }
}
