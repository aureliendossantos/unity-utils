using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public static partial class Utils
{
    /// <summary>
    /// Returns a random index. The higher the weight of the index, the more likely it is to be chosen.
    /// </summary>
    public static int GetWeightedRandomIndex(List<int> weights)
    {
        int randomNumber = UnityEngine.Random.Range(1, weights.Sum() + 1);
        int cumulativeWeight = 0;
        foreach (var (weight, index) in weights.WithIndex())
        {
            cumulativeWeight += weight;
            if (randomNumber <= cumulativeWeight)
            {
                // Debug.Log($"Random number was {randomNumber}/{weights.Sum()}, chose target {index}");
                return index;
            }
        }
        return 0;
    }

    /// <summary>
    /// Inverts weights used in randomized calculations. For example the list 2, 5, 9, 6 becomes 9, 6, 2, 5.
    /// The weights can be any positive number.
    /// </summary>
    /// <returns></returns>
    public static List<int> InvertWeights(List<int> weights)
    {
        int baseNumber = weights.Min() + weights.Max();
        return weights.Select(weight => baseNumber - weight).ToList();
    }
}
