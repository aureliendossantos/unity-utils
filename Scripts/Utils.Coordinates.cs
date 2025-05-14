using UnityEngine;

public static partial class Utils
{
    /// <summary>
    /// In 2D, clamps a world point to the screen bounds, with an optional margin outside the screen.
    /// </summary>
    /// <returns>The clamped world point.</returns>
    public static Vector2 ClampToScreenBounds(Vector2 position, Camera camera, float margin = 0f)
    {
        Vector2 min = camera.ViewportToWorldPoint(Vector2.zero) - new Vector3(margin, margin);
        Vector2 max = camera.ViewportToWorldPoint(Vector2.one) + new Vector3(margin, margin);
        float clampedX = Mathf.Clamp(position.x, min.x, max.x);
        float clampedY = Mathf.Clamp(position.y, min.y, max.y);

        return new Vector2(clampedX, clampedY);
    }

    /// <summary>
    /// Gets the position of a corner of a RectTransform.
    /// </summary>
    /// <param name="rect">Which RectTransform?</param>
    /// <param name="cornerIndex">0: bottom left, 1: top left, 2: top right, 3: bottom right.</param>
    /// <returns>A Vector3 in world space.</returns>
    public static Vector3 GetRectTransformCorner(RectTransform rect, int cornerIndex)
    {
        // Unity has a weird way of returning corners, so we have to do this.
        Vector3[] corners = new Vector3[4];
        rect.GetWorldCorners(corners);
        return corners[cornerIndex];
    }

    /// <summary>
    /// In a 2D grid, list of coordinates to get the 8 cells around a given cell.
    /// </summary>
    public static int[,] nearbyCells = new int[,] {
        { -1, -1 },
        { -1, 0 },
        { -1, 1 },
        { 0, -1 },
        { 0, 1 },
        { 1, -1 },
        { 1, 0 },
        { 1, 1 },
    };
}