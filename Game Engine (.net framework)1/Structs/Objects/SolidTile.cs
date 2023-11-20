#region Includes

using SFML.Graphics;
using SFML.System;

#endregion

public class SolidTile : Object
{
    // base
    public Vector2f Size { get; set; }
    public Color Color { get; set; }
    public float Rotation { get; set; }
    public Anchor Anchor { get; set; } = Anchor.TopLeft;

    public string TextureID { get; set; } = null;

    public override void Draw(RenderWindow e)
    {
        Vector2u dim = EngineInstance.Instance.GuiData.Size;

        RectangleShape shape = new RectangleShape();

        if (TextureID != null)
            shape.Texture = TextureHandler.GetTexture(TextureID);
        else shape.FillColor = Color;

        shape.Size = Size;

        shape.Rotation = Rotation;

        // anchor statement
        switch (Anchor)
        {
            case Anchor.TopLeft:
                shape.Position = Position;
                break;

            case Anchor.TopRight:
                shape.Position = new Vector2f(dim.X - Size.X - Position.X, Position.Y);
                break;

            case Anchor.BottomRight:
                shape.Position = new Vector2f(dim.X - Size.X - Position.X, dim.Y - Size.Y - Position.Y);
                break;

            case Anchor.BottomLeft:
                shape.Position = new Vector2f(Position.X, dim.Y - Size.Y - Position.Y);
                break;

            case Anchor.None:
                shape.Position = new Vector2f((dim.X - Size.X) / 2 + Position.X, (dim.Y - Size.Y) / 2 + Position.Y);
                break;
        }

        e.Draw(shape);
    }
}