public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) 
    {
        if (nums.Length == 0)
            return nums;
        int n = nums.Length, l = 0, 
        r = l + k - 1 >= n ? n - 1 : l + k - 1;
        var n_win = new List<int>();
        var max_list = new List<int>();
        n_win.Add(0);
        //Windows form
        for (int i = 0; i <= r; i++)
        {
            while(nums[i] >= nums[n_win.Last()])
            {
                var win_n = n_win.Count();
                n_win.RemoveAt(win_n - 1);
                if (n_win.Count == 0) break;
            }
            n_win.Add(i);
        }
        max_list.Add(nums[n_win.FirstOrDefault()]);
        //Windows move and correct queue
        while (r < n)
        {
            r++;
            l++;
            if (n_win[0] < l) n_win.RemoveAt(0);
            if (r == n) break;
            var count = 0;
            if (n_win.Count > 0)
                while (nums[r] >= nums[n_win.Last()])
                {
                    count++;
                    var win_n = n_win.Count();
                    n_win.RemoveAt(win_n - 1);
                    if (n_win.Count == 0) break;
                }
            n_win.Add(r);
            max_list.Add(nums[n_win.First()]);
        }
        return max_list.ToArray();
    }
}
