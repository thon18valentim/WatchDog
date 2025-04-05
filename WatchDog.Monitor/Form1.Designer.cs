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
			soundCheckBox = new CheckBox();
			contextMenuStrip1 = new ContextMenuStrip(components);
			Title = new Label();
			((System.ComponentModel.ISupportInitialize)servicesDataGridView).BeginInit();
			SuspendLayout();
			// 
			// servicesDataGridView
			// 
			servicesDataGridView.AllowUserToAddRows = false;
			servicesDataGridView.AllowUserToDeleteRows = false;
			servicesDataGridView.BackgroundColor = SystemColors.ActiveCaption;
			servicesDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			servicesDataGridView.Location = new Point(12, 84);
			servicesDataGridView.Name = "servicesDataGridView";
			servicesDataGridView.ReadOnly = true;
			servicesDataGridView.Size = new Size(251, 354);
			servicesDataGridView.TabIndex = 0;
			// 
			// soundCheckBox
			// 
			soundCheckBox.AutoSize = true;
			soundCheckBox.Checked = true;
			soundCheckBox.CheckState = CheckState.Checked;
			soundCheckBox.Location = new Point(155, 59);
			soundCheckBox.Name = "soundCheckBox";
			soundCheckBox.Size = new Size(108, 19);
			soundCheckBox.TabIndex = 1;
			soundCheckBox.Text = "Warning Sound";
			soundCheckBox.UseVisualStyleBackColor = true;
			// 
			// contextMenuStrip1
			// 
			contextMenuStrip1.Name = "contextMenuStrip1";
			contextMenuStrip1.Size = new Size(61, 4);
			// 
			// Title
			// 
			Title.AutoSize = true;
			Title.Location = new Point(12, 9);
			Title.Name = "Title";
			Title.Size = new Size(167, 15);
			Title.TabIndex = 2;
			Title.Text = "WatchDog Monitored Services";
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.HotTrack;
			ClientSize = new Size(365, 450);
			Controls.Add(Title);
			Controls.Add(soundCheckBox);
			Controls.Add(servicesDataGridView);
			Name = "Form1";
			Text = "Form1";
			((System.ComponentModel.ISupportInitialize)servicesDataGridView).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private DataGridView servicesDataGridView;
		private CheckBox soundCheckBox;
		private ContextMenuStrip contextMenuStrip1;
		private Label Title;
	}
}
