﻿using Arena.Models;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Arena
{
	public partial class Form1 : Form
	{
		Player player;
		Player enemy;
		
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
			//progressBar1
			Map.Init();
			this.Width = Map.CellSize * Map.MapWidth+15;
			this.Height = Map.CellSize * (Map.MapHeight+1)+8;

			player = new Player(150, 270, Hero.IdleFrames, Hero.RunFrames, Hero.AttackFrames, Hero.DeathFrames, Hero.Icon);
			enemy = new Player(200, 270, Satyr.IdleFrames, Satyr.RunFrames, Satyr.AttackFrames, Satyr.DeathFrames, Satyr.Icon);

			timer1.Start();
		}

		private void OnKeyUp(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
                case Keys.W:
					player.dY = 0;
					break;
				case Keys.A:
					player.dX = 0;
					break;
				case Keys.S:
					player.dY = 0;
					break;
				case Keys.D:
					player.dX = 0;
					break;
				case Keys.Up:
					enemy.dY = 0;
					break;
				case Keys.Left:
					enemy.dX = 0;
					break;
				case Keys.Down:
					enemy.dY = 0;
					break;
				case Keys.Right:
					enemy.dX = 0;
					break;
			}

			if (player.dY == 0 && player.dX == 0)
			{
				player.IsMoving = false;
				if (player.Flip == 1)
					player.SetAnimationConfiguration(0);
				else
					player.SetAnimationConfiguration(4);
			}

			if (enemy.dY == 0 && enemy.dX == 0)
			{
				enemy.IsMoving = false;
				if (enemy.Flip == 1)
					enemy.SetAnimationConfiguration(0);
				else
					enemy.SetAnimationConfiguration(4);
			}
		}

		private void OnKeyDown(object sender, KeyEventArgs e)
		{
			if (player.IsAlive)
			{
				switch (e.KeyCode)
				{
					case Keys.W:
						player.IsMoving = true;
						if (player.Flip == 1)
							player.SetAnimationConfiguration(1);
						else
							player.SetAnimationConfiguration(5);
						player.dY = -player.Speed;
						break;
					case Keys.A:
						player.IsMoving = true;
						player.SetAnimationConfiguration(5);
						player.Flip = -1;
						player.dX = -player.Speed;
						break;
					case Keys.S:
						player.IsMoving = true;
						if (player.Flip == 1)
							player.SetAnimationConfiguration(1);
						else
							player.SetAnimationConfiguration(5);
						player.dY = player.Speed;
						break;
					case Keys.D:
						player.IsMoving = true;
						player.SetAnimationConfiguration(1);
						player.dX = player.Speed;
						player.Flip = 1;
						break;
					case Keys.Space:
						if (player.IsCollide(enemy))
							enemy.GetDamage();
						player.dX = 0;
						player.dY = 0;
						if (player.Flip == 1)
							player.SetAnimationConfiguration(2);
						else
							player.SetAnimationConfiguration(6);
						break;
				}
			}

			if (enemy.IsAlive)
			{
				switch (e.KeyCode)
				{
					case Keys.Up:
						enemy.IsMoving = true;
						if (enemy.Flip == 1)
							enemy.SetAnimationConfiguration(1);
						else
							enemy.SetAnimationConfiguration(5);
						enemy.dY = -enemy.Speed;
						break;
					case Keys.Left:
						enemy.IsMoving = true;
						enemy.SetAnimationConfiguration(5);
						enemy.Flip = -1;
						enemy.dX = -enemy.Speed;
						break;
					case Keys.Down:
						enemy.IsMoving = true;
						if (enemy.Flip == 1)
							enemy.SetAnimationConfiguration(1);
						else
							enemy.SetAnimationConfiguration(5);
						enemy.dY = enemy.Speed;
						break;
					case Keys.Right:
						enemy.IsMoving = true;
						enemy.SetAnimationConfiguration(1);
						enemy.dX = enemy.Speed;
						enemy.Flip = 1;
						break;
					case Keys.Enter:
						if (player.IsCollide(enemy))
							player.GetDamage();
						enemy.dX = 0;
						enemy.dY = 0;
						if (enemy.Flip == 1)
							enemy.SetAnimationConfiguration(2);
						else
							enemy.SetAnimationConfiguration(6);
						break;
				}
			}
		}

		private void Update(object sender, EventArgs e)
		{
			player.Move();
			enemy.Move();

			if (player.HP <= 100 && player.HP >= 0)
				HPPlayerBar.Value = player.HP;
			if (enemy.HP <= 100 && enemy.HP >= 0)
				HPEnemyBar.Value = enemy.HP;

			if (player.HP == 0)
				player.IsDead();
			if (enemy.HP == 0)
				enemy.IsDead();

			Invalidate();
		}

		private void OnPaint(object sender, PaintEventArgs e)
		{
			Graphics graphics = e.Graphics;

			DrawMap(graphics);
			SeedMap(graphics);
			PlayAnimation(graphics, player);
			PlayAnimation(graphics, enemy);
        }

		private void PlayAnimation(Graphics graphics, Player player)
		{
			if (player.IsAlive == false)
				return;
			if (player.CurFrame < player.CurLimit - 1)
				player.CurFrame++;
			else
				player.CurFrame = 0;

			graphics.DrawImage(player.Sprite,
					new Rectangle(new Point(player.PosX, player.PosY), new Size(player.Size, player.Size)),
					50 * player.CurFrame, 50 * player.CurAnimation, player.Size, player.Size, GraphicsUnit.Point);
		}

		private void DrawMap(Graphics graphics)
		{
			for (int i = 0; i < Map.MapHeight; i++)
				for (int j = 0; j < Map.MapWidth; j++)
				{
					DrawThing(graphics, i, j, 0, 0, 20, 20);
					switch (Map.map[i, j])
					{
						case 1:
							DrawThing(graphics, i, j, 96, 0, 20, 20);
							break;
						case 2:
							DrawThing(graphics, i, j, 170, 0, 20, 20);
							break;
						case 3:
							DrawThing(graphics, i, j, 96, 75, 20, 20);
							break;
						case 4:
							DrawThing(graphics, i, j, 170, 75, 20, 20);
							break;
						case 5:
							DrawThing(graphics, i, j, 96, 20, 20, 20);
							break;
						case 6:
							DrawThing(graphics, i, j, 120, 0, 20, 20);
							break;
						case 7:
							DrawThing(graphics, i, j, 170, 30, 20, 20);
							break;
						case 8:
							DrawThing(graphics, i, j, 120, 75, 20, 20);
							break;
						case 9:
							DrawThing(graphics, i, j, 230, 40, 20, 20);
							break;
						
					}
				}
		}

		private void SeedMap(Graphics graphics)
		{
			for (int i = 0; i < Map.MapHeight; i++)
				for (int j = 0; j < Map.MapWidth; j++)
				{
					if (Map.map[i, j] == 20)
						DrawThing(graphics, i, j, 8, 293, 110, 120, Map.CellSize*3, Map.CellSize*3);

					if (Map.map[i, j] == 21)
						DrawThing(graphics, i, j, 581, 114, 19, 11, 20, 11);

					if (Map.map[i, j] == 22)
						DrawThing(graphics, i, j, 610, 4, 10, 8, 15, 15);
				}

		}

		private void DrawThing(Graphics graphics, int i, int j, int srcX, int srcY, int srcW, int srcH)
		{
			graphics.DrawImage(Map.MapSprite,
						new Rectangle(new Point(j * Map.CellSize, i * Map.CellSize), new Size(Map.CellSize, Map.CellSize)),
						srcX, srcY, srcW, srcH, GraphicsUnit.Point);
		}

		private void DrawThing(Graphics graphics, int i, int j, int srcX, int srcY, int srcW, int srcH, int s1, int s2)
		{
			graphics.DrawImage(Map.MapSprite,
						new Rectangle(new Point(j * Map.CellSize, i * Map.CellSize), new Size(s1, s2)),
						srcX, srcY, srcW, srcH, GraphicsUnit.Point);
			Map.MapThings.Add(new Thing(new Point(j * Map.CellSize, i * Map.CellSize), new Size(s1, s2)));

		}
    }
}
