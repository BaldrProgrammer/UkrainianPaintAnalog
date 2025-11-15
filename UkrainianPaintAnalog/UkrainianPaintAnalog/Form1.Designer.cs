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

    private System.Windows.Forms.Panel sizePanel;
    private System.Windows.Forms.Label sizeLbl;
    private System.Windows.Forms.Button sizeBtn;
    private System.Windows.Forms.TrackBar sizeBar;

    private System.Windows.Forms.Panel modePanel;
    private System.Windows.Forms.PictureBox brushBtn;
    private System.Windows.Forms.PictureBox eraserBtn;
    private System.Windows.Forms.PictureBox trashBtn;
    
    private System.Windows.Forms.Panel filePanel;
    private System.Windows.Forms.Button saveBtn;
    private System.Windows.Forms.Button saveasBtn;
    private System.Windows.Forms.Button openBtn;

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
        
        this.sizePanel = new Panel();
        this.sizeLbl = new Label();
        this.sizeBar = new TrackBar();
        
        this.modePanel = new Panel();
        this.brushBtn = new PictureBox();
        this.eraserBtn = new PictureBox();
        this.trashBtn = new PictureBox();
        
        this.filePanel = new Panel();
        this.saveBtn = new Button();
        this.saveasBtn = new Button();
        this.openBtn = new Button();
        
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
        
        
        // сектор выбора ширины кисти
        List<int> sizes = new List<int>() { 1, 3, 5, 8, 10 };
        
        // панель
        this.sizePanel.BackColor = Color.White;
        this.sizePanel.Location = new Point(475, 10);
        this.sizePanel.Size = new Size(450, 90);
        
        // отображение пикселей
        this.sizeLbl.Text = $"{_penWidth}px";
        this.sizeLbl.Location = new Point(350, 15);
        this.sizeLbl.Size = new Size(75, 25);
        this.sizePanel.Controls.Add(sizeLbl);
        
        // кнопки
        int startXfs = 75;
        int diffrencefs = 50;
        for (int i = 0; i < sizes.Count; i++)
        {
            this.sizeBtn = new Button();
            this.sizeBtn.Text = $"{sizes[i]}px";
            this.sizeBtn.Location = new Point(startXfs, 15);
            this.sizeBtn.Size = new Size(50, 25);
            this.sizeBtn.Cursor = Cursors.Hand;
            this.sizeBtn.MouseClick += this.ChangeWidth;
            this.sizePanel.Controls.Add(this.sizeBtn);
            startXfs += diffrencefs;
        }
        
        // сайдбар
        this.sizeBar.Location = new Point(25, 45);
        this.sizeBar.Size = new Size(400, 25);
        this.sizeBar.Minimum = 0;
        this.sizeBar.Maximum = 300;
        this.sizeBar.Value = 20;
        this.sizeBar.ValueChanged += ChangeWidthBar;
        this.sizeBar.Cursor = Cursors.Hand;
        this.sizePanel.Controls.Add(sizeBar);
        
        
        // сектор выбора режима кисти и очистки экрана
        this.modePanel.BackColor = Color.White;
        this.modePanel.Location = new Point(940, 10);
        this.modePanel.Size = new Size(130, 90);

        // кнопка на переключение в кисть
        string brushPath = Path.Combine(Application.StartupPath, "sysmedia", "kist.png");
        this.brushBtn.Image = Image.FromFile(brushPath);
        this.brushBtn.SizeMode = PictureBoxSizeMode.StretchImage;
        this.brushBtn.Location = new Point(5, 5);
        this.brushBtn.Size = new Size(40, 40);
        this.brushBtn.Cursor = Cursors.Hand;
        this.modePanel.Controls.Add(brushBtn);
        
        // кнопка на переключение в затирачку
        string eraserPath = Path.Combine(Application.StartupPath, "sysmedia", "zatiraczka.png");
        this.eraserBtn.Image = Image.FromFile(eraserPath);
        this.eraserBtn.SizeMode = PictureBoxSizeMode.StretchImage;
        this.eraserBtn.Location = new Point(5, 45);
        this.eraserBtn.Size = new Size(40, 40);
        this.eraserBtn.Cursor = Cursors.Hand;
        this.modePanel.Controls.Add(eraserBtn);
        
        // кнопка на переключение в затирачку
        string trashPath = Path.Combine(Application.StartupPath, "sysmedia", "musorka.png");
        this.trashBtn.Image = Image.FromFile(trashPath);
        this.trashBtn.SizeMode = PictureBoxSizeMode.StretchImage;
        this.trashBtn.Location = new Point(55, 10);
        this.trashBtn.Size = new Size(70, 70);
        this.trashBtn.Cursor = Cursors.Hand;
        this.modePanel.Controls.Add(trashBtn);
        
        
        // сектор сохранения/открытия файла
        this.filePanel.BackColor = Color.White;
        this.filePanel.Location = new Point(1080, 10);
        this.filePanel.Size = new Size(130, 90);
        
        // сохранить
        this.saveBtn.Text = "Сохранить";
        this.saveBtn.Font = new Font("Arial", 6.5f);
        this.saveBtn.Location = new Point(10, 10);
        this.saveBtn.Size = new Size(110, 20);
        this.saveBtn.Cursor = Cursors.Hand;
        this.saveBtn.MouseClick += Save;
        this.filePanel.Controls.Add(saveBtn);
        
        // сохранить как
        this.saveasBtn.Text = "Сохранить как";
        this.saveasBtn.Font = new Font("Arial", 6.5f);
        this.saveasBtn.Location = new Point(10, 35);
        this.saveasBtn.Size = new Size(110, 20);
        this.saveasBtn.Cursor = Cursors.Hand;
        this.saveasBtn.MouseClick += SaveAs;
        this.filePanel.Controls.Add(saveasBtn);
        
        // открыть
        this.openBtn.Text = "Открыть";
        this.openBtn.Font = new Font("Arial", 6.5f);
        this.openBtn.Location = new Point(10, 60);
        this.openBtn.Size = new Size(110, 20);
        this.openBtn.Cursor = Cursors.Hand;
        this.openBtn.MouseClick += Open;
        this.filePanel.Controls.Add(openBtn);
        
        
        // главное окно для рисования
        this.mainPcBx.Size = new Size(1200, 680);
        this.mainPcBx.Location = new Point(10, 110);
        this.mainPcBx.BackColor = Color.White;
        this.mainPcBx.Cursor = Cursors.Cross;
        this.mainPcBx.Image = new Bitmap(1230, 650);
        
        this.Controls.AddRange(new System.Windows.Forms.Control[]
        {
            this.mainPcBx,
            this.colorPanel, this.sizePanel, this.modePanel, this.filePanel
        });
        
        // редакция главного окна
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(1220, 800);
        this.Text = "UPA";
        this.BackColor = Color.AntiqueWhite;
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox = false; // не свернёшь)) мне лень оптимизировать размеры, и так сойдёт

    }
}