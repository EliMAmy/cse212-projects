/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.  
///
/// If there is a wall, then throw an InvalidOperationException with the message "Can't go that way!".  If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>
public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    // TODO Problem 4 - ADD YOUR CODE HERE
    /// <summary>
    /// Check to see if you can move left.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveLeft()
    {
        // here we need to check if we can move left by checking the first element of the boolean array in the dictionary for the current position. 
        bool[] directions = _mazeMap[(_currX, _currY)];
        // if the first element is false, then we throw an InvalidOperationException with the message "Can't go that way!"
        if (!directions[0])
        {
            throw new InvalidOperationException("Can't go that way!");
        }
        // if the first element is true, then we can move left by decrementing the current x position
        _currX--;
    }

    /// <summary>
    /// Check to see if you can move right.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveRight()
    {
        // here we need to check if we can move right by checking the second element of the boolean array in the dictionary for the current position.
        bool[] directions = _mazeMap[(_currX, _currY)];
        // if the second element is false, then we throw an InvalidOperationException with the message "Can't go that way!"
        if (!directions[1])
        {
            throw new InvalidOperationException("Can't go that way!");
        }
        // if the second element is true, then we can move right by incrementing the current x position
        _currX++;
    }

    /// <summary>
    /// Check to see if you can move up.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveUp()
    {
        // here we need to check if we can move up by checking the third element of the boolean array in the dictionary for the current position.
        bool[] directions = _mazeMap[(_currX, _currY)];
        // if the third element is false, then we throw an InvalidOperationException with the message "Can't go that way!"
        if (!directions[2])
        {
            throw new InvalidOperationException("Can't go that way!");
        }
        // if the third element is true, then we can move up by decrementing the current y position
        _currY--;
    }

    /// <summary>
    /// Check to see if you can move down.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveDown()
    {
        // here we need to check if we can move down by checking the fourth element of the boolean array in the dictionary for the current position.
        bool[] directions = _mazeMap[(_currX, _currY)];
        // if the fourth element is false, then we throw an InvalidOperationException with the message "Can't go that way!"
        if (!directions[3])
        {
            throw new InvalidOperationException("Can't go that way!");
        }
        // if the fourth element is true, then we can move down by incrementing the current y positionn
        _currY++;
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}