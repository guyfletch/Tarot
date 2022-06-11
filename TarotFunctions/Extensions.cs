namespace TarotFunctions
{
    public static class Extensions
    {
        public static bool IsNullOrEmpty<T>(this IList<T> list) where T : class
        {
            return list == null || list.Count == 0;
        }
    }
}
