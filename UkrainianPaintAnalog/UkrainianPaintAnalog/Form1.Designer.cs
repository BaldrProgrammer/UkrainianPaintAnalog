namespace UkrainianPaintAnalog;

partial class Form1
{
    // инициализация объектов виджетов
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.PictureBox mainPcBx;
    private System.Windows.Forms.Panel colorPanel;

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
        // создание виджетов
        this.colorPanel = new Panel();
        this.mainPcBx = new PictureBox();
        
        this.SuspendLayout();
        
        // сектор выбора цвета кисти
        List<string> colors = new List<string>()
        {
            "000000", "FFFFFF", // черно-белый
            "999999", "CCCCCC", // серый
            "880000", "794949", // бордовый
            "FF0000", "FF9999", // красный
            "FF8800", "FFBB77", // оранжевый
            "FFFF00", "FFFF77", // желтый
            "00FF00", "99FF99", // зеленый
            "00FFFF", "99FFFF", // голубой
            "0000FF", "9999FF", // синий
            "BB00FF", "eebbff", // фиолетовый
        };
        
        this.colorPanel.BackColor = Color.White;
        this.colorPanel.Location = new Point(10, 10);
        this.colorPanel.Size = new Size(250, 130);
        
        // главное окно для рисования
        this.mainPcBx.Size = new Size(1180, 640);
        this.mainPcBx.Location = new Point(10, 150);
        this.mainPcBx.BackColor = Color.White;
        
        this.Controls.AddRange(new System.Windows.Forms.Control[]
        {
            this.mainPcBx, this.colorPanel
        });
        
        // редакция главного окна
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(1200, 800);
        this.Text = "UPA";
        this.BackColor = Color.AntiqueWhite;
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox = false; // не свернёшь)) мне лень оптимизировать размеры, и так сойдёт

    }
}