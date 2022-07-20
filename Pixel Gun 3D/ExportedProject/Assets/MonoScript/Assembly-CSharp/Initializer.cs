using System;
using System.Collections.Generic;
using UnityEngine;

public class Initializer : MonoBehaviour
{
	private GameObject _playerPrefab;

	public GameObject networkTablePref;

	private bool _isMultiplayer;

	public GUIStyle messagesStyle;

	private Vector2 scrollPosition = Vector2.zero;

	private List<Vector3> _initPlayerPositions = new List<Vector3>();

	private List<float> _rots = new List<float>();

	private float koofScreen = (float)Screen.height / 768f;

	public WeaponManager _weaponManager;

	public bool showMaxPlayer;

	public bool showDisconnect;

	public float timerShow = -1f;

	public Transform playerPrefab;

	public Texture fonLoadingScene;

	private bool showLoading;

	public static event Action PlayerAddedEvent;

	private void Awake()
	{
		GameObject gameObject = null;
		if (PlayerPrefs.GetInt("MultyPlayer") != 1)
		{
			gameObject = ((GlobalGameController.currentLevel != GlobalGameController.levelMapping[0]) ? (Resources.Load("BackgroundMusic/BackgroundMusic_Level" + (GlobalGameController.previousLevel + 1)) as GameObject) : (Resources.Load("BackgroundMusic/BackgroundMusic_Level0") as GameObject));
		}
		else
		{
			if (Defs.levelNumsForMusicInMult.ContainsKey(Application.loadedLevelName))
			{
				GlobalGameController.currentLevel = Defs.levelNumsForMusicInMult[Application.loadedLevelName];
			}
			gameObject = Resources.Load("BackgroundMusic/BackgroundMusic_Level" + GlobalGameController.currentLevel) as GameObject;
		}
		UnityEngine.Object.Instantiate(gameObject);
		if (PlayerPrefs.GetInt("MultyPlayer") != 1)
		{
			GameObject gameObject2 = GameObject.FindGameObjectWithTag("Configurator");
			CoinConfigurator component = gameObject2.GetComponent<CoinConfigurator>();
			if (component.CoinIsPresent)
			{
				GameObject original = Resources.Load("coin") as GameObject;
				UnityEngine.Object.Instantiate(original, component.pos, Quaternion.Euler(270f, 0f, 0f));
			}
		}
	}

	private void Start()
	{
		PhotonNetwork.isMessageQueueRunning = true;
		if (PlayerPrefs.GetInt("MultyPlayer") == 1)
		{
			_isMultiplayer = true;
		}
		else
		{
			_isMultiplayer = false;
		}
		_weaponManager = GameObject.FindGameObjectWithTag("WeaponManager").GetComponent<WeaponManager>();
		_weaponManager.players.Clear();
		if (!_isMultiplayer)
		{
			_initPlayerPositions.Add(new Vector3(12f, 1f, 9f));
			_initPlayerPositions.Add(new Vector3(17f, 1f, -15f));
			_initPlayerPositions.Add(new Vector3(-30f, 1f, -35f));
			_initPlayerPositions.Add(new Vector3(0f, 1f, 0f));
			_initPlayerPositions.Add(new Vector3(-33f, 1.2f, -13f));
			_initPlayerPositions.Add(new Vector3(-2.67f, 1f, 2.67f));
			_initPlayerPositions.Add(new Vector3(0f, 1f, 0f));
			_initPlayerPositions.Add(new Vector3(19f, 1f, -0.8f));
			_initPlayerPositions.Add(new Vector3(-28.5f, 1.75f, -3.73f));
			_initPlayerPositions.Add(new Vector3(-2.5f, 1.75f, 0f));
			_rots.Add(0f);
			_rots.Add(0f);
			_rots.Add(270f);
			_rots.Add(0f);
			_rots.Add(180f);
			_rots.Add(0f);
			_rots.Add(0f);
			_rots.Add(270f);
			_rots.Add(270f);
			_rots.Add(270f);
			if (keychainPlugin.getKCValue(Defs.EarnedCoins) > 0 || GlobalGameController.currentLevel == GlobalGameController.levelMapping[1])
			{
				GameObject original = Resources.Load("MessageCoinsObject") as GameObject;
				GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(original);
				if (GlobalGameController.currentLevel == GlobalGameController.levelMapping[1] && keychainPlugin.getKCValue(Defs.EarnedCoins) <= 0)
				{
					CoinsMessage component = gameObject.GetComponent<CoinsMessage>();
					if ((bool)component)
					{
						component.singleMessage = true;
					}
				}
			}
			AddPlayer();
		}
		else if (PlayerPrefs.GetString("TypeConnect").Equals("local"))
		{
			if (PlayerPrefs.GetString("TypeGame").Equals("client"))
			{
				bool flag2 = (Network.useNat = !Network.HavePublicAddress());
				Debug.Log(_weaponManager.ServerIp + " " + Network.Connect(_weaponManager.ServerIp, 25002));
			}
			else
			{
				_weaponManager.myTable = (GameObject)Network.Instantiate(networkTablePref, base.transform.position, base.transform.rotation, 0);
			}
		}
		else
		{
			_weaponManager.myTable = PhotonNetwork.Instantiate("NetworkTable", base.transform.position, base.transform.rotation, 0);
		}
	}

	[RPC]
	private void SpawnOnNetwork(Vector3 pos, Quaternion rot, int id1, PhotonPlayer np)
	{
		Transform transform = UnityEngine.Object.Instantiate(networkTablePref, pos, rot).transform;
		PhotonView component = transform.GetComponent<PhotonView>();
		component.viewID = id1;
	}

	private void AddPlayer()
	{
		_playerPrefab = Resources.Load("Player") as GameObject;
		int index = ((GlobalGameController.currentLevel != GlobalGameController.levelMapping[0]) ? GlobalGameController.previousLevel : 0);
		Vector3 position = ((GlobalGameController.currentLevel != GlobalGameController.levelMapping[0]) ? _initPlayerPositions[index] : new Vector3(-0.72f, 1.75f, -13.23f));
		float y = ((GlobalGameController.currentLevel != GlobalGameController.levelMapping[0]) ? _rots[index] : 0f);
		UnityEngine.Object.Instantiate(_playerPrefab, position, Quaternion.Euler(0f, y, 0f));
		Invoke("SetupObjectThatNeedsPlayer", 0.01f);
	}

	public void SetupObjectThatNeedsPlayer()
	{
		if (PlayerPrefs.GetInt("MultyPlayer") == 1)
		{
			Initializer.PlayerAddedEvent();
			return;
		}
		GameObject gameObject = GameObject.FindGameObjectWithTag("CoinBonus");
		if ((bool)gameObject)
		{
			CoinBonus component = gameObject.GetComponent<CoinBonus>();
			if ((bool)component)
			{
				component.SetPlayer();
			}
		}
		GetComponent<ZombieCreator>().BeganCreateEnemies();
		GetComponent<BonusCreator>().BeginCreateBonuses();
		Initializer.PlayerAddedEvent();
	}

	private void OnGUI()
	{
		messagesStyle.alignment = TextAnchor.MiddleCenter;
		messagesStyle.fontSize = Mathf.RoundToInt(60f * (float)Screen.height / 768f);
		messagesStyle.normal.textColor = Color.white;
		Rect position = new Rect(0f, (float)Screen.height * 0.15f, Screen.width, (float)Screen.height * 0.2f);
		if ((!PhotonNetwork.connected || showLoading) && PlayerPrefs.GetInt("MultyPlayer") == 1 && PlayerPrefs.GetString("TypeConnect").Equals("inet"))
		{
			if (_weaponManager.myTable != null)
			{
				_weaponManager.myTable.GetComponent<NetworkStartTable>().isShowNickTable = false;
				_weaponManager.myTable.GetComponent<NetworkStartTable>().showTable = false;
			}
			Rect position2 = new Rect(((float)Screen.width - 2048f * (float)Screen.height / 1154f) / 2f, 0f, 2048f * (float)Screen.height / 1154f, Screen.height);
			GUI.DrawTexture(position2, fonLoadingScene, ScaleMode.StretchToFill);
		}
		if (showMaxPlayer)
		{
			GUI.Label(position, "Server is full...", messagesStyle);
		}
		if (showDisconnect)
		{
			GUI.Label(position, "No connection", messagesStyle);
		}
	}

	private void Update()
	{
		if (timerShow > 0f)
		{
			timerShow -= Time.deltaTime;
			Debug.Log("OnLeftRoom (local) init");
			showLoading = true;
			Invoke("goToConnect", 0.1f);
		}
	}

	private void OnConnectedToServer()
	{
		_weaponManager.myTable = (GameObject)Network.Instantiate(networkTablePref, base.transform.position, base.transform.rotation, 0);
		Debug.Log("OnConnectedToServer");
	}

	private void OnFailedToConnect(NetworkConnectionError error)
	{
		Debug.Log("Could not connect to server: " + error);
		if (error == NetworkConnectionError.TooManyConnectedPlayers)
		{
			showMaxPlayer = true;
		}
		if (error == NetworkConnectionError.ConnectionFailed)
		{
			showDisconnect = true;
		}
		timerShow = 5f;
		Debug.Log("timerShow=5f;");
		if (!(_weaponManager == null) && !(_weaponManager.myTable == null))
		{
			_weaponManager.myTable.GetComponent<NetworkStartTable>().isShowNickTable = false;
			_weaponManager.myTable.GetComponent<NetworkStartTable>().showTable = false;
		}
	}

	private void goToConnect()
	{
		ConnectGUI.Local();
	}

	public void OnLeftRoom()
	{
		Debug.Log("OnLeftRoom (local) init");
		showLoading = true;
		Invoke("goToConnect", 0.1f);
		if (!(_weaponManager == null) && !(_weaponManager.myTable == null))
		{
			_weaponManager.myTable.GetComponent<NetworkStartTable>().isShowNickTable = false;
			_weaponManager.myTable.GetComponent<NetworkStartTable>().showTable = false;
		}
	}

	public void OnDisconnectedFromPhoton()
	{
		Debug.Log("OnDisconnectedFromPhotoninit");
		showDisconnect = true;
		timerShow = 5f;
		if (!(_weaponManager == null) && !(_weaponManager.myTable == null))
		{
			_weaponManager.myTable.GetComponent<NetworkStartTable>().isShowNickTable = false;
			_weaponManager.myTable.GetComponent<NetworkStartTable>().showTable = false;
		}
	}

	public void OnPhotonPlayerConnected(PhotonPlayer player)
	{
		Debug.Log("OnPhotonPlayerConnectedinit: " + player);
	}

	public void OnPhotonPlayerDisconnected(PhotonPlayer player)
	{
		Debug.Log("OnPlayerDisconnecedinit: " + player);
	}

	public void OnReceivedRoomList()
	{
		Debug.Log("OnReceivedRoomListinit");
	}

	public void OnReceivedRoomListUpdate()
	{
		Debug.Log("OnReceivedRoomListUpdateinit");
	}

	public void OnConnectedToPhoton()
	{
		Debug.Log("OnConnectedToPhotoninit");
	}

	public void OnFailedToConnectToPhoton()
	{
		Debug.Log("OnFailedToConnectToPhotoninit");
	}

	public void OnPhotonInstantiate(PhotonMessageInfo info)
	{
		Debug.Log("OnPhotonInstantiate init" + info.sender);
	}
}
