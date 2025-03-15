using Newtonsoft.Json.Linq;
using Proyecto_Autolavado_Georges.Clases.CustomFormControls;
using System.Windows.Forms;

namespace Proyecto_Autolavado_Georges.Clases.UI
{
    public static class AppSettings
    {
        public enum ButtonType
        {
            Filled,
            Hollow
        }

        private const string colorPanel = "colorPanel";
        private const string colorLabel = "mainLabel";

        private static readonly Color DarkColor = Color.FromArgb(36, 36, 36);
        public static Color MainColor { get; set; } = Color.Brown;

        public static bool IsDarkMode { get; private set; } = false;

        public static void SetMainColor(Color color)
        {
            MainColor = color;
        }

        public static void SetDarkMode(bool isDarkMode)
        {
            IsDarkMode = isDarkMode;
        }

        public static JObject SerializeToJson()
        {
            JObject temp = [];

            temp.Add(nameof(MainColor), MainColor.ToArgb());
            temp.Add(nameof(IsDarkMode), IsDarkMode);

            return temp;
        }
        public static void DeserializeFromJson(JToken json)
        {
            if (json[nameof(MainColor)] != null)
            {
                SetMainColor(Color.FromArgb(json[nameof(MainColor)].Value<int>()));
            }
            if (json[nameof(IsDarkMode)] != null)
            {
                IsDarkMode = (bool)json[nameof(IsDarkMode)];
            }
        }

        public static void InitializeSettings(Form form)
        {
            if (IsDarkMode) //avoids updating the UI when launching if light mode is enabled (because it is by default)
            {
                SetDarkOrLightMode(form);
            }
            LoadMenuColor(form);
            //The rest of future settings...
        }

        public static void LoadMenuColor(Control form)
        {
            foreach (Control ctl in form.Controls)
            {
                if(ctl is Panel) //If a panel is reached, recursively call this method
                {
                    LoadMenuColor(ctl);
                }

                if (ctl is RoundButton roundButton)
                {
                    roundButton.SetColor(MainColor);
                }
                if (ctl is Panel panel)
                {
                    if (panel.Tag == null) continue;

                    if(panel.Tag.ToString() == colorPanel)
                    {
                        panel.BackColor = MainColor;
                    }
                    
                }
                if (ctl is Label label)
                {
                    if (label.Tag == null) continue;

                    if (label.Tag.ToString() == colorLabel)
                    {
                        label.ForeColor = MainColor;
                    }
                }
            }
        }

        private static void UpdateLabel(Label label, Color color)
        {
            if (label.Tag == null) label.ForeColor = color;
        }
        private static void UpdatePanel(Panel panel, Color color)
        {
            if (panel.Tag == null)
            {
                panel.BackColor = color;
                SetDarkOrLightMode(panel);
            }
            else if (panel.Tag.ToString() == colorPanel)
            {
                panel.BackColor = MainColor;
            }
        }

        public static void SetDarkOrLightMode(Control control)
        {
            if (IsDarkMode) //Dark Mode
            {
                if (control is Form) control.BackColor = DarkColor;

                foreach (Control ctl in control.Controls)
                {
                    if (ctl is Label label)
                    {
                        UpdateLabel(label, SystemColors.Control);
                    }
                    else if (ctl is Panel panel)
                    {
                        UpdatePanel(panel, DarkColor);
                    }
                }
            }
            else            //Light Mode
            {
                if (control is Form) control.BackColor = SystemColors.Control;

                foreach (Control ctl in control.Controls)
                {
                    if (ctl is Label label)
                    {
                        UpdateLabel(label, SystemColors.ControlText);
                    }
                    else if (ctl is Panel panel)
                    {
                        UpdatePanel(panel, SystemColors.Control);
                    }
                }
            }
        }
    }
}
