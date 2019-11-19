﻿
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
            //string src = @"C:\Users\zhangly\source\repos\Pdf\Pdf\33.pdf";
            string src = @"C:\Users\zhangly\source\repos\Pdf\Pdf\1022.pdf";
            string dest = @"C:\Users\zhangly\source\repos\Pdf\Pdf\out.pdf";

            PdfReader reader = new PdfReader(src);
            reader.SetUnethicalReading(true);
            PdfWriter writer = new PdfWriter(dest);
            PdfDocument pdfDoc = new PdfDocument(reader, writer);
            PdfAcroForm form = PdfAcroForm.GetAcroForm(pdfDoc, true);
           
            IDictionary<string, PdfFormField> fields = form.GetFormFields();//这样获取的是没有顺序的数据
            Console.WriteLine("length of {0}", fields.Count);
            foreach (var key in fields.Keys)
            {
                PdfFormField value;
                if(fields.TryGetValue(key, out value))
                {
                    Console.WriteLine("{0}={1}", key, value.GetValueAsString());
                    //Console.WriteLine("{0}={1}", key, value);
                } 
                else
                {
                    Console.WriteLine("{0} without value", key);
                }   

            }

        }

        Dictionary<String, string> data = new Dictionary<String, string>
        {
            {"name fam", "Zhang"},{"name giv", "Lingyun"},{"dob", "06/DEC/1991"},{"birth town", "Baoji"},{"birth cntry", "China"},{"marital mar", "None"},{"marital eng", "None"},{"marital def", "None"},{"marital sep", "None"},{"marital div", "None"},{"marital wid", "None"},{"marital nev mar", "Ye"},{"pass no", "E58913657"},{"pass cntry", "China"},{"ident no", "610323199322059648"},{"ident cntry", "China"},{"cit", "China"},{"resi str", "Dexilu china china"},{"resi sub", "zhongshan china china china"},{"resi cntry", "china china china"},{"resi pc", "591564"},{"corresp str", "AS ABOVE"},{"corresp sub", "None"},{"corresp cntry", "None"},{"corresp hap", "None"},{"off ph cc", "None"},{"off ph ac", "None"},{"off ph", "None"},{"after ph cc", "86"},{"after ph ac", "None"},{"after pn", "None"},{"fax cc", "None"},{"fax ac", "None"},{"fax ph", "None"},{"email", "timit.cloud@qq.com"},{"file no", "None"},{"name fam 1", "Zhang"},{"name giv 1", "Lingyilnksdf"},{"dob 1", "06-DEC-1991"},{"birth cntry 1", "China "},{"pass no 1", "E564654"},{"cit 1", "china"},{"resi str 1", "asdfasdf asdfasd fasdfa sdfa sd"},{"resi sub 1", "asdfasdf asdf asdf asd fasd fasd fas"},{"resi cntry 1", "asd fasd fas df"},{"resi pc 1", "412356"},{"name fam 2", "Zhang"},{"name giv 2", "Lingddlo lishg"},{"dob 2", "06-DEC-1991"},{"birth cntry 2", "Baoji"},{"pass no 2", "E654561321"},{"cit 2", "China"},{"resi str 2", "alsdkjflkjasdfklj;lkjasdf alkjsd;flkjas d;flka js"},{"resi sub 2", "alkjsdf;lkjasd;fl a;lsdkj f;kjasd f;lk"},{"resi cntry 2", "alkjsdfljas alsjdflkj"},{"resi pc 2", "123546"},{"name fam 3", "Zhang "},{"name giv 3", "alskdjf lkajsd"},{"dob 3", "06-DEC-1991"},{"birth cntry 3", "China"},{"pass no 3", "E48896216"},{"cit 3", "China"},{"resi str 3", "asdfasdfa asd fasdf asd fasdf"},{"resi sub 3", "asd fasd fas dfa sdf a"},{"resi cntry 3", "as dfa sdf asdf a"},{"resi pc 3", "591568"},{"info dtl 1", "111111111111111111111111111111111111111111222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222"},{"new dtl 1", "3333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333asdfasdfas"},{"info dtl 2", "asdfzxcvasdfqwerqwfasdf"},{"new dtl 2", "asdfxzcvzxcvqawer qwerq werqwerq wfasd fqwe fqwfasdfsaaaaaaaaaaaaaaaaa"},{"info dtl 3", "asdffffffffffffffffffffffffffffffffd"},{"new dtl 3", "qwefasdf zxcvads"},{"visa dog", "06-DEC-1991"},{"visa stay", "12 months"},{"visa cl", "E1"},{"app doa", "06-DEC-1991"},{"app ldge", "asdfqw"},{"visa cl 1", "qwerasdfas"},{"dec 1", "None"},{"dec 2", "None"},{"dec 3", "None"},{"dec 4", "None"}
        };


    }
}
