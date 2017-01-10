using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace ProjectIntercept.Config
{
    class Actions
    {
        private static readonly string FileName = Application.StartupPath + @"\mySettings.xml";

        internal static bool Change(string name, string value)
        {
            try
            {
                var theDoc = new XmlDocument { PreserveWhitespace = false };
                theDoc.Load(FileName);

                var theWrite = new XmlTextWriter(FileName, Encoding.ASCII) { Formatting = Formatting.Indented };

                var theList = theDoc.GetElementsByTagName(name);

                for (var i = 0; i < theList.Count; i++)
                {
                    theList[i].InnerXml = value.Trim();
                }

                theDoc.Save(theWrite);
                theWrite.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(@"Error: " + e.Message);
                return false;
            }
        }

        internal static string Get(string name)
        {
            try
            {
                var theDoc = new XmlDocument { PreserveWhitespace = false };
                theDoc.Load(FileName);

                var theList = theDoc.GetElementsByTagName(name);

                int i;
                for (i = 0; i < theList.Count; )
                {
                    return theList[i].InnerXml;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(@"Error: " + e.Message);
                return null;
            }
            return null;
        }

        internal static void ResetDefaults()
        {
            try
            {
                TextWriter write = new StreamWriter(FileName);
                write.Write(
@"<?xml version='1.0' encoding='us-ascii'?>
<Settings>
  <CloseToTray>False</CloseToTray>
  <StartWithWindows>True</StartWithWindows>
  <GamePath></GamePath>  
</Settings>         
            ");
                write.Close();


            }
            catch (Exception e)
            {
                MessageBox.Show(@"Unable to create default settings file: " + e.Message, @"Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }

        }
    }
}
