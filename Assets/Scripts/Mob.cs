using UnityEngine;

[RequireComponent(typeof(MobMotor))]
public class Mob : MonoBehaviour
{
	private Vector3 _moveDirection;

	protected MobMotor motor;

	public Vector3 moveDirection
	{
		get { return _moveDirection; }

		set { _moveDirection = value.normalized; }
	}

	public bool canMove
	{
		get { return !motor.ignoreMovement && motor.isGrounded; }
	}

	protected virtual void Awake()
	{
		motor = GetComponent<MobMotor>();
	}

	protected virtual void FixedUpdate()
	{
		motor.Move(moveDirection);
	}
}
