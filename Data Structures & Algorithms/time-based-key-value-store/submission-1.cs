public class TimeMap {
    Dictionary<string, List<(int timestamp, string value)>> Map;
    public TimeMap() {
        Map = new();
    }

    public void Set(string key, string value, int timestamp) {
        if (!Map.ContainsKey(key))
            Map.Add(key, new());
        var n = Map[key].Count;
        int l = 0, r = n - 1;
        while (l <= r) {
            int mid = (l + r) / 2;
            var mid_timestamp = Map[key][mid].timestamp;
            if (mid_timestamp == timestamp)
                Map[key][mid] = (mid_timestamp, value);
            else if (mid_timestamp < timestamp)
                l = l + 1;
            else
                r = r - 1;
        }
        Map[key].Insert(l, (timestamp, value));
    }

    public string Get(string key, int timestamp) {
        if (Map.ContainsKey(key)) {
            var n = Map[key].Count;
            var max_elem = Map[key][n - 1];
            var _list = Map[key];
            int l = 0, r = n - 1;
            while (l <= r) {
                int mid = (l + r) / 2;
                if (_list[mid].timestamp <= timestamp)
                    l = mid + 1;
                else
                    r = mid - 1;
            }
            if (r == -1)
                return "";
            // Console.WriteLine(l < r ? _list[l].value : _list[r].value);
            return l < r ? _list[l].value : _list[r].value;

        } else
            return "";
    }
}
