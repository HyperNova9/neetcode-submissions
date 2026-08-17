public class Solution {
    public bool IsValidSudoku(char[][] board) {
        int n = board.Length;
        //xy - rotation
        for (int i = 0; i < 9; i++)
        {
            var x = new List<int>();
            var y = new List<int>();
           for (int j = 0; j < 9; j++)
           {
            char elem_x = board[j][i], elem_y = board[i][j];
            if (elem_x != '.')          x.Add(int.Parse(elem_x.ToString()));
            if (elem_y != '.')
y.Add(int.Parse(elem_y.ToString()));
           }
        if (x.Count() != x.Distinct().Count() || y.Count() != y.Distinct().Count())
            return false;
        }

        for (int i = 0; i < n; i+=3)
        {
        for (int j = 0; j < n; j+=3)
        {
        var cube = new List<int>();
           for (int k = 0; k <= 2; k++)
           {
              for (int s = 0; s <= 2; s++)
              {
                int value = -1;
                if (!int.TryParse(board[i+k][j+s].ToString(), out value))
                {
                    value = -1;
                }
                if (value != -1)              cube.Add(value);  
              }
           } 
           if (cube.Count() != cube.Distinct().Count())
           return false;       
        }
        }
        return true;

    }
}
