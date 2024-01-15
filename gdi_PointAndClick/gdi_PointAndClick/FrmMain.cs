using System.Collections.Generic; // ben�tigt f�r Listen

namespace gdi_PointAndClick
{
    public partial class FrmMain : Form
    {
        List<Rectangle> rectangles = new List<Rectangle>();

        public FrmMain()
        {
            InitializeComponent();
            ResizeRedraw = true;
        }

        private void FrmMain_Paint(object sender, PaintEventArgs e)
        {
            // Hilfsvarablen
            Graphics g = e.Graphics;
            int w = this.ClientSize.Width;
            int h = this.ClientSize.Height;

            // Zeichenmittel
            Brush b = new SolidBrush(Color.Lavender);


            for (int i = 0; i < rectangles.Count; i++)
            {
                g.FillRectangle(b, rectangles[i]);
            }

        }

        private void FrmMain_MouseClick(object sender, MouseEventArgs e)
        {
            Point mausposition = e.Location;

            Rectangle r = new Rectangle(mausposition.X-20, mausposition.Y-20, 40, 40);

            for (int i = -20; i <= 40;i++)
            {
                mausposition.X+= i;
                mausposition.Y+= i;
                if (!rectangles.Contains(r))
                {
                    rectangles.Add(new Rectangle(mausposition.X - 20, mausposition.Y - 20, 40, 40)); // Kurze Variante: rectangles.Add( new Rectangle(...)  );
                }
            }
            Refresh();
        }

        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                rectangles.Clear();
                Refresh();
            }
        }
    }
}