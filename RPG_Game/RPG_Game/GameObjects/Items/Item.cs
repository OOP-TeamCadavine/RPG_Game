﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RPG_Game.Interfaces;

namespace RPG_Game.GameObjects.Items
{
    public abstract class Item : IGameObject
    {
        protected Item(Point position)
        {
            this.Position = position;
        }

        public Point Position { get; set; }

        public abstract void Draw(SpriteBatch spriteBatch, GameTime gameTime);

        public abstract void Update(GameTime gameTime);
    }
}
