using UnityEngine;

public class MobMotor : MonoBehaviour
{
	public bool ignoreMovement = false;
	public float moveSpeed = 3.0f;
	public float moveSmoothTime = 0.1f;
	public float jumpHeight = 0.7f;
	public float gravityScale = 1.0f;

	private Vector3 _velocity, smoothVelocity;
	private CharacterController controller;

	public Vector3 velocity
	{
		get { return controller.velocity; }
	}

	public CollisionFlags collisionFlags
	{
		get { return controller.collisionFlags; }
	}

	public bool isGrounded
	{
		get { return controller.isGrounded; }
	}

	private void Awake()
	{
		controller = GetComponent<CharacterController>();
	}

	public virtual void Move(Vector3 direction)
	{
		_velocity.y += Physics.gravity.y * gravityScale * Time.fixedDeltaTime;
		_velocity = Vector3.SmoothDamp(_velocity.OnlyXZ(), !ignoreMovement ? direction * moveSpeed : Vector3.zero, ref smoothVelocity, moveSmoothTime) + _velocity.y * Vector3.up;

		controller.Move(_velocity * Time.fixedDeltaTime);

		if (controller.isGrounded)
			_velocity.y = 0.0f;
	}

	public void Jump()
	{
		_velocity.y = Mathf.Sqrt(Physics.gravity.y * gravityScale * jumpHeight * -2.0f);
	}
}
