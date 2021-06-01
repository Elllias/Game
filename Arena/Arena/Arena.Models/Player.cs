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
            Fire = 0,
            Earth = 8,
            Electricity = 16,
            Water = 24
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
            CurAnimation = curAnimation + (int)CurElement;
            
            switch (curAnimation)
            {
                case 0:
                    CurLimit = IdleFrames;
                    break;
                case 1:
                    CurLimit = RunFrames;
                    break;
                case 2:
                    CurLimit = AttackFrames;
                    break;
                case 3:
                    CurLimit = DeathFrames;
                    break;
                case 4:
                    CurLimit = IdleFrames;
                    break;
                case 5:
                    CurLimit = RunFrames;
                    break;
                case 6:
                    CurLimit = AttackFrames;
                    break;
                case 7:
                    CurLimit = DeathFrames;
                    break;
                case 8:
                    CurLimit = IdleFrames;
                    break;
                case 9:
                    CurLimit = RunFrames;
                    break;
                case 10:
                    CurLimit = AttackFrames;
                    break;
                case 11:
                    CurLimit = DeathFrames;
                    break;
                case 12:
                    CurLimit = IdleFrames;
                    break;
                case 13:
                    CurLimit = RunFrames;
                    break;
                case 14:
                    CurLimit = AttackFrames;
                    break;
                case 15:
                    CurLimit = DeathFrames;
                    break;
                case 16:
                    CurLimit = IdleFrames;
                    break;
                case 17:
                    CurLimit = RunFrames;
                    break;
                case 18:
                    CurLimit = AttackFrames;
                    break;
                case 19:
                    CurLimit = DeathFrames;
                    break;
                case 20:
                    CurLimit = IdleFrames;
                    break;
                case 21:
                    CurLimit = RunFrames;
                    break;
                case 22:
                    CurLimit = AttackFrames;
                    break;
                case 23:
                    CurLimit = DeathFrames;
                    break;
                case 24:
                    CurLimit = IdleFrames;
                    break;
                case 25:
                    CurLimit = RunFrames;
                    break;
                case 26:
                    CurLimit = AttackFrames;
                    break;
                case 27:
                    CurLimit = DeathFrames;
                    break;
                case 28:
                    CurLimit = IdleFrames;
                    break;
                case 29:
                    CurLimit = RunFrames;
                    break;
                case 30:
                    CurLimit = AttackFrames;
                    break;
                case 31:
                    CurLimit = DeathFrames;
                    break;
            }
        }

        public bool IsCollide(Player enemy)
        {
            PointF delta = FindDelta(enemy);
                
                if (Math.Abs(delta.X) <= (enemy.Size / 2 + Size / 2) / 1.5)
                {
                    if (Math.Abs(delta.Y) <= (enemy.Size / 2 + Size / 2) / 1.5)
                    {
                        if (delta.X < 0
                            && enemy.PosY + enemy.Size / 2 > PosY
                            && enemy.PosY + enemy.Size / 2 < PosY + Size)
                        {
                            return true;
                        }
                        if (delta.X > 0 
                            && enemy.PosY + enemy.Size / 2 > PosY
                            && enemy.PosY + enemy.Size / 2 < PosY + Size)
                        {
                            return true;
                        }
                        if (delta.Y < 0
                            && enemy.PosX + enemy.Size / 2 > PosX
                            && enemy.PosX + enemy.Size / 2 < PosX + Size)
                        {
                            return true;
                        }
                        if (delta.Y > 0
                            && enemy.PosX + enemy.Size / 2 > PosX
                            && enemy.PosX + enemy.Size / 2 < PosX + Size)
                        {
                            return true;
                        }
                    }
                }
            return false;
        }

        public void GetDamage()
        {
            HP -= 10;
        }

        public void IsDead()
        {
            IsAlive = false;
            Speed = 0;
            SetAnimationConfiguration(3);
        }

        public bool IsStronger(Player enemy)
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

        private PointF FindDelta(Player enemy)
        {
            var del = new PointF()
            {
                X = (enemy.PosX + enemy.Size / 2) - (PosX + Size / 2),
                Y = (enemy.PosY + enemy.Size / 2) - (PosY + Size / 2)
            };
            return del;
        }
    }
}
