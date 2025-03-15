using System.Drawing.Drawing2D;
using System.ComponentModel;
using Newtonsoft.Json.Linq;

namespace Proyecto_Autolavado_Georges.Clases.CustomFormControls
{
    public class RoundButton : Button
    {
        private int borderSize = 0;
        private int borderRadius = 20;
        private Color borderColor = Color.Blue;
        private bool isFilledButton = true;

        [Category("Appearance")]
        public bool IsFilledButton
        {
            get => isFilledButton;
            set
            {
                isFilledButton = value;
                this.Invalidate();
            }
        }

        [Category("Appearance")]
        public Color BorderColor
        {
            get => borderColor;
            set
            {
                borderColor = value;
                this.Invalidate();
            }
        }

        [Category("Appearance")]
        public int BorderSize
        {
            get => borderSize; 
            set
            {
                borderSize = value;
                this.Invalidate();
            }
        }
        [Category("Appearance")]
        public int BorderRadius
        {
            get => borderRadius; 
            set
            {
                borderRadius = value;
                this.Invalidate();
            }
        }

        public RoundButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Size = new(150, 40);
            this.BackColor = Color.Blue;
            this.ForeColor = SystemColors.Control;
            this.IsFilledButton = true;
            this.Resize += new (ButtonResize);
        }

        public void SetColor(Color mainColor)
        {
            if(IsFilledButton)
            {
                this.BackColor = mainColor;
            }
            else
            {
                this.borderColor = mainColor;
                this.ForeColor = mainColor;
            }
        }

        private void ButtonResize(object sender, EventArgs e)
        {
            borderRadius = borderRadius > this.Height? this.Height : borderRadius;
        }

        private GraphicsPath GetFigurePath(Rectangle rect, float radius)
        {
            GraphicsPath grPath = new();
            float curveSize = radius * 2F;

            grPath.StartFigure();
            grPath.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            grPath.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            grPath.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            grPath.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            grPath.CloseFigure();
            return grPath;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            Rectangle rectSurface = this.ClientRectangle;
            Rectangle rectBorder = Rectangle.Inflate(rectSurface, -borderSize, -borderSize);
            int smoothSize = borderSize > 0 ? borderSize: 2;

            if (borderRadius > 2) //Rounded button
            {
                using GraphicsPath pathSurface = GetFigurePath(rectSurface, borderRadius);
                using GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - borderSize);
                using Pen penSurface = new (this.Parent.BackColor, smoothSize);
                using Pen penBorder = new (borderColor, borderSize);
                pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                //Button surface
                this.Region = new Region(pathSurface);
                //Draw surface border for HD result
                pevent.Graphics.DrawPath(penSurface, pathSurface);
                //Button border                    
                if (borderSize >= 1)
                    //Draw control border
                    pevent.Graphics.DrawPath(penBorder, pathBorder);
            }
            else //Normal button
            {
                pevent.Graphics.SmoothingMode = SmoothingMode.None;
                //Button surface
                this.Region = new Region(rectSurface);
                //Button border
                if (borderSize >= 1)
                {
                    using Pen penBorder = new Pen(borderColor, borderSize);
                    penBorder.Alignment = PenAlignment.Inset;
                    pevent.Graphics.DrawRectangle(penBorder, 0, 0, this.Width - 1, this.Height - 1);
                }
            }

            // Draw focus border
            if (this.Focused)
            {
                Rectangle rectFocusBorder = Rectangle.Inflate(rectSurface, -1, -1);
                using Pen penFocusBorder = new(this.borderColor, 10);
                pevent.Graphics.DrawRectangle(penFocusBorder, rectFocusBorder);
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.Parent.BackColorChanged += new EventHandler(ContainerBackColorChanged);
        }

        private void ContainerBackColorChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}
