namespace UkrainianPaintAnalog;

partial class Form1
{
    // инициализация объектов виджетов
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.PictureBox mainPcBx;
    private System.Windows.Forms.Panel colorPanel;
    private System.Windows.Forms.Button colorBtn;

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
            // яркие версии
            "000000", "999999", "880000", "FF0000", "FF8800",
            "FFFF00", "00FF00", "00FFFF", "0000FF", "BB00FF",
            // тусклые версии
            "FFFFFF", "CCCCCC", "794949", "FF9999", "FFBB77",
            "FFFF77", "99FF99", "99FFFF", "9999FF", "eebbff"
        };
        
        // панель
        this.colorPanel.BackColor = Color.White;
        this.colorPanel.Location = new Point(10, 10);
        this.colorPanel.Size = new Size(750, 130);

        // кнопки
        int startX = 10;
        int diffrence = 30;
        for (int i = 0; i < colors.Count; i++)
        {
            this.colorBtn = new Button();
            if (i > 9)
            {
                this.colorBtn.Location = new Point(startX, 10);
            }
            else
            {
                this.colorBtn.Location = new Point(startX, 40);
            }
            this.colorBtn.BackColor = ColorTranslator.FromHtml("#" + colors[i]);
            this.colorBtn.Size = new Size(25, 25);
            colorPanel.Controls.Add(this.colorBtn);
            startX += diffrence;
        }
        
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