using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static partial class Utils
{
    /// <summary>
    /// Allows to write foreach loops with indexes.
    /// <example>
    /// How to use:
    /// <code>foreach (var (item, index) in list.WithIndex()) { instructions }</code>
    /// </example>
    /// </summary>
    /// <returns>The same Enumerable with (item, index) values.</returns>
    public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> self)
    {
        return self.Select((item, index) => (item, index));
    }

    /// <summary>
    /// Repeats an action a given number of times.
    /// The index goes from 0 to number - 1.
    /// <example>
    /// How to use:
    /// <code>Repeat(6, (index) => { instructions })</code>
    /// </example>
    /// </summary>
    /// <param name="count">Number of times the action will be repeated.</param>
    /// <param name="action">The action to repeat that takes the parameter "index" starting at 0.</param>
    public static void Repeat(int count, System.Action<int> action)
    {
        for (int i = 0; i < count; i++)
        {
            action(i);
        }
    }
}
