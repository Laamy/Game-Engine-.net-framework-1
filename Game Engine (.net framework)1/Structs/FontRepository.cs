#region Includes

using System.Collections.Generic;

using SFML.Graphics;

#endregion

public class FontRepository
{
    private static Dictionary<string, Font> _fonts = new Dictionary<string, Font>()
    {
        { "arial", new Font("Data\\Font\\Arial.ttf") }
    };

    public Font GetFont(string name) => _fonts[name.ToLower()];
}