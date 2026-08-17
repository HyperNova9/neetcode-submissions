public class Solution {
    public string Encode(IList<string> strs) {
        var enc_str = "";

        foreach (var str in strs)
        {
            enc_str += $"{str.Length}:";
            enc_str += str;
        }
        return enc_str;
    }

    public List<string> Decode(string s) {
     List<string> strs = new();
     for (int i = 0; i < s.Length; i++)
     {
        if (char.IsDigit(s[i]))
        {
            int j = i, count = -1, len = 0;
            while (s[j] != ':')
            {
            count++;
              j++;
            }
            var shift = count+1;
            //Console.WriteLine(count);
//Console.WriteLine(s[i]);
            while (s[i] != ':')
            {
                int num = int.Parse(s[i].ToString());
                len += (int)Math.Pow(10, count) * num;
                //Console.WriteLine(num);
                count--;
                i++;

            }
            //Console.WriteLine(s);
//Console.WriteLine(len);
            var sub =   s.Substring(i+1, len);
            //Console.WriteLine(len);
            i+=len;
            strs.Add(sub);
        }
     }
     return strs;
   }
}
