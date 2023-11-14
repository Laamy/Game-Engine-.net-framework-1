#region Includes

using System.Collections.Generic;

using SFML.Graphics;

#endregion

internal class Level
{
    public List<Object> children = new List<Object>();

    public void Draw(RenderWindow e)
    {
        // loop over the scene and draw u fuckign retard
        foreach (Object child in children)
        {
            child.Draw(e);
        }
    }
}