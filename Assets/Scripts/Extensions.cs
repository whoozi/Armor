using UnityEngine;

public static class Extensions
{
	/// <summary>
	/// Checks whether value is near to zero within a tolerance.
	/// </summary>
	public static bool IsZero(this float value)
	{
		return Mathf.Abs(value) < 0.0000000001f;
	}

	/// <summary>
	/// Checks whether vector is near to zero within a tolerance.
	/// </summary>
	public static bool IsZero(this Vector3 vector3)
	{
		return vector3.sqrMagnitude < 9.99999943962493E-11;
	}

	/// <summary>
	/// Checks whether vector is near to zero within a tolerance.
	/// </summary>
	public static bool IsZero(this Vector2 vector2)
	{
		return vector2.sqrMagnitude < 9.99999943962493E-11;
	}

	/// <summary>
	/// Returns a copy of given vector with only X component of the vector.
	/// </summary>
	public static Vector3 OnlyX(this Vector3 vector3)
	{
		vector3.y = 0.0f;
		vector3.z = 0.0f;

		return vector3;
	}

	/// <summary>
	/// Returns a copy of given vector with only Y component of the vector.
	/// </summary>
	public static Vector3 OnlyY(this Vector3 vector3)
	{
		vector3.x = 0.0f;
		vector3.z = 0.0f;

		return vector3;
	}

	/// <summary>
	/// Returns a copy of given vector with only Z component of the vector.
	/// </summary>
	public static Vector3 OnlyZ(this Vector3 vector3)
	{
		vector3.x = 0.0f;
		vector3.y = 0.0f;

		return vector3;
	}

	/// <summary>
	/// Returns a copy of given vector with only X and Z components of the vector.
	/// </summary>
	public static Vector3 OnlyXZ(this Vector3 vector3)
	{
		vector3.y = 0.0f;

		return vector3;
	}
}
