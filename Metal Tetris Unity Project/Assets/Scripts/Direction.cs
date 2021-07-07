public static class Direction
{
    public enum Facing { Up,Right,Down,Left}

    public static Facing RotateRight(Facing facing)
    {
        switch (facing)
        {
            case Facing.Up:
                return Facing.Right;
            case Facing.Right:
                return Facing.Down;
            case Facing.Down:
                return Facing.Left;
            case Facing.Left:
                return Facing.Up;
            default:
                return Facing.Up;
        }
    }

    public static Facing RotateLeft(Facing facing)
    {
        switch (facing)
        {
            case Facing.Up:
                return Facing.Left;
            case Facing.Right:
                return Facing.Up;
            case Facing.Down:
                return Facing.Right;
            case Facing.Left:
                return Facing.Down;
            default:
                return Facing.Up;
        }
    }
}
