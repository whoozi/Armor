using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class GameManager : Singleton<GameManager>
{
	private static Camera _mainCamera;

	public LocalPlayer playerPrefab;
	public Camera cameraPrefab;
	public List<LocalPlayer> localPlayers = new List<LocalPlayer>(4);

	public static Camera mainCamera
	{
		get
		{
			if (!_mainCamera)
				_mainCamera = Camera.main;

			return _mainCamera;
		}
	}

	public static void AddPlayers(int amount = 1)
	{
		if (amount < 1)
			return;

		for (int i = 0; i < amount; i++)
		{
			LocalPlayer localPlayer = Instantiate(instance.playerPrefab);
			localPlayer.localPlayerID = (LocalPlayerID)instance.localPlayers.Count;

			instance.localPlayers.Add(localPlayer);
		}
	}

	private void Start()
	{
		Controller[] controllers = ReInput.controllers.GetControllers(ControllerType.Joystick);

		AddPlayers();

		if (controllers != null && controllers.Length > 1)
			AddPlayers(controllers.Length - 1);

		SetupCameraViewports();
	}

	private void SetupCameraViewports()
	{
		switch (localPlayers.Count)
		{
			case 1: // One players
				localPlayers[0].camera.rect = new Rect(0.0f, 0.0f, 1.0f, 1.0f);
				break;

			case 2: // Two players
				localPlayers[0].camera.rect = new Rect(0.0f, 0.0f, 0.5f, 1.0f);
				localPlayers[1].camera.rect = new Rect(0.5f, 0.0f, 0.5f, 1.0f);
				break;

			case 3: // Three players
				localPlayers[0].camera.rect = new Rect(0.0f, 0.5f, 0.5f, 0.5f);
				localPlayers[1].camera.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
				localPlayers[2].camera.rect = new Rect(0.25f, 0.0f, 0.5f, 0.5f);
				break;

			case 4: // Four players
				localPlayers[0].camera.rect = new Rect(0.0f, 0.5f, 0.5f, 0.5f);
				localPlayers[1].camera.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
				localPlayers[2].camera.rect = new Rect(0.0f, 0.0f, 0.5f, 0.5f);
				localPlayers[3].camera.rect = new Rect(0.5f, 0.0f, 0.5f, 0.5f);
				break;
		}
	}
}
