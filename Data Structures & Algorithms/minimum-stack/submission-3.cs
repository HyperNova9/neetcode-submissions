public class MinStack 
{

    Stack<int> stack;
    List<int> min;
    public MinStack() 
    {
        stack = new();
        min = new();
    }
    
    public void Push(int val) 
    {
        if (stack.Count > 0)
        {
            stack.Push(val);
            if (val <= min.Last())
            {
                min.Add(val);
            }
        }
        else
        {
            stack.Push(val);
            min.Add(val);
        }
        
    }
    
    public void Pop() 
    {
        if (stack.Count > 0)
        {
            if (min.Last() == stack.Peek())
                min.RemoveAt(min.Count - 1); 
            stack.Pop();
        }
        
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
            return min.Last();
        else
            return min.LastOrDefault();
    }
}
