﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG_Game
{
    public static class Assets
    {
        public static Texture2D gameBackground;
        public static Texture2D archangelFly;
        public static Texture2D archangelFlyLeft;
        public static Texture2D archangel;
        public static Texture2D pill;
        public static Texture2D healthPotion;
        public static Texture2D cloak;
        public static Texture2D shield;
        public static Texture2D mainMenuImage;
        public static Texture2D buttonPlay;
        public static Texture2D buttonScore;
        public static Texture2D buttonExit;


        public static void Init(Game1 game)
        {
            gameBackground = game.Content.Load<Texture2D>("background");
            archangelFly = game.Content.Load<Texture2D>("fly");
            archangelFlyLeft = game.Content.Load<Texture2D>("flyleft");
            archangel = game.Content.Load<Texture2D>("arhangel");
            pill = game.Content.Load<Texture2D>("pill");
            healthPotion = game.Content.Load<Texture2D>("healthPotion");
            cloak = game.Content.Load<Texture2D>("cloak");
            shield = game.Content.Load<Texture2D>("shield");
            mainMenuImage = game.Content.Load<Texture2D>("DragonsEmpire");
            buttonPlay = game.Content.Load<Texture2D>("buttonPlay");
            buttonScore = game.Content.Load<Texture2D>("buttonScore");
            buttonExit = game.Content.Load<Texture2D>("buttonExit");
        }
    }
}
