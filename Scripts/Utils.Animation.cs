using System.Collections;
using UnityEngine;

public static partial class Utils
{
    /// <summary>
    /// Repeats a given function every frame for the given duration.
    /// The function has access to a timer going from 0 to 1. 
    /// <example>
    /// How to use:
    /// <code>StartCoroutine(Animate(duration, (timer) => { instructions }), () => { optionalAction })</code>
    /// </example>
    /// </summary>
    /// <param name="duration">Duration of the animation in seconds.</param>
    /// <param name="action">An action that takes the parameter "timer", a float going from 0 to 1.</param>
    /// <param name="easing">An optional easing function that takes a float and returns a float. Default is linear.</param>
    /// <param name="actionAtTheEnd">An optional action executed after the timer has reached 1.</param>
    public static IEnumerator Animate(float duration, System.Action<float> action, System.Func<float, float> easing = null, System.Action actionAtTheEnd = null)
    {
        easing ??= (x => x);
        float timer = 0;
        while (timer < duration)
        {
            action(easing(timer / duration));
            timer += Time.deltaTime;
            yield return null;
        }
        action(1);
        actionAtTheEnd?.Invoke();
    }

    /// <summary>
    /// Takes a timer x evolving from 0 to 1 and turns it into an eased timer. https://easings.net/#easeOutQuint
    /// <example>
    /// <code>StartCoroutine(Animate(duration, (timer) => { easedTimer = EaseOutQuint(timer) }))</code>
    /// </example>
    /// </summary>
    /// <param name="x">Transition progress from 0 to 1.</param>
    /// <returns>Eased value from 0 to 1.</returns>
    public static float EaseOutQuint(float x)
    {
        return 1 - Mathf.Pow(1 - x, 5);
    }

    /// <summary>
    /// Takes a timer x evolving from 0 to 1 and turns it into an eased timer. https://easings.net/#easeInQuint
    /// <example>
    /// <code>StartCoroutine(Animate(duration, (timer) => { easedTimer = EaseOutQuint(timer) }))</code>
    /// </example>
    /// </summary>
    /// <param name="x">Transition progress from 0 to 1.</param>
    /// <returns>Eased value from 0 to 1.</returns>
    public static float EaseInQuint(float x)
    {
        return x * x * x * x * x;
    }
}
