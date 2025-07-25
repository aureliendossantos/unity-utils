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

    public void Update()
    {
        Value = Mathf.SmoothDamp(Value, target, ref velocity, smoothTime);
    }
}

/// <summary>
/// Works like `DampedFloat` with a smoothing function that is more suitable for angles.
/// </summary>
[System.Serializable]
public class DampedAngle
{
    [ShowNativeProperty] public float Value { get; private set; }
    [HideInInspector] public float target;
    float velocity = 0f;
    [SerializeField] public float smoothTime = 0.5f;

    public DampedAngle(float initialValue)
    {
        Value = initialValue;
        target = initialValue;
    }

    public void Update()
    {
        Value = Mathf.SmoothDampAngle(Value, target, ref velocity, smoothTime);
    }
}
