using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

