#region Includes

using System.Collections.Generic;

using SFML.Graphics;

#endregion

public class Level
{
    public List<Object> children = new List<Object>();

    public List<Object> GetTag(string tag)
    {
        List<Object> objects = new List<Object>();

        foreach (Object obj in children)
        {
            if (obj.Tags.Contains(tag))
            {
                objects.Add(obj);
            }
        }

        return objects;
    }

    public void Draw(RenderWindow e)
    {
        // loop over the scene and draw u fuckign retard
        foreach (Object child in children)
        {
            child.Draw(e);
        }
    }
}