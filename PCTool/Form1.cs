using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices; // to release COM objects using Marshal

namespace PCTool
{
    public partial class Form1 : Form
    {
        
        public List<string> fileIds = new List<string>{"OVL",  "HAI" , "BXL", "LIM" };

        public List<String> filepaths = new List<String>();

        public string outputfile = "";
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private List<Entry> LoadParamList(string filepath, string fileId)
        {
            List<XElement> loadedXml = XElement.Load(filepath).Descendants("paramList").ToList();

            List<Entry> resultList = new List<Entry>();

            foreach (XElement xList in loadedXml)
            {
                string setName = xList.Element("setName").Value;
                string listName = xList.Element("paramListName").Value;
                
                List<XElement> xEntries = xList.Descendants("paramListEntry").ToList();
                foreach (XElement xEntry in xEntries)
                {
                    string paramName = xEntry.Element("paramName").Value;
                    string configName = xEntry.Element("configName").Value;
                    string value = System.Net.WebUtility.HtmlDecode(xEntry.Element("paramValue").Value);

                    Entry entry = new Entry(setName, listName, paramName, configName);
                    entry.AddValue(fileId, value);

                    resultList.Add(entry);
                }
            }
            return resultList;
        }

        private void DisplayInExcel2(string[,] Matrix)
        {
            Cursor = Cursors.WaitCursor;

            System.Diagnostics.Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();

            Excel.Application app = null;
            Excel.Application openApp = null;
        
            Excel.Workbooks books = null;
            Excel.Workbooks openBooks = null;

            Excel.Workbook book = null;

            Excel.Sheets sheets = null;
            Excel.Worksheet sheet = null;
          
            Excel.Range range = null;
            Excel.Range rows = null;

            List<string> errors = new List<string>();

            try
            {
                try
                {
                    openApp = (Excel.Application)Marshal.GetActiveObject("Excel.Application");

                    openBooks = openApp.Workbooks;

                    for (int i = 1; i <= openBooks.Count; i++)
                    {
                        Excel.Workbook openBook = openBooks[i];
                        Console.WriteLine(openBook.FullName);
                        if (openBook.FullName == outputfile)
                        {
                            errors.Add("The output file is already opened. Please close this file or choose a different output file.");
                        }

                        Marshal.ReleaseComObject(openBook);
                    }
                }
                catch
                {

                }
                finally
                {
                    if (openBooks != null) Marshal.ReleaseComObject(openBooks);
                    if (openApp != null) Marshal.ReleaseComObject(openApp);
                }


                if (errors.Count == 0)
                {
                    app = new Excel.Application();

                    if (app == null)
                    {
                        MessageBox.Show("A working instance of Excel needs to be installed.");
                        return;
                    }


                    books = app.Workbooks;
                    book = books.Add();
                    sheets = book.Sheets;
                    sheet = sheets.Item[1];
                    range = sheet.Cells[1, 1];

                    int rowCount = Matrix.GetLength(0);
                    int columnCount = Matrix.GetLength(1);

                    range = range.Resize[rowCount, columnCount];

                    range.Value = Matrix;

                    rows = range.Rows;

                    for (int iRow = 2; iRow <= rowCount; iRow++)
                    {
                        Excel.Range row = rows.Item[iRow]; //Index start van 1. Eerste rij = headers.

                        object[,] objRow = row.Value2;
                        List<string> listRow = objRow.Cast<string>().ToList();

                        for (int i = 3; i < listRow.Count; i++)
                        {
                            string cellValue = listRow[i];
                            List<string> allSameValues = listRow.FindAll(x => x == cellValue);
                            List<string> allValuesWithNotFound = listRow.FindAll(x => x == "!NOT_FOUND");

                            if (allValuesWithNotFound.Count == 0)
                            {
                                if (allSameValues.Count < listRow.Count - 3)
                                {
                                    //Console.WriteLine(row.Cells[iRow, listRow.Count].Value2);
                                    Excel.Range value = row.Cells[1, i + 1];
                                    //Console.WriteLine(value.Value2);
                                    value.Interior.Color = Color.Red;
                                    value.Font.Color = Color.White;

                                    if (value != null) Marshal.ReleaseComObject(value);
                                }
                            }
                            if (cellValue == "!NOT_FOUND")
                            {
                                Excel.Range cell = row.Cells[1, i + 1];
                                cell.Interior.Color = Color.Orange;
                                cell.Value2 = "";

                                if (cell != null) Marshal.ReleaseComObject(cell);
                            }
                        }

                        if (row != null) Marshal.ReleaseComObject(row);
                    }

                    app.DisplayAlerts = false;
                    object missing = System.Reflection.Missing.Value;
                    book.SaveAs(outputfile, Excel.XlFileFormat.xlWorkbookDefault, missing, missing, missing, missing, Excel.XlSaveAsAccessMode.xlExclusive, missing, missing, missing, missing, missing);
                    book.Close(true, missing, missing);
                    app.DisplayAlerts = true;
                    app.Quit();

                    string elapsed = watch.Elapsed.Seconds.ToString();
                    string message = "The output file '" + OutputFilenameBox.Text + ".xlsx' was succesfully created at " + OutputDirBox.Text;
                    message = message + Environment.NewLine + "Elapsed time: " + elapsed + "s.";
                    Cursor = Cursors.Arrow;
                    MessageBox.Show(message);
                }
                else
                {
                    DisplayErrors(errors);
                }
            }
            finally
            {
                Cursor = Cursors.Arrow;
                if (rows != null) Marshal.ReleaseComObject(rows);
                if (range != null) Marshal.ReleaseComObject(range);
                if (sheet != null) Marshal.ReleaseComObject(sheet);
                if (sheets != null) Marshal.ReleaseComObject(sheets);
                if (book != null) Marshal.ReleaseComObject(book);
                if (books != null) Marshal.ReleaseComObject(books);
                if (app != null) Marshal.ReleaseComObject(app);


                //Don't think these are needed anymore since they are part of inner try. Is this inner finally always reached?
                //if (openBooks != null) Marshal.ReleaseComObject(openBooks); 
                //if (openApp != null) Marshal.ReleaseComObject(openApp);
            }



        }

        private string[,] GetMatrix(List<Entry> Entries, List<string> FileIds)
        {
            int rowCount = Entries.Count;
            int colCount = FileIds.Count;

            string[,] matrix = new string[rowCount+1, colCount + 3];
            matrix[0, 0] = "ListName";
            matrix[0, 1] = "ParamName";
            matrix[0, 2] = "ConfigName";

            for (int i = 0; i < colCount; i++)
            {
                matrix[0, i + 3] = FileIds[i];
            }

            for (int i = 0; i < rowCount; i++)
            {
                Entry entry = Entries[i];
                matrix[i + 1, 0] = entry.ListName;
                matrix[i + 1, 1] = entry.ParamName;
                matrix[i + 1, 2] = entry.ConfigName;

                for (int j = 0; j < colCount; j++)
                {
                    string id = fileIds[j];
                    
                    ParamValue val = entry.Values.Find(v => v.FileId == id);
                    if (val != null)
                    {
                        matrix[i + 1, j + 3] = val.Value;
                    }
                    else
                    {
                        matrix[i + 1, j + 3] = "!NOT_FOUND";
                    }
                    
                }
            }
            return matrix;
        }

        private List<Entry> AddToList2(List<Entry> baseList, List<Entry> listToAdd)
        {
            foreach (Entry entry in listToAdd)
            {
                int index = baseList.FindIndex(e => (e.SetName == entry.SetName && e.ListName == entry.ListName && e.ParamName == entry.ParamName && e.ConfigName == entry.ConfigName));

                if (index == -1)
                {
                    baseList.Add(entry);
                }
                else
                {
                    baseList[index].Merge(entry);
                }

            }

            return baseList;
        }

        private List<string> LoadPaths()
        {
            //string url = "C:/Users/tplateus/Desktop/XML/";

            //List<string> list = new List<string>
            //{
            //    "OVL","HAI","BXL","LIM"
            //};

            //for (int i = 0; i < list.Count; i++)
            //{
            //    list[i] = string.Concat(url, list[i], ".xml");
            //}

            List<string> paths = new List<string>();

            int nRows = dataGridView1.Rows.Count;

            if (nRows !=0)
            {
                for (int i = 0; i < nRows; i++)
                {
                    paths.Add(dataGridView1.Rows[i].Cells[1].Value.ToString());
                }

            }

            return paths;
        }

        private List<string> LoadIds()
        {
            List<string> Ids = new List<string>();

            int nRows = dataGridView1.Rows.Count;

            if (nRows != 0)
            {
                //For each row, take the value of the 1st column of the Grid and store it as a string in Ids.
                for (int i = 0; i < nRows; i++)
                {
                    Ids.Add(dataGridView1.Rows[i].Cells[0].Value.ToString()); 
                }
            }



            return Ids;
        }

        private void DisplayErrors(List<string> errors)
        {
            string errorMessage = "The following errors have occured:";
            foreach (string error in errors)
            {
                errorMessage = errorMessage + Environment.NewLine + "   \u2022 " + error;

            }
            MessageBox.Show(errorMessage, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void SelectFileBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                SelectFileLbl.Text = openFileDialog1.FileName;
                this.GetNextControl((Control)sender, true).Focus();
            }
        }

        private void GenerateExcelBtn_Click(object sender, EventArgs e)
        {
            List<string> errors = SetOutputFile(OutputDirBox.Text, OutputFilenameBox.Text);
            filepaths = LoadPaths();
            fileIds = LoadIds();
            
            if (filepaths.Count == 0 || fileIds.Count == 0)
            {
                errors.Add("At least one file has to be selected.");
            }

            if (errors.Count != 0)
            {
                DisplayErrors(errors);
                return;
            }

            List<Entry> baseList = LoadParamList(filepaths[0], fileIds[0]);

            for (int i = 1; i < filepaths.Count; i++)
            {
                List<Entry> newList = LoadParamList(filepaths[i], fileIds[i]);
                baseList = AddToList2(baseList, newList);
            }

            string[,] allCells = GetMatrix(baseList, fileIds);
            DisplayInExcel2(allCells);
            
        }

        private void AddToGridView(object sender, bool goBackTwice)
        {
            List<string> errors = new List<string>();
            List<string> fileIds = new List<string>();

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                fileIds.Add(dataGridView1.Rows[i].Cells[0].Value.ToString());
            }

            if (SelectFileLbl.Text == "")
            {
                errors.Add("No file is selected.");
            }
            if (DescriptionBox.Text == "")
            {
                errors.Add("Description can't be empty.");
            }
            if (fileIds.Find(x => x == DescriptionBox.Text) != null)
            {
                errors.Add("Description has to be unique.");
            }

            if (errors.Count == 0)
            {
                dataGridView1.Rows.Add(DescriptionBox.Text, SelectFileLbl.Text);
                SelectFileLbl.Text = "";
                DescriptionBox.Text = "";
                Control prevCtl = GetNextControl((Control)sender, false);
                if (goBackTwice == true)
                {
                    GetNextControl(prevCtl, false).Focus();
                }
                else
                {
                    prevCtl.Focus();
                }
            }
            else
            {
                DisplayErrors(errors);
            }

            
        }

        private void DescriptionBox_Enter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                AddToGridView(sender, false);
            }
        }

        private void DisclaimerLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Disclaimer copyrightForm = new Disclaimer();
            copyrightForm.ShowDialog(this);
        }

        private void AddToListBtn_Click(object sender, EventArgs e)
        {
            AddToGridView(sender, true);
        }

        private void BrowseDirBtn_Click(object sender, EventArgs e)
        {
            string selectedPath = "";

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                selectedPath = folderBrowserDialog1.SelectedPath;
            }

            OutputDirBox.Text = selectedPath;

        }

        private void DeleteFilesBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear the table?", "",MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                dataGridView1.Rows.Clear();
            }
        }

        private void OutputFilenameBox_Enter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                this.GetNextControl((Control)sender, true).Focus();
            }
        }

        private List<string> SetOutputFile(string outputDirectory, string outputFilename)
        {
            List<string> errors = new List<string>();
            List<string> invalidChars = new List<string> { @"<", @">", @":", @"/", @"\", @"|", @"?", @"*" };
            
            //Check for empty directory.
            if (outputDirectory == "")
            {
                errors.Add("Output directory cannot be empty.");
            }

            //Check for empty filename
            if (outputFilename == "")
            {
                errors.Add("Output filename cannot be empty.");
            }
            //Check that filename does not use an invalid character.
            foreach (string character in invalidChars)
            {
                if (outputFilename.Contains(character)) errors.Add("Filename is invalid. Please verify that your filename does not contain any of the following characters: \\ / : * ? \" < > |");
            }

            if (errors.Count == 0)
            {
                outputfile = outputDirectory + @"\" + outputFilename;
            
            }

            return errors;
        }
    }
}
