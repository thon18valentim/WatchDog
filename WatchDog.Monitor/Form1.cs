using WatchDog.Models;

namespace WatchDog.Monitor
{
	public partial class Form1 : Form
	{
		private ContextMenuStrip contextMenu;
		private ServerContext serverContext;

		public Form1()
		{
			this.AutoSize = true;
			this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			this.FormBorderStyle = FormBorderStyle.FixedDialog;

			InitializeComponent();
			InitDataGridView();
			InitContextMenu();

			var serverInitTask = Task.Run(() => serverContext = new ServerContext("ws://localhost:8082/ws", "12345"));
			serverInitTask.Wait();
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

		private void ServicesDataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
			{
				servicesDataGridView.ClearSelection();
				servicesDataGridView.Rows[e.RowIndex].Selected = true;
				servicesDataGridView.CurrentCell = servicesDataGridView.Rows[e.RowIndex].Cells[0];
			}
		}

		private void InitContextMenu()
		{
			contextMenu = new ContextMenuStrip();

			var startStopItem = new ToolStripMenuItem("Start/Stop");
			var flagUnflagItem = new ToolStripMenuItem("Flag/Unflag");

			startStopItem.Click += StartStopToolStripMenuItem_Click;
			flagUnflagItem.Click += FlagUnflagToolStripMenuItem_Click;

			contextMenu.Items.Add(startStopItem);
			contextMenu.Items.Add(flagUnflagItem);

			servicesDataGridView.ContextMenuStrip = contextMenu;
			servicesDataGridView.CellMouseDown += ServicesDataGridView_CellMouseDown;
		}

		private void StartStopToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var selectedRow = servicesDataGridView.SelectedRows[0];
			//MessageBox.Show("Start/Stop: " + selectedRow.Cells[0].Value.ToString());
			var msgTask = Task.Run(() => serverContext.StartService("Star Wars").Wait());
			msgTask.Wait();
		}

		private void FlagUnflagToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var selectedRow = servicesDataGridView.SelectedRows[0];
			MessageBox.Show("Flag/Unflag: " + selectedRow.Cells[0].Value.ToString());
		}
	}
}
