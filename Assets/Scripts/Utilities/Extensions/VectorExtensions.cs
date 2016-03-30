﻿using System;

namespace UnityEngine
{
  public static class VectorExtensions
  {
    public static Vector3 ToVector3(this Vector2 vector)
      => vector.ToVector3(0f);

    public static Vector3 ToVector3(this Vector2 vector, float z)
      => new Vector3(vector.x, vector.y, z);

    public static Quaternion ToQuaternion(this Vector3 vector)
      => Quaternion.Euler(vector);

    public static bool IsZero(this Vector2 vector)
      => vector.x.IsZero() && vector.y.IsZero();

    public static Vector2 Set(this Vector2 vector, float? x = null, float? y = null)
      => new Vector2(x ?? vector.x, y ?? vector.y);

    public static Vector3 Set(this Vector3 vector, float? x = null, float? y = null, float? z = null)
      => new Vector3(x ?? vector.x, y ?? vector.y, z ?? vector.z);

    public static Vector2 Add(this Vector2 vector, float x = 0f, float y = 0f)
      => new Vector2(vector.x + x, vector.y + y);

    public static Vector3 Add(this Vector3 vector, float x = 0f, float y = 0f, float z = 0f)
      => new Vector3(vector.x + x, vector.y + y, vector.z + z);

    public static Vector2 Scale(this Vector2 vector, float x = 1f, float y = 1f)
      => Vector2.Scale(vector, new Vector2(x, y));

    public static Vector3 Scale(this Vector3 vector, float x = 1f, float y = 1f, float z = 1f)
      => Vector3.Scale(vector, new Vector3(x, y, z));

    public static Vector2 Transform(
      this Vector2 vector,
      Func<float, float> x = null,
      Func<float, float> y = null)
      => new Vector2(
        x?.Invoke(vector.x) ?? vector.x,
        y?.Invoke(vector.y) ?? vector.y);

    public static Vector3 Transform(
      this Vector3 vector,
      Func<float, float> x = null,
      Func<float, float> y = null,
      Func<float, float> z = null)
      => new Vector3(
        x?.Invoke(vector.x) ?? vector.x,
        y?.Invoke(vector.y) ?? vector.y,
        z?.Invoke(vector.z) ?? vector.z);

    public static float DistanceTo(this Vector3 vector, Transform transform)
      => vector.DistanceTo(transform.position);

    public static float DistanceTo(this Vector2 a, Vector2 b)
      => Vector2.Distance(a, b);

    public static float DistanceTo(this Vector3 a, Vector3 b)
      => Vector3.Distance(a, b);

    public static Vector2 LerpTo(this Vector2 a, Vector2 b, float t)
      => Vector2.Lerp(a, b, t);

    public static float Angle(this Vector3 vector)
      => Vector3.Angle(Vector3.up, vector);

    public static float AngleTo(this Vector2 from, Vector2 to)
      => Vector2.Angle(@from, to);

    public static float AngleTo(this Vector3 from, Vector3 to)
      => Vector3.Angle(from, to);

    public static Vector2 Vary(this Vector2 vector, float variance)
      => new Vector2(
        vector.x.Vary(variance),
        vector.y.Vary(variance));

    public static Vector3 Vary(this Vector3 vector, float variance, bool varyZ = false)
      => new Vector3(
        vector.x.Vary(variance),
        vector.y.Vary(variance),
        varyZ ? vector.z.Vary(variance) : vector.z);

    public static float RandomRange(this Vector2 parent)
      => Random.Range(parent.x, parent.y);

    public static Quaternion LookAt2D(this Vector3 vector, Vector3 target)
      => new Vector3(0f, 0f, DirectionToRotation2D(target - vector).z).ToQuaternion();

    public static Vector3 DirectionToRotation2D(this Vector3 vector)
    {
      var angle = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;

      return Quaternion.AngleAxis(angle, Vector3.forward).eulerAngles;
    }
  }
}