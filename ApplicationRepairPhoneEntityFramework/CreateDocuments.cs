using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;
using System.IO;
using System.Windows.Controls;

namespace ApplicationRepairPhoneEntityFramework
{
    
    public class CreateDocuments
    {
        
        FileInfo fileInfo;
        FileInfo FileInfoSave;
        public CreateDocuments(string fileName, string fileInfoSave) 
        {
            if (File.Exists(fileName) && File.Exists(fileInfoSave))
            { 
                fileInfo = new FileInfo(fileName);
                FileInfoSave = new FileInfo(fileInfoSave);
            
            }

            else 
            {
                throw new ArgumentException("Файл не найден");
            
            }
        
        }

        internal bool Process(Dictionary<string, string> items)
        {
            Word.Application app = null;
            try
            {
                app = new Word.Application();
                Object file = fileInfo.FullName;

                Object missing = Type.Missing;

                app.Documents.Open(file);

                foreach (var item in items)
                {
                    Word.Find find = app.Selection.Find;
                    find.Text = item.Key;
                    find.Replacement.Text = item.Value;

                    Object wrap = Word.WdFindWrap.wdFindContinue;
                    Object replace = Word.WdReplace.wdReplaceAll;

                    find.Execute(FindText: Type.Missing,
                        MatchCase: false,
                        MatchWholeWord: false,
                        MatchWildcards: false,
                        MatchSoundsLike: missing,
                        MatchAllWordForms: false,
                        Forward: true,
                        Wrap: wrap,
                        Format: false,
                        ReplaceWith: missing, Replace: replace);
                }

                Object newFileName = Path.Combine(FileInfoSave.DirectoryName, FileInfoSave.Name);

                app.ActiveDocument.SaveAs2(newFileName);


                

                //if (fileInfo.Exists) 
                //{
                //    string DateName =  FileInfoSave.FullName + DateTime.Now;
                //    File.Copy(FileInfoSave.FullName, DateName.ToString(), true);
                //}
                



                return true;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);



            }
            finally 
            {
                if (app != null)
                {
                    app.ActiveDocument.Close();
                    app.Quit();
                }

            }

        }


        




    }



}
