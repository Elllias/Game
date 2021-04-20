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
		Player satyr;
		
		public Form1()
		{
			InitializeComponent();

			timer1.Interval = 10;
			timer1.Tick += new EventHandler(Update);
			KeyDown += new KeyEventHandler(OnKeyDown);
			KeyUp += new KeyEventHandler(OnKeyUp);

			Initialize();
		}

		public void Initialize()
		{
			player = new Player(100, 100, Hero.IdleFrames, Hero.RunFrames, Hero.AttackFrames, Hero.DeathFrames, Hero.Icon);
			satyr = new Player(700, 250, Satyr.IdleFrames, Satyr.RunFrames, Satyr.AttackFrames, Satyr.DeathFrames, Satyr.Icon); // пока просто поставил на карту

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

			PlayAnimation(graphics, satyr);
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
					100 * player.CurFrame, 100 * player.CurAnimation, player.size, player.size, GraphicsUnit.Point);
		}
	}
}
