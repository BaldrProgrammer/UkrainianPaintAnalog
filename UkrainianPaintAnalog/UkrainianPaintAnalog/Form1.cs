namespace UkrainianPaintAnalog;

public partial class Form1 : Form
{
    private Thread CursorSpi;
    private Point pastPos;
    private bool isPressed;
    
    public Form1()
    {
        CursorSpi = new Thread(SpiCursor);
        CursorSpi.IsBackground = true;
        CursorSpi.Start();
        InitializeComponent();
    }

    private void FillPixel(int x, int y)
    {
        if (mainPcBx.Image == null)
        {
            mainPcBx.Image = new Bitmap(ClientSize.Width, ClientSize.Height);
        }

        using (Graphics g = Graphics.FromImage(mainPcBx.Image))
        {
            Console.WriteLine(isPressed);
            if (isPressed == false)
            {
                g.FillRectangle(Brushes.Black, x, y, 1, 1);
            }
            else
            {
                g.DrawLine(Pens.Black, new Point(pastPos.X, pastPos.Y), new Point(x, y));
            }
        }
        
        mainPcBx.Invalidate();
    }

    private void SpiCursor()
    {
        while (true)
        {
            if (MouseButtons == MouseButtons.Left)
            {
                Point pos = PointToClient(Cursor.Position);
                if (pos.X <= ClientSize.Width && pos.Y <= ClientSize.Height &&  pos.X >= 0 && pos.Y >= 0)
                {
                    Console.WriteLine(pos);
                    Console.WriteLine(pastPos);
                    FillPixel(pos.X, pos.Y);
                    SpinWait.SpinUntil(() => false, 1);
                    if (pos.X != pastPos.X || pos.Y != pastPos.Y)
                    {
                        isPressed = true;
                    }
                    pastPos = pos;
                    Console.WriteLine("");
                }
            }
            else
            {
                isPressed = false;
            }
        }
    }
}