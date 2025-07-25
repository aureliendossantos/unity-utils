using UnityEngine;
using NaughtyAttributes;

/// <summary>
/// Use instead of a simple `float` to have a smooth transition towards a target value that can be changed at any time.
/// </summary>
[System.Serializable]
public class DampedFloat
{
    [ShowNativeProperty] public float Value { get; private set; }
    [HideInInspector] public float target;
    float velocity = 0f;
    [SerializeField] float smoothTime = 0.5f;

    public DampedFloat(float initialValue)
    {
        Value = initialValue;
        target = initialValue;
    }

    public float Update()
    {
        Value = Mathf.SmoothDamp(Value, target, ref velocity, smoothTime);
        return Value;
    }
}

/// <summary>
/// Works like `DampedFloat` with a smoothing function that is more suitable for angles.
/// </summary>
[System.Serializable]
public class DampedAngle
{
    [ShowNativeProperty] public float Value { get; private set; }
    [HideInInspector] public float Target { get; private set; }
    float velocity = 0f;
    [SerializeField] public float smoothTime = 0.5f;

    public DampedAngle(float initialValue)
    {
        Value = initialValue;
        target = initialValue;
    }

    public void SetTarget(Vector3 direction)
    {
        target = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    }

    public void SetTarget(Vector2 direction)
    {
        target = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    }

    public void SetTarget(float angle)
    {
        target = angle;
    }

    public float Update()
    {
        Value = Mathf.SmoothDampAngle(Value, target, ref velocity, smoothTime);
        return Value;
    }
}
