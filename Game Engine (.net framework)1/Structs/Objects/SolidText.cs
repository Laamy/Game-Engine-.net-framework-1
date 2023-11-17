using SFML.Graphics;
using SFML.System;

public class SolidText : Object
{
    public Color Color { get; set; }
    public string Text { get; set; }
    public Font Font { get; set; }
    public uint Size { get; set; }
    public float Rotation { get; set; }
    public Anchor Anchor { get; set; } = Anchor.TopLeft;

    public override void Draw(RenderWindow e)
    {
        Vector2u dim = EngineInstance.Instance.GuiData.Size;

        Text text = new Text(Text, Font, Size);

        text.FillColor = Color;
        text.Rotation = Rotation;

        // anchor statement
        switch (Anchor)
        {
            case Anchor.TopLeft:
                text.Position = Position;
                break;

            case Anchor.TopRight:
                text.Position = new Vector2f(dim.X - text.GetGlobalBounds().Width - Position.X, Position.Y);
                break;

            case Anchor.BottomRight:
                text.Position = new Vector2f(dim.X - text.GetGlobalBounds().Width - Position.X, dim.Y - text.GetGlobalBounds().Height - Position.Y);
                break;

            case Anchor.BottomLeft:
                text.Position = new Vector2f(Position.X, dim.Y - text.GetGlobalBounds().Height - Position.Y);
                break;

            case Anchor.None:
                text.Position = new Vector2f((dim.X - text.GetGlobalBounds().Width) / 2 - Position.Y, (dim.Y - text.GetGlobalBounds().Height) / 2 - Position.Y);
                break;
        }

        e.Draw(text);
    }
}