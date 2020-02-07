using UnityEngine;
using Cinemachine;
using Rewired;

public class LocalPlayer : MonoBehaviour
{
	public PlayerMob mob { get; private set; }
	public Player input { get; private set; }
	public CinemachineVirtualCamera virtualCamera { get; private set; }
	new public Camera camera { get; private set; }

	private LocalPlayerID _localPlayerID;

	public LocalPlayerID localPlayerID
	{
		get { return _localPlayerID; }

		set
		{
			_localPlayerID = value;

			SetupLocalPlayer();
		}
	}

	private void Awake()
	{
		mob = GetComponent<PlayerMob>();
		virtualCamera = GetComponentInChildren<CinemachineVirtualCamera>();
	}

	private void SetupLocalPlayer()
	{
		name = "Player " + localPlayerID;

		switch (localPlayerID)
		{
			case LocalPlayerID.One:
				camera = GameManager.mainCamera;
				camera.cullingMask |= LayerMask.GetMask("Player One");
				virtualCamera.gameObject.layer = LayerMask.NameToLayer("Player One");
				break;

			case LocalPlayerID.Two:
			case LocalPlayerID.Three:
			case LocalPlayerID.Four:
				if (camera && camera != GameManager.mainCamera)
					Destroy(camera);

				camera = Instantiate(GameManager.instance.cameraPrefab);
				camera.name = "Player " + localPlayerID + " Camera";
				camera.tag = "Untagged";
				camera.cullingMask |= LayerMask.GetMask("Player " + localPlayerID);
				virtualCamera.gameObject.layer = LayerMask.NameToLayer("Player " + localPlayerID);
				break;
		}

		input = ReInput.players.GetPlayer((int)localPlayerID);
	}
}
