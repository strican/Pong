using UnityEngine;
using System.Collections;

public class MovementHelpers
{
    public static float IncrementToward(float current, float target, float delta)
    {
        if (current == target)
        {
            return target;
        }
        else
        {
            float dir = Mathf.Sign(target - current);
            float newValue = current + Time.deltaTime * delta * dir;
            return (dir == Mathf.Sign(target - newValue)) ? newValue : target;
        }
    }
}
