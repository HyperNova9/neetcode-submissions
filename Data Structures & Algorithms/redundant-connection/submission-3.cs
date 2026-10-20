public class Solution {
    public int[] FindRedundantConnection(int[][] edges) {
        var comps = new int[edges.Length + 1];
        Array.Fill(comps, -1);
        // Формирование неориентированного графа
        foreach (var edge in edges) {
            var root_0 = edge[0];
            var root_1 = edge[1];
            if (comps[edge[0]] == -1 && comps[edge[1]] != -1) {
                comps[edge[0]] = edge[1];
            } else if (comps[edge[1]] == -1 && comps[edge[0]] != -1) {
                comps[edge[1]] = edge[0];
            } else if (comps[edge[1]] != -1 && comps[edge[0]] != -1) {
                while (root_0 != comps[root_0]) root_0 = comps[root_0];
                while (root_1 != comps[root_1]) root_1 = comps[root_1];
                if (root_0 == root_1)
                    return edge;
                comps[root_0] = root_1;
            } else {
                comps[edge[0]] = edge[0];
                comps[edge[1]] = edge[0];
            }
        }
        return new int[] {};
    }
}
