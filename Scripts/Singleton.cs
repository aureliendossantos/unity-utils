using UnityEngine;

/// <summary>
/// Generic singleton class for MonoBehaviour-derived classes.
/// Create a singleton: MyClass : Singleton<MyClass>
/// Use it anywhere: MyClass.Instance.Method();
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance { get; private set; }

    protected virtual void Awake()
    {
        if (Instance == null)
        {
            Instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this) Destroy(gameObject);
    }
}
