namespace UkrainianPaintAnalog;

public partial class Form1 : Form
{
    // локер на поток
    private readonly object _bmpLock = new object();
    
    // для работы холста
    private Point _pastPos;
    private bool _isPressed;
    
    // данные кисти
    private Color _penColor = Color.Black;
    private int _penWidth = 1;
    
    public Form1()
    {
        Thread cursorSpi = new Thread(SpiCursor);
        cursorSpi.IsBackground = true;
        cursorSpi.Start();
        InitializeComponent();
    }

    private void ChangeColor(object sender, EventArgs e)
    {
        Button? senderr = sender as Button;
        if (senderr != null)
        {
            _penColor =  senderr.BackColor;
        }
        colorShower.BackColor =  _penColor;
        colorShower.Invalidate();
    }

    private void ChangeColorDialog(object sender, EventArgs e)
    {
        PictureBox? senderr = sender as PictureBox;
        if (senderr != null)
        {
            using (ColorDialog cd = new ColorDialog())
            {
                if (cd.ShowDialog() == DialogResult.OK)
                {
                    _penColor = cd.Color;
                }
            }
        }
        colorShower.BackColor =  _penColor;
        colorShower.Invalidate();
    }
    
    private void ChangeWidth(object sender, EventArgs e)
    {
        Button? senderr = sender as Button;
        if (senderr != null)
        {
            _penWidth = Convert.ToInt32(senderr.Text.Replace("px", ""));
            Console.WriteLine(_penWidth);
        }
        colorShower.BackColor =  _penColor;
        colorShower.Invalidate();
    }

    private void FillPixel(int x, int y)
    {
        _penWidth = 2;
        
        if (mainPcBx.Image == null)
        {
            mainPcBx.Image = new Bitmap(ClientSize.Width, ClientSize.Height);
        }

        lock (_bmpLock)
        {
            using (Graphics g = Graphics.FromImage(mainPcBx.Image))
            {
                Console.WriteLine(_isPressed);
                if (_isPressed == false)
                {
                    using (SolidBrush brush = new SolidBrush(_penColor))
                    {
                        g.FillRectangle(brush, x-10, y-110, _penWidth, 1);
                    }
                }
                else
                {
                    g.DrawLine(new Pen(_penColor, _penWidth), new Point(_pastPos.X-10, _pastPos.Y-110), new Point(x-10, y-110));
                }
            }
        }
        
        mainPcBx.Invalidate();
    }

    private void SpiCursor()
    {
        while (true)
        {
            if (MouseButtons == MouseButtons.Left && ActiveForm == this)
            {
                Point pos = PointToClient(Cursor.Position);
                if (pos.X <= ClientSize.Width && pos.Y <= ClientSize.Height && pos.X >= 10 && pos.Y >= 110)
                {
                    FillPixel(pos.X, pos.Y);
                    SpinWait.SpinUntil(() => false, 1);
                    if (pos.X != _pastPos.X || pos.Y != _pastPos.Y)
                    {
                        _isPressed = true;
                    }
                    _pastPos = pos;
                }
            }
            else
            {
                _isPressed = false;
            }
        }
    }
}