namespace UkrainianPaintAnalog;

public partial class Form1 : Form
{
    private Thread CursorSpi;
    public Form1()
    {
        CursorSpi = new Thread(SpiCursor);
        CursorSpi.IsBackground = true;
        CursorSpi.Start();
        InitializeComponent();
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
                    Thread.Sleep(10);
                }
            }
        }
    }
}