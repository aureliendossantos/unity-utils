using UnityEngine;
using NaughtyAttributes;

/// <summary>
/// Use instead of a simple `float` to have a smooth transition towards a target value that can be changed at any time.
/// </summary>
[System.Serializable]
public class DampedFloat(float initialValue)
{
    [ShowNativeProperty] public float Value { get; private set; } = initialValue;
    [HideInInspector] public float Target = initialValue;
    float velocity = 0f;
    [SerializeField] float smoothTime = 0.5f;

    public void Update()
    {
        Value = Mathf.SmoothDamp(Value, Target, ref velocity, smoothTime);
    }
}

/// <summary>
/// Works like `DampedFloat` with a smoothing function that is more suitable for angles.
/// </summary>
[System.Serializable]
public class DampedAngle(float initialValue)
{
    [ShowNativeProperty] public float Value { get; private set; } = initialValue;
    [HideInInspector] public float Target = initialValue;
    float velocity = 0f;
    [SerializeField] public float smoothTime = 0.5f;

    public void Update()
    {
        Value = Mathf.SmoothDampAngle(Value, Target, ref velocity, smoothTime);
    }
}
