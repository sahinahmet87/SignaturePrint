using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using File = System.IO.File;
using Word = Microsoft.Office.Interop.Word;

namespace BRS
{
    public partial class Form1 : Form
    {
        public string? Barcode { get; set; }
        public string? Signature { get; set; }
        public string? BuchName { get; set; }

        public List<string> Brs_Print = new List<string>();

        PrintDialog PRD = new PrintDialog();

        public string PrintText { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        public void buttoncheck_Click(object sender, EventArgs e)
    {     
           
        if (textBox1.Text=="" ) 
        {
         MessageBox.Show("Bitte Barcode eingeben", "Nachricht");
        }
        else 
        {
        Brs_Print.Clear();
        richTextBox1.Clear();
        Get_Signature_and_Name(Barcode);
            if (Signature == null)
            {MessageBox.Show("Der Barcode wurde nicht gefunden", "Nachricht");}
            else 
            { 
            SplitSignature(Signature);
        string result=""; 
      //  result+=BuchName+ "\n";
        
        foreach (string s in Brs_Print)
        {
            result += s+"\n" ;
        }
        richTextBox1.Text = result;
        
             }
        }

    }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Barcode = textBox1.Text;
        }

        private void buttonprint_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Signature)) 
            {
                MessageBox.Show("Bitte Barcode eingeben", "Nachricht");
            }
            else 
            { 
           CreateWordDocument(@"C:\Users\sahin_a\source\repos\BarcodePrint\TestBarcode\Temp1.docx", @"C:\Users\sahin_a\source\repos\BarcodePrint\TestBarcode\test4.docx");
            }
            //PrintDocument a =new PrintDocument();
            //DialogResult print;
            //print = PRD.ShowDialog();
            //a.PrintPage += A_PrintPage;
            //if(print==DialogResult.OK)
            //{
            //    a.Print();
            //}

        }

        private void A_PrintPage(object sender, PrintPageEventArgs e)
        {
            
            Font schrift = new Font("Arial", 12);
            SolidBrush pen=new SolidBrush(Color.Black);
            PointF punkt = new PointF(70, 60);
            StringFormat stringFormat = new StringFormat();
            stringFormat.FormatFlags = StringFormatFlags.DirectionVertical;
          //  stringFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft;
            e.Graphics.DrawString(PrintText,schrift,pen,punkt,stringFormat);
            
        }

        public void Get_Signature_and_Name(string barcode)
        {
            try { 
            string url = "https://api-eu.hosted.exlibrisgroup.com/almaws/v1/items?item_barcode=" + barcode + "&apikey=l8xx60f2549444854849b9706a876352a5a9";
            XDocument document = XDocument.Load(url);
            
            Signature = document.Descendants("alternative_call_number").ElementAt(0).Value;
            BuchName  = document.Descendants("title").ElementAt(0).Value;
                     
            }
            catch
            {
                Signature= null;
                BuchName= null;
            }
         }  
        public void SplitSignature(string signature)
        {
            string[] BrsArray= signature.Split(new char[] { ' ' });

            foreach (string b in BrsArray)
            {
                Brs_Print.Add(b);  
            }
            
        }
        private void FindAndReplace(Word.Application wordApp, object toFindText, object replaceWithText)
        {
            object matchCase = true;
            object matchwholeWord = true;
            object matchwildCards = false;
            object matchSoundLike = false;
            object nmatchAllforms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiactitics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = -2;
            object wrap = 1;

            wordApp.Selection.Find.Execute(ref toFindText, ref matchCase, ref matchwholeWord, ref matchwildCards, ref matchSoundLike,
                                           ref nmatchAllforms, ref forward, ref wrap, ref format, ref replaceWithText,
                                           ref replace, ref matchKashida, ref matchDiactitics, ref matchAlefHamza,
                                           ref matchControl);
        }
        private void CreateWordDocument(object filename, object SaveAs)
        {
            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myWordDoc = null;

            if (File.Exists((string)filename))
            {
                object readOnly = false;
                object isvisible = false;
                wordApp.Visible = false;
                myWordDoc = wordApp.Documents.Open(ref filename, ref missing, ref readOnly,
                                                    ref missing, ref missing, ref missing,
                                                    ref missing, ref missing, ref missing,
                                                    ref missing, ref missing, ref missing,
                                                    ref missing, ref missing, ref missing, ref missing);
                myWordDoc.Activate();



                for(int i=0; i<Brs_Print.Count;i++)
                { 
                this.FindAndReplace(wordApp, "BRS"+i, Brs_Print[i] );
                }
                for (int i = Brs_Print.Count; i < 6; i++)
                {
                 this.FindAndReplace(wordApp, "BRS"+i,"");
                }


                myWordDoc.SaveAs2(ref SaveAs, ref missing, ref missing, ref missing,
                                  ref missing, ref missing, ref missing,
                                  ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                                  ref missing, ref missing, ref missing);
                myWordDoc.PrintOut();
                myWordDoc.Close();
                wordApp.Quit();
            }
        }
    }
}