using System;
using Game.Graphics.Sprites;
using Game.Interface.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game.World.Entities
{
    //TODO this class is doing too much
    public class Skeleton : IEntity
    {
        private AnimatedSprite _sprite;
        private TimeSpan _timeSinceLastAnimationUpdate = TimeSpan.MinValue;
        private readonly TimeSpan _animationTime = new TimeSpan(0, 0, 0, 0, 400);
        private Rectangle _collision;


        //for onclick stuff
        public delegate void Click(Skeleton sender);
        public event Click OnClickEvent;
        private MouseState _currentMouseState;
        private MouseState _prevMouseState;

        public Skeleton(string name, Vector2 location)
        {
            Name = name;
            Location = location;
            Direction = GameData.DefaultDirection;
        }

        public void Initialize(ContentManager content)
        {
            var texture = content.Load<Texture2D>(Img);
            _sprite = new AnimatedSprite(texture, 0, 3);
            _collision = new Rectangle((int)Location.X, (int)Location.Y, 24, 32);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _sprite.Draw(spriteBatch, Location, new Rectangle(_sprite.Frame * 24, Direction * 32, 24, 32), 1f, Color);
        }

        public void Update(GameTime gameTime)
        {
            _currentMouseState = Mouse.GetState();

            //check to see if hero has been clicked
            if (_currentMouseState.LeftButton == ButtonState.Released && _prevMouseState.LeftButton == ButtonState.Pressed)
            {
                if (_collision.Contains(_currentMouseState.X, _currentMouseState.Y))
                {
                    OnClick();
                }
            }

            if (gameTime.TotalGameTime > _timeSinceLastAnimationUpdate + _animationTime)
            {
                _sprite.IncrementFrame();

                _timeSinceLastAnimationUpdate = gameTime.TotalGameTime;
            }
            _prevMouseState = _currentMouseState;
        }

        public void OnClick()
        {
            if (OnClickEvent != null)
            {
                OnClickEvent(this);
            }
        }

        public void MoveHorizontal(float amount)
        {
            var adjustment = new Vector2 { X = amount };
            Location += adjustment;

            Direction = amount < 0 ? 3 : 1;
            _collision.X = (int)Location.X;
        }

        public void MoveVertical(float amount)
        {
            var adjustment = new Vector2 { Y = amount };
            Location += adjustment;


            Direction = amount < 0 ? 0 : 2;
            _collision.Y = (int)Location.Y;
        }

        public String Name { get; protected set; }
        public Vector2 Location { get; private set; }
        public int Direction { get; private set; }
        public string Img { get; protected set; }
        public Color Color { get; protected set; }
    }
}
