#region Includes

using SFML.System;
using SFML.Window;
using System;

#endregion

internal class SolidObjectMovementProxy : IUpdateable
{
    private EngineInstance Instance = EngineInstance.Instance;
    private readonly SolidObject Proxied;
    private float Speed = 1;

    private const int OffsetFactor = 100000;

    public static Vector2f Up = new Vector2f(0, -1);
    public static Vector2f Left = new Vector2f(-1, 0);
    public static Vector2f Right = new Vector2f(1, 0);
    public static Vector2f Down = new Vector2f(0, 1);

    public SolidObjectMovementProxy(SolidObject player)
    {
        Proxied = player;
    }

    public void Move(float X, float Y)
    {
        Vector2f newPos = Proxied.Position + new Vector2f(X, Y);

        if (!CheckCollisions(newPos))
        {
            Proxied.Position = newPos;
        }
    }
    public void Move(Vector2f movement) => Move(movement.X, movement.Y);

    public void SetSpeed(float speed) => Speed = speed;
    public float GetSpeed() => Speed;

    public void Update(float deltaTime)
    {
        // Adjust the player's position based on input
        // TODO: movement vectors
        if (Keyboard.IsKeyPressed(Keyboard.Key.W))
            Move(Up * Speed * OffsetFactor * deltaTime);

        if (Keyboard.IsKeyPressed(Keyboard.Key.A))
            Move(Left * Speed * OffsetFactor * deltaTime);

        if (Keyboard.IsKeyPressed(Keyboard.Key.S))
            Move(Down * Speed * OffsetFactor * deltaTime);

        if (Keyboard.IsKeyPressed(Keyboard.Key.D))
            Move(Right * Speed * OffsetFactor * deltaTime);
    }

    private bool CheckCollisions(Vector2f newPos)
    {
        foreach (var levelObj in Instance.Level.children)
        {
            // handle each object by themselves (this is why its not in the engine its self yet..)
            if (!(levelObj is SolidObject)) // not solid object
                continue;

            if (levelObj == Proxied) // current object is our proxied object
                continue;

            SolidObject solid = (SolidObject)levelObj;

            // collision test
            if (newPos.Y < solid.Position.Y + solid.Size.Y &&
                    newPos.Y + Proxied.Size.Y > solid.Position.Y &&
                    newPos.X < solid.Position.X + solid.Size.X &&
                    newPos.X + Proxied.Size.X > solid.Position.X)
                return true;
        }

        return false; // no collision
    }
}