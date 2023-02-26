namespace OmniLifeValidationTool
  {
  partial class Form1
    {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
      {
      this.loadSupplierBtn = new System.Windows.Forms.Button();
      this.panel1 = new System.Windows.Forms.Panel();
      this.tabControl2 = new System.Windows.Forms.TabControl();
      this.tabPage3 = new System.Windows.Forms.TabPage();
      this.LoadedSupplierTb = new System.Windows.Forms.TextBox();
      this.showDuplicatesBtn = new System.Windows.Forms.Button();
      this.duplicateRowDgv = new System.Windows.Forms.DataGridView();
      this.tabPage4 = new System.Windows.Forms.TabPage();
      this.deleteRowBtn = new System.Windows.Forms.Button();
      this.tabControl2.SuspendLayout();
      this.tabPage3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.duplicateRowDgv)).BeginInit();
      this.SuspendLayout();
      // 
      // loadSupplierBtn
      // 
      this.loadSupplierBtn.Location = new System.Drawing.Point(6, 6);
      this.loadSupplierBtn.Name = "loadSupplierBtn";
      this.loadSupplierBtn.Size = new System.Drawing.Size(110, 23);
      this.loadSupplierBtn.TabIndex = 0;
      this.loadSupplierBtn.Text = "Load Supplier";
      this.loadSupplierBtn.UseVisualStyleBackColor = true;
      this.loadSupplierBtn.Click += new System.EventHandler(this.loadSupplierBtn_Click);
      // 
      // panel1
      // 
      this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.panel1.Location = new System.Drawing.Point(12, 12);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(1291, 718);
      this.panel1.TabIndex = 1;
      // 
      // tabControl2
      // 
      this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tabControl2.Controls.Add(this.tabPage3);
      this.tabControl2.Controls.Add(this.tabPage4);
      this.tabControl2.Location = new System.Drawing.Point(12, 12);
      this.tabControl2.Name = "tabControl2";
      this.tabControl2.SelectedIndex = 0;
      this.tabControl2.Size = new System.Drawing.Size(1288, 715);
      this.tabControl2.TabIndex = 1;
      // 
      // tabPage3
      // 
      this.tabPage3.Controls.Add(this.deleteRowBtn);
      this.tabPage3.Controls.Add(this.LoadedSupplierTb);
      this.tabPage3.Controls.Add(this.showDuplicatesBtn);
      this.tabPage3.Controls.Add(this.duplicateRowDgv);
      this.tabPage3.Controls.Add(this.loadSupplierBtn);
      this.tabPage3.Location = new System.Drawing.Point(4, 24);
      this.tabPage3.Name = "tabPage3";
      this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage3.Size = new System.Drawing.Size(1280, 687);
      this.tabPage3.TabIndex = 0;
      this.tabPage3.Text = "tabPage3";
      this.tabPage3.UseVisualStyleBackColor = true;
      // 
      // LoadedSupplierTb
      // 
      this.LoadedSupplierTb.Location = new System.Drawing.Point(122, 6);
      this.LoadedSupplierTb.Name = "LoadedSupplierTb";
      this.LoadedSupplierTb.Size = new System.Drawing.Size(100, 23);
      this.LoadedSupplierTb.TabIndex = 3;
      // 
      // showDuplicatesBtn
      // 
      this.showDuplicatesBtn.Location = new System.Drawing.Point(236, 5);
      this.showDuplicatesBtn.Name = "showDuplicatesBtn";
      this.showDuplicatesBtn.Size = new System.Drawing.Size(110, 23);
      this.showDuplicatesBtn.TabIndex = 2;
      this.showDuplicatesBtn.Text = "Show Duplicates";
      this.showDuplicatesBtn.UseVisualStyleBackColor = true;
      this.showDuplicatesBtn.Click += new System.EventHandler(this.showDuplicatesBtn_Click);
      // 
      // duplicateRowDgv
      // 
      this.duplicateRowDgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.duplicateRowDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.duplicateRowDgv.Location = new System.Drawing.Point(236, 35);
      this.duplicateRowDgv.Name = "duplicateRowDgv";
      this.duplicateRowDgv.RowTemplate.Height = 25;
      this.duplicateRowDgv.Size = new System.Drawing.Size(1038, 646);
      this.duplicateRowDgv.TabIndex = 1;
      // 
      // tabPage4
      // 
      this.tabPage4.Location = new System.Drawing.Point(4, 24);
      this.tabPage4.Name = "tabPage4";
      this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage4.Size = new System.Drawing.Size(1280, 687);
      this.tabPage4.TabIndex = 1;
      this.tabPage4.Text = "tabPage4";
      this.tabPage4.UseVisualStyleBackColor = true;
      // 
      // deleteRowBtn
      // 
      this.deleteRowBtn.Location = new System.Drawing.Point(352, 5);
      this.deleteRowBtn.Name = "deleteRowBtn";
      this.deleteRowBtn.Size = new System.Drawing.Size(75, 23);
      this.deleteRowBtn.TabIndex = 4;
      this.deleteRowBtn.Text = "Delete Row";
      this.deleteRowBtn.UseVisualStyleBackColor = true;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1315, 742);
      this.Controls.Add(this.tabControl2);
      this.Controls.Add(this.panel1);
      this.Name = "Form1";
      this.Text = "Form1";
      this.tabControl2.ResumeLayout(false);
      this.tabPage3.ResumeLayout(false);
      this.tabPage3.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.duplicateRowDgv)).EndInit();
      this.ResumeLayout(false);

      }

    #endregion
    private TabControl tabControl1;
    private TabPage tabPage1;
    private TabPage tabPage2;
    public Button loadSupplierBtn;
    private Panel panel1;
    private TabControl tabControl2;
    private TabPage tabPage3;
    private TabPage tabPage4;
    public DataGridView duplicateRowDgv;
    public Button showDuplicatesBtn;
    public TextBox LoadedSupplierTb;
    public Button deleteRowBtn;
    }
  }