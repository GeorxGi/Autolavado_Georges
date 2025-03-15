using Proyecto_Autolavado_Georges.Clases.UI;

namespace Proyecto_Autolavado_Georges.Forms
{
    public partial class UIPersonalization : Form
    {

        public Color? pickedColor = null;
        public UIPersonalization()
        {
            InitializeComponent();
        }

        private void UIPersonalization_Load(object sender, EventArgs e)
        {
            RedRoundButton.SetColor(brownpanel.BackColor);
            OrangeRoundButton.SetColor(orangepanel.BackColor);
            OliveRoundButton.SetColor(olivepanel.BackColor);
            TurquoiseRoundButton.SetColor(turquoisepanel.BackColor);
            DarkBlueRoundButton.SetColor(DarkBluePanel.BackColor);
            VioletroundButton.SetColor(BlueVioletPanel.BackColor);
        }

        private void UIPersonalization_KeyDown(object sender, KeyEventArgs e)
        {
            UIHandler.CloseWithEscape(e, this);
        }

        private void BrownButton_Click(object sender, EventArgs e)
        {
            pickedColor = brownpanel.BackColor;
            this.Close();
        }

        private void OrangeButton_Click(object sender, EventArgs e)
        {
            pickedColor = orangepanel.BackColor;
            this.Close();
        }

        private void OliveDrabButton_Click(object sender, EventArgs e)
        {
            pickedColor = olivepanel.BackColor;
            this.Close();
        }

        private void TurquoiseButton_Click(object sender, EventArgs e)
        {
            pickedColor = turquoisepanel.BackColor;
            this.Close();
        }

        private void DarkBlueButton_Click(object sender, EventArgs e)
        {
            pickedColor = DarkBluePanel.BackColor;
            this.Close();
        }

        private void BlueVioletButton_Click(object sender, EventArgs e)
        {
            pickedColor = BlueVioletPanel.BackColor;
            this.Close();
        }
    }
}
