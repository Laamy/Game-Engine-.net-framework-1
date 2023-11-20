using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;
using System.Windows.Forms;

internal class TextureHandler
{
    public static Vector2u Tile = new Vector2u(24, 24);

    private static Dictionary<string, Texture> _textures = new Dictionary<string, Texture>();

    // cache textures
    internal static Texture GetTexture(string textureID)
    {
        if (_textures.ContainsKey(textureID))
            return _textures[textureID];
        else
        {
            _textures.Add(textureID, new Texture($"{Application.StartupPath}\\{textureID}"));
            return _textures[textureID];
        }
    }
}