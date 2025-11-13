namespace UkrainianPaintAnalog;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.PictureBox mainPcBx;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        // inicjalizacja widgetow
        this.mainPcBx = new PictureBox();
        
        this.SuspendLayout();
        
        
        // glowne okno
        this.mainPcBx.Size = new Size(200, 200);
        this.mainPcBx.Location = new Point(0, 0);
        this.mainPcBx.BackColor = Color.White;
        this.mainPcBx.Paint += Risuem;
        
        this.Controls.AddRange(new System.Windows.Forms.Control[]
        {
            this.mainPcBx
        });
        
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(800, 450);
        this.Text = "UPA";
        this.BackColor = Color.AntiqueWhite;
    }
}