using WatchDog.Models;

namespace WatchDog.Monitor
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			this.AutoSize = true;
			this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			this.FormBorderStyle = FormBorderStyle.FixedDialog;

			InitializeComponent();
			InitDataGridView();

			servicesDataGridView.MouseClick += DataGridView1_MouseClick;
		}

		private void InitDataGridView()
		{
			var services = new List<Service>
			{
				new() {
					Name = "Assassins Creed",
					Env = "DEV",
					Status = ServiceStatus.RUNNING
				},
				new() {
					Name = "Cyberpunk",
					Env = "DEV",
					Status = ServiceStatus.STOPPED
				},
				new() {
					Name = "Star Wars",
					Env = "DEV",
					Status = ServiceStatus.PENDING
				},
				new() {
					Name = "Cyberpunk",
					Env = "DEV",
					Status = ServiceStatus.STOPPED
				},
				new() {
					Name = "Star Wars",
					Env = "DEV",
					Status = ServiceStatus.RUNNING
				},
				new() {
					Name = "Cyberpunk",
					Env = "DEV",
					Status = ServiceStatus.PENDING
				},
				new() {
					Name = "Star Wars",
					Env = "DEV",
					Status = ServiceStatus.RUNNING
				},
				new() {
					Name = "Cyberpunk",
					Env = "DEV",
					Status = ServiceStatus.STOPPED
				},
				new() {
					Name = "Star Wars",
					Env = "DEV",
					Status = ServiceStatus.PENDING
				},
				new() {
					Name = "Cyberpunk",
					Env = "DEV",
					Status = ServiceStatus.PENDING
				},
				new() {
					Name = "Star Wars",
					Env = "DEV",
					Status = ServiceStatus.RUNNING
				},
				new() {
					Name = "Cyberpunk",
					Env = "DEV",
					Status = ServiceStatus.STOPPED
				},
				new() {
					Name = "Star Wars",
					Env = "DEV",
					Status = ServiceStatus.PENDING
				},
				new() {
					Name = "Cyberpunk",
					Env = "DEV",
					Status = ServiceStatus.PENDING
				},
				new() {
					Name = "Star Wars",
					Env = "DEV",
					Status = ServiceStatus.PENDING
				},
				new() {
					Name = "Cyberpunk",
					Env = "DEV",
					Status = ServiceStatus.STOPPED
				},
				new() {
					Name = "Star Wars",
					Env = "DEV",
					Status = ServiceStatus.RUNNING
				},
				new() {
					Name = "Cyberpunk",
					Env = "DEV",
					Status = ServiceStatus.STOPPED
				},
				new() {
					Name = "Star Wars",
					Env = "DEV",
					Status = ServiceStatus.RUNNING
				},
				new() {
					Name = "Cyberpunk",
					Env = "DEV",
					Status = ServiceStatus.STOPPED
				},
				new() {
					Name = "Star Wars",
					Env = "DEV",
					Status = ServiceStatus.RUNNING
				},
				new() {
					Name = "Cyberpunk",
					Env = "DEV",
					Status = ServiceStatus.STOPPED
				},
				new() {
					Name = "Star Wars",
					Env = "DEV",
					Status = ServiceStatus.RUNNING
				},
				new() {
					Name = "Cyberpunk",
					Env = "DEV",
					Status = ServiceStatus.STOPPED
				},
				new() {
					Name = "Star Wars",
					Env = "DEV",
					Status = ServiceStatus.RUNNING
				}
			};

			servicesDataGridView.DataSource = services;
			servicesDataGridView.CellFormatting += ServicesDataGridView_CellFormatting;
		}

		private void ServicesDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (servicesDataGridView.Columns[e.ColumnIndex].Name == "Status")
			{
				if (e.Value == null || e.CellStyle == null)
					return;

				var status = (ServiceStatus)e.Value;
				e.CellStyle.BackColor = status switch
				{
					ServiceStatus.RUNNING => Color.DarkGreen,
					ServiceStatus.STOPPED => Color.DarkRed,
					_ => Color.Gray
				};
				e.CellStyle.ForeColor = Color.White;
			}
		}

		private void DataGridView1_MouseClick(object sender, MouseEventArgs e)
		{
			// Verifica se o botão direito foi clicado
			if (e.Button == MouseButtons.Right)
			{
				var hitTestInfo = servicesDataGridView.HitTest(e.X, e.Y);

				if (hitTestInfo.RowIndex >= 0) 
				{
					servicesDataGridView.ClearSelection();
					servicesDataGridView.Rows[hitTestInfo.RowIndex].Selected = true;

					// Exibe o ContextMenuStrip no local do mouse
					contextMenuStrip1.Show(Cursor.Position);
				}
			}
		}
	}
}
