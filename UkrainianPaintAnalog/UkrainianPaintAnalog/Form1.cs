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
    private float _penWidth = 2.0f;
    private string _brushType = "brush";
    
    // куда сохранять файл
    private string? _filePath;
    
    public Form1()
    {
        Thread cursorSpi = new Thread(SpiCursor);
        cursorSpi.IsBackground = true;
        cursorSpi.Start();
        InitializeComponent();
        using (Graphics g = Graphics.FromImage(mainPcBx.Image))
        {
            g.Clear(Color.White);
        }
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
            _penWidth = float.Parse(senderr.Text.Replace("px", ""));
            Console.WriteLine(_penWidth);
        }
        sizeLbl.Text =  $"{_penWidth}px";
        sizeBar.Value = (int)_penWidth * 10;
    }

    private void ChangeWidthBar(object sender, EventArgs e)
    {
        _penWidth = Convert.ToInt32(sizeBar.Value) / 10f;
        sizeLbl.Text =  $"{_penWidth}px";
    }

    private void Save(object sender, EventArgs e)
    {
        if (_filePath != null)
        {
            lock (_bmpLock)
            {
                mainPcBx.Image.Save(_filePath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }
        else
        {
            SaveAs(null, null);
        }
    }
    
    private void SaveAs(object? sender, EventArgs? e)
    {
        lock (_bmpLock) 
        {
            using (SaveFileDialog fd = new SaveFileDialog())
            {
                fd.Filter = "JPEG Image|*.jpg;*.jpeg|PNG Image|*.png";
                _filePath = fd.FileName;
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    _filePath = fd.FileName;
                    mainPcBx.Image.Save(_filePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
        }
        
    }

    private void Open(object sender, EventArgs e)
    {
        using (OpenFileDialog ofd = new OpenFileDialog())
        {
            ofd.Filter = "JPEG Image|*.jpg;*.jpeg;*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                mainPcBx.Image = new Bitmap(Image.FromFile(ofd.FileName));
            }
        }
        mainPcBx.Invalidate();
    }

    private void brusheraserChange(object sender, EventArgs e)
    {
        PictureBox senderr = sender as PictureBox;
        _brushType = senderr.Tag as string;
        Console.WriteLine(_brushType);
    }

    private void ClearHolst(object sender, EventArgs e)
    {
        DialogResult dialogresult =
            MessageBox.Show(
                "Вы прям на миллиард в третьей степени процентов полны решимостью стереть к чертям ваш шедевральный шедевр современного исскуства???????",
                "Точно-Точноо!??", MessageBoxButtons.YesNo);
        if (dialogresult == DialogResult.Yes)
        {
            using (Graphics g = Graphics.FromImage(mainPcBx.Image))
            {
                g.Clear(Color.White);
            }
            mainPcBx.Invalidate();
        }
    }

    private void FillPixel(int x, int y)
    {
        lock (_bmpLock)
        {
            using (Graphics g = Graphics.FromImage(mainPcBx.Image))
            {
                Console.WriteLine(_isPressed);
                if (_isPressed == false)
                {
                    g.DrawEllipse(new Pen(_penColor, _penWidth), x-10, y-110, _penWidth, _penWidth);
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
            Thread.Sleep(10);
            if (MouseButtons == MouseButtons.Left && ActiveForm == this)
            {
                Point pos = PointToClient(Cursor.Position);
                if (pos.X <= ClientSize.Width && pos.Y <= ClientSize.Height && pos.X >= 10 && pos.Y >= 110)
                {
                    Invoke((Action)(() => FillPixel(pos.X, pos.Y))); // здесь проблема с вылетами была, я поставил инвок для запуска в UI-потоке

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