namespace UkrainianPaintAnalog;

public partial class Form1 : Form
{
    private Thread CursorSpi;
    private Point pastPos;
    private bool isPressed;
    
    // данные кисти
    private Color penColor;
    private int penWidth;
    
    public Form1()
    {
        CursorSpi = new Thread(SpiCursor);
        CursorSpi.IsBackground = true;
        CursorSpi.Start();
        InitializeComponent();
    }

    private void ChangeColor(object sender, EventArgs e)
    {
        
    }

    private void FillPixel(int x, int y)
    {
        penWidth = 2;
        
        if (mainPcBx.Image == null)
        {
            mainPcBx.Image = new Bitmap(ClientSize.Width, ClientSize.Height);
        }

        using (Graphics g = Graphics.FromImage(mainPcBx.Image))
        {
            Console.WriteLine(isPressed);
            if (isPressed == false)
            {
                g.FillRectangle(Brushes.Black, x-10, y-150, penWidth, 1);
            }
            else
            {
                g.DrawLine(new Pen(Color.Black, penWidth), new Point(pastPos.X-10, pastPos.Y-150), new Point(x-10, y-150));
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
                if (pos.X <= ClientSize.Width && pos.Y <= ClientSize.Height &&  pos.X >= 0 && pos.Y >= 0)
                {
                    FillPixel(pos.X, pos.Y);
                    SpinWait.SpinUntil(() => false, 1);
                    if (pos.X != pastPos.X || pos.Y != pastPos.Y)
                    {
                        isPressed = true;
                    }
                    pastPos = pos;
                }
            }
            else
            {
                isPressed = false;
            }
        }
    }
}