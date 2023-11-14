#region Includes

using SFML.System;

#endregion

internal class GuiData
{
    public float Rate { get; set; }

    public Vector2u Size { get; set; }

    public float DeltaTime { get; set; }
    public long DeltaTime_M { get; set; }
}