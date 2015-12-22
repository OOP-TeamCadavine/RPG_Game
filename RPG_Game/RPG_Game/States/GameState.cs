﻿using System.Linq;
using System.Net;
using RPG_Game.Core;
using RPG_Game.GameObjects.Characters.Enemy;
using RPG_Game.GameObjects.Items;

namespace RPG_Game.States
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;    
    using Microsoft.Xna.Framework.Graphics;

    using Interfaces;

    using GameObjects.Characters.Player;

    public class GameState : State
    {
        public static Player player;
        private readonly string playerName;
        private List<IGameObject> entities;
        private PlayerController playerController;
        private CollisionHandler collisionHandler;
        private string health = string.Empty;
        private string killedDragons = string.Empty;
        private string experience = string.Empty;

        Rectangle toolbarArea = new Rectangle(200,500,750,350);

        public GameState(string playerName, MapInitializer mapInitializer, PlayerController playerController, CollisionHandler collisionHandler)
        {
            this.playerName = playerName;
            player = new Archangel(new Position(0, 0), playerName);
            this.playerController = playerController;
            this.collisionHandler = collisionHandler;
            entities = mapInitializer.PopulateMap();
        }


        public override void Update(GameTime gameTime)
        {
            playerController.HandleInput();
            collisionHandler.HandleCollisions(player, entities);
            foreach (var entity in entities)
            {
                entity.Update(gameTime);
            }
            this.entities.RemoveAll(x => !x.Exists);
            player.Update(gameTime);
            if (!player.Exists)
            {
                StateManager.CurrentState = new GameOverState();
            }

            IList<IGameObject> items = entities.Where(i => i is Item).ToList();
            IList<IGameObject> enemies = entities.Where(i => i is Enemy).ToList();

            if (items.Count == 0)
            {
                MapInitializer.GenerateItems(entities);
            }
            if (enemies.Count == 0)
            {
                MapInitializer.GenerateEnemies(entities);
            }

            this.health = player.HealthPoints.ToString();
            this.killedDragons = player.DragonsKilled.ToString();
            this.experience = player.Experience.ToString();

        }
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(Assets.gameBackground, Vector2.Zero);     
            spriteBatch.Draw(Assets.toolbar,toolbarArea,Color.White);
            spriteBatch.DrawString(Assets.health, health, new Vector2(310,660), Color.White);
            spriteBatch.DrawString(Assets.experience, experience, new Vector2(570, 660), Color.White);
            spriteBatch.DrawString(Assets.dragonsKilled, killedDragons, new Vector2(790, 660), Color.White);

            foreach (var entity in entities)
            {                
                entity.Draw(spriteBatch, gameTime);
            }

            player.Draw(spriteBatch, gameTime);

            spriteBatch.End();
        }
    }
}
