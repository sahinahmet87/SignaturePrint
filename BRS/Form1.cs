using System.Collections.Generic;
using System.Diagnostics.Metrics;
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
        foreach (string s in Brs_Print)
        {
        result += s+"\n" ;
        }
        result=result.Remove(result.Length - 1, 1);
        richTextBox1.Text = result;
        richTextBox_BuchName.Text = BuchName;
        if (autodruck.Checked)
        {
        string pfad = System.IO.Directory.GetCurrentDirectory();
        CreateWordDocument(Path.Combine(pfad, "Temp1.docx"));
        }
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
                string pfad = System.IO.Directory.GetCurrentDirectory();
                CreateWordDocument(Path.Combine(pfad, "Temp1.docx"));              
            }   

                }
        public void Get_Signature_and_Name(string barcode) // Sendet Barcode-Nummer mit API und gibt Signature und Buchname aus
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
        public void SplitSignature(string signature)// Die Signatur wird aufgeteilt und jeder Teil der Signatur wird einer String-Liste (BRS_Print) hinzugefügt
        {
            string[] BrsArray= signature.Split(new char[] { ' ' });

            foreach (string b in BrsArray)
            {
                Brs_Print.Add(b);  
            }

        }  
        private void FindAndReplace(Word.Application wordApp, object toFindText, object replaceWithText)  //Word-Vorlage wird durch Elemente von BRC_Print ersetzt
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
        private void CreateWordDocument(object filename)// Ein neues Word-Dokument wird erstellt
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
                FindAndReplace(wordApp, "BRS"+i, Brs_Print[i] );
                }
                for (int i = Brs_Print.Count; i < 6; i++)
                {
                FindAndReplace(wordApp, "BRS"+i,"");
                }
                myWordDoc.PrintOut();
                myWordDoc.Close(0);
                wordApp.Quit();
            }
        }
        private void autodruck_CheckedChanged(object sender, EventArgs e)
        {
            if (autodruck.Checked)
            buttonprint.Enabled = false;
            else
            buttonprint.Enabled = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            PrintDialog PrintDialog1 = new PrintDialog();
            PrintDialog1.ShowDialog();
        }
    }
}