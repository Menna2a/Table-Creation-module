
namespace FileOrgPro
{
    partial class Form1
    {
        

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DGV = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ColHeaderTxt = new System.Windows.Forms.TextBox();
            this.colHeader = new System.Windows.Forms.Button();
            this.ColDeleteButton = new System.Windows.Forms.Button();
            this.RowDeleteButton = new System.Windows.Forms.Button();
            this.nullCheckTxt = new System.Windows.Forms.TextBox();
            this.CheckNullButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.addRowsButton = new System.Windows.Forms.Button();
            this.numOfRowsInput = new System.Windows.Forms.NumericUpDown();
            this.saveButton = new System.Windows.Forms.Button();
            this.saveFileNameTextBox = new System.Windows.Forms.TextBox();
            this.saveFilePathTxtBox = new System.Windows.Forms.TextBox();
            this.Clear = new System.Windows.Forms.Button();
            this.openTableButton = new System.Windows.Forms.Button();
            this.openFileNameTxtBox = new System.Windows.Forms.TextBox();
            this.openFilePathTxtBox = new System.Windows.Forms.TextBox();
            this.ConstraintChecker = new System.Windows.Forms.Button();
            this.constraint = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.ConstraintColumn = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PkLabel = new System.Windows.Forms.Label();
            this.PkColNameTxtBox = new System.Windows.Forms.TextBox();
            this.SetPKButton = new System.Windows.Forms.Button();
            this.UniqueCheckButton = new System.Windows.Forms.Button();
            this.UniqueChecKColNameTxtBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOfRowsInput)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV
            // 
            this.DGV.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.DGV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DGV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.GridColor = System.Drawing.SystemColors.Control;
            this.DGV.Location = new System.Drawing.Point(13, 52);
            this.DGV.Name = "DGV";
            this.DGV.RowHeadersWidth = 72;
            this.DGV.Size = new System.Drawing.Size(829, 272);
            this.DGV.TabIndex = 0;
            this.DGV.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.DGV_CellValidating_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("PMingLiU-ExtB", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(280, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Table Creation Module";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 372);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Column Header";
            // 
            // ColHeaderTxt
            // 
            this.ColHeaderTxt.BackColor = System.Drawing.SystemColors.Info;
            this.ColHeaderTxt.Location = new System.Drawing.Point(123, 371);
            this.ColHeaderTxt.Multiline = true;
            this.ColHeaderTxt.Name = "ColHeaderTxt";
            this.ColHeaderTxt.Size = new System.Drawing.Size(100, 21);
            this.ColHeaderTxt.TabIndex = 4;
            // 
            // colHeader
            // 
            this.colHeader.Location = new System.Drawing.Point(246, 369);
            this.colHeader.Name = "colHeader";
            this.colHeader.Size = new System.Drawing.Size(75, 23);
            this.colHeader.TabIndex = 6;
            this.colHeader.Text = "Create";
            this.colHeader.UseVisualStyleBackColor = true;
            this.colHeader.Click += new System.EventHandler(this.Create_Click);
            // 
            // ColDeleteButton
            // 
            this.ColDeleteButton.Location = new System.Drawing.Point(477, 369);
            this.ColDeleteButton.Name = "ColDeleteButton";
            this.ColDeleteButton.Size = new System.Drawing.Size(136, 23);
            this.ColDeleteButton.TabIndex = 8;
            this.ColDeleteButton.Text = "Delete Column";
            this.ColDeleteButton.UseVisualStyleBackColor = true;
            this.ColDeleteButton.Click += new System.EventHandler(this.ColDeleteButton_Click);
            // 
            // RowDeleteButton
            // 
            this.RowDeleteButton.Location = new System.Drawing.Point(619, 369);
            this.RowDeleteButton.Name = "RowDeleteButton";
            this.RowDeleteButton.Size = new System.Drawing.Size(136, 23);
            this.RowDeleteButton.TabIndex = 9;
            this.RowDeleteButton.Text = "Delete Row";
            this.RowDeleteButton.UseVisualStyleBackColor = true;
            this.RowDeleteButton.Click += new System.EventHandler(this.RowDeleteButton_Click);
            // 
            // nullCheckTxt
            // 
            this.nullCheckTxt.BackColor = System.Drawing.SystemColors.Info;
            this.nullCheckTxt.Location = new System.Drawing.Point(123, 494);
            this.nullCheckTxt.Margin = new System.Windows.Forms.Padding(2);
            this.nullCheckTxt.Multiline = true;
            this.nullCheckTxt.Name = "nullCheckTxt";
            this.nullCheckTxt.Size = new System.Drawing.Size(100, 20);
            this.nullCheckTxt.TabIndex = 11;
            // 
            // CheckNullButton
            // 
            this.CheckNullButton.Location = new System.Drawing.Point(246, 491);
            this.CheckNullButton.Margin = new System.Windows.Forms.Padding(2);
            this.CheckNullButton.Name = "CheckNullButton";
            this.CheckNullButton.Size = new System.Drawing.Size(75, 23);
            this.CheckNullButton.TabIndex = 13;
            this.CheckNullButton.Text = "Check";
            this.CheckNullButton.UseVisualStyleBackColor = true;
            this.CheckNullButton.Click += new System.EventHandler(this.CheckNullButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 497);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Check If Null";
            // 
            // addRowsButton
            // 
            this.addRowsButton.Location = new System.Drawing.Point(246, 411);
            this.addRowsButton.Name = "addRowsButton";
            this.addRowsButton.Size = new System.Drawing.Size(75, 23);
            this.addRowsButton.TabIndex = 15;
            this.addRowsButton.Text = "Add rows";
            this.addRowsButton.UseVisualStyleBackColor = true;
            this.addRowsButton.Click += new System.EventHandler(this.addRowsButton_Click);
            // 
            // numOfRowsInput
            // 
            this.numOfRowsInput.Location = new System.Drawing.Point(123, 414);
            this.numOfRowsInput.Name = "numOfRowsInput";
            this.numOfRowsInput.Size = new System.Drawing.Size(100, 20);
            this.numOfRowsInput.TabIndex = 16;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(761, 449);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 17;
            this.saveButton.Text = "Save Table";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // saveFileNameTextBox
            // 
            this.saveFileNameTextBox.Location = new System.Drawing.Point(634, 451);
            this.saveFileNameTextBox.Name = "saveFileNameTextBox";
            this.saveFileNameTextBox.Size = new System.Drawing.Size(121, 20);
            this.saveFileNameTextBox.TabIndex = 18;
            // 
            // saveFilePathTxtBox
            // 
            this.saveFilePathTxtBox.Location = new System.Drawing.Point(508, 452);
            this.saveFilePathTxtBox.Name = "saveFilePathTxtBox";
            this.saveFilePathTxtBox.Size = new System.Drawing.Size(120, 20);
            this.saveFilePathTxtBox.TabIndex = 21;
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(761, 369);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(75, 23);
            this.Clear.TabIndex = 22;
            this.Clear.Text = "Clear Table";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // openTableButton
            // 
            this.openTableButton.Location = new System.Drawing.Point(761, 494);
            this.openTableButton.Name = "openTableButton";
            this.openTableButton.Size = new System.Drawing.Size(75, 23);
            this.openTableButton.TabIndex = 23;
            this.openTableButton.Text = "Open Table";
            this.openTableButton.UseVisualStyleBackColor = true;
            this.openTableButton.Click += new System.EventHandler(this.openTableButton_Click);
            // 
            // openFileNameTxtBox
            // 
            this.openFileNameTxtBox.Location = new System.Drawing.Point(634, 496);
            this.openFileNameTxtBox.Name = "openFileNameTxtBox";
            this.openFileNameTxtBox.Size = new System.Drawing.Size(121, 20);
            this.openFileNameTxtBox.TabIndex = 24;
            // 
            // openFilePathTxtBox
            // 
            this.openFilePathTxtBox.Location = new System.Drawing.Point(508, 497);
            this.openFilePathTxtBox.Name = "openFilePathTxtBox";
            this.openFilePathTxtBox.Size = new System.Drawing.Size(120, 20);
            this.openFilePathTxtBox.TabIndex = 25;
            // 
            // ConstraintChecker
            // 
            this.ConstraintChecker.Location = new System.Drawing.Point(261, 589);
            this.ConstraintChecker.Margin = new System.Windows.Forms.Padding(2);
            this.ConstraintChecker.Name = "ConstraintChecker";
            this.ConstraintChecker.Size = new System.Drawing.Size(75, 23);
            this.ConstraintChecker.TabIndex = 32;
            this.ConstraintChecker.Text = "Check";
            this.ConstraintChecker.UseVisualStyleBackColor = true;
            this.ConstraintChecker.Click += new System.EventHandler(this.ConstraintChecker_Click);
            // 
            // constraint
            // 
            this.constraint.Location = new System.Drawing.Point(184, 589);
            this.constraint.Margin = new System.Windows.Forms.Padding(2);
            this.constraint.Name = "constraint";
            this.constraint.Size = new System.Drawing.Size(56, 20);
            this.constraint.TabIndex = 31;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.ItemHeight = 13;
            this.comboBox1.Items.AddRange(new object[] {
            ">",
            "<",
            "=",
            ">=",
            "<=",
            "!="});
            this.comboBox1.Location = new System.Drawing.Point(125, 589);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(50, 21);
            this.comboBox1.TabIndex = 30;
            // 
            // ConstraintColumn
            // 
            this.ConstraintColumn.Location = new System.Drawing.Point(17, 589);
            this.ConstraintColumn.Margin = new System.Windows.Forms.Padding(2);
            this.ConstraintColumn.Name = "ConstraintColumn";
            this.ConstraintColumn.Size = new System.Drawing.Size(97, 20);
            this.ConstraintColumn.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 562);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 17);
            this.label4.TabIndex = 28;
            this.label4.Text = "Constraint Checker";
            // 
            // PkLabel
            // 
            this.PkLabel.AutoSize = true;
            this.PkLabel.Location = new System.Drawing.Point(16, 459);
            this.PkLabel.Name = "PkLabel";
            this.PkLabel.Size = new System.Drawing.Size(62, 13);
            this.PkLabel.TabIndex = 33;
            this.PkLabel.Text = "Primary Key";
            // 
            // PkColNameTxtBox
            // 
            this.PkColNameTxtBox.Location = new System.Drawing.Point(123, 459);
            this.PkColNameTxtBox.Name = "PkColNameTxtBox";
            this.PkColNameTxtBox.Size = new System.Drawing.Size(100, 20);
            this.PkColNameTxtBox.TabIndex = 34;
            // 
            // SetPKButton
            // 
            this.SetPKButton.Location = new System.Drawing.Point(246, 459);
            this.SetPKButton.Name = "SetPKButton";
            this.SetPKButton.Size = new System.Drawing.Size(75, 23);
            this.SetPKButton.TabIndex = 35;
            this.SetPKButton.Text = "set";
            this.SetPKButton.UseVisualStyleBackColor = true;
            this.SetPKButton.Click += new System.EventHandler(this.SetPKButton_Click);
            // 
            // UniqueCheckButton
            // 
            this.UniqueCheckButton.Location = new System.Drawing.Point(246, 525);
            this.UniqueCheckButton.Name = "UniqueCheckButton";
            this.UniqueCheckButton.Size = new System.Drawing.Size(75, 23);
            this.UniqueCheckButton.TabIndex = 36;
            this.UniqueCheckButton.Text = "check";
            this.UniqueCheckButton.UseVisualStyleBackColor = true;
            this.UniqueCheckButton.Click += new System.EventHandler(this.UniqueCheckButton_Click);
            // 
            // UniqueChecKColNameTxtBox
            // 
            this.UniqueChecKColNameTxtBox.BackColor = System.Drawing.SystemColors.Info;
            this.UniqueChecKColNameTxtBox.Location = new System.Drawing.Point(123, 527);
            this.UniqueChecKColNameTxtBox.Margin = new System.Windows.Forms.Padding(2);
            this.UniqueChecKColNameTxtBox.Multiline = true;
            this.UniqueChecKColNameTxtBox.Name = "UniqueChecKColNameTxtBox";
            this.UniqueChecKColNameTxtBox.Size = new System.Drawing.Size(100, 20);
            this.UniqueChecKColNameTxtBox.TabIndex = 37;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 532);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 16);
            this.label5.TabIndex = 38;
            this.label5.Text = "Check unique";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(855, 637);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.UniqueChecKColNameTxtBox);
            this.Controls.Add(this.UniqueCheckButton);
            this.Controls.Add(this.SetPKButton);
            this.Controls.Add(this.PkColNameTxtBox);
            this.Controls.Add(this.PkLabel);
            this.Controls.Add(this.ConstraintChecker);
            this.Controls.Add(this.constraint);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.ConstraintColumn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.openFilePathTxtBox);
            this.Controls.Add(this.openFileNameTxtBox);
            this.Controls.Add(this.openTableButton);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.saveFilePathTxtBox);
            this.Controls.Add(this.saveFileNameTextBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.numOfRowsInput);
            this.Controls.Add(this.addRowsButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CheckNullButton);
            this.Controls.Add(this.nullCheckTxt);
            this.Controls.Add(this.RowDeleteButton);
            this.Controls.Add(this.ColDeleteButton);
            this.Controls.Add(this.colHeader);
            this.Controls.Add(this.ColHeaderTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DGV);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOfRowsInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion
        
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ColHeaderTxt;
        private System.Windows.Forms.Button colHeader;
        private System.Windows.Forms.Button ColDeleteButton;
        private System.Windows.Forms.Button RowDeleteButton;
        private System.Windows.Forms.TextBox nullCheckTxt;
        private System.Windows.Forms.Button CheckNullButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button addRowsButton;
        private System.Windows.Forms.NumericUpDown numOfRowsInput;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox saveFileNameTextBox;
        private System.Windows.Forms.TextBox saveFilePathTxtBox;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Button openTableButton;
        private System.Windows.Forms.TextBox openFileNameTxtBox;
        private System.Windows.Forms.TextBox openFilePathTxtBox;
        private System.Windows.Forms.Button ConstraintChecker;
        private System.Windows.Forms.TextBox constraint;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox ConstraintColumn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label PkLabel;
        private System.Windows.Forms.TextBox PkColNameTxtBox;
        private System.Windows.Forms.Button SetPKButton;
        private System.Windows.Forms.Button UniqueCheckButton;
        private System.Windows.Forms.TextBox UniqueChecKColNameTxtBox;
        private System.Windows.Forms.Label label5;
    } 
}

