using Microsoft.Xna.Framework;

namespace Game.Entities
{
    public class Character : IEntity, IMoveable
    {
        public Character(string name, int id, Vector2 location)
        {
            Name = name;
            Id = id;
            Location = location;
            Direction = GameData.DefaultDirection;
        }

        public virtual void Update(GameTime gameTime) { }

        public void MoveRight(float amount)
        {
            var adjustment = new Vector2 {X = amount};
            Location += adjustment;

            Direction = amount < 0 ? 3 : 1;

            Moving = true;
        }

        public void MoveDown(float amount)
        {
            var adjustment = new Vector2 { Y = amount };
            Location += adjustment;
            Direction = amount < 0 ? 0 : 2;
            Moving = true;
        }

        public int Direction { get; protected set; }
        public bool Moving { get; protected set; }
        public string Name { get; private set; }
        public int Id { get; private set; }
        public Vector2 Location { get;  set; }
    }


}
