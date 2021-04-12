using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena.Entites
{
    public class Player
    {
        public int PosX;
        public int PosY;

        public Image Sprite;
        public int IdleFrames;
        public int RunFrames;
        public int AttackFrames;
        public int DeathFrames;
        public int SizeX;
        public int SizeY;

        public Player(int posX, int posY, int idleFrames, int runFrames, int attackFrames, int deathFrames, Image sprite)
        {
            PosX = posX;
            PosY = posY;
            IdleFrames = idleFrames;
            RunFrames = runFrames;
            AttackFrames = attackFrames;
            DeathFrames = deathFrames;
            Sprite = sprite;
            // Размеры всех спрайтов
            SizeX = 26;
            SizeY = 49;
        }

        public void Move(int dX, int dY)
        {
            PosX += dX;
            PosY += dY;
        }
    }
}
