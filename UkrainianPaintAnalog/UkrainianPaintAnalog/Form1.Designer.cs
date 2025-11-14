namespace UkrainianPaintAnalog;

partial class Form1
{
    // инициализация объектов виджетов
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.PictureBox mainPcBx;
    private System.Windows.Forms.Panel colorPanel;
    private System.Windows.Forms.Button colorBtn;
    private System.Windows.Forms.PictureBox colorPicker;
    private System.Windows.Forms.PictureBox colorShower;

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
        this.colorPicker = new PictureBox();
        this.colorShower = new PictureBox();
        
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
        this.colorPanel.Size = new Size(450, 90);

        // colordialog кнопка
        string imagePath = Path.Combine(Application.StartupPath, "sysmedia", "tsveta.png");
        this.colorPicker.Image = Image.FromFile(imagePath);
        this.colorPicker.SizeMode = PictureBoxSizeMode.StretchImage;
        this.colorPicker.Location = new Point(15, 20);
        this.colorPicker.Size = new Size(45, 45);
        this.colorPicker.Cursor = Cursors.Hand;
        this.colorPicker.Click += ChangeColorDialog;
        this.colorPanel.Controls.Add(this.colorPicker);
        
        // кнопки
        int startX = 75;
        int buttonsY = 15;
        int diffrence = 30;
        for (int i = 0; i < colors.Count; i++)
        {
            if (i == 10)
            {
                startX = 75;
                buttonsY = 50;
            }
            this.colorBtn = new Button();
            this.colorBtn.Location = new Point(startX, buttonsY);
            this.colorBtn.BackColor = ColorTranslator.FromHtml("#" + colors[i]);
            this.colorBtn.Size = new Size(25, 25);
            this.colorBtn.Cursor = Cursors.Hand;
            this.colorBtn.MouseClick += this.ChangeColor;
            this.colorPanel.Controls.Add(this.colorBtn);
            startX += diffrence;
        }
        
        // показать цвет
        this.colorShower.Location = new Point(400, 30);
        this.colorShower.Size = new Size(30, 30);
        this.colorShower.BackColor = this._penColor;
        this.colorPanel.Controls.Add(this.colorShower);
        
        // главное окно для рисования
        this.mainPcBx.Size = new Size(1180, 680);
        this.mainPcBx.Location = new Point(10, 110);
        this.mainPcBx.BackColor = Color.White;
        this.mainPcBx.Cursor = Cursors.Cross;
        
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