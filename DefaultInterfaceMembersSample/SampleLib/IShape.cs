﻿namespace SampleLib
{
    public interface IPosition
    {
        int X { get; set; }
        int Y { get; set; }
    }

    public interface IShape
    {
        IPosition Position { get; set; }

        // IPosition Move(IPosition newPosition);

        public IPosition Move(IPosition newPosition)
        {
            Position.X = newPosition.X;
            Position.Y = newPosition.Y;
            return Position;
        }
    }
}
