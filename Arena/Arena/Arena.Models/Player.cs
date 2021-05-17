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
            // Размеры всех спрайтов
            Size = 50;
        }

        public void Move()
        {
            PosX += dX;
            PosY += dY;
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
    }
}
