public class Solution {
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        Dictionary<int, List<int>> Graph = new();
        int[] inDegree = new int[numCourses];
        Queue<int> queue = new();
        int count = 0;
        foreach (var pair in prerequisites) {
            inDegree[pair[0]]++;
            if (!Graph.ContainsKey(pair[1])) {
                Graph.Add(pair[1], new List<int>() { pair[0] });
                continue;
            }
            Graph[pair[1]].Add(pair[0]);
        }
        for (int i = 0; i < numCourses; i++) {
            if (inDegree[i] == 0)
                queue.Enqueue(i);
        }
        while (queue.Count > 0) {
            var course = queue.Dequeue();
            count++;
            if (Graph.ContainsKey(course)) {
                var neighbors = Graph[course];
                foreach (var elem in neighbors) {
                    inDegree[elem]--;
                    if (inDegree[elem] == 0)
                        queue.Enqueue(elem);
                }
            }
        }
        if (count < numCourses)
            return false;
        return true;
    }
}
