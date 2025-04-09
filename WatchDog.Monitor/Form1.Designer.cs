using System.Windows.Forms;

namespace WatchDog.Monitor
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
			components = new System.ComponentModel.Container();
			servicesDataGridView = new DataGridView();
			contextMenuStrip1 = new ContextMenuStrip(components);
			tabControl1 = new TabControl();
			tabPage1 = new TabPage();
			tabPage2 = new TabPage();
			groupBox2 = new GroupBox();
			groupBox1 = new GroupBox();
			button1 = new Button();
			label2 = new Label();
			textBox2 = new TextBox();
			label1 = new Label();
			textBox1 = new TextBox();
			checkBox1 = new CheckBox();
			checkBox2 = new CheckBox();
			checkBox3 = new CheckBox();
			((System.ComponentModel.ISupportInitialize)servicesDataGridView).BeginInit();
			tabControl1.SuspendLayout();
			tabPage1.SuspendLayout();
			tabPage2.SuspendLayout();
			groupBox2.SuspendLayout();
			groupBox1.SuspendLayout();
			SuspendLayout();
			// 
			// servicesDataGridView
			// 
			servicesDataGridView.AllowUserToAddRows = false;
			servicesDataGridView.AllowUserToDeleteRows = false;
			servicesDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			servicesDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			servicesDataGridView.BackgroundColor = SystemColors.ActiveCaption;
			servicesDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			servicesDataGridView.Dock = DockStyle.Fill;
			servicesDataGridView.Location = new Point(3, 3);
			servicesDataGridView.MultiSelect = false;
			servicesDataGridView.Name = "servicesDataGridView";
			servicesDataGridView.ReadOnly = true;
			servicesDataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
			servicesDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			servicesDataGridView.Size = new Size(439, 392);
			servicesDataGridView.TabIndex = 0;
			// 
			// contextMenuStrip1
			// 
			contextMenuStrip1.Name = "contextMenuStrip1";
			contextMenuStrip1.Size = new Size(61, 4);
			// 
			// tabControl1
			// 
			tabControl1.Controls.Add(tabPage1);
			tabControl1.Controls.Add(tabPage2);
			tabControl1.Location = new Point(12, 12);
			tabControl1.Name = "tabControl1";
			tabControl1.SelectedIndex = 0;
			tabControl1.Size = new Size(453, 426);
			tabControl1.TabIndex = 1;
			// 
			// tabPage1
			// 
			tabPage1.BackColor = Color.MidnightBlue;
			tabPage1.Controls.Add(servicesDataGridView);
			tabPage1.ForeColor = SystemColors.ControlText;
			tabPage1.Location = new Point(4, 24);
			tabPage1.Name = "tabPage1";
			tabPage1.Padding = new Padding(3);
			tabPage1.Size = new Size(445, 398);
			tabPage1.TabIndex = 0;
			tabPage1.Text = "Services";
			// 
			// tabPage2
			// 
			tabPage2.BackColor = Color.MidnightBlue;
			tabPage2.Controls.Add(groupBox2);
			tabPage2.Controls.Add(groupBox1);
			tabPage2.Location = new Point(4, 24);
			tabPage2.Name = "tabPage2";
			tabPage2.Padding = new Padding(3);
			tabPage2.Size = new Size(445, 398);
			tabPage2.TabIndex = 1;
			tabPage2.Text = "Settings";
			// 
			// groupBox2
			// 
			groupBox2.Controls.Add(checkBox3);
			groupBox2.Controls.Add(checkBox2);
			groupBox2.Controls.Add(checkBox1);
			groupBox2.ForeColor = Color.White;
			groupBox2.Location = new Point(6, 134);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(433, 79);
			groupBox2.TabIndex = 1;
			groupBox2.TabStop = false;
			groupBox2.Text = "Warnings";
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(button1);
			groupBox1.Controls.Add(label2);
			groupBox1.Controls.Add(textBox2);
			groupBox1.Controls.Add(label1);
			groupBox1.Controls.Add(textBox1);
			groupBox1.ForeColor = Color.White;
			groupBox1.Location = new Point(6, 6);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(433, 122);
			groupBox1.TabIndex = 0;
			groupBox1.TabStop = false;
			groupBox1.Text = "Email";
			// 
			// button1
			// 
			button1.BackColor = Color.Transparent;
			button1.ForeColor = Color.Black;
			button1.Location = new Point(296, 84);
			button1.Name = "button1";
			button1.Size = new Size(131, 23);
			button1.TabIndex = 4;
			button1.Text = "Send Test";
			button1.UseVisualStyleBackColor = false;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(6, 66);
			label2.Name = "label2";
			label2.Size = new Size(19, 15);
			label2.TabIndex = 3;
			label2.Text = "To";
			// 
			// textBox2
			// 
			textBox2.Location = new Point(6, 84);
			textBox2.Name = "textBox2";
			textBox2.Size = new Size(217, 23);
			textBox2.TabIndex = 2;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(6, 19);
			label1.Name = "label1";
			label1.Size = new Size(35, 15);
			label1.TabIndex = 1;
			label1.Text = "From";
			// 
			// textBox1
			// 
			textBox1.Location = new Point(6, 37);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(217, 23);
			textBox1.TabIndex = 0;
			// 
			// checkBox1
			// 
			checkBox1.AutoSize = true;
			checkBox1.Location = new Point(6, 22);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new Size(87, 19);
			checkBox1.TabIndex = 0;
			checkBox1.Text = "Error sound";
			checkBox1.UseVisualStyleBackColor = true;
			// 
			// checkBox2
			// 
			checkBox2.AutoSize = true;
			checkBox2.Location = new Point(6, 47);
			checkBox2.Name = "checkBox2";
			checkBox2.Size = new Size(103, 19);
			checkBox2.TabIndex = 1;
			checkBox2.Text = "Starting sound";
			checkBox2.UseVisualStyleBackColor = true;
			// 
			// checkBox3
			// 
			checkBox3.AutoSize = true;
			checkBox3.Location = new Point(136, 22);
			checkBox3.Name = "checkBox3";
			checkBox3.Size = new Size(83, 19);
			checkBox3.TabIndex = 2;
			checkBox3.Text = "Error email";
			checkBox3.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.Desktop;
			ClientSize = new Size(477, 450);
			Controls.Add(tabControl1);
			Name = "Form1";
			Text = "Watch Dog Monitor";
			((System.ComponentModel.ISupportInitialize)servicesDataGridView).EndInit();
			tabControl1.ResumeLayout(false);
			tabPage1.ResumeLayout(false);
			tabPage2.ResumeLayout(false);
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private DataGridView servicesDataGridView;
		private ContextMenuStrip contextMenuStrip1;
		private TabControl tabControl1;
		private TabPage tabPage1;
		private TabPage tabPage2;
		private GroupBox groupBox2;
		private GroupBox groupBox1;
		private Label label1;
		private TextBox textBox1;
		private Button button1;
		private Label label2;
		private TextBox textBox2;
		private CheckBox checkBox3;
		private CheckBox checkBox2;
		private CheckBox checkBox1;
	}
}
