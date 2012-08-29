using System;
using Game.Graphics.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Entities
{
    public class Player : Character
    {
        private AnimatedSprite _sprite;
        private  TimeSpan _timeSinceLastUpdate = TimeSpan.MinValue;
        private readonly TimeSpan _animationTime = new TimeSpan(0,0,0,0,150);

        public Player(string name, int id, Vector2 location) : base(name, id, location)
        {
            Moving = false;
            Direction = GameData.DefaultDirection;
        }

        public void Initialize(ContentManager content)
        {
            var texture = content.Load<Texture2D>("player");
            _sprite = new AnimatedSprite(texture,0, 2);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _sprite.Draw(spriteBatch, Location, new Rectangle(_sprite.Frame * 24, Direction * 32, 24, 32), 1f);
        }

        public override void Update(GameTime gameTime)
        {
            if (Moving)
            {
                if (gameTime.TotalGameTime > _timeSinceLastUpdate + _animationTime)
                {
                    _sprite.IncrementFrame();

                    if (_sprite.Frame == 0)
                    {
                        Moving = false;
                    }

                    _timeSinceLastUpdate = gameTime.TotalGameTime;
                }
            }
        }
    }
}
