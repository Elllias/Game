using Arena.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena
{
    [TestFixture]
    public class GameTests
    {
        Image IconHero;

        [SetUp]
        public void SetUp()
        {
            IconHero = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).FullName.ToString(), "Sprites\\Hero\\Frames.png"));
        }

        [Test]
        public void PlayerFarFromEnemy()
        {
            var player = CreatePlayer(0, 10);
            var enemy = CreatePlayer(0, 100);
            Assert.AreEqual(false, player.IsCollide(enemy));
        }

        [Test]
        public void PlayerCloseFromEnemy()
        {
            var player = CreatePlayer(0, 10);
            var enemy = CreatePlayer(0, 11);
            Assert.AreEqual(true, player.IsCollide(enemy));
        }

        [Test]
        public void GetDamageWorkCorrect()
        {
            var player = CreatePlayer(0, 10);
            player.GetDamage();
            Assert.AreEqual(90, player.HP);
        }

        [TestCase (Player.Element.Earth, Player.Element.Fire)]
        [TestCase (Player.Element.Fire, Player.Element.Water)]
        public void PlayerIsStongerWorkCorrect(Player.Element element , Player.Element element1)
        {
            var player = CreatePlayer(50, 50);
            var enemy = CreatePlayer(0, 0);
            player.CurElement = element1;
            enemy.CurElement = element;
            Assert.AreEqual(true, player.IsStronger(enemy));
        }

        [Test]
        public void PlayerIsDeadWorkCorrect()
        {
            var player = CreatePlayer(0, 0);
            player.IsDead();
            Assert.AreEqual(false, player.IsAlive);
        }

        private Player CreatePlayer(int x, int y)
        {
            return new Player(x, y, 5, 7, 7, 7, IconHero);
        }
    }
}
