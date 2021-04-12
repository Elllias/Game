using Arena.Entites;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Arena
{
    public partial class Form1 : Form
    {
        public Image Woodcutter;
        Player player;

        public Form1()
        {
            InitializeComponent();
            Initialize();
        }

        public void Initialize()
        {
            Woodcutter = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\Woodcutter\\woodcutter.png"));
            player = new Player(150, 150, Hero.IdleFrames, Hero.RunFrames, Hero.AttackFrames, Hero.DeathFrames, Woodcutter);

            Invalidate();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            graphics.DrawImage(player.Sprite,
                new Rectangle(new Point(player.PosX, player.PosY), new Size(player.SizeX,player.SizeY)),
                0, 0, player.SizeX, player.SizeY, GraphicsUnit.Pixel); // Чисто ради интереса отрисовал)) Забавно
        }
    }
}
