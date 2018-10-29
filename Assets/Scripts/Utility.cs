using UnityEngine;

public static class Utility
{
    public static Vector3 GetScalarMultiplied(Vector3 vec, float scale)
    {
        return new Vector3(vec.x * scale, vec.y * scale, vec.z * scale);
    }
}