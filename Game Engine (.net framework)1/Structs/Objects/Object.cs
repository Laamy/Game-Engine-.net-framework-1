#region Includes

using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;

#endregion

internal class Object
{
    // base
    public Vector2f Position { get; set; }
    public List<string> Tags { get; set; } = new List<string>();

    public virtual void Draw(RenderWindow e) { }
}