using Proyecto_Autolavado_Georges.Clases.UI;
using System.Diagnostics;

namespace Proyecto_Autolavado_Georges.Formularios
{
    public partial class Creditos : Form
    {
        public Creditos()
        {
            InitializeComponent();
        }

        private void Creditos_Load(object sender, EventArgs e)
        {
            AppSettings.LoadMenuColor(this);
        }

        private void RjCodeAdvanceRoundButton_Click(object sender, EventArgs e)
        {
            OpenUrl("https://rjcodeadvance.com/rounded-button-custom-controls-winform-c/");
        }

        private void GitHubRoundButton_Click(object sender, EventArgs e)
        {
            OpenUrl("https://github.com/GeorxGi");
        }

        private void Icon8roundButton_Click(object sender, EventArgs e)
        {
            OpenUrl("https://icons8.com/icons");
        }

        private void CloseWithEsc(object sender, KeyEventArgs e)
        {
            UIHandler.CloseWithEscape(e, this);
        }

        private static void OpenUrl(string url)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                };
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo abrir el enlace: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
