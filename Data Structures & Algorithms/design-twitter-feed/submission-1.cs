public class Twitter {
    Dictionary<int, HashSet<int>> UserAndFollows;
    Dictionary<int, List<(int id, int priority)>> UserPosts;
    int max_id = 1;
    public Twitter() {
        UserAndFollows = new();
        UserPosts = new();
    }
    public void InitOrCheckUser(int userId) {
        if (!UserAndFollows.ContainsKey(userId))
            UserAndFollows.Add(userId, new());

        if (!UserPosts.ContainsKey(userId))
            UserPosts.Add(userId, new());
    }
    public void PostTweet(int userId, int tweetId) {
        InitOrCheckUser(userId);
        UserPosts[userId].Add((tweetId, max_id));
        max_id++;
    }
    public List<int> GetNewsFeed(int userId) {
        InitOrCheckUser(userId);
        PriorityQueue<int, int> LastNewsHeap = new(Comparer<int>.Create((x, y) => y.CompareTo(x)));
        List<int> lastNews = new();
        var userFollows = UserAndFollows[userId];
        int step = 0;
        while (step < 10) {
            var o = UserPosts[userId].Count - 1 - step;
        if (o >= 0)    LastNewsHeap.Enqueue(UserPosts[userId][o].id, UserPosts[userId][o].priority);
            foreach (var followee in userFollows) {
                var i = UserPosts[followee].Count - 1 - step;
                if (i < 0)
                    continue;
                var iPost = UserPosts[followee][i];
                LastNewsHeap.Enqueue(iPost.id, iPost.priority);
            }
            step++;
        }
        while (LastNewsHeap.Count > 0 && lastNews.Count < 10) {
            lastNews.Add(LastNewsHeap.Peek());
            LastNewsHeap.Dequeue();
        }
        return lastNews;
    }

    public void Follow(int followerId, int followeeId) {
        InitOrCheckUser(followerId);
        InitOrCheckUser(followeeId);
        var userFollower = UserAndFollows[followerId];
        if (!userFollower.Contains(followeeId))
            userFollower.Add(followeeId);
    }

    public void Unfollow(int followerId, int followeeId) {
        InitOrCheckUser(followerId);
        InitOrCheckUser(followeeId);
        var userFollower = UserAndFollows[followerId];
        if (userFollower.Contains(followeeId))
            userFollower.Remove(followeeId);
    }
}
