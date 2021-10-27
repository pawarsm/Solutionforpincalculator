using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingBall.Tests
{
    [TestClass]
    public class GameFixture
    {
        [TestMethod]
        public void Gutter_game_score_should_be_zero_test()
        {
            IGame game = new Game();
            Roll(game, 0, 20);
            Assert.AreEqual(0, game.GetScore());
        }

        [TestMethod]
        public void Game_score_when_valid_pins_count_should_calculate_positive()
        {
            IGame game = new Game();
            game.Roll(1);
            game.Roll(4);

            game.Roll(5);
            game.Roll(3);

            game.Roll(10);

            game.Roll(4);
            game.Roll(2);

            game.Roll(10);

            game.Roll(3);
            game.Roll(3);

            game.Roll(4);
            game.Roll(3);

            game.Roll(1);
            game.Roll(4);

            game.Roll(10);

            game.Roll(1);
            game.Roll(4);
            Assert.AreEqual(89, game.GetScore());
        }

        [TestMethod]
        public void Game_score_when_10th_frame_have_spare_with_3_chance_should_calculate_positive()
        {
            IGame game = new Game();
            game.Roll(1);
            game.Roll(4);

            game.Roll(5);
            game.Roll(4);

            game.Roll(8);
            game.Roll(2);

            game.Roll(10);

            game.Roll(10);

            game.Roll(3);
            game.Roll(3);

            game.Roll(4);
            game.Roll(3);

            game.Roll(1);
            game.Roll(4);

            game.Roll(10);

            //Last frame have 3 rolls because of spare 
            game.Roll(8);
            game.Roll(2);
            game.Roll(10);
            Assert.AreEqual(131, game.GetScore());
        }

        [TestMethod]
        public void Game_score_when_any_frame_gutter_should_calculate_positive()
        {
            IGame game = new Game();
            game.Roll(1);
            game.Roll(4);

            //gutter frame
            game.Roll(0);
            game.Roll(0);

            game.Roll(8);
            game.Roll(2);

            game.Roll(10);

            game.Roll(10);

            game.Roll(3);
            game.Roll(3);

            game.Roll(4);
            game.Roll(3);

            game.Roll(1);
            game.Roll(4);

            game.Roll(10);

            //Last frame have 3 rolls because of strike 
            game.Roll(10);
            game.Roll(2);
            game.Roll(8);
            Assert.AreEqual(124, game.GetScore());
        }

        [TestMethod]
        public void Game_score_when_all_frame_have_strike_should_calculate_positive()
        {
            IGame game = new Game();
            game.Roll(10);

            game.Roll(10);

            game.Roll(10);

            game.Roll(10);

            game.Roll(10);

            game.Roll(10);

            game.Roll(10);

            game.Roll(10);

            game.Roll(10);

            //Last frame have 3 rolls because of strike 
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            Assert.AreEqual(300, game.GetScore());
        }

        [TestMethod]
        public void Game_score_when_all_frame_have_spare_should_calculate_positive()
        {
            IGame game = new Game();
            game.Roll(6);
            game.Roll(4);

            //gutter frame
            game.Roll(7);
            game.Roll(3);

            game.Roll(8);
            game.Roll(2);

            game.Roll(3);
            game.Roll(7);

            game.Roll(8);
            game.Roll(2);

            game.Roll(8);
            game.Roll(2);

            game.Roll(3);
            game.Roll(7);

            game.Roll(7);
            game.Roll(3);

            game.Roll(1);
            game.Roll(9);

            //Last frame have 3 rolls because of strike 
            game.Roll(2);
            game.Roll(8);
            game.Roll(10);
            Assert.AreEqual(157, game.GetScore());
        }

        private void Roll(IGame game, int pins, int times)
        {
            for (int i = 0; i < times; i++)
            {
                game.Roll(pins);
            }
        }
    }
}
