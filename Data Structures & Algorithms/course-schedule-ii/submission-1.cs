public class Solution {
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        Dictionary<int, List<int>> Graph = new();
        int[] inDegree = new int[numCourses];
        Stack<int> FreeNodes = new();
        int count = 0;
        List<int> courses_list = new();
        foreach (var pair in prerequisites) {
            inDegree[pair[0]]++;
            if (!Graph.ContainsKey(pair[1])) {
                Graph.Add(pair[1], new List<int>() { pair[0] });
                continue;
            }
            Graph[pair[1]].Add(pair[0]);
        }
        for (int i = numCourses - 1; i >= 0; i--) {
            if (inDegree[i] == 0) {
                FreeNodes.Push(i);
            }
        }
        while (FreeNodes.Count > 0) {
            var course = FreeNodes.Pop();
            courses_list.Add(course);
            count++;
            if (Graph.ContainsKey(course)) {
                var neighbors = Graph[course];
                foreach (var elem in neighbors) {
                    inDegree[elem]--;
                    if (inDegree[elem] == 0)
                        FreeNodes.Push(elem);
                }
            }
        }
        if (count < numCourses)
            return new int[] {};

        return courses_list.ToArray();
    }
}
