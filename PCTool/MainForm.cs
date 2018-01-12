// file:	MainForm.cs
//
// summary:	Implements the MainForm class

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
using System.Xml;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices; // to release COM objects using Marshal

namespace PCTool
{
    /// <summary> Main form. </summary>
    /// <remarks> Tplateus, 3/01/2018. </remarks>
    public partial class MainForm : Form
    {
        
        /// <summary> The full pathname of the outputfile. Will be set using the method SetOutputFile </summary>
        public string outputfile = "";
        

        /// <summary> Default constructor. </summary>
        /// <remarks> Tplateus, 3/01/2018. </remarks>
        public MainForm()
        {
            InitializeComponent();
        }


        #region Dataloader methods
        /// <summary> Loads an XML file with paramList elements into a list of entries. </summary>
        /// <remarks> Tplateus, 3/01/2018. </remarks>
        /// <param name="filepath"> The filepath. </param>
        /// <param name="fileId">   Identifier for the file. Will be used to compare entries of diffenrent files and to populate Excel header row. </param>
        /// <returns> The list of entries. </returns>
        private List<Entry> LoadParamList(string filepath, string fileId)
        {

            try
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
            catch (XmlException xmlEx)
            {
                string message = "The following file is not valid XML:" + Environment.NewLine + filepath + "." + Environment.NewLine + Environment.NewLine + xmlEx.Message;
                Exception e = new Exception(message);
                throw e;
            }
        }

        /// <summary> Transform list of entries into 2D array. </summary>
        /// <remarks> Tplateus, 3/01/2018. </remarks>
        /// <param name="Entries"> The entries. </param>
        /// <param name="FileIds"> List of identifiers for the files (for the headers). </param>
        /// <returns> A 2D array of strings. </returns>
        private string[,] TransformInto2DArray(List<Entry> Entries, List<string> FileIds)
        {
            int rowCount = Entries.Count;
            int colCount = FileIds.Count;

            //Make an array of strings with dimension rowCount+1 (add 1 row for headers) and colCount+4 (add 4 rows for identifiers).
            string[,] matrix = new string[rowCount + 1, colCount + 4];
            matrix[0, 0] = "SetName";
            matrix[0, 1] = "ListName";
            matrix[0, 2] = "ParamName";
            matrix[0, 3] = "ConfigName";

            for (int i = 0; i < colCount; i++)
            {
                matrix[0, i + 4] = FileIds[i];
            }

            for (int i = 0; i < rowCount; i++)
            {
                Entry entry = Entries[i];
                matrix[i + 1, 0] = entry.SetName;
                matrix[i + 1, 1] = entry.ListName;
                matrix[i + 1, 2] = entry.ParamName;
                matrix[i + 1, 3] = entry.ConfigName;

                for (int j = 0; j < colCount; j++)
                {
                    string id = FileIds[j];

                    ParamValue val = entry.Values.Find(v => v.FileId == id);
                    if (val != null)
                    {
                        matrix[i + 1, j + 4] = val.Value;
                    }
                    else
                    {
                        matrix[i + 1, j + 4] = "!NOT_FOUND";
                    }

                }
            }
            return matrix;
        }

        /// <summary> Merge two lists of entries. </summary>
        /// <remarks> Tplateus, 3/01/2018. </remarks>
        /// <param name="baselist">  The baselist. </param>
        /// <param name="listToAdd"> The list to add. </param>
        /// <returns> The merged list; </returns>
        private List<Entry> MergeLists(List<Entry> baselist, List<Entry> listToAdd)
        {
            List<Entry> result = baselist;
            foreach (Entry entry in listToAdd)
            {
                int index = result.FindIndex(e => (e.SetName == entry.SetName && e.ListName == entry.ListName && e.ParamName == entry.ParamName && e.ConfigName == entry.ConfigName));

                if (index == -1)
                {
                    result.Add(entry);
                }
                else
                {
                    result[index].Merge(entry);
                }

            }

            return result;
        }

        /// <summary> Loads file paths. </summary>
        /// <remarks> Tplateus, 3/01/2018. </remarks>
        /// <returns> The file paths. Returns null if a filepath was omitted.</returns>
        private List<string> LoadFilePaths()
        {
            List<string> paths = new List<string>();

            try
            {
                int nRows = dataGridView1.Rows.Count;

                if (nRows != 0)
                {
                    for (int i = 0; i < nRows; i++)
                    {
                        paths.Add(dataGridView1.Rows[i].Cells[1].Value.ToString());
                    }

                }
            }
            catch (NullReferenceException)
            {
                paths = null;
            }

            return paths;
        }

        /// <summary> Loads the identifiers. </summary>
        /// <remarks> Tplateus, 3/01/2018. </remarks>
        /// <returns> The identifiers. Returns null if a fileId was omitted.</returns>
        private List<string> LoadIds()
        {

            List<string> Ids = new List<string>();

            try
            {
                int nRows = dataGridView1.Rows.Count;

                if (nRows != 0)
                {
                    //For each row, take the value of the 1st column of the Grid and store it as a string in Ids.
                    for (int i = 0; i < nRows; i++)
                    {
                        Ids.Add(dataGridView1.Rows[i].Cells[0].Value.ToString());
                    }
                }
            }
            catch (NullReferenceException)
            {
                Ids = null;
            }



            return Ids;
        }

        /// <summary> Sets global variable outputfile (if no errors occured). </summary>
        /// <remarks> Tplateus, 3/01/2018. </remarks>
        /// <param name="outputDirectory"> Pathname of the output directory. </param>
        /// <param name="outputFilename">  Filename of the output file. </param>
        /// <returns> A list of errors.</returns>
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

        /// <summary> Check if 'list1' has same SetName as 'list2'. </summary>
        /// <remarks> Tplateus, 4/01/2018. </remarks>
        /// <param name="list1"> The first list. </param>
        /// <param name="list2"> The second list. </param>
        /// <returns> True if same set, false if not. </returns>
        private bool IsSameSet(List<Entry> list1, List<Entry> list2)
        {
            bool isSameSet = false;

            if (list1[0].SetName == list2[0].SetName)
            {
                isSameSet = true;
            }
            return isSameSet;
        }

        #endregion


        #region Display/output methods
        /// <summary> Displays a list of errors in a MessageBox. </summary>
        /// <remarks> Tplateus, 3/01/2018. </remarks>
        /// <param name="errors"> The errors. </param>
        private void DisplayErrors(List<string> errors)
        {
            string errorMessage = "The following errors have occured:";
            foreach (string error in errors)
            {
                errorMessage = errorMessage + Environment.NewLine + "   \u2022 " + error;

            }
            MessageBox.Show(errorMessage, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        private void DisplayErrors(string error)
        {
            string errorMessage = "The following error has occured:" + Environment.NewLine + Environment.NewLine + error;

            MessageBox.Show(errorMessage, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        /// <summary> Adds path and fileId to the grid view. </summary>
        /// <remarks> Tplateus, 3/01/2018. </remarks>
        /// <param name="sender">      Source of the event. </param>
        /// <param name="goBackTwice"> True to go back two Controls and focus. False to only go back one Control. </param>
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

        /// <summary> Displays a 2DArray in excel. </summary>
        /// <remarks> Tplateus, 3/01/2018. </remarks>
        /// <param name="Matrix"> The 2DArray of entries. </param>
        private void DisplayInExcel2(string[,] Matrix)
        {
            Excel.Application app = null;
            Excel.Application openApp = null;

            Excel.Workbooks books = null;
            Excel.Workbooks openBooks = null;

            Excel.Workbook book = null;

            Excel.Sheets sheets = null;
            Excel.Worksheet sheet = null;

            Excel.Range range = null;
            Excel.Range rows = null;
            Excel.Range cols = null;

            List<string> errors = new List<string>();

            try
            {
                try
                {
                    openApp = (Excel.Application)Marshal.GetActiveObject("Excel.Application");

                    openBooks = openApp.Workbooks;

                    for (int i = 1; i <= openBooks.Count; i++)
                    {
                        Excel.Workbook openBook = openBooks.Item[i];
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


                app = new Excel.Application();

                if (app == null)
                {
                    errors.Add("No working instance of Excel could be found on this computer.");
                }

                if (errors.Count == 0)
                {



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

                    cols = range.Columns;

                    //Set column widths to 300 pixels for each column in range.
                    for (int iCol = 1; iCol <= columnCount; iCol++) //COMObject has a 1-based index.
                    {
                        Excel.Range column = cols[iCol];
                        column.ColumnWidth = 32.56; //Translates to 300 pixels. Verify in Excel.

                        if (column != null) Marshal.ReleaseComObject(column);
                    }

                    for (int iRow = 2; iRow <= rowCount; iRow++) // COMObject index starts at 1, not 0. First row is ignored (headers) => iRow = 2
                    {
                        Excel.Range row = rows.Item[iRow]; 

                        object[,] objRow = row.Value2;
                        List<string> listRow = objRow.Cast<string>().ToList(); //To utilize methods like findAll, the array is transformed to a list.

                        for (int i = 4; i < listRow.Count; i++) //First 3 columns are ignored since they dont have values (only ids).
                        {
                            string cellValue = listRow[i];
                            List<string> allSameValues = listRow.FindAll(x => x == cellValue); //Search all cells with value == current cell value. If all values in the row are the same, its count should be the listRowCount -3 (ids).
                            List<string> allValuesWithNotFound = listRow.FindAll(x => x == "!NOT_FOUND"); //!NOT_FOUND value is manually added in the 'TransformInto2DArray' method.

                            if (allValuesWithNotFound.Count == 0)
                            {
                                if (allSameValues.Count < listRow.Count - 4)
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

                    string message = "The file '" + OutputFilenameBox.Text + ".xlsx' was succesfully created and placed in " + OutputDirBox.Text;
                    MessageBox.Show(message, "Succes!");
                }
                else
                {
                    DisplayErrors(errors);
                }
            }
            finally
            {
                if (cols != null) Marshal.ReleaseComObject(cols);
                if (rows != null) { Marshal.ReleaseComObject(rows); Console.WriteLine("COMObject 'rows' released."); }
                if (range != null) { Marshal.ReleaseComObject(range); Console.WriteLine("COMObject 'range' released."); }
                if (sheet != null) { Marshal.ReleaseComObject(sheet); Console.WriteLine("COMObject 'sheet' released."); }
                if (sheets != null) { Marshal.ReleaseComObject(sheets); Console.WriteLine("COMObject 'sheets' released."); }
                if (book != null) { Marshal.ReleaseComObject(book); Console.WriteLine("COMObject 'book' released."); }
                if (books != null) { Marshal.ReleaseComObject(books); Console.WriteLine("COMObject 'books' released."); }
                if (app != null) { Marshal.ReleaseComObject(app); Console.WriteLine("COMObject 'app' released."); }


            }



        }

        /// <summary> Generates the Excel file and populates it. </summary>
        /// <remarks> Tplateus, 3/01/2018. </remarks>
        private void GenerateExcel()
        {
            List<string> errors = SetOutputFile(OutputDirBox.Text, OutputFilenameBox.Text);
            List<string> filepaths = LoadFilePaths();
            List<string> fileIds = LoadIds();

            if (fileIds == null)
            {
                errors.Add("File description cannot be empty.");
            }

            if (filepaths == null)
            {
                errors.Add("Filepath cannot be empty.");
            }
            else if (filepaths.Count == 0)
            {
                errors.Add("At least one file has to be selected.");
            }

            if (errors.Count != 0)
            {
                DisplayErrors(errors);
                return;
            }

            try
            {
                //Create a 'baselist' of entries (1 file), then merge all other files into this list.
                List<Entry> baseList = LoadParamList(filepaths[0], fileIds[0]);

                for (int i = 1; i < filepaths.Count; i++)
                {
                    List<Entry> newList = LoadParamList(filepaths[i], fileIds[i]);

                    if (!IsSameSet(baseList,newList))
                    {
                        string message = "The selected files have different setnames." + Environment.NewLine + "Comparing files that come from different sets can take considerably longer. Do you want to continue?";
                        if (MessageBox.Show(message, "Attention!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return;
                        }
                    }
                    baseList = MergeLists(baseList, newList);
                }

                string[,] allCells = TransformInto2DArray(baseList, fileIds);
                DisplayInExcel2(allCells);
            }
            catch (Exception e)
            {
                DisplayErrors(e.Message);
                return;
            }

        }

        /// <summary> Creates a new directory if directory does not yet exist. </summary>
        /// <remarks> Tplateus, 3/01/2018. </remarks>
        /// <param name="directory"> Pathname of the directory. </param>
        /// <returns>  A list of errors (can be empty). Return null when the user cancels the action. </returns>
        private List<string> CreateDir(string directory)
        {

            List<string> errors = new List<string>();

            try
            {
                DirectoryInfo di = new DirectoryInfo(directory);

                if (!di.Exists)
                {
                    string message = "The directory does not exist. Create new directory?";
                    if (MessageBox.Show(message, "Attention",MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        di.Create();
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                errors.Add("You do not have sufficient access to create this directory.");
            }
            catch (PathTooLongException)
            {
                errors.Add("The selected path is too long.");
            }
            catch (ArgumentException e)
            {
                errors.Add(e.Message);
            }
            catch (Exception)
            {
                errors.Add("An unspecified error occured while creating the directory.");
            }

            return errors;

        }

        #endregion


        #region Event Handlers
        /// <summary> Event handler. Called by GenerateExcelBtn for click events. </summary>
        /// <remarks> Tplateus, 3/01/2018. </remarks>
        /// <param name="sender"> Source of the event. </param>
        /// <param name="e">      Event information. </param>
        private void GenerateExcelBtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            GenerateExcel();
            Cursor = Cursors.Arrow;
        }

        /// <summary> Event handler. Called by DescriptionBox for enter events. </summary>
        /// <remarks> Tplateus, 3/01/2018. </remarks>
        /// <param name="sender"> Source of the event. </param>
        /// <param name="e">      Key press event information. </param>
        private void DescriptionBox_Enter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                AddToGridView(sender, false);
            }
        }

        /// <summary> Event handler. Called by DisclaimerLbl for link clicked events. </summary>
        /// <remarks> Tplateus, 3/01/2018. </remarks>
        /// <param name="sender"> Source of the event. </param>
        /// <param name="e">      Link label link clicked event information. </param>
        private void DisclaimerLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Disclaimer copyrightForm = new Disclaimer();
            copyrightForm.ShowDialog(this);
        }

        /// <summary> Event handler. Called by AddToListBtn for click events. </summary>
        /// <remarks> Tplateus, 3/01/2018. </remarks>
        /// <param name="sender"> Source of the event. </param>
        /// <param name="e">      Event information. </param>
        private void AddToListBtn_Click(object sender, EventArgs e)
        {
            AddToGridView(sender, true);
        }

        /// <summary> Event handler. Called by BrowseDirBtn for click events. </summary>
        /// <remarks> Tplateus, 3/01/2018. </remarks>
        /// <param name="sender"> Source of the event. </param>
        /// <param name="e">      Event information. </param>
        private void BrowseDirBtn_Click(object sender, EventArgs e)
        {
            string selectedPath = "";

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                selectedPath = folderBrowserDialog1.SelectedPath;
                OutputDirBox.Text = selectedPath;
            }



        }

        /// <summary> Event handler. Called by DeleteFilesBtn for click events. </summary>
        /// <remarks> Tplateus, 3/01/2018. </remarks>
        /// <param name="sender"> Source of the event. </param>
        /// <param name="e">      Event information. </param>
        private void DeleteFilesBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear the table?", "", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                dataGridView1.Rows.Clear();
            }
        }

        /// <summary> Event handler. Called by OutputFilenameBox for enter events. </summary>
        /// <remarks> Tplateus, 3/01/2018. </remarks>
        /// <param name="sender"> Source of the event. </param>
        /// <param name="e">      Key press event information. </param>
        private void OutputFilenameBox_Enter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                this.GetNextControl((Control)sender, true).Focus();
            }
        }

        /// <summary> Event handler. Called by SelectFileBtn for click events. </summary>
        /// <remarks> Tplateus, 3/01/2018. </remarks>
        /// <param name="sender"> Source of the event. </param>
        /// <param name="e">      Event information. </param>
        private void SelectFileBtn_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                SelectFileLbl.Text = openFileDialog1.FileName;
                this.GetNextControl((Control)sender, true).Focus();
            }
        }

        /// <summary> Event handler. Called by OutputDirBox for leave events. Does nothing when OutputDirBox is empty. </summary>
        /// <remarks> Tplateus, 3/01/2018. </remarks>
        /// <param name="sender"> Source of the event. </param>
        /// <param name="e">      Event information. </param>
        private void OutputDirBox_Leave(object sender, EventArgs e)
        {
            string directory = OutputDirBox.Text;

            //To ensure users can still leave this field (e.g. to click on the browse button), nothing will be done when the field is empty.
            // This prevents the CreateDir method from throwing an ArgumentException.
            if (directory == "")
            {
                return;
            }

            List<string> dirErrs = CreateDir(directory);

            if (dirErrs == null)
            {
                OutputDirBox.Text = "";
            }
            else if (dirErrs.Count != 0)
            {
                DisplayErrors(dirErrs);
                OutputDirBox.Text = "";
            }

        }

        /// <summary> Event handler. Called by MainForm for key up events. Clicks GenerateExcelBtn if F5 is pressed. </summary>
        /// <remarks> Tplateus, 5/01/2018. </remarks>
        /// <param name="sender"> Source of the event. </param>
        /// <param name="e">      Key event information. </param>
        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                GenerateExcelBtn_Click(sender, e);
            }
        }
        #endregion

        #region Todo: Tables

        private List<ColumnRecord> LoadParamTable(string filepath,string fileId)
        {
            try
            {
                List<XElement> loadedXml = XElement.Load(filepath).Descendants("paramTable").ToList();

                List<ColumnRecord> records = new List<ColumnRecord>();

                foreach (XElement xTable in loadedXml)
                {
                    string setName = xTable.Element("setName").Value;
                    string tableName = xTable.Element("paramTableName").Value;

                    List<XElement> xRecords = xTable.Descendants("paramRecord").ToList();
                    foreach (XElement xRecord in xRecords)
                    {
                        string configName = xRecord.Element("configName").Value;

                        List<XElement> xValues = xRecord.Descendants("paramRecordValue").ToList();

                        foreach (XElement xRecordValue in xValues)
                        {
                            string columnName = xRecordValue.Element("paramColumnName").Value;
                            string columnValue = xRecordValue.Element("paramColumnValue").Value;

                            ParamValue pVal = new ParamValue(fileId, columnValue);
                            ColumnRecord colRec = new ColumnRecord(configName, columnName, pVal);

                            records.Add(colRec);
                        }
                    }
                }
                return records;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception while loading from file {0}:", filepath);
                Console.WriteLine(e.Message);
                return null;
            }

        }

        //Opgepast: Als de XML een lege paramLists node heeft (<paramLists />) dan geeft hij een error weer.
        // Todo: taal wijzigen
        
        #endregion

       
    }
}
