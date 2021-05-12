using Arena.Models;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Arena
{
	public partial class Form1 : Form
	{
		Player player;
		
		public Form1()
		{
			InitializeComponent();

			timer1.Interval = 20;
			timer1.Tick += new EventHandler(Update);
			KeyDown += new KeyEventHandler(OnKeyDown);
			KeyUp += new KeyEventHandler(OnKeyUp);

			Initialize();
		}

		public void Initialize()
		{
			Map.Init();
			this.Width = Map.CellSize * Map.MapWidth+15;
			this.Height = Map.CellSize * (Map.MapHeight+1)+8;

			player = new Player(150, 270, Hero.IdleFrames, Hero.RunFrames, Hero.AttackFrames, Hero.DeathFrames, Hero.Icon);

			timer1.Start();
		}

		private void OnKeyUp(object sender, KeyEventArgs e)
		{
			player.dX = 0;
			player.dY = 0;
			player.IsMoving = false;
			player.SetAnimationConfiguration(0);
		}

		private void OnKeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.W:
					player.IsMoving = true;
					player.SetAnimationConfiguration(1);
					player.dY = -player.Speed;
					break;
				case Keys.A:
					player.IsMoving = true;
					player.SetAnimationConfiguration(1);
					player.Flip = -1;
					player.dX = -player.Speed;
					break;
				case Keys.S:
					player.IsMoving = true;
					player.SetAnimationConfiguration(1);
					player.dY = player.Speed;
					break;
				case Keys.D:
					player.IsMoving = true;
					player.SetAnimationConfiguration(1);
					player.Flip = 1;
					player.dX = player.Speed;
					break;
                case Keys.Space:
					player.dX = 0;
					player.dY = 0;
					player.IsMoving = false;
					player.SetAnimationConfiguration(2);
					break;
			}
		}

		private void Update(object sender, EventArgs e)
		{
			if (player.IsMoving)
				player.Move();
			
			Invalidate();
		}

		private void OnPaint(object sender, PaintEventArgs e)
		{
			Graphics graphics = e.Graphics;

			DrawMap(graphics);
			SeedMap(graphics);
			PlayAnimation(graphics, player);
        }

		public void PlayAnimation(Graphics graphics, Player player)
		{
			if (player.CurFrame < player.CurLimit - 1)
				player.CurFrame++;
			else
				player.CurFrame = 0;

			graphics.DrawImage(player.Sprite,
					new Rectangle(new Point(player.PosX - player.Flip*player.size/2, player.PosY), new Size(player.Flip * player.size, player.size)),
					50 * player.CurFrame, 50 * player.CurAnimation, player.size, player.size, GraphicsUnit.Point);
		}

		public void DrawMap(Graphics graphics)
		{
			for (int i = 0; i < Map.MapWidth; i++)
				for (int j = 0; j < Map.MapHeight; j++)
				{
					graphics.DrawImage(Map.MapSprite,
							new Rectangle(new Point(j * Map.CellSize, i * Map.CellSize), new Size(Map.CellSize, Map.CellSize)),
							0, 0, 20, 20, GraphicsUnit.Point);
					switch (Map.map[i, j])
					{
						case 1:
							graphics.DrawImage(Map.MapSprite,
							new Rectangle(new Point(j * Map.CellSize, i * Map.CellSize), new Size(Map.CellSize, Map.CellSize)),
							96, 0, 20, 20, GraphicsUnit.Point);
							break;
						case 2:
							graphics.DrawImage(Map.MapSprite,
							new Rectangle(new Point(j * Map.CellSize, i * Map.CellSize), new Size(Map.CellSize, Map.CellSize)),
							170, 0, 20, 20, GraphicsUnit.Point);
							break;
						case 3:
							graphics.DrawImage(Map.MapSprite,
							new Rectangle(new Point(j * Map.CellSize, i * Map.CellSize), new Size(Map.CellSize, Map.CellSize)),
							96, 75, 20, 20, GraphicsUnit.Point);
							break;
						case 4:
							graphics.DrawImage(Map.MapSprite,
							new Rectangle(new Point(j * Map.CellSize, i * Map.CellSize), new Size(Map.CellSize, Map.CellSize)),
							170, 75, 20, 20, GraphicsUnit.Point);
							break;
						case 5:
							graphics.DrawImage(Map.MapSprite,
							new Rectangle(new Point(j * Map.CellSize, i * Map.CellSize), new Size(Map.CellSize, Map.CellSize)),
							96, 20, 20, 20, GraphicsUnit.Point);
							break;
						case 6:
							graphics.DrawImage(Map.MapSprite,
							new Rectangle(new Point(j * Map.CellSize, i * Map.CellSize), new Size(Map.CellSize, Map.CellSize)),
							120, 0, 20, 20, GraphicsUnit.Point);
							break;
						case 7:
							graphics.DrawImage(Map.MapSprite,
							new Rectangle(new Point(j * Map.CellSize, i * Map.CellSize), new Size(Map.CellSize, Map.CellSize)),
							170, 30, 20, 20, GraphicsUnit.Point);
							break;
						case 8:
							graphics.DrawImage(Map.MapSprite,
							new Rectangle(new Point(j * Map.CellSize, i * Map.CellSize), new Size(Map.CellSize, Map.CellSize)),
							120, 75, 20, 20, GraphicsUnit.Point);
							break;
					}
				}
		}

		public void SeedMap(Graphics graphics)
		{
			for (int i = 0; i < Map.MapWidth; i++)
				for (int j = 0; j < Map.MapHeight; j++)
				{
					if (Map.map[i, j] == 10)
						graphics.DrawImage(Map.MapSprite,
						new Rectangle(new Point(j * Map.CellSize, i * Map.CellSize), new Size(Map.CellSize *3, Map.CellSize * 3)),
						202, 298, 107, 114, GraphicsUnit.Point);

					if (Map.map[i, j] == 11)
						graphics.DrawImage(Map.MapSprite,
						new Rectangle(new Point(j * Map.CellSize, i * Map.CellSize), new Size(20,11)),
						581, 114, 19, 11, GraphicsUnit.Point);

					if (Map.map[i, j] == 12)
						graphics.DrawImage(Map.MapSprite,
						new Rectangle(new Point(j * Map.CellSize, i * Map.CellSize), new Size(10, 10)),
						610, 4, 10, 8, GraphicsUnit.Point);
				}

		}
    }
}
