#region Includes

using System.Collections.Generic;

using SFML.Graphics;
using SFML.System;

#endregion

internal class Object
{
    // base
    public Vector2f Position;

    public virtual void Draw(RenderWindow e) { }
}