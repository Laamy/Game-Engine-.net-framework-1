#region Includes

using System.Collections.Generic;

using SFML.Graphics;
using SFML.System;

#endregion

public class SolidObject : Object
{
    // base
    public Vector2f Size { get; set; }
    public Color Color { get; set; }
    public float Rotation { get; set; }
    public Anchor Anchor { get; set; } = Anchor.TopLeft;

    public override void Draw(RenderWindow e)
    {
        Vector2u dim = EngineInstance.Instance.GuiData.Size;

        RectangleShape shape = new RectangleShape(Size);

        shape.FillColor = Color;
        shape.Rotation = Rotation;

        // anchor statement
        switch (Anchor)
        {
            case Anchor.TopLeft:
                shape.Position = Position;
                break;

            case Anchor.TopRight:
                shape.Position = new Vector2f(dim.X - shape.Size.X - Position.X, Position.Y);
                break;

            case Anchor.BottomRight:
                shape.Position = new Vector2f(dim.X - shape.Size.X - Position.X, dim.Y - shape.Size.Y - Position.Y);
                break;

            case Anchor.BottomLeft:
                shape.Position = new Vector2f(Position.X, dim.Y - shape.Size.Y - Position.Y);
                break;

            case Anchor.None:
                shape.Position = new Vector2f((dim.X - shape.Size.X) / 2 + Position.X, (dim.Y - shape.Size.Y) / 2 + Position.Y);
                break;
        }

        e.Draw(shape);
    }
}