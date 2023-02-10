// See https://aka.ms/new-console-template for more information


using System.Xml.Linq;
using static System.Net.WebRequestMethods;
using File = System.IO.File;
using Word = Microsoft.Office.Interop.Word;
using System.Drawing.Text;
using System.Reflection;
using System.Runtime.CompilerServices;
using static System.Net.Mime.MediaTypeNames;


internal class Program
{
    private static void Main(string[] args)
    {
        Program a = new Program();
        a.CreateWordDocument(@"C:\Users\sahin_a\source\repos\BarcodePrint\TestBarcode\Temp1.docx", @"C:\Users\sahin_a\source\repos\BarcodePrint\TestBarcode\test4.docx");
       

    }
    public void FindAndReplace(Word.Application wordApp, object toFindText, object replaceWithText)
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
    public void CreateWordDocument(object filename, object SaveAs)
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
            this.FindAndReplace(wordApp, "BRS0", "some");
            myWordDoc.SaveAs2(ref SaveAs, ref missing, ref missing, ref missing,
                              ref missing, ref missing, ref missing,
                              ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                              ref missing, ref missing, ref missing);

            myWordDoc.Close();
            wordApp.Quit();
        }
    }
}

































//Word.Application wordapp =new Word.Application();   
//wordapp.Visible= true;
//Object missing = Type.Missing;
//Word.Document worddoc = wordapp.Documents.Open(@"C:\\Users\\sahin_a\\source\\repos\\BarcodePrint\\TestBarcode\\BRS_PRINT.docx", ReadOnly: false, Visible: false);
//object wordobj = System.Reflection.Missing.Value;
//worddoc=wordapp.Documents.Add(wordobj);
//Word.Find find = wordapp.Selection.Find;
//find.Text = "BRS0";
//find.Replacement.Text = "aaa";

//Object wrap = Word.WdFindWrap.wdFindContinue;
//Object replace = Word.WdReplace.wdReplaceAll;

//find.Execute(FindText: Type.Missing,
//    MatchCase: false,
//    MatchWholeWord: false,
//    MatchWildcards: false,
//    MatchSoundsLike: missing,
//    MatchAllWordForms: false,
//    Forward: true,
//    Wrap: wrap ,
//    Format:false,
//    ReplaceWith: missing,
//    Replace: replace);

////Object newfilename = @"C:\\Users\\sahin_a\\source\\repos\\BarcodePrint\\TestBarcode\\"+DateTime.Now.ToString()+".docx";
//wordapp.ActiveDocument.SaveAs2("C:\\Users\\sahin_a\\source\\repos\\BarcodePrint\\TestBarcode\\test3.docx");
//wordapp.ActiveDocument.Close();
//wordapp.Quit();
//Document doc = new Document(@"C:\\Users\\sahin_a\\source\\repos\\BarcodePrint\\TestBarcode\\BRS_PRINT.docx");
//doc.Replace("BRS0", "yyy",false,true);


//string api = "l8xx60f2549444854849b9706a876352a5a9";
//string url = "https://api-eu.hosted.exlibrisgroup.com/almaws/v1/items?item_barcode=025462201&apikey=l8xx60f2549444854849b9706a876352a5a9";
//XDocument document = XDocument.Load(url);
//var barcode = document.Descendants("alternative_call_number").ElementAt(0).Value;

//string[] Brs = barcode.Split(new char[] { ' ' });

//foreach (var brs in Brs)
//{
//    Console.WriteLine(brs);
//}

//static void FindAndReplace(Word.Application wordapp,object ToFindText, object replaceWithText)
//{
//    object matchCase = true;
//    object matchWholeWord = true;
//    object matchWildCards = false;
//    object matchSoundLike = false;
//    object nmatchAllforms = false;
//    object forward = true;
//    object format = false;
//    object matchKashida = false;
//    object matchDiactitics = false;
//    object matchAlefHamza = false;
//    object matchControl = false;
//    object read_Only = false;
//    object visible = true;
//    object replace = 2;
//    object wrap = 1;

//    wordapp.Selection.Find.Execute(ref ToFindText, 
//        ref matchCase,ref matchWholeWord,ref matchWildCards,
//        ref matchSoundLike,ref nmatchAllforms, ref forward,ref wrap,ref format,ref replaceWithText,
//        ref replace,ref matchKashida,ref matchDiactitics, ref matchAlefHamza, ref matchControl );


//}

//static void CreateWordDocument(object fileName, object SaveAs )
//{
//    Word.Application wordapp = new Word.Application();
//    object missing = Missing.Value;
//    Word.Document myWordDoc = null;

//    if(File.Exists((string)fileName))
//    {
//        object readOnly = false;
//        object isVisible = false;
//        wordapp.Visible = false;

//        myWordDoc= wordapp.Documents.Open(ref fileName,ref missing, ref readOnly,
//           ref missing, ref missing, ref missing,
//           ref missing, ref missing, ref missing,
//           ref missing, ref missing, ref missing,
//           ref missing, ref missing, ref missing,ref missing);
//        myWordDoc.Activate();

//        FindAndReplace(wordApp, "BRS", "sss");
//            }
//}


