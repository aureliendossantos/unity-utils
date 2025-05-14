using UnityEngine;
using NaughtyAttributes;

/// <summary>
/// Use instead of a simple `float` to have a smooth transition towards a target value that can be changed at any time.
/// </summary>
[System.Serializable]
public class DampedFloat
{
    [ShowNativeProperty] public float Value { get; private set; }
    float velocity = 0f;
    [SerializeField] float smoothTime = 0.5f;

    public void SetInitialValue(float initialValue)
    {
        Value = initialValue;
    }

    public void Update(float target)
    {
        Value = Mathf.SmoothDamp(Value, target, ref velocity, smoothTime);
    }
}

/// <summary>
/// Works like `DampedFloat` with a smoothing function that is more suitable for angles.
/// </summary>
/// <see cref="DampedFloat"/> 
[System.Serializable]
public class DampedAngle
{
    [ShowNativeProperty] public float Value { get; private set; }
    float velocity = 0f;
    [SerializeField] float smoothTime = 0.5f;

    public void SetInitialValue(float initialValue)
    {
        Value = initialValue;
    }

    public void Update(float targetAngle)
    {
        Value = Mathf.SmoothDampAngle(Value, targetAngle, ref velocity, smoothTime);
    }
}
