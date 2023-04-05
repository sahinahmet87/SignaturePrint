using Word = Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BRS
{
    public partial class Form2 : Form
    {
        public List<string> Zeilen = new List<string>();     


        public Form2()
        {
            InitializeComponent();             
        }
        
        private void buttonprint_Click(object sender, EventArgs e)
        {
            Zeilen.Add(textBox1.Text);
            Zeilen.Add(textBox2.Text);
            Zeilen.Add(textBox3.Text);
            Zeilen.Add(textBox4.Text);
            Zeilen.Add(textBox5.Text);
            Zeilen.Add(textBox6.Text);

            var allBoxesNull=true;
            foreach (string s in Zeilen)
            {
                if (s!="")
                { allBoxesNull = false; }
            }

            if (allBoxesNull)
            {
                MessageBox.Show("Bitte Signature eingeben");
                Zeilen.Clear();
            }
            else
            {
              
                string pfad = System.IO.Directory.GetCurrentDirectory();
                PrintWordDocument(Path.Combine(pfad, "Temp1.docx"));
                Zeilen.Clear();
            }
                     
        }

        private void PrintWordDocument(object filename)// Das Worddokument wird ausgedruckt
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
                for (int i = 0; i < Zeilen.Count; i++)
                {
                    FindAndReplace(wordApp, "BRS" + i, Zeilen[i]);
                }
                //for (int i = Zeilen.Count; i < 6; i++)
                //{
                //    FindAndReplace(wordApp, "BRS" + i, "");
                //}
                myWordDoc.PrintOut();
                myWordDoc.Close(0);
                wordApp.Quit();
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

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
