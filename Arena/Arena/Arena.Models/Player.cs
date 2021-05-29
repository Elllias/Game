using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena.Models
{
    public class Player
    {
        public int PosX;
        public int PosY;
        public int dX;
        public int dY;
        public bool IsMoving;
        public int Speed;

        public int CurFrame;
        public int CurAnimation;
        public int CurLimit;
        public int Flip;

        public Image Sprite;
        public int IdleFrames;
        public int RunFrames;
        public int AttackFrames;
        public int DeathFrames;
        public int Size;

        public int HP;
        public bool IsAlive;
        public Element CurElement;
        public enum Element
        {
            Fire = 1,
            Earth = 2,
            Electricity = 3,
            Water = 4
        }

        public Player(int posX, int posY, int idleFrames, int runFrames, int attackFrames, int deathFrames, Image sprite)
        {
            PosX = posX;
            PosY = posY;
            IdleFrames = idleFrames;
            RunFrames = runFrames;
            AttackFrames = attackFrames;
            DeathFrames = deathFrames;
            Sprite = sprite;
            CurLimit = idleFrames;
            Speed = 3;
            CurAnimation = 0;
            CurFrame = 0;
            Flip = 1;
            HP = 100;
            IsAlive = true;
            CurElement = Element.Fire;
            // Размеры всех спрайтов
            Size = 50;
        }

        public void Move()
        {
            if (!Map.IsCollide(this, new Point(dX, dY)))
            {
                if (IsMoving)
                {
                    PosX += dX;
                    PosY += dY;
                }
            }
        }


        public void SetAnimationConfiguration(int curAnimation)
        {
            this.CurAnimation = curAnimation;
            
            switch (curAnimation)
            {
                case 0:
                    CurLimit = this.IdleFrames;
                    break;
                case 1:
                    CurLimit = this.RunFrames;
                    break;
                case 2:
                    CurLimit = this.AttackFrames;
                    break;
                case 3:
                    CurLimit = this.DeathFrames;
                    break;
                case 4:
                    CurLimit = this.IdleFrames;
                    break;
                case 5:
                    CurLimit = this.RunFrames;
                    break;
                case 6:
                    CurLimit = this.AttackFrames;
                    break;
                case 7:
                    CurLimit = this.DeathFrames;
                    break;
            }
        }

        public bool IsCollide(Player Enemy)
        {
                PointF delta = new PointF();
                delta.X = (Enemy.PosX + Enemy.Size / 2) - (PosX + Size / 2);
                delta.Y = (Enemy.PosY + Enemy.Size / 2) - (PosY + Size / 2);
                if (Math.Abs(delta.X) <= (Enemy.Size / 2 + Size / 2) / 1.5)
                {
                    if (Math.Abs(delta.Y) <= (Enemy.Size / 2 + Size / 2) / 1.5)
                    {
                        if (delta.X < 0
                            && Enemy.PosY + Enemy.Size / 2 > PosY
                            && Enemy.PosY + Enemy.Size / 2 < PosY + Size)
                        {
                            return true;
                        }
                        if (delta.X > 0 
                            && Enemy.PosY + Enemy.Size / 2 > PosY
                            && Enemy.PosY + Enemy.Size / 2 < PosY + Size)
                        {
                            return true;
                        }
                        if (delta.Y < 0
                            && Enemy.PosX + Enemy.Size / 2 > PosX
                            && Enemy.PosX + Enemy.Size / 2 < PosX + Size)
                        {
                            return true;
                        }
                        if (delta.Y > 0
                            && Enemy.PosX + Enemy.Size / 2 > PosX
                            && Enemy.PosX + Enemy.Size / 2 < PosX + Size)
                        {
                            return true;
                        }
                    }
                }
            return false;
        }

        public void GetDamage()
        {
            this.HP -= 10;
        }

        public void IsDead()
        {
            this.IsAlive = false;
            this.Speed = 0;
            this.SetAnimationConfiguration(3);
        }

        public bool IsWeak(Player enemy)
        {
            switch (CurElement)
            {
                case Element.Fire:
                    return enemy.CurElement == Element.Earth;
                case Element.Earth:
                    return enemy.CurElement == Element.Electricity;
                case Element.Electricity:
                    return enemy.CurElement == Element.Water;
                case Element.Water:
                    return enemy.CurElement == Element.Fire;
            }
            return false;
        }
    }
}
