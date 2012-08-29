using Microsoft.Xna.Framework;

namespace Game.Entities
{
    interface IMoveable
    {
        void MoveRight(float amount);
        void MoveDown(float amount);
        int Direction { get; }
        bool Moving { get; }
    }
}