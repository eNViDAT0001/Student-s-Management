using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace UI_for_Project.Controller
{
    static class ExportExcel
    {

        public static void ExportToExcel(this DataGrid dg, string filename = "")
        {
            try
            {
                dg.SelectionMode = DataGridSelectionMode.Extended;
                dg.SelectAllCells();

                Clipboard.Clear();
                ApplicationCommands.Copy.Execute(null, dg);

                var saveFileDialog = new SaveFileDialog
                {
                    FileName = filename != "" ? filename : "gpmfca-exportedDocument",
                    DefaultExt = ".csv",
                    Filter = "Common Seprated Documents (.csv)|*.csv"
                };

                if (saveFileDialog.ShowDialog() == true)
                {
                    var clip2 = Clipboard.GetText();
                    File.WriteAllText(saveFileDialog.FileName, clip2.Replace('\t', ','), Encoding.UTF8);
                    Process.Start(saveFileDialog.FileName);
                }

                dg.UnselectAllCells();
                dg.SelectionMode = DataGridSelectionMode.Single;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Clipboard.Clear();
            }
        }
    }
}
