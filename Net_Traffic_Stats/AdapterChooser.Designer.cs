namespace Net_Traffic_Stats
{
	partial class AdapterChooser
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.adapterGrid = new System.Windows.Forms.DataGridView();
			this.AdapterID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.AdapterName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Desription = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.InterfaceType = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.selectButton = new System.Windows.Forms.Button();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			((System.ComponentModel.ISupportInitialize)(this.adapterGrid)).BeginInit();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// adapterGrid
			// 
			this.adapterGrid.AllowUserToAddRows = false;
			this.adapterGrid.AllowUserToDeleteRows = false;
			this.adapterGrid.AllowUserToResizeRows = false;
			this.adapterGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.adapterGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.adapterGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AdapterID,
            this.AdapterName,
            this.Desription,
            this.Status,
            this.InterfaceType});
			this.adapterGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.adapterGrid.Location = new System.Drawing.Point(3, 3);
			this.adapterGrid.Name = "adapterGrid";
			this.adapterGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
			this.adapterGrid.Size = new System.Drawing.Size(794, 406);
			this.adapterGrid.TabIndex = 0;
			// 
			// AdapterID
			// 
			this.AdapterID.FillWeight = 25F;
			this.AdapterID.HeaderText = "ID";
			this.AdapterID.Name = "AdapterID";
			this.AdapterID.ReadOnly = true;
			// 
			// AdapterName
			// 
			this.AdapterName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.AdapterName.HeaderText = "Name";
			this.AdapterName.Name = "AdapterName";
			this.AdapterName.ReadOnly = true;
			// 
			// Desription
			// 
			this.Desription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Desription.HeaderText = "Desription";
			this.Desription.Name = "Desription";
			this.Desription.ReadOnly = true;
			// 
			// Status
			// 
			this.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Status.FillWeight = 65F;
			this.Status.HeaderText = "Status";
			this.Status.Name = "Status";
			this.Status.ReadOnly = true;
			// 
			// InterfaceType
			// 
			this.InterfaceType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.InterfaceType.HeaderText = "Interface Type";
			this.InterfaceType.Name = "InterfaceType";
			this.InterfaceType.ReadOnly = true;
			// 
			// selectButton
			// 
			this.selectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.selectButton.Location = new System.Drawing.Point(707, 415);
			this.selectButton.Name = "selectButton";
			this.selectButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.selectButton.Size = new System.Drawing.Size(90, 32);
			this.selectButton.TabIndex = 1;
			this.selectButton.Text = "Select";
			this.selectButton.UseVisualStyleBackColor = true;
			this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.adapterGrid, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.selectButton, 0, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
			this.tableLayoutPanel1.TabIndex = 2;
			// 
			// AdapterChooser
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "AdapterChooser";
			this.Text = "AdapterChooser";
			this.Load += new System.EventHandler(this.AdapterChooser_Load);
			((System.ComponentModel.ISupportInitialize)(this.adapterGrid)).EndInit();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView adapterGrid;
		private System.Windows.Forms.Button selectButton;
		private System.Windows.Forms.DataGridViewTextBoxColumn AdapterID;
		private System.Windows.Forms.DataGridViewTextBoxColumn AdapterName;
		private System.Windows.Forms.DataGridViewTextBoxColumn Desription;
		private System.Windows.Forms.DataGridViewTextBoxColumn Status;
		private System.Windows.Forms.DataGridViewTextBoxColumn InterfaceType;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
	}
}

