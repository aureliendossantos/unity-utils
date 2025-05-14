using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public static partial class Utils
{
    /// <summary>
    /// Get a random element from a list.
    /// </summary>
    /// <param name="list">The list to pick from.</param>
    /// <typeparam name="T">Type of the list elements.</typeparam>
    /// <returns>A random element from the list.</returns>
    public static T RandomElement<T>(List<T> list)
    {
        return list[Random.Range(0, list.Count)];
    }

    /// <summary>
    /// Changes the opacity of all corners of a VertexGradient at once.
    /// </summary>
    public static VertexGradient ChangeVertexGradientOpacity(VertexGradient vertexGradient, float opacity)
    {
        return new VertexGradient
        (
            ChangeColorOpacity(vertexGradient.topLeft, opacity),
            ChangeColorOpacity(vertexGradient.topRight, opacity),
            ChangeColorOpacity(vertexGradient.bottomLeft, opacity),
            ChangeColorOpacity(vertexGradient.bottomRight, opacity)
        );
    }

    /// <summary>
    /// Changes the opacity of a color with a simple syntax.
    /// </summary>
    public static Color ChangeColorOpacity(Color color, float opacity)
    {
        return new Color(color.r, color.g, color.b, opacity);
    }

    /// <summary>
    /// Destroys all children of a GameObject.
    /// </summary>
    public static void DestroyChildren(GameObject t)
    {
        t.transform.Cast<Transform>().ToList().ForEach(c => UnityEngine.Object.Destroy(c.gameObject));
    }
}
