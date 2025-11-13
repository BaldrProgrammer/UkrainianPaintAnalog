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
    

    private void Risuem(object sender, PaintEventArgs e)
    {
        e.Graphics.Clear(this.BackColor);
        
        e.Graphics.DrawLine(
            new Pen(Color.Red, 3),
            new Point(0, 0),
            new Point(this.Width, this.Height));
    }

    private void SpiCursor()
    {
        while (true)
        {
            Console.WriteLine(Cursor.Position);
            Thread.Sleep(10);
        }
    }
}