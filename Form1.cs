using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FileOrgPro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DGV.AllowUserToAddRows = false;
        }


        int counter = 0, nullCheckIndex =-1, uniqueCheckIndex = -1, primaryKeyindex = -1, constrainCheckIndex = -1;

        private void Create_Click(object sender, EventArgs e)
        {
            addColumn();

        }

        private void addColumn()
        {
            var col = new DataGridViewTextBoxColumn();
            //string noNewLines = DeleteNewLines(ColHeaderTxt.Text);
            col.HeaderText = ColHeaderTxt.Text;
            col.Name = "Col" + counter;
            DGV.Columns.AddRange(new DataGridViewColumn[] { col });
            ColHeaderTxt.Text = "";
           counter++;
        }

        /*private string DeleteNewLines(string raw)
        {
            string noNewLines = "";
            string[] unpack;
            unpack = raw.Split('\n');
            int x;
            foreach(string str in unpack)
            {
                x = str.IndexOf('\n');
                if(x > -1) { str.Remove(x); }
                noNewLines += str;
            }

            return noNewLines;
        }*/

        private void RowDeleteButton_Click(object sender, EventArgs e)
        {
           if (DGV.CurrentRow != null)
            {
                DGV.Rows.Remove(DGV.CurrentRow);
            }
        }

        private void ColDeleteButton_Click(object sender, EventArgs e)
        {
            DGV.Columns.RemoveAt(DGV.CurrentCell.ColumnIndex);
            counter--;
        }

        private void addRowsButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (numOfRowsInput.Value == 0)
                {
                    DGV.Rows.Add();
                }
                else
                {
                    for (int i = 1; i <= numOfRowsInput.Value; i++)
                    {
                        DGV.Rows.Add();
                    }
                }
            }
            catch
            {
                DialogResult cantAddRow = MessageBox.Show("make sure that there are columns added before trying to add new rows", "no columns found", MessageBoxButtons.OK);
            }
        }

        private void openTableButton_Click(object sender, EventArgs e)
        {
            string filePath = @openFilePathTxtBox.Text;
            string fileName = @openFileNameTxtBox.Text;


            FileStream openFile;
            BinaryFormatter bf;
            StreamReader sr;
            gridViewDataGraber gvdg;


            try
            {
                openFile = new FileStream(filePath + "\\" + fileName + ".txt", FileMode.Open);
                bf = new BinaryFormatter();
                gvdg = (gridViewDataGraber)bf.Deserialize(openFile);

                openFile.Close();
               
                MessageBox.Show("Table Data grabbed");
               try
               {
                    openFile = new FileStream(filePath + "\\" + fileName + "-ColInfo" + ".txt", FileMode.Open);
                    sr = new StreamReader(openFile);

                    string[] tableDataInfo = new string[6];
                    string[] temp;

                    sr.ReadLine();
                    for (int i = 0;i<6 && sr.Peek() != -1; i++)
                    {
                        string tmp = sr.ReadLine();
                        temp = tmp.Split(':');
                        tableDataInfo[i] = temp[1];
                    }
                    openFile.Close();
                    sr.Close();

                    primaryKeyindex = Convert.ToInt32(tableDataInfo[0]);
                    nullCheckIndex = Convert.ToInt32(tableDataInfo[1]);
                    uniqueCheckIndex = Convert.ToInt32(tableDataInfo[2]);
                    constrainCheckIndex = Convert.ToInt32(tableDataInfo[3]);
                    constraint.Text = tableDataInfo[4];
                    comboBox1.SelectedIndex = Convert.ToInt32(tableDataInfo[5]);
                    

                    setDGVData(gvdg.ColumnsHeaderNames,gvdg.TableData);
                    if(primaryKeyindex > -1 && primaryKeyindex < DGV.Columns.Count)
                    {
                        PkColNameTxtBox.Text = DGV.Columns[primaryKeyindex].HeaderText;
                    }
                    if (nullCheckIndex > -1 && nullCheckIndex < DGV.Columns.Count)
                    {
                       nullCheckTxt.Text = DGV.Columns[nullCheckIndex].HeaderText;
                    }
                    if (constrainCheckIndex > -1 && constrainCheckIndex < DGV.Columns.Count)
                    {
                        ConstraintColumn.Text = DGV.Columns[constrainCheckIndex].HeaderText;
                    }
                    if (uniqueCheckIndex > -1 && uniqueCheckIndex < DGV.Columns.Count)
                    {
                        UniqueChecKColNameTxtBox.Text = DGV.Columns[uniqueCheckIndex].HeaderText;
                    }
               }
               catch
               {
                   MessageBox.Show("Could not load " + fileName + "-ColInfo.txt properly, check file Path for its existance.");
               }

            }
            catch
            {
                MessageBox.Show(fileName + " doesn't exist in givin context of path");
            }
           

        }

        private void Clear_Click(object sender, EventArgs e)
        {
            ClearDGV();
        }

        private void ClearDGV()
        {
            while (DGV.Rows.Count > 0)
            {
                DGV.Rows.RemoveAt(DGV.Rows.Count - 1);
            }
            while (DGV.Columns.Count > 0)
            {
                DGV.Columns.RemoveAt(DGV.Columns.Count - 1);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit form?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string filePath = @saveFilePathTxtBox.Text;
            string fileName = @saveFileNameTextBox.Text;
            if (checkNullColumn() && CheckConstraintColumn() && ColumnUniqueCheck(UniqueChecKColNameTxtBox.Text))
            {
                DialogResult result = MessageBox.Show("are you sure that you want to name your file " + fileName + "?", "Save", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK) // Test result.
                {
                    gridViewDataGraber gvdg = new gridViewDataGraber(GetColumHeadertext(), GetTableData());

                    try 
                    {
                        FileStream saveFile = new FileStream(filePath + "\\" + fileName + ".txt", FileMode.Truncate);
                        saveFile.Close();
                        saveFile = new FileStream(filePath + "\\" + fileName + ".txt", FileMode.Append);
                        SaveTableData(filePath, fileName, saveFile, gvdg);
                    }
                    catch
                    {
                        FileStream saveFile = new FileStream(filePath + "\\" + fileName + ".txt", FileMode.Create);
                        SaveTableData(filePath, fileName, saveFile, gvdg);
                    }
                }
            }
        }   

        private void SaveTableData(string filePath, string fileName, FileStream saveFile, gridViewDataGraber gvdg)
        {
            try
            {
                BinaryFormatter br = new BinaryFormatter();
                br.Serialize(saveFile, gvdg);
                saveFile.Close();
            }
            catch
            {
               MessageBox.Show(fileName + "created but Data grid view is empty");
               saveFile.Close();
            }

            string colInfoText =
                "\nPK:" + primaryKeyindex +
                "\nnotNuLL:" + nullCheckIndex +
                "\nunique:"+ uniqueCheckIndex +
                "\nConst:" + constrainCheckIndex +
                "\nconstVal:" + constraint.Text +
                "\nconstCond:" + comboBox1.SelectedIndex;

            try
            {
                saveFile = new FileStream(filePath+ "\\" + fileName + "-ColInfo" + ".txt", FileMode.Truncate);
                saveFile.Close();
                saveFile = new FileStream(filePath + "\\" + fileName + "-ColInfo" + ".txt", FileMode.Append);
            }
            catch
            {
                saveFile.Close();
                saveFile = new FileStream(filePath + "\\" + fileName + "-ColInfo" + ".txt", FileMode.Create);
            }
            finally
            {
                StreamWriter writerFile = new StreamWriter(saveFile);
                writerFile.Write(colInfoText);
                writerFile.Close();
                MessageBox.Show("saved");
            }
        }
        
        public void setDGVData(List<string> columnsData, List<List<string>> tableData)
        {
            ClearDGV();
            foreach( string columnName in columnsData)
            {
                var col = new DataGridViewTextBoxColumn();
                col.HeaderText = columnName;
                col.Name = "Col" + col;
                DGV.Columns.AddRange(new DataGridViewColumn[] { col });
            }
            int i = 0;
            foreach( List<string> rowData in tableData)
            {
                DGV.Rows.Add();
                int j = 0;
                foreach(string cellData in rowData)
                {
                    DGV.Rows[i].Cells[j].Value = cellData;
                    j++;
                }
                i++;
            }
        }

        public List<List<string>> GetTableData()
        {
            List< List < string >> tableData = new List<List<string>>();
            foreach (DataGridViewRow row in DGV.Rows)
            {
                List<string> rowData = new List<string>();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if(cell.Value == null || cell.Value == DBNull.Value) 
                    {
                        rowData.Add("");
                    } 
                    else 
                    {
                        rowData.Add(cell.Value.ToString()); 
                    }
                    
                }
                tableData.Add(rowData);
            }
            return tableData;
        }

        public List<string> GetColumHeadertext()
        {
            List<string> columnsHeaderText = new List<string>();
            foreach ( DataGridViewColumn col in DGV.Columns)
            {
                columnsHeaderText.Add(col.HeaderText);
            }
            return columnsHeaderText;
        }

        private void ConstraintChecker_Click(object sender, EventArgs e)
        {
            CheckConstraintColumn();
        }

        private void CheckNullButton_Click(object sender, EventArgs e)
        {
            checkNullColumn();
        }
        private bool checkNullColumn()
        {

            // true equals check passed false equals failed

            DataGridViewColumn columnFound = new DataGridViewColumn();
            foreach (DataGridViewColumn col in DGV.Columns)
            {
                if (col.HeaderText.Equals(nullCheckTxt.Text))
                {
                    columnFound = col;
                    nullCheckIndex = col.Index;
                    break;
                }
            }
            int colIndex = DGV.Columns.IndexOf(columnFound);
            if (colIndex > -1)
            {
                string missingCells = columnFound.HeaderText + " Column has an empty cell at Rows :-";
                for (int i = 0; i < DGV.Rows.Count; i++)
                {

                    if (DGV.Rows[i].Cells[colIndex].Value == null || DGV.Rows[i].Cells[colIndex].Value == DBNull.Value || DGV.Rows[i].Cells[colIndex].Value == "")
                    {
                        missingCells += "\n \t" + DGV.Rows[i];

                    }

                }
                if (missingCells != (columnFound.HeaderText + " Column has an empty cell at Rows :-"))
                {
                    MessageBox.Show(missingCells);
                    return false;
                }
                else
                {
                    MessageBox.Show("no nulls found!");
                    return true;
                }

            }
            else
            {
                MessageBox.Show("column " + nullCheckTxt.Text + " could not be found", "column not found", MessageBoxButtons.OK);
                return true;
            }
        }

        private bool checkNullColumn(int colIndex)
        {
            DataGridViewColumn columnFound = DGV.Columns[colIndex];
            if (colIndex > -1)
            {
                string missingCells = columnFound.HeaderText + " Column has an empty cell at Rows :-";
                for (int i = 0; i < DGV.Rows.Count; i++)
                {

                    if (DGV.Rows[i].Cells[colIndex].Value == null || DGV.Rows[i].Cells[colIndex].Value == DBNull.Value || DGV.Rows[i].Cells[colIndex].Value == "")
                    {
                        missingCells += "\n \t" + DGV.Rows[i];

                    }

                }
                if (missingCells != (columnFound.HeaderText + " Column has an empty cell at Rows :-"))
                {
                    MessageBox.Show(missingCells);
                    return false;
                }
                else
                {
                    MessageBox.Show("All Good!");
                    return true;
                }

            }
            else
            {
                MessageBox.Show("column " + nullCheckTxt.Text + " could not be found", "column not found", MessageBoxButtons.OK);
                return true;
            }
        }

        private void CellCheckNull(System.Windows.Forms.DataGridViewCellValidatingEventArgs e)
        {
            if (e.FormattedValue == null | e.FormattedValue == DBNull.Value | e.FormattedValue.ToString() =="")
            {
                MessageBox.Show("cell [" + DGV.CurrentCell.RowIndex + ',' + DGV.CurrentCell.ColumnIndex + "] can not be empty");
            }
            else
            {
                
            }
        }

        private void DGV_CellValidating_1(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (DGV.CurrentCell.ColumnIndex == nullCheckIndex)
            {
                CellCheckNull(e);
            }
            if (DGV.CurrentCell.ColumnIndex == constrainCheckIndex)
            {
                ConstraintCellSwitchCheck(e);
            }
            if(DGV.CurrentCell.ColumnIndex == primaryKeyindex)
            {
                CellCheckNull(e);
                CellUniqueCheck(e);
            }
            if(DGV.CurrentCell.ColumnIndex == uniqueCheckIndex)
            {
                CellUniqueCheck(e);
            }
        }

        private void SetPKButton_Click(object sender, EventArgs e)
        {
            bool found = false;
            bool isValid = false;
            var Pk_Col = new DataGridViewTextBoxColumn();
            
            foreach (DataGridViewColumn col in DGV.Columns)
            {
                if (col.HeaderText.Equals(PkColNameTxtBox.Text))
                {
                    Pk_Col.HeaderText = PkColNameTxtBox.Text;
                    primaryKeyindex = col.Index;
                    if (checkNullColumn(primaryKeyindex) && ColumnUniqueCheck(Pk_Col.HeaderText))
                    {
                        isValid = true;
                    }
                    found = true;
                    break;
                }      
            }
            if (found && isValid)
            {
                MessageBox.Show(PkColNameTxtBox.Text + " column is now the primary key");
            }
            else if (found && !isValid)
            {
                MessageBox.Show("The column you entered is not valid either has null values or is not unique.");
            }
            else
            {
                MessageBox.Show("Could not find the column you entered.");
            }
        }

        private void UniqueCheckButton_Click(object sender, EventArgs e)
        {
            ColumnUniqueCheck(UniqueChecKColNameTxtBox.Text);
        }

        private bool ColumnUniqueCheck(string colName)
        {
            DataGridViewColumn selectedColumn = new DataGridViewColumn();
            foreach (DataGridViewColumn col in DGV.Columns)
            {
                if (col.HeaderText.Equals(colName))
                {
                    selectedColumn = col;
                    break;
                }
            }
            int colIndex = DGV.Columns.IndexOf(selectedColumn);
            uniqueCheckIndex = colIndex;
            int i ;
            string duplicateMessage = "column has duplacites at rows:- ";
            if (colIndex > -1)
            {
                for (i = 0; i < DGV.Rows.Count -1; i++)
                {
                    for (int j = i +1; j < DGV.Rows.Count; j++)
                    {
                        
                        if (DGV.Rows[i].Cells[colIndex].Value.ToString() == DGV.Rows[j].Cells[colIndex].Value.ToString())
                        {
                            duplicateMessage += "\n" + i.ToString() + " & " + j.ToString() ;
                        }
                    }
                }
                if (duplicateMessage.Equals("column has duplacites at rows:- "))
                {
                    
                    MessageBox.Show("No duplicates found.");
                    return true;
                }
                else
                {
                    MessageBox.Show(duplicateMessage);
                    return false;
                }
            }
            return true;
        }
        private bool CellUniqueCheck(DataGridViewCellValidatingEventArgs e)
        {
            int colIndex = DGV.CurrentCell.ColumnIndex ;
            int i ;
            string duplicateMessage = "column has duplacites at rows:- ";
            if (colIndex > -1)
            {
                for (i = 0; i < DGV.Rows.Count -1; i++)
                {
                    if (DGV.Rows[i].Cells[colIndex].Value.ToString() == e.FormattedValue.ToString())
                    {
                        if (i == e.ColumnIndex) { continue; }
                        duplicateMessage += "\n" + i.ToString() + " & " + e.RowIndex.ToString();
                    } 
                }
                if (duplicateMessage.Equals("column has duplacites at rows:- "))
                {
                    return true;
                }
                else
                {
                    MessageBox.Show(duplicateMessage);
                    return false;
                }
            }
            return true;
        }
        private bool CheckConstraintColumn()
        {
            bool x = true;
            if (constraint.Text != null && constraint.Text != "")
            {
                long numberConstraint = Convert.ToInt64(constraint.Text);
                string colName = ConstraintColumn.Text;
                
                foreach (DataGridViewColumn column in DGV.Columns)
                {
                    if (column.HeaderText == colName)
                    {
                        for (int iRow = 0; iRow < DGV.RowCount; iRow++)
                        {
                           
                            if (!ConstraintColumnSwitch(column, iRow, numberConstraint))
                            {
                            x = false;
                            }
                        }
                    }
                }
            }
            return x;
        }

        private bool ConstraintColumnSwitch(DataGridViewColumn column, int iRow, long numberConstraint)
        {
            string colName = column.HeaderText;
            constrainCheckIndex = column.Index;
            string data = (string)DGV[column.Index, iRow].Value;

            if ( data != null && data != DBNull.Value.ToString() && data != "")
            {
                //false equals failed true equals passed
                switch (comboBox1.SelectedItem)
                {
                    case ">":
                    if (Convert.ToInt64(data) < numberConstraint || Convert.ToInt64(data) == numberConstraint)
                    {
                    MessageBox.Show(colName + " Column, Row " + iRow + " should contain value greater than " + numberConstraint);
                    return false;
                    }
                    break;
                    case "<":
                     if (Convert.ToInt64(data) > numberConstraint || Convert.ToInt64(data) == numberConstraint)
                        {
                        MessageBox.Show(colName + " Column, Row " + iRow + " should contain value less than " + numberConstraint);
                        return false;
                    }
                    break;
                    case "=":
                    if (Convert.ToInt64(data) != numberConstraint)
                    {
                        MessageBox.Show(colName + " Column, Row " + iRow + " should contain value equal to " + numberConstraint);
                        return false;
                    }
                    break;
                    case ">=":
                    if (Convert.ToInt64(data) < numberConstraint && Convert.ToInt64(data) != numberConstraint)
                    {
                        MessageBox.Show(colName + " Column, Row " + iRow + " should contain value greater than or equal to " + numberConstraint);
                        return false;
                    }
                    break;
                    case "<=":
                    if (Convert.ToInt64(data) > numberConstraint && Convert.ToInt64(data) != numberConstraint)
                    {
                        MessageBox.Show(colName + " Column, Row " + iRow + " should contain value less than or equal to " + numberConstraint);
                        return false;
                    }
                    break;
                    case "!=":
                    if (Convert.ToInt64(data) == numberConstraint)
                    {
                        MessageBox.Show(colName + " Column, Row " + iRow + " should contain value not equal to " + numberConstraint);
                        return false;
                    }
                    break;

                    default:
                    MessageBox.Show("All good!");
                    return true;

                }
            }
            MessageBox.Show("ok");
            return true;
        }

        private bool ConstraintCellSwitchCheck(DataGridViewCellValidatingEventArgs e)
        {
            DataGridViewColumn column = DGV.Columns[DGV.CurrentCell.ColumnIndex];
            long numberConstraint = Convert.ToInt64(constraint.Text);

            string colName = column.HeaderText;
            string data = (string)e.FormattedValue;
            int iRow = DGV.CurrentCell.RowIndex;
            if(data != "" && data != null)
            {
                switch (comboBox1.SelectedItem)
                {
                case ">":
                    if (Convert.ToInt64(data) < numberConstraint || Convert.ToInt64(data) == numberConstraint)
                    {
                        MessageBox.Show(colName + " Column, Row " + iRow + " should contain value greater than " + numberConstraint);
                        return false;
                    }
                    break;
                case "<":
                    if (Convert.ToInt64(data) > numberConstraint || Convert.ToInt64(data) == numberConstraint)
                    {
                        MessageBox.Show(colName + " Column, Row " + iRow + " should contain value less than " + numberConstraint);
                        return false;
                    }
                    break;
                case "=":
                    if (Convert.ToInt64(data) != numberConstraint)
                    {
                        MessageBox.Show(colName + " Column, Row " + iRow + " should contain value equal to " + numberConstraint);
                        return false;
                    }
                    break;
                case ">=":
                    if (Convert.ToInt64(data) < numberConstraint && Convert.ToInt64(data) != numberConstraint)
                    {
                        MessageBox.Show(colName + " Column, Row " + iRow + " should contain value greater than or equal to " + numberConstraint);
                        return false;
                    }
                    break;
                case "<=":
                    if (Convert.ToInt64(data) > numberConstraint && Convert.ToInt64(data) != numberConstraint)
                    {
                        MessageBox.Show(colName + " Column, Row " + iRow + " should contain value less than or equal to " + numberConstraint);
                        return false;
                    }
                    break;
                case "!=":
                    if (Convert.ToInt64(data) == numberConstraint)
                    {
                        MessageBox.Show(colName + " Column, Row " + iRow + " should contain value not equal to " + numberConstraint);
                        return false;
                    }
                    break;

                default:
                    MessageBox.Show("All good!");
                    return true;
                }
            }
            return true;
        
            }
    }
}
