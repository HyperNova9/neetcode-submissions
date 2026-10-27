public class Solution {
    public List<string> FindItinerary(List<List<string>> tickets) {
        List<string> fullWay = new();
        var Graph = new Dictionary<string, List<string>>();
        foreach (var t in tickets) {
            for (int i = 0; i <= 1; i++) {
                if (!Graph.ContainsKey(t[i])) {
                    Graph.Add(t[i], new());
                }
            }
            Graph[t[0]].Add(t[1]);
        }
        foreach (var city in Graph.Keys) {
            Graph[city].Sort((a, b) => StringComparer.Ordinal.Compare(b, a));
        }
        var DFS = new Stack<string>();
        DFS.Push("JFK");
        var Route = new Stack<string>();

        while (DFS.Count > 0) {
            var person = DFS.Peek();
            if (Graph[person].Count == 0) {
                Route.Push(person);
                DFS.Pop();
                continue;
            }
            int len = Graph[person].Count;
            DFS.Push(Graph[person][len - 1]);
            Graph[person].RemoveAt(len - 1);
        }
        foreach (var person in Graph.Values) {
            if (person.Count > 0)
                return new();
        }
        while (Route.Count > 0) {
            fullWay.Add(Route.Pop());
        }

        return fullWay;
    }
}
