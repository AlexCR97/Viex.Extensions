namespace Viex.Extensions.Enumerables;

public static class Extensions
{
    public static bool Empty<TSource>(this IEnumerable<TSource> source)
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));
        return !source.Any();
    }

    public static string JoinString<TSource>(this IEnumerable<TSource> source)
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));
        return JoinString(source, "");
    }

    public static string JoinString<TSource>(this IEnumerable<TSource> source, char separator)
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));
        var str = string.Join(separator, source);
        return str;
    }

    public static string JoinString<TSource>(this IEnumerable<TSource> source, string separator)
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(separator, nameof(separator));
        var str = string.Join(separator, source);
        return str;
    }

    public static async Task<IEnumerable<TResult>> SelectAsync<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, Task<TResult>> task)
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(task, nameof(task));

        var mappedResults = new List<TResult>();
        
        foreach (var item in source)
        {
            var mappedResult = await task(item);
            mappedResults.Add(mappedResult);
        }

        return mappedResults;
    }

    public static async Task<List<TSource>> ToListAsync<TSource>(this Task<IEnumerable<TSource>> source)
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));
        var result = await source;
        return result.ToList();
    }

    public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> source)
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));
        return source.Select((item, index) => (item, index));
    }
}
