public class Solution {
    public int CarFleet(int target, int[] position, int[] speed) {
        Stack<double> stack = new();
        int n = position.Length;
        if (n == 0)
            return 0;
        var cars = position.Select((pos, i) => new { Position = pos, Speed = speed[i] })
                       .OrderByDescending(x => x.Position)
                       .ToList();
        foreach (var car in cars) {
            var time = (double)(target - car.Position) / car.Speed;
            if (stack.Count == 0 || time > stack.Peek()) {
                stack.Push(time);
            }
        }

        return stack.Count();
    }
}
