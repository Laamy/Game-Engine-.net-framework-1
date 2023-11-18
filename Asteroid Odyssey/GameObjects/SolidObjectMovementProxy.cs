#region Includes

using SFML.System;
using SFML.Window;

#endregion

internal class SolidObjectMovementProxy : IUpdateable
{
    private readonly SolidObject proxied;
    private float speed = 1;

    private const int OffsetFactor = 100000;

    public static Vector2f Up = new Vector2f(0, -1);
    public static Vector2f Left = new Vector2f(-1, 0);
    public static Vector2f Right = new Vector2f(1, 0);
    public static Vector2f Down = new Vector2f(0, 1);

    public SolidObjectMovementProxy(SolidObject player)
    {
        proxied = player;
    }

    public void Move(float X, float Y) => proxied.Position += new Vector2f(X, Y);
    public void Move(Vector2f movement) => Move(movement.X, movement.Y);

    public void Update(float deltaTime)
    {
        // Adjust the player's position based on input
        // TODO: movement vectors
        if (Keyboard.IsKeyPressed(Keyboard.Key.W))
            Move(Up * speed * OffsetFactor * deltaTime);

        if (Keyboard.IsKeyPressed(Keyboard.Key.A))
            Move(Left * speed * OffsetFactor * deltaTime);

        if (Keyboard.IsKeyPressed(Keyboard.Key.S))
            Move(Down * speed * OffsetFactor * deltaTime);

        if (Keyboard.IsKeyPressed(Keyboard.Key.D))
            Move(Right * speed * OffsetFactor * deltaTime);
    }
}