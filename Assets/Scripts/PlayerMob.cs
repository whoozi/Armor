using UnityEngine;

[RequireComponent(typeof(LocalPlayer))]
public class PlayerMob : Mob
{
	public Transform wheel;

	private Vector2 moveInput;
	private float lookInput;
	private Quaternion lastRotation;
	private LocalPlayer player;

	protected override void Awake()
	{
		base.Awake();

		player = GetComponent<LocalPlayer>();
	}

	protected override void FixedUpdate()
	{
		moveInput = player.input.GetAxis2D("Move Horizontal", "Move Vertical");
		lookInput = player.input.GetAxis("Look Horizontal");

		if (canMove)
			moveDirection = Quaternion.LookRotation(player.camera.transform.forward) * new Vector3(moveInput.x, 0.0f, moveInput.y);

		transform.Rotate(Vector3.up, lookInput * 2.0f);

		wheel.rotation = lastRotation;
		wheel.Rotate(Quaternion.LookRotation(Vector3.right) * motor.velocity.OnlyXZ(), motor.velocity.OnlyXZ().magnitude, Space.World);
		lastRotation = wheel.rotation;

		base.FixedUpdate();
	}
}
