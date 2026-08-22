public class MinStack 
{

    Stack<int> stack;
    public MinStack() 
    {
        stack = new();
    }
    
    public void Push(int val) 
    {
        stack.Push(val);
    }
    
    public void Pop() 
    {
        if (stack.Count > 0)
            stack.Pop();
    }
    
    public int Top() 
    {
        if (stack.Count > 0)
            return stack.Peek();
        else   
            return stack.FirstOrDefault();
    }
    
    public int GetMin() 
    {
        if (stack.Count > 0)
            return stack.Min();
        else
            return stack.FirstOrDefault();
    }
}
