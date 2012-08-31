using System;
using Microsoft.Xna.Framework;

namespace Game.Entities
{
    public interface IEntity
    {
        String Name { get; }
        int Id { get; }
        Vector2 Location { get; }

    }
}

