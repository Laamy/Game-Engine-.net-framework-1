#region Includes

using System.Collections.Generic;
using System.Management.Instrumentation;
using SFML.Graphics;
using SFML.System;

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
        EngineInstance instance = EngineInstance.Instance;

        Vector2u dims = instance.GuiData.Size;

        // loop over the scene and draw dumbass
        for (int i = 0; i < children.Count; ++i) 
        {
            Object child = children[i];

            if (child.Position.X > dims.X || child.Position.Y > dims.Y)
                continue;

            child.Draw(e);
        }
    }
}