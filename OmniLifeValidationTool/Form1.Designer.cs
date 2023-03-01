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
      this.supplierPremiumTp = new System.Windows.Forms.TabPage();
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
      this.LoadedSupplierTb = new System.Windows.Forms.TextBox();
      this.showAllBtn = new System.Windows.Forms.Button();
      this.showDuplicatesBtn = new System.Windows.Forms.Button();
      this.showMismatchBtn = new System.Windows.Forms.Button();
      this.duplicateRowDgv = new System.Windows.Forms.DataGridView();
      this.tabControl2.SuspendLayout();
      this.supplierPremiumTp.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.flowLayoutPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.duplicateRowDgv)).BeginInit();
      this.SuspendLayout();
      // 
      // loadSupplierBtn
      // 
      this.loadSupplierBtn.Location = new System.Drawing.Point(3, 6);
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
      this.tabControl2.Controls.Add(this.supplierPremiumTp);
      this.tabControl2.Location = new System.Drawing.Point(12, 12);
      this.tabControl2.Name = "tabControl2";
      this.tabControl2.SelectedIndex = 0;
      this.tabControl2.Size = new System.Drawing.Size(1288, 715);
      this.tabControl2.TabIndex = 1;
      // 
      // supplierPremiumTp
      // 
      this.supplierPremiumTp.Controls.Add(this.splitContainer1);
      this.supplierPremiumTp.Location = new System.Drawing.Point(4, 24);
      this.supplierPremiumTp.Name = "supplierPremiumTp";
      this.supplierPremiumTp.Padding = new System.Windows.Forms.Padding(3);
      this.supplierPremiumTp.Size = new System.Drawing.Size(1280, 687);
      this.supplierPremiumTp.TabIndex = 0;
      this.supplierPremiumTp.Text = "Supplier Premium";
      this.supplierPremiumTp.UseVisualStyleBackColor = true;
      // 
      // splitContainer1
      // 
      this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.splitContainer1.Location = new System.Drawing.Point(6, 6);
      this.splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.loadSupplierBtn);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanel1);
      this.splitContainer1.Panel2.Controls.Add(this.duplicateRowDgv);
      this.splitContainer1.Size = new System.Drawing.Size(1268, 675);
      this.splitContainer1.SplitterDistance = 125;
      this.splitContainer1.TabIndex = 4;
      // 
      // flowLayoutPanel1
      // 
      this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.flowLayoutPanel1.Controls.Add(this.LoadedSupplierTb);
      this.flowLayoutPanel1.Controls.Add(this.showAllBtn);
      this.flowLayoutPanel1.Controls.Add(this.showDuplicatesBtn);
      this.flowLayoutPanel1.Controls.Add(this.showMismatchBtn);
      this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
      this.flowLayoutPanel1.Name = "flowLayoutPanel1";
      this.flowLayoutPanel1.Size = new System.Drawing.Size(1131, 33);
      this.flowLayoutPanel1.TabIndex = 4;
      // 
      // LoadedSupplierTb
      // 
      this.LoadedSupplierTb.Location = new System.Drawing.Point(3, 3);
      this.LoadedSupplierTb.Name = "LoadedSupplierTb";
      this.LoadedSupplierTb.ReadOnly = true;
      this.LoadedSupplierTb.Size = new System.Drawing.Size(100, 23);
      this.LoadedSupplierTb.TabIndex = 3;
      this.LoadedSupplierTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // showAllBtn
      // 
      this.showAllBtn.Location = new System.Drawing.Point(109, 3);
      this.showAllBtn.Name = "showAllBtn";
      this.showAllBtn.Size = new System.Drawing.Size(75, 23);
      this.showAllBtn.TabIndex = 4;
      this.showAllBtn.Text = "Show All";
      this.showAllBtn.UseVisualStyleBackColor = true;
      this.showAllBtn.Click += new System.EventHandler(this.showAllBtn_Click);
      // 
      // showDuplicatesBtn
      // 
      this.showDuplicatesBtn.Location = new System.Drawing.Point(190, 3);
      this.showDuplicatesBtn.Name = "showDuplicatesBtn";
      this.showDuplicatesBtn.Size = new System.Drawing.Size(110, 23);
      this.showDuplicatesBtn.TabIndex = 2;
      this.showDuplicatesBtn.Text = "Show Duplicates";
      this.showDuplicatesBtn.UseVisualStyleBackColor = true;
      this.showDuplicatesBtn.Click += new System.EventHandler(this.showDuplicatesBtn_Click);
      // 
      // showMismatchBtn
      // 
      this.showMismatchBtn.Location = new System.Drawing.Point(306, 3);
      this.showMismatchBtn.Name = "showMismatchBtn";
      this.showMismatchBtn.Size = new System.Drawing.Size(120, 23);
      this.showMismatchBtn.TabIndex = 3;
      this.showMismatchBtn.Text = "Show Mismatch";
      this.showMismatchBtn.UseVisualStyleBackColor = true;
      this.showMismatchBtn.Click += new System.EventHandler(this.showMismatchBtn_Click);
      // 
      // duplicateRowDgv
      // 
      this.duplicateRowDgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.duplicateRowDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.duplicateRowDgv.Location = new System.Drawing.Point(3, 42);
      this.duplicateRowDgv.Name = "duplicateRowDgv";
      this.duplicateRowDgv.ReadOnly = true;
      this.duplicateRowDgv.RowTemplate.Height = 25;
      this.duplicateRowDgv.Size = new System.Drawing.Size(1131, 628);
      this.duplicateRowDgv.TabIndex = 1;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1315, 742);
      this.Controls.Add(this.tabControl2);
      this.Controls.Add(this.panel1);
      this.MinimumSize = new System.Drawing.Size(1330, 780);
      this.Name = "Form1";
      this.Text = "OmniLife Validation Tool";
      this.tabControl2.ResumeLayout(false);
      this.supplierPremiumTp.ResumeLayout(false);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      this.flowLayoutPanel1.ResumeLayout(false);
      this.flowLayoutPanel1.PerformLayout();
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
    private TabPage supplierPremiumTp;
    public DataGridView duplicateRowDgv;
    public Button showDuplicatesBtn;
    public TextBox LoadedSupplierTb;
    private SplitContainer splitContainer1;
    private FlowLayoutPanel flowLayoutPanel1;
    public Button showMismatchBtn;
    public Button showAllBtn;
    }
  }