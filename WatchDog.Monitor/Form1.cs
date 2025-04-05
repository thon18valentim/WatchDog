using System.Windows.Forms;
using WatchDog.Models;

namespace WatchDog.Monitor
{
	public partial class Form1 : Form
	{
		public Form1()
		{
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
					Status = ServiceStatus.Active
				},
				new() {
					Name = "Cyberpunk",
					Status = ServiceStatus.Stopped
				},
				new() {
					Name = "Star Was",
					Status = ServiceStatus.Active
				}
			};

			servicesDataGridView.DataSource = services;
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
