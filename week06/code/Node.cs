public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1

        // Base Case: If the value is a duplicate, exit
        if (value == Data)
            return;

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2

        // Base Case: If the value is found, return 'true'
        if (value == Data)
            return true;

        if (value < Data)
        {
            // Check to the left
            if (Left is not null)
                return Left.Contains(value);
        }
        else
        {
            // Check to the right
            if (Right is not null)
                return Right.Contains(value);
        }

        return false;
    }

    public int GetHeight()
    {
        // TODO Start Problem 4

        // Base Case: return 1 when a leaf is reached (Left and Right are null).
        if (Left is null && Right is null)
            return 1;

        if (Left is null && Right is not null)
        {
            return Right.GetHeight() + 1;
        }
        if (Right is null && Left is not null)
        {
            return Left.GetHeight() + 1;
        }

        return 1 + Math.Max(Left!.GetHeight(), Right!.GetHeight());
        //return 0; // replace.
    }
}