public class Solution 
{
    public List<List<int>> ThreeSum(int[] nums) 
    {
        var n = nums.Length;
        var list_nums = nums.ToList().OrderBy(x => x).ToList();
        var res = new List<List<int>>();
        for (int i = 0; i < n-2; i++)
        {
            int l = i+1, r = n - 1;
            var a = list_nums[i];
            if (i >= 1)
                if (list_nums[i] == list_nums[i-1])
                {
                    continue;
                }
            while (l < r)
            {
                int left = list_nums[l], right = list_nums[r];
                var sum = a + left + right;
                if (sum > 0)
                    r--;
                else if (sum < 0)
                    l++;
                else
                {
                    var list = new List<int>();
                    list.Add(a); list.Add(left); list.Add(right);
                    res.Add(list);
                    l++;
                    r--;
                    while (list_nums[l] == left && l < r)
                        l++;  
                } 
            }
        }
        return res;
    }
}
