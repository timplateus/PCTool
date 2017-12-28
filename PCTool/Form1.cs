using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            #region WriteToFile
            //List<string> output = new List<string> { "ListName | ParamName | Value (OVL) | Value (HAI) |" };
            //output.Add("----------------------------------------------------------");

            //foreach (Entry entry in baseList)
            //{
            //    string newLine = String.Concat(entry.ListName, " | ", entry.ParamName," | ");

            //    foreach (var pVal in entry.Values)
            //    {
            //        newLine = String.Concat(newLine, pVal.Value);
            //        //Console.WriteLine("{0}.{2} ({1})", entry.ParamName, pVal.FileId, pVal.Value);
            //    }

            //    output.Add(newLine);
            //    output.Add("----------------------------------------------------------");

            //}
            //System.IO.File.WriteAllLines("c:/Users/tplateus/Desktop/XML/output.txt", output); 
            #endregion
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

        private List<Entry> AddToList(List<Entry> baseList, List<Entry> listToAdd)
        {
            foreach (Entry entry in listToAdd)
            {
                bool isNew = false;

                foreach (Entry baseEntry in baseList)
                {
                    //Console.WriteLine("base: {0}.{1}.{2}.{3}",baseEntry.SetName,baseEntry.ListName,baseEntry.ParamName,baseEntry.ConfigName);
                    //Console.WriteLine("new: {0}.{1}.{2}.{3}", entry.SetName, entry.ListName, entry.ParamName, entry.ConfigName);

                    Entry merged = baseEntry.Merge(entry);
                    
                    if (merged != null)
                    {
                        isNew = true;
                    }
                    //Console.WriteLine("bool: {0}", isNew);
                }

                if (isNew)
                {
                    baseList.Add(entry);
                }
            }

            return baseList;
        }

        private void DisplayInExcel(List<Entry> list)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            int colCount = fileIds.Count + 2; //first 2 rows are listname and paramname => +2
            int rowCount = list.Count;

            Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            if (xlApp == null)
            {
                MessageBox.Show("A working instance of Excel needs to be installed.");
                return;
            }

            Excel.Workbook xlWorkbook;
            Excel.Worksheet xlWorksheet;
            object missing = System.Reflection.Missing.Value;

            xlWorkbook = xlApp.Workbooks.Add(missing);
            xlWorksheet = (Excel.Worksheet)xlWorkbook.Worksheets.get_Item(1);

            xlApp.DisplayAlerts = false;

            xlWorksheet.Cells[1, 1] = "ListName";
            xlWorksheet.Cells[1, 2] = "ParamName";
            xlWorksheet.Cells[1, 3] = "Value (OVL)";
            xlWorksheet.Cells[1, 4] = "Value (HAI)";

            for (int i = 0; i < list.Count; i++)
            {
                xlWorksheet.Cells[i + 2, 1] = list[i].ListName;
                xlWorksheet.Cells[i + 2, 2] = list[i].ParamName;

                for (int j = 0; j < fileIds.Count; j++)
                {
                    string id = fileIds[j];
                    ParamValue val = list[i].Values.Find(v => v.FileId == id);
                    if (val == null)
                    {
                        
                    
                    }
                    else
                    {
                        xlWorksheet.Cells[i + 2, j + 3] = val.Value;
                    }
                }
            }

            xlWorkbook.SaveAs("C:\\Users\\tplateus\\Desktop\\XML\\output.xlsx", Excel.XlFileFormat.xlWorkbookDefault, missing, missing, missing, missing, Excel.XlSaveAsAccessMode.xlExclusive, missing, missing, missing, missing, missing);
            xlWorkbook.Close(true, missing, missing);
            xlApp.DisplayAlerts = true;
            xlApp.Quit();

            Marshal.ReleaseComObject(xlWorksheet);
            Marshal.ReleaseComObject(xlWorkbook);
            Marshal.ReleaseComObject(xlApp);

            string elapsed = watch.ElapsedMilliseconds.ToString();

            string message = String.Concat("Done in ", elapsed, " ms.");

            MessageBox.Show(message);


        }

        private void DisplayInExcel2(string[,] Matrix)
        {
            Excel.Application app = null;
            Excel.Workbooks books = null;
            Excel.Workbook book = null;
            Excel.Sheets sheets = null;
            Excel.Worksheet sheet = null;
          
            Excel.Range range = null;
            Excel.Range rows = null;


            try
            {
                app = new Excel.Application();
                books = app.Workbooks;
                book = books.Open(@"C:\Users\tplateus\Documents\Custom Office Templates\templatev1.xltx");
                sheets = book.Sheets;
                sheet = sheets.Item[1];
                range = sheet.Cells[1,1];

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
                            if (allSameValues.Count < listRow.Count-3)
                            {
                                //Console.WriteLine(row.Cells[iRow, listRow.Count].Value2);
                                Excel.Range value = row.Cells[1, i+1];
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
                book.SaveAs("C:\\Users\\tplateus\\Desktop\\XML\\output.xlsx", Excel.XlFileFormat.xlWorkbookDefault, missing, missing, missing, missing, Excel.XlSaveAsAccessMode.xlExclusive, missing, missing, missing, missing, missing);
                book.Close(true, missing, missing);
                app.DisplayAlerts = true;
                app.Quit();
            }
            finally
            {
                if (rows != null) Marshal.ReleaseComObject(rows);
                if (range != null) Marshal.ReleaseComObject(range);
                if (sheet != null) Marshal.ReleaseComObject(sheet);
                if (sheets != null) Marshal.ReleaseComObject(sheets);
                if (book != null) Marshal.ReleaseComObject(book);
                if (books != null) Marshal.ReleaseComObject(books);
                if (app != null) Marshal.ReleaseComObject(app);

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
            }
        }

        private void GenerateExcelBtn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();
            filepaths = LoadPaths();
            fileIds = LoadIds();
            if (filepaths.Count == 0 || fileIds.Count == 0)
            {
                DisplayErrors(new List<string> { "At least one file has to be selected." });
                return;
            }
            List<Entry> baseList = LoadParamList(filepaths[0], fileIds[0]);

            for (int i = 1; i < filepaths.Count; i++)
            {
                List<Entry> newList = LoadParamList(filepaths[i], fileIds[i]);
                baseList = AddToList2(baseList, newList);
            }



            string[,] test = GetMatrix(baseList, fileIds);
            DisplayInExcel2(test);
            string elapsed = watch.Elapsed.ToString();
            Console.WriteLine("Elapsed time: {0}", elapsed);
            string message = "An output file 'output.xlsx' was created at C:/Users/tplateus/Desktop/XML.";
            message = message + Environment.NewLine + "Elapsed time: ";
            
            elapsed = String.Concat(message, elapsed, "s.");
            MessageBox.Show(elapsed);
        }

        private void AddDescriptionBtn_Click(object sender, EventArgs e)
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
                AddDescriptionBtn_Click(sender, e);
            }
        }

        private void DisclaimerLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
