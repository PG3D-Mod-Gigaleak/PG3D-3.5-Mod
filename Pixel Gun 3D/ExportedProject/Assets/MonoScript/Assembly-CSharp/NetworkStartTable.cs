using System.Collections.Generic;
using Prime31;
using UnityEngine;

public class NetworkStartTable : MonoBehaviour
{
	public struct infoClient
	{
		public string ipAddress;

		public string name;

		public string coments;
	}

	public List<GameObject> zombiePrefabs = new List<GameObject>();

	private GameObject _playerPrefab;

	public GameObject tempCam;

	public GameObject zombieManagerPrefab;

	private bool _isMultiplayer;

	private int addCoins;

	private bool showMessagFacebook;

	private bool showMessagTiwtter;

	private bool clickButtonFacebook;

	public bool isIwin;

	public List<infoClient> players = new List<infoClient>();

	public GUIStyle back;

	public GUIStyle start;

	public GUIStyle restart;

	public GUIStyle playersWindow;

	public GUIStyle playersWindowFrags;

	public GUIStyle twitterStyle;

	public GUIStyle facebookStyle;

	public GUIStyle labelStyle;

	public GUIStyle messagesStyle;

	public Texture head_players;

	public Texture nicksStyle;

	public Texture killsStyle;

	public Texture scoreTexture;

	private Vector2 scrollPosition = Vector2.zero;

	public GameObject _purchaseActivityIndicator;

	private float koofScreen = (float)Screen.height / 768f;

	public WeaponManager _weaponManager;

	public bool showTable;

	public string nickPobeditelya;

	public bool isShowNickTable;

	public bool runGame = true;

	public GUIStyle zagolovokStyle;

	public GameObject[] zoneCreatePlayer;

	private GameObject _cam;

	public bool showDisconnectFromServer;

	public bool showDisconnectFromMasterServer;

	private float timerShow = -1f;

	public string NamePlayer;

	public int CountKills;

	public int oldCountKills = -1;

	public string[] oldSpisokName;

	public string[] oldCountLilsSpisok;

	public int oldIndexMy;

	private GameObject tc;

	public float score = -1f;

	public float scoreOld = -1f;

	private string _userId;

	private bool _canUserUseFacebookComposer;

	private bool _hasPublishPermission;

	private bool _hasPublishActions;

	private string _SocialMessage()
	{
		keychainPlugin.createKCValue(0, Defs.COOPScore);
		if (isIwin)
		{
			return (PlayerPrefs.GetInt("COOP", 0) != 1) ? ("Now I have " + PlayerPrefs.GetInt("Rating", 0) + " wons! Try Pixel Gun 3D right now! https://itunes.apple.com/us/app/pixlgun-3d-block-world-pocket/id640111933?mt=8") : ("Now I have" + keychainPlugin.getKCValue(Defs.COOPScore) + " score! Try Pixel Gun 3D right now! https://itunes.apple.com/us/app/pixlgun-3d-block-world-pocket/id640111933?mt=8");
		}
		return (PlayerPrefs.GetInt("COOP", 0) != 1) ? ("I won " + PlayerPrefs.GetInt("Rating", 0) + " matches at this time! Try Pixel Gun 3D right now! https://itunes.apple.com/us/app/pixlgun-3d-block-world-pocket/id640111933?mt=8") : ("I received " + keychainPlugin.getKCValue(Defs.COOPScore) + " scores at this time! Try Pixel Gun 3D right now! https://itunes.apple.com/us/app/pixlgun-3d-block-world-pocket/id640111933?mt=8");
	}

	private string _SocialSentSuccess(string SocialName)
	{
		return "Message was sent to " + SocialName;
	}

	private void completionHandler(string error, object result)
	{
		if (error != null)
		{
			Debug.LogError(error);
		}
		else
		{
			Utils.logObject(result);
		}
	}

	private void Awake()
	{
		string[] array = null;
		array = new string[10] { "1", "15", "14", "2", "3", "9", "11", "12", "10", "16" };
		string[] array2 = array;
		foreach (string text in array2)
		{
			GameObject item = Resources.Load("Enemies/Enemy" + text + "_go") as GameObject;
			zombiePrefabs.Add(item);
		}
	}

	public void setScoreFromGlobalGameController()
	{
		score = GlobalGameController.Score;
		synchState();
	}

	[RPC]
	private void addPlayer(string _name, string _ip)
	{
		_weaponManager = GameObject.FindGameObjectWithTag("WeaponManager").GetComponent<WeaponManager>();
		WeaponManager.infoClient item = default(WeaponManager.infoClient);
		item.name = _name;
		item.ipAddress = _ip;
		Debug.Log("---addPlayer " + _name);
		_weaponManager.players.Add(item);
	}

	[RPC]
	private void RunGame()
	{
		GameObject[] array = GameObject.FindGameObjectsWithTag("NetworkTable");
		GameObject[] array2 = array;
		foreach (GameObject gameObject in array2)
		{
			gameObject.GetComponent<NetworkStartTable>().runGame = true;
		}
	}

	[RPC]
	private void delPlayer(string _name)
	{
		_weaponManager = GameObject.FindGameObjectWithTag("WeaponManager").GetComponent<WeaponManager>();
		for (int i = 0; i < _weaponManager.players.Count; i++)
		{
			if (_weaponManager.players[i].name.Equals(_name))
			{
				_weaponManager.players.RemoveAt(i);
			}
		}
	}

	public void sendDelMyPlayer()
	{
		if (PlayerPrefs.GetString("TypeConnect").Equals("local"))
		{
			if (base.GetComponent<NetworkView>().isMine)
			{
				base.GetComponent<NetworkView>().RPC("delPlayer", RPCMode.Others, PlayerPrefs.GetString("NamePlayer", Defs.defaultPlayerName));
			}
			return;
		}
		PhotonView photonView = PhotonView.Get(this);
		if (photonView.isMine)
		{
			photonView.RPC("delPlayer", PhotonTargets.Others, PlayerPrefs.GetString("NamePlayer", Defs.defaultPlayerName));
		}
	}

	private void playersTable()
	{
		GUIStyle gUIStyle;
		if (isShowNickTable)
		{
			zagolovokStyle.fontSize = Mathf.RoundToInt(60f * (float)Screen.height / 768f);
			zagolovokStyle.normal.textColor = new Color(0f, 0f, 0f, 1f);
			GUI.Label(new Rect((float)Screen.width / 2f - ((float)head_players.width / 2f + 4f) * koofScreen, (float)Screen.height * 0.15f - (float)head_players.height / 2f * (float)Screen.height / 768f, (float)head_players.width * koofScreen, (float)head_players.height * koofScreen), string.Empty + nickPobeditelya + " WINS!", zagolovokStyle);
			GUI.Label(new Rect((float)Screen.width / 2f - ((float)head_players.width / 2f - 4f) * koofScreen, (float)Screen.height * 0.15f - (float)head_players.height / 2f * (float)Screen.height / 768f, (float)head_players.width * koofScreen, (float)head_players.height * koofScreen), string.Empty + nickPobeditelya + " WINS!", zagolovokStyle);
			GUI.Label(new Rect((float)Screen.width / 2f - ((float)head_players.width / 2f + 4f) * koofScreen, (float)Screen.height * 0.15f - ((float)head_players.height / 2f + 4f) * (float)Screen.height / 768f, (float)head_players.width * koofScreen, (float)head_players.height * koofScreen), string.Empty + nickPobeditelya + " WINS!", zagolovokStyle);
			GUI.Label(new Rect((float)Screen.width / 2f - ((float)head_players.width / 2f + 4f) * koofScreen, (float)Screen.height * 0.15f - ((float)head_players.height / 2f - 4f) * (float)Screen.height / 768f, (float)head_players.width * koofScreen, (float)head_players.height * koofScreen), string.Empty + nickPobeditelya + " WINS!", zagolovokStyle);
			GUI.Label(new Rect((float)Screen.width / 2f - ((float)head_players.width / 2f - 4f) * koofScreen, (float)Screen.height * 0.15f - ((float)head_players.height / 2f + 4f) * (float)Screen.height / 768f, (float)head_players.width * koofScreen, (float)head_players.height * koofScreen), string.Empty + nickPobeditelya + " WINS!", zagolovokStyle);
			GUI.Label(new Rect((float)Screen.width / 2f - ((float)head_players.width / 2f - 4f) * koofScreen, (float)Screen.height * 0.15f - ((float)head_players.height / 2f - 4f) * (float)Screen.height / 768f, (float)head_players.width * koofScreen, (float)head_players.height * koofScreen), string.Empty + nickPobeditelya + " WINS!", zagolovokStyle);
			GUI.Label(new Rect((float)Screen.width / 2f - (float)head_players.width / 2f * koofScreen, (float)Screen.height * 0.15f - ((float)head_players.height / 2f + 4f) * (float)Screen.height / 768f, (float)head_players.width * koofScreen, (float)head_players.height * koofScreen), string.Empty + nickPobeditelya + " WINS!", zagolovokStyle);
			GUI.Label(new Rect((float)Screen.width / 2f - (float)head_players.width / 2f * koofScreen, (float)Screen.height * 0.15f - ((float)head_players.height / 2f - 4f) * (float)Screen.height / 768f, (float)head_players.width * koofScreen, (float)head_players.height * koofScreen), string.Empty + nickPobeditelya + " WINS!", zagolovokStyle);
			zagolovokStyle.normal.textColor = new Color(1f, 1f, 0f, 1f);
			GUI.Label(new Rect((float)Screen.width / 2f - (float)head_players.width / 2f * koofScreen, (float)Screen.height * 0.15f - (float)head_players.height / 2f * (float)Screen.height / 768f, (float)head_players.width * koofScreen, (float)head_players.height * koofScreen), string.Empty + nickPobeditelya + " WINS!", zagolovokStyle);
			gUIStyle = restart;
			Rect position = new Rect((float)Screen.width * 0.5f + (float)facebookStyle.normal.background.width * 0.2f * koofScreen, (float)Screen.height * 0.923f - (float)Screen.height * 0.0525f, (float)facebookStyle.normal.background.width * koofScreen, (float)facebookStyle.normal.background.height * koofScreen);
			Rect position2 = new Rect((float)Screen.width * 0.5f - (float)facebookStyle.normal.background.width * 1.2f * koofScreen, (float)Screen.height * 0.923f - (float)Screen.height * 0.0525f, (float)facebookStyle.normal.background.width * koofScreen, (float)facebookStyle.normal.background.height * koofScreen);
			if (GUI.Button(position, string.Empty, twitterStyle))
			{
				InitTwitter();
			}
			if (GUI.Button(position2, string.Empty, facebookStyle))
			{
				InitFacebook();
			}
		}
		else
		{
			GUI.DrawTexture(new Rect((float)Screen.width / 2f - (float)head_players.width / 2f * koofScreen, (float)Screen.height * 0.15f - (float)head_players.height / 2f * (float)Screen.height / 768f, (float)head_players.width * koofScreen, (float)head_players.height * koofScreen), head_players);
			gUIStyle = start;
		}
		Texture texture = ((PlayerPrefs.GetInt("COOP", 0) != 1) ? killsStyle : scoreTexture);
		GUI.DrawTexture(new Rect((float)Screen.width / 2f + ((float)playersWindow.normal.background.width / 2f - (float)texture.width * 1.6f) * koofScreen, (float)Screen.height * 0.55f - ((float)playersWindow.normal.background.height + (float)nicksStyle.height * 1.8f) * 0.5f * koofScreen, (float)texture.width * koofScreen, (float)texture.height * koofScreen), texture);
		GUI.DrawTexture(new Rect((float)Screen.width / 2f - (float)playersWindow.normal.background.width / 2f * koofScreen, (float)Screen.height * 0.55f - ((float)playersWindow.normal.background.height + (float)nicksStyle.height * 1.8f) * 0.5f * koofScreen, (float)nicksStyle.width * koofScreen, (float)nicksStyle.height * koofScreen), nicksStyle);
		if ((PlayerPrefs.GetString("TypeGame").Equals("server") || runGame || PlayerPrefs.GetString("TypeConnect").Equals("inet")) && (!isShowNickTable || !PlayerPrefs.GetString("TypeConnect").Equals("local")) && GUI.Button(new Rect((float)Screen.width * 0.9f - (float)gUIStyle.normal.background.width / 2f * (float)Screen.height / 768f, (float)Screen.height * 0.9f - (float)gUIStyle.normal.background.height / 2f * (float)Screen.height / 768f, (float)(gUIStyle.normal.background.width * Screen.height) / 768f, (float)(gUIStyle.normal.background.height * Screen.height) / 768f), string.Empty, gUIStyle))
		{
			isShowNickTable = false;
			CountKills = 0;
			score = 0f;
			GlobalGameController.Score = 0;
			synchState();
			_playerPrefab = Resources.Load("Player") as GameObject;
			_cam = GameObject.FindGameObjectWithTag("CamTemp");
			_cam.SetActive(false);
			_weaponManager.useCam = null;
			GameObject gameObject = zoneCreatePlayer[Random.Range(0, zoneCreatePlayer.Length)];
			BoxCollider component = gameObject.GetComponent<BoxCollider>();
			Vector2 vector = new Vector2(component.size.x * gameObject.transform.localScale.x, component.size.z * gameObject.transform.localScale.z);
			Rect rect = new Rect(gameObject.transform.position.x - vector.x / 2f, gameObject.transform.position.z - vector.y / 2f, vector.x, vector.y);
			Vector3 position3 = new Vector3(rect.x + Random.Range(0f, rect.width), gameObject.transform.position.y + 2f, rect.y + Random.Range(0f, rect.height));
			GameObject myPlayer;
			if (PlayerPrefs.GetString("TypeConnect").Equals("inet"))
			{
				myPlayer = PhotonNetwork.Instantiate("Player", position3, base.transform.rotation, 0);
				GameObject.FindGameObjectWithTag("GameController").GetComponent<BonusCreator>().BeginCreateBonuses();
			}
			else
			{
				_playerPrefab = Resources.Load("Player") as GameObject;
				myPlayer = (GameObject)Network.Instantiate(_playerPrefab, position3, base.transform.rotation, 0);
			}
			ObjectLabel.currentCamera = Camera.main;
			_weaponManager.myPlayer = myPlayer;
			if (PlayerPrefs.GetString("TypeConnect").Equals("local") && PlayerPrefs.GetString("TypeGame").Equals("server"))
			{
				Debug.Log("networkView.RPC(RunGame, RPCMode.OthersBuffered);");
				base.GetComponent<NetworkView>().RPC("RunGame", RPCMode.OthersBuffered);
				GameObject.FindGameObjectWithTag("GameController").GetComponent<BonusCreator>().BeginCreateBonuses();
			}
			GameObject.FindGameObjectWithTag("GameController").GetComponent<Initializer>().SetupObjectThatNeedsPlayer();
			showTable = false;
			return;
		}
		playersWindow.fontSize = Mathf.RoundToInt(30f * koofScreen);
		playersWindowFrags.fontSize = Mathf.RoundToInt(30f * koofScreen);
		playersWindowFrags.alignment = TextAnchor.UpperRight;
		GUILayout.Space((float)Screen.height * 0.55f - (float)playersWindow.normal.background.height * 0.5f * koofScreen);
		GUILayout.BeginHorizontal(GUILayout.Height((float)playersWindow.normal.background.height * koofScreen));
		GUILayout.Space((float)Screen.width * 0.5f - (float)playersWindow.normal.background.width * 0.5f * koofScreen);
		scrollPosition = GUILayout.BeginScrollView(scrollPosition, playersWindow);
		if (showTable)
		{
			GameObject[] array = GameObject.FindGameObjectsWithTag("NetworkTable");
			for (int i = 1; i < array.Length; i++)
			{
				GameObject gameObject2 = array[i];
				int num = i - 1;
				while (num >= 0 && ((PlayerPrefs.GetInt("COOP", 0) != 1) ? ((float)array[num].GetComponent<NetworkStartTable>().CountKills) : array[num].GetComponent<NetworkStartTable>().score) < ((PlayerPrefs.GetInt("COOP", 0) != 1) ? ((float)gameObject2.GetComponent<NetworkStartTable>().CountKills) : gameObject2.GetComponent<NetworkStartTable>().score))
				{
					array[num + 1] = array[num];
					num--;
				}
				array[num + 1] = gameObject2;
			}
			if (array.Length > 0)
			{
				GameObject[] array2 = array;
				foreach (GameObject gameObject3 in array2)
				{
					GUILayout.Space(20f * koofScreen);
					GUILayout.BeginHorizontal();
					GUILayout.Space(20f * koofScreen);
					if (gameObject3.Equals(_weaponManager.myTable))
					{
						playersWindow.normal.textColor = new Color(1f, 1f, 0f, 1f);
						playersWindowFrags.normal.textColor = new Color(1f, 1f, 0f, 1f);
					}
					else
					{
						playersWindow.normal.textColor = new Color(0.7843f, 0.7843f, 0.7843f, 1f);
						playersWindowFrags.normal.textColor = new Color(0.7843f, 0.7843f, 0.7843f, 1f);
					}
					GUILayout.Label(gameObject3.GetComponent<NetworkStartTable>().NamePlayer, playersWindow, GUILayout.Width((float)playersWindow.normal.background.width * koofScreen * 0.75f));
					if (PlayerPrefs.GetInt("COOP", 0) == 1)
					{
						float num2 = gameObject3.GetComponent<NetworkStartTable>().score;
						GUILayout.Label((num2 != -1f) ? num2.ToString() : "---", playersWindowFrags, GUILayout.Width((float)playersWindow.normal.background.width * koofScreen * 0.1f));
					}
					else
					{
						int countKills = gameObject3.GetComponent<NetworkStartTable>().CountKills;
						GUILayout.Label((countKills != -1) ? countKills.ToString() : "---", playersWindowFrags, GUILayout.Width((float)playersWindow.normal.background.width * koofScreen * 0.1f));
					}
					GUILayout.Space(20f * koofScreen);
					GUILayout.EndHorizontal();
				}
			}
			GUILayout.EndScrollView();
			GUILayout.EndHorizontal();
		}
		else
		{
			if (oldSpisokName.Length > 0)
			{
				for (int k = 0; k < oldSpisokName.Length; k++)
				{
					if (oldIndexMy == k)
					{
						playersWindow.normal.textColor = new Color(1f, 1f, 0f, 1f);
						playersWindowFrags.normal.textColor = new Color(1f, 1f, 0f, 1f);
					}
					else
					{
						playersWindow.normal.textColor = new Color(0.7843f, 0.7843f, 0.7843f, 1f);
						playersWindowFrags.normal.textColor = new Color(0.7843f, 0.7843f, 0.7843f, 1f);
					}
					GUILayout.Space(20f * koofScreen);
					GUILayout.BeginHorizontal();
					GUILayout.Space(20f * koofScreen);
					string text = oldCountLilsSpisok[k];
					GUILayout.Label(oldSpisokName[k], playersWindow, GUILayout.Width((float)playersWindow.normal.background.width * koofScreen * 0.85f));
					GUILayout.Label((!text.Equals("-1")) ? text.ToString() : "---", playersWindowFrags, GUILayout.Width((float)playersWindow.normal.background.width * koofScreen * 0.1f));
					GUILayout.Space(20f * koofScreen);
					GUILayout.EndHorizontal();
				}
			}
			GUILayout.EndScrollView();
			GUILayout.EndHorizontal();
			if (PlayerPrefs.GetInt("COOP", 0) == 1)
			{
				int num3 = 0;
				if (int.Parse(oldCountLilsSpisok[0]) >= 7500 && int.Parse(oldCountLilsSpisok[0]) < 8000)
				{
					num3 = 1;
				}
				if (int.Parse(oldCountLilsSpisok[0]) >= 8000 && int.Parse(oldCountLilsSpisok[0]) < 9000)
				{
					num3 = 2;
				}
				if (int.Parse(oldCountLilsSpisok[0]) >= 9000)
				{
					num3 = 3;
				}
				if (num3 > 0)
				{
					if (oldIndexMy == 0)
					{
						playersWindowFrags.normal.textColor = new Color(1f, 1f, 0f, 1f);
					}
					else
					{
						playersWindowFrags.normal.textColor = new Color(0.7843f, 0.7843f, 0.7843f, 1f);
					}
					playersWindowFrags.fontSize = Mathf.RoundToInt(23f * koofScreen);
					playersWindowFrags.alignment = TextAnchor.UpperLeft;
					GUI.Label(new Rect((float)Screen.width * 0.5f + (float)playersWindow.normal.background.width * 0.54f * koofScreen, (float)Screen.height * 0.55f - (float)playersWindow.normal.background.height * 0.45f * koofScreen, (float)Screen.width * 0.5f - (float)playersWindow.normal.background.width * 0.5f * koofScreen, (float)playersWindowFrags.fontSize * 2f), "+" + num3 + " coins", playersWindowFrags);
				}
			}
		}
		if (!GUI.Button(new Rect((float)Screen.width * 0.1f - (float)back.active.background.width / 2f * (float)Screen.height / 768f, (float)Screen.height * 0.9f - (float)back.active.background.height / 2f * (float)Screen.height / 768f, (float)(back.active.background.width * Screen.height) / 768f, (float)(back.active.background.height * Screen.height) / 768f), string.Empty, back))
		{
			return;
		}
		if (PlayerPrefs.GetString("TypeConnect").Equals("local"))
		{
			sendDelMyPlayer();
			if (PlayerPrefs.GetString("TypeGame").Equals("server"))
			{
				Network.Disconnect(200);
				GameObject.FindGameObjectWithTag("NetworkTable").GetComponent<LANBroadcastService>().StopBroadCasting();
			}
			else if (Network.connections.Length == 1)
			{
				Debug.Log("Disconnecting: " + Network.connections[0].ipAddress + ":" + Network.connections[0].port);
				Network.CloseConnection(Network.connections[0], true);
			}
			_purchaseActivityIndicator.SetActive(false);
			ConnectGUI.Local();
		}
		else
		{
			sendDelMyPlayer();
			_purchaseActivityIndicator.SetActive(false);
			PhotonNetwork.LeaveRoom();
		}
	}

	[RPC]
	private void setState(string _namePlayer, int _countKills, int _oldCountLills, float _score)
	{
		NamePlayer = _namePlayer;
		CountKills = _countKills;
		oldCountKills = _oldCountLills;
		score = _score;
	}

	public void addZombiManager()
	{
		PhotonView photonView = PhotonView.Get(this);
		int num = PhotonNetwork.AllocateViewID();
		photonView.RPC("addZombiManagerRPC", PhotonTargets.All, base.transform.position, base.transform.rotation, num);
	}

	[RPC]
	private void addZombiManagerRPC(Vector3 pos, Quaternion rot, int id1)
	{
		GameObject gameObject = (GameObject)Object.Instantiate(zombieManagerPrefab, pos, rot);
		PhotonView component = gameObject.GetComponent<PhotonView>();
		component.viewID = id1;
	}

	[RPC]
	private void addZombiManagerNewClientRPC(int playerId, Vector3 pos, Quaternion rot, int id1)
	{
		if (playerId == PhotonNetwork.player.ID)
		{
			GameObject gameObject = GameObject.FindGameObjectWithTag("ZombiCreator");
			if (!(gameObject != null) || id1 != gameObject.GetComponent<PhotonView>().viewID)
			{
				GameObject gameObject2 = (GameObject)Object.Instantiate(zombieManagerPrefab, pos, rot);
				PhotonView component = gameObject2.GetComponent<PhotonView>();
				component.viewID = id1;
			}
		}
	}

	public void OnPhotonPlayerConnected(PhotonPlayer player)
	{
		if (PlayerPrefs.GetInt("COOP", 0) != 1)
		{
			return;
		}
		Debug.Log("OnPhotonPlayerConnectedtable: " + player.ID);
		PhotonView photonView = PhotonView.Get(this);
		if (GetComponent<PhotonView>().owner.ID == PhotonNetwork.player.ID)
		{
			photonView.RPC("addZombiManagerNewClientRPC", PhotonTargets.Others, player.ID, base.transform.position, base.transform.rotation, GameObject.FindGameObjectWithTag("ZombiCreator").GetComponent<PhotonView>().viewID);
			GameObject[] array = GameObject.FindGameObjectsWithTag("Enemy");
			GameObject[] array2 = array;
			foreach (GameObject gameObject in array2)
			{
				photonView.RPC("addZombiNewClientRPC", PhotonTargets.Others, player.ID, gameObject.GetComponent<ZombiUpravlenie>().typeZombInMas, gameObject.transform.position, gameObject.GetComponent<PhotonView>().viewID);
			}
		}
		if (photonView.isMine)
		{
			synchState();
		}
	}

	[RPC]
	private void addZombiNewClientRPC(int _playerId, int typeOfZomb, Vector3 pos, int _id)
	{
		Debug.Log(string.Empty + GetComponent<PhotonView>().owner.ID + " " + PhotonNetwork.player.ID);
		if (_playerId != PhotonNetwork.player.ID)
		{
			return;
		}
		GameObject[] array = GameObject.FindGameObjectsWithTag("Enemy");
		GameObject[] array2 = array;
		foreach (GameObject gameObject in array2)
		{
			if (gameObject.GetComponent<PhotonView>().viewID == _id)
			{
				return;
			}
		}
		GameObject gameObject2 = (GameObject)Object.Instantiate(zombiePrefabs[typeOfZomb], pos, Quaternion.identity);
		PhotonView component = gameObject2.GetComponent<PhotonView>();
		component.viewID = _id;
	}

	public void synchState()
	{
		if (PlayerPrefs.GetString("TypeConnect").Equals("inet"))
		{
			PhotonView photonView = PhotonView.Get(this);
			photonView.RPC("setState", PhotonTargets.OthersBuffered, NamePlayer, CountKills, oldCountKills, score);
			if (PlayerPrefs.GetInt("COOP", 0) == 1)
			{
				keychainPlugin.createKCValue(0, Defs.COOPScore);
				if (GlobalGameController.Score > keychainPlugin.getKCValue(Defs.COOPScore))
				{
					keychainPlugin.updateKCValue(GlobalGameController.Score, Defs.COOPScore);
				}
			}
		}
		else
		{
			base.GetComponent<NetworkView>().RPC("setState", RPCMode.OthersBuffered, NamePlayer, CountKills, oldCountKills);
		}
	}

	private void InitTwitter()
	{
		Debug.Log("InitTwitter(): init");
		if (GlobalGameController.isFullVersion)
		{
			TwitterBinding.init("Aw3DKZAHCPluVbLi9ZvUg", "amiSRlQgYmblYHsxJVZLu2t9Nvn6ogZKa2zclu8Lld4");
		}
		else
		{
			TwitterBinding.init("Jb7CwCaMgCQQiMViQRNHw", "zGVrax4vqgs3CYf04O7glsoRbNT3vhIafte6lfm8w");
		}
		if (!TwitterBinding.isLoggedIn())
		{
			TwitterLogin();
		}
		else
		{
			TwitterPost();
		}
	}

	private void TwitterLogin()
	{
		TwitterManager.loginSucceededEvent += OnTwitterLogin;
		TwitterManager.loginFailedEvent += OnTwitterLoginFailed;
		TwitterBinding.showOauthLoginDialog();
	}

	private void OnTwitterLogin()
	{
		TwitterManager.loginSucceededEvent -= OnTwitterLogin;
		TwitterManager.loginFailedEvent -= OnTwitterLoginFailed;
		TwitterPost();
	}

	private void OnTwitterLoginFailed(string _error)
	{
		TwitterManager.loginSucceededEvent -= OnTwitterLogin;
		TwitterManager.loginFailedEvent -= OnTwitterLoginFailed;
	}

	private void TwitterPost()
	{
		TwitterManager.postSucceededEvent += OnTwitterPost;
		TwitterManager.postFailedEvent += OnTwitterPostFailed;
		TwitterBinding.postStatusUpdate(_SocialMessage());
	}

	private void OnTwitterPost()
	{
		TwitterManager.postSucceededEvent -= OnTwitterPost;
		TwitterManager.postFailedEvent -= OnTwitterPostFailed;
		showMessagTiwtter = true;
		Invoke("hideMessagTwitter", 3f);
	}

	private void OnTwitterPostFailed(string _error)
	{
		TwitterManager.postSucceededEvent -= OnTwitterPost;
		TwitterManager.postFailedEvent -= OnTwitterPostFailed;
	}

	private void hideMessag()
	{
		showMessagFacebook = false;
	}

	private void hideMessagTwitter()
	{
		showMessagTiwtter = false;
	}

	private void InitFacebook()
	{
		clickButtonFacebook = true;
		if (!FacebookBinding.isSessionValid())
		{
			Debug.Log("!isSessionValid");
			string[] permissions = new string[1] { "email" };
			FacebookBinding.loginWithReadPermissions(permissions);
		}
		else
		{
			Debug.Log("isSessionValid");
			OnEventFacebookLogin();
		}
	}

	private void InitFacebookEvents()
	{
		FacebookManager.reauthorizationSucceededEvent += OnEventFacebookLogin;
		FacebookManager.loginFailedEvent += OnEventFacebookLoginFailed;
		FacebookManager.sessionOpenedEvent += OnEventFacebookLogin;
	}

	private void CleanFacebookEvents()
	{
		FacebookManager.reauthorizationSucceededEvent -= OnEventFacebookLogin;
		FacebookManager.loginFailedEvent -= OnEventFacebookLoginFailed;
		FacebookManager.sessionOpenedEvent -= OnEventFacebookLogin;
	}

	private void OnEventFacebookLogin()
	{
		if (!clickButtonFacebook)
		{
			return;
		}
		Debug.Log("OnEventFacebookLogin");
		if (FacebookBinding.isSessionValid())
		{
			if (_hasPublishPermission)
			{
				Debug.Log("sendMessag");
				clickButtonFacebook = false;
				showMessagFacebook = true;
				Invoke("hideMessag", 3f);
				Facebook.instance.postMessage(_SocialMessage(), completionHandler);
			}
			else
			{
				Debug.Log("poluchau permissions");
				string[] permissions = new string[2] { "publish_actions", "publish_stream" };
				FacebookBinding.reauthorizeWithPublishPermissions(permissions, FacebookSessionDefaultAudience.Everyone);
			}
		}
	}

	private void facebookGraphReqCompl(object result)
	{
		Utils.logObject(result);
	}

	private void facebookSessionOpened()
	{
		_hasPublishPermission = FacebookBinding.getSessionPermissions().Contains("publish_stream");
		_hasPublishActions = FacebookBinding.getSessionPermissions().Contains("publish_actions");
	}

	private void facebookreauthorizationSucceededEvent()
	{
		_hasPublishPermission = FacebookBinding.getSessionPermissions().Contains("publish_stream");
		_hasPublishActions = FacebookBinding.getSessionPermissions().Contains("publish_actions");
	}

	private void OnEventFacebookLoginFailed(string s)
	{
		clickButtonFacebook = false;
		Debug.Log("OnEventFacebookLoginFailed=" + s);
	}

	private void Start()
	{
		if (PlayerPrefs.GetInt("MultyPlayer") == 1 && PlayerPrefs.GetString("TypeConnect").Equals("local") && base.GetComponent<NetworkView>().isMine)
		{
			GameObject[] array = GameObject.FindGameObjectsWithTag("Bullet");
			for (int i = 0; i < array.Length; i++)
			{
				Object.Destroy(array[i]);
			}
		}
		InitFacebookEvents();
		FacebookBinding.init();
		FacebookBinding.setSessionLoginBehavior(FacebookSessionLoginBehavior.UseSystemAccountIfPresent);
		FacebookManager.graphRequestCompletedEvent += facebookGraphReqCompl;
		FacebookManager.sessionOpenedEvent += facebookSessionOpened;
		FacebookManager.reauthorizationSucceededEvent += facebookreauthorizationSucceededEvent;
		_canUserUseFacebookComposer = FacebookBinding.canUserUseFacebookComposer();
		PhotonView photonView = PhotonView.Get(this);
		if (PlayerPrefs.GetInt("COOP", 0) == 1 && PlayerPrefs.GetString("TypeConnect").Equals("inet") && photonView.isMine && PlayerPrefs.GetString("TypeGame").Equals("server"))
		{
			addZombiManager();
		}
		if ((bool)photonView && photonView.isMine)
		{
			GlobalGameController.Score = -1;
		}
		_purchaseActivityIndicator = StoreKitEventListener.purchaseActivityInd;
		zoneCreatePlayer = GameObject.FindGameObjectsWithTag("MultyPlayerCreateZone");
		_weaponManager = GameObject.FindGameObjectWithTag("WeaponManager").GetComponent<WeaponManager>();
		if (((PlayerPrefs.GetString("TypeConnect").Equals("local") && base.GetComponent<NetworkView>().isMine) || (PlayerPrefs.GetString("TypeConnect").Equals("inet") && photonView.isMine)) && PlayerPrefs.GetInt("MultyPlayer") == 1)
		{
			showTable = true;
			Debug.Log("add NetworkView");
			Vector3 position = new Vector3(17f, 11f, 17f);
			Quaternion rotation = Quaternion.Euler(new Vector3(39f, 226f, 0f));
			if (PlayerPrefs.GetString("MapName").Equals("Maze"))
			{
				position = new Vector3(23f, 5.25f, -20.5f);
				rotation = Quaternion.Euler(new Vector3(33f, -50f, 0f));
			}
			if (PlayerPrefs.GetString("MapName").Equals("Cementery"))
			{
				position = new Vector3(17f, 11f, 17f);
				rotation = Quaternion.Euler(new Vector3(39f, 226f, 0f));
			}
			if (PlayerPrefs.GetString("MapName").Equals("Hospital"))
			{
				position = new Vector3(9.5f, 3.2f, 9.5f);
				rotation = Quaternion.Euler(new Vector3(25f, -140f, 0f));
			}
			if (PlayerPrefs.GetString("MapName").Equals("City"))
			{
				position = new Vector3(17f, 11f, 17f);
				rotation = Quaternion.Euler(new Vector3(39f, 226f, 0f));
			}
			if (PlayerPrefs.GetString("MapName").Equals("Jail"))
			{
				position = new Vector3(13.5f, 2.9f, 3.1f);
				rotation = Quaternion.Euler(new Vector3(11f, -66f, 0f));
			}
			if (PlayerPrefs.GetString("MapName").Equals("Gluk"))
			{
				position = new Vector3(17f, 11f, 17f);
				rotation = Quaternion.Euler(new Vector3(39f, 226f, 0f));
			}
			if (PlayerPrefs.GetString("MapName").Equals("Pool"))
			{
				position = new Vector3(-17.36495f, 5.448204f, -5.605346f);
				rotation = Quaternion.Euler(new Vector3(31.34471f, 31.34471f, 0.2499542f));
			}
			if (PlayerPrefs.GetString("MapName").Equals("Assault"))
			{
				position = new Vector3(19.36158f, 19.61019f, -24.24763f);
				rotation = Quaternion.Euler(new Vector3(35.9299f, -11.80757f, -1.581451f));
			}
			if (PlayerPrefs.GetString("MapName").Equals("Level3_city"))
			{
				position = new Vector3(19.36158f, 19.61019f, -24.24763f);
				rotation = Quaternion.Euler(new Vector3(35.9299f, -11.80757f, -1.581451f));
			}
			if (PlayerPrefs.GetString("MapName").Equals("Level2_maze"))
			{
				position = new Vector3(19.36158f, 19.61019f, -24.24763f);
				rotation = Quaternion.Euler(new Vector3(35.9299f, -11.80757f, -1.581451f));
			}
			if (PlayerPrefs.GetString("MapName").Equals("Level3_city25"))
			{
				position = new Vector3(19.36158f, 19.61019f, -24.24763f);
				rotation = Quaternion.Euler(new Vector3(35.9299f, -11.80757f, -1.581451f));
			}
			if (PlayerPrefs.GetString("MapName").Equals("Slender"))
			{
				position = new Vector3(31.82355f, 5.959687f, 37.378f);
				rotation = Quaternion.Euler(new Vector3(36.08264f, -110.1159f, 2.307983f));
			}
			if (PlayerPrefs.GetString("MapName").Equals("Castle"))
			{
				position = new Vector3(-12.3107f, 4.9f, 0.2716838f);
				rotation = Quaternion.Euler(new Vector3(26.89935f, 89.99986f, 0f));
			}
			if (PlayerPrefs.GetString("MapName").Equals("Bridge"))
			{
				position = new Vector3(-14.22702f, 14.6011f, -74.93485f);
				rotation = Quaternion.Euler(new Vector3(24.68127f, -151.4293f, 0.2789154f));
			}
			if (PlayerPrefs.GetString("MapName").Equals("Farm"))
			{
				position = new Vector3(22.4933f, 16.03175f, -35.17904f);
				rotation = Quaternion.Euler(new Vector3(29.99995f, -28.62347f, 0f));
			}
			if (PlayerPrefs.GetString("MapName").Equals("Sky_islands"))
			{
				position = new Vector3(-3.111776f, 21.94557f, 25.31594f);
				rotation = Quaternion.Euler(new Vector3(41.94537f, -143.1731f, 6.383652f));
			}
			if (PlayerPrefs.GetString("MapName").Equals("Dust"))
			{
				position = new Vector3(-12.67253f, 6.92115f, 28.89415f);
				rotation = Quaternion.Euler(new Vector3(28.46265f, 147.2818f, 0.2389221f));
			}
			if (PlayerPrefs.GetString("MapName").Equals("Utopia"))
			{
				position = new Vector3(-10.62854f, 10.01794f, -51.20456f);
				rotation = Quaternion.Euler(new Vector3(13.26845f, 16.31204f, 1.440735f));
			}
			tc = Object.Instantiate(tempCam, position, rotation) as GameObject;
			ObjectLabel.currentCamera = tc.GetComponent<Camera>();
			tempCam.SetActive(true);
			_weaponManager = GameObject.FindGameObjectWithTag("WeaponManager").GetComponent<WeaponManager>();
			if (PlayerPrefs.GetString("TypeGame").Equals("server"))
			{
				addPlayer(PlayerPrefs.GetString("NamePlayer", Defs.defaultPlayerName), Network.player.ipAddress);
				if (PlayerPrefs.GetInt("MultyPlayer") == 1)
				{
					if (PlayerPrefs.GetString("TypeConnect").Equals("local"))
					{
						base.GetComponent<NetworkView>().RPC("addPlayer", RPCMode.OthersBuffered, PlayerPrefs.GetString("NamePlayer", Defs.defaultPlayerName), Network.player.ipAddress);
					}
					else
					{
						Debug.Log("addPlayer server  " + photonView);
						NamePlayer = PlayerPrefs.GetString("NamePlayer", Defs.defaultPlayerName);
						CountKills = -1;
						score = -1f;
						GlobalGameController.Score = -1;
						synchState();
						photonView.RPC("addPlayer", PhotonTargets.OthersBuffered, PlayerPrefs.GetString("NamePlayer", Defs.defaultPlayerName), Network.player.ipAddress);
					}
				}
				if (PlayerPrefs.GetString("TypeConnect").Equals("local"))
				{
					LANBroadcastService component = GetComponent<LANBroadcastService>();
					component.serverMessage.name = PlayerPrefs.GetString("ServerName");
					component.serverMessage.map = PlayerPrefs.GetString("MapName");
					component.serverMessage.connectedPlayers = 0;
					component.serverMessage.playerLimit = int.Parse(PlayerPrefs.GetString("PlayersLimits"));
					component.serverMessage.comment = PlayerPrefs.GetString("MaxKill");
					component.StartAnnounceBroadCasting();
				}
			}
			else if (PlayerPrefs.GetString("TypeConnect").Equals("local"))
			{
				base.GetComponent<NetworkView>().RPC("addPlayer", RPCMode.AllBuffered, PlayerPrefs.GetString("NamePlayer", Defs.defaultPlayerName), Network.player.ipAddress);
			}
			else
			{
				Debug.Log("addPlayer client  " + photonView);
				photonView.RPC("addPlayer", PhotonTargets.AllBuffered, PlayerPrefs.GetString("NamePlayer", Defs.defaultPlayerName), Network.player.ipAddress);
			}
			NamePlayer = PlayerPrefs.GetString("NamePlayer", Defs.defaultPlayerName);
			CountKills = -1;
			synchState();
		}
		else
		{
			showTable = false;
		}
	}

	private void Update()
	{
		if (PlayerPrefs.GetString("TypeConnect").Equals("local") && PlayerPrefs.GetString("TypeGame").Equals("server"))
		{
			LANBroadcastService component = GetComponent<LANBroadcastService>();
			if (component != null)
			{
				component.serverMessage.connectedPlayers = GameObject.FindGameObjectsWithTag("NetworkTable").Length;
			}
		}
		if (PlayerPrefs.GetString("TypeConnect").Equals("inet") && PlayerPrefs.GetInt("COOP") == 1)
		{
			PhotonView photonView = PhotonView.Get(this);
			if (photonView.isMine)
			{
				GameObject[] array = GameObject.FindGameObjectsWithTag("ZombiCreator");
				GameObject[] array2 = array;
				foreach (GameObject gameObject in array2)
				{
					if (gameObject.GetComponent<PhotonView>().owner != null)
					{
						continue;
					}
					GameObject[] array3 = GameObject.FindGameObjectsWithTag("NetworkTable");
					int viewID = array3[0].GetComponent<PhotonView>().viewID;
					GameObject gameObject2 = array3[0];
					GameObject[] array4 = array3;
					foreach (GameObject gameObject3 in array4)
					{
						if (gameObject3.GetComponent<PhotonView>().viewID < viewID)
						{
							gameObject2 = gameObject3;
							viewID = gameObject3.GetComponent<PhotonView>().viewID;
						}
					}
					if (gameObject2 == base.gameObject)
					{
						int viewID2 = PhotonNetwork.AllocateViewID();
						gameObject.GetComponent<PhotonView>().viewID = viewID2;
						GameObject[] array5 = GameObject.FindGameObjectsWithTag("Enemy");
						GameObject[] array6 = array5;
						foreach (GameObject gameObject4 in array6)
						{
							gameObject4.GetComponent<PhotonView>().viewID = PhotonNetwork.AllocateViewID();
						}
						Debug.Log("Set My Upravlenie");
					}
				}
			}
		}
		if (timerShow > 0f)
		{
			timerShow -= Time.deltaTime;
			if (timerShow < 0f)
			{
				_purchaseActivityIndicator.SetActive(false);
				ConnectGUI.Local();
			}
		}
	}

	private void OnDisconnectedFromServer(NetworkDisconnection info)
	{
		Debug.Log("OnDisconnectedFromServer");
		showDisconnectFromServer = true;
		timerShow = 3f;
	}

	private void OnPlayerDisconnected(NetworkPlayer player)
	{
		Debug.Log("Clean up after player " + player.ipAddress);
		Network.RemoveRPCs(player);
		Network.DestroyPlayerObjects(player);
		GameObject[] array = GameObject.FindGameObjectsWithTag("PlayerGun");
		GameObject[] array2 = array;
		foreach (GameObject gameObject in array2)
		{
			if (!player.ipAddress.Equals(gameObject.GetComponent<Player_move_c>().myIp))
			{
				continue;
			}
			GameObject[] array3 = GameObject.FindGameObjectsWithTag("ObjectLabel");
			GameObject[] array4 = array3;
			foreach (GameObject gameObject2 in array4)
			{
				if (gameObject2.GetComponent<ObjectLabel>().target == gameObject.transform)
				{
					Object.Destroy(gameObject2);
					break;
				}
			}
			Object.Destroy(gameObject.transform.parent.transform.gameObject);
		}
	}

	private void OnFailedToConnectToMasterServer(NetworkConnectionError info)
	{
		Debug.Log("Could not connect to master server: " + info);
		showDisconnectFromMasterServer = true;
		timerShow = 3f;
	}

	public void win(string winner)
	{
		PhotonView photonView = PhotonView.Get(this);
		nickPobeditelya = winner;
		GameObject[] array = GameObject.FindGameObjectsWithTag("NetworkTable");
		for (int i = 1; i < array.Length; i++)
		{
			GameObject gameObject = array[i];
			int num = i - 1;
			while (num >= 0 && ((PlayerPrefs.GetInt("COOP", 0) != 1) ? ((float)array[num].GetComponent<NetworkStartTable>().CountKills) : array[num].GetComponent<NetworkStartTable>().score) < ((PlayerPrefs.GetInt("COOP", 0) != 1) ? ((float)gameObject.GetComponent<NetworkStartTable>().CountKills) : gameObject.GetComponent<NetworkStartTable>().score))
			{
				array[num + 1] = array[num];
				num--;
			}
			array[num + 1] = gameObject;
		}
		oldSpisokName = new string[array.Length];
		oldCountLilsSpisok = new string[array.Length];
		for (int j = 0; j < array.Length; j++)
		{
			if (array[j].Equals(_weaponManager.myTable))
			{
				oldIndexMy = j;
				if (j == 0 && PlayerPrefs.GetInt("COOP", 0) == 1)
				{
					addCoins = 0;
					if (array[j].GetComponent<NetworkStartTable>().score >= 100f && array[j].GetComponent<NetworkStartTable>().score < 200f)
					{
						addCoins = 1;
					}
					if (array[j].GetComponent<NetworkStartTable>().score >= 200f && array[j].GetComponent<NetworkStartTable>().score < 300f)
					{
						addCoins = 2;
					}
					if (array[j].GetComponent<NetworkStartTable>().score >= 300f)
					{
						addCoins = 3;
					}
					if (addCoins > 0)
					{
						keychainPlugin.createKCValue(0, Defs.Coins);
						keychainPlugin.updateKCValue(keychainPlugin.getKCValue(Defs.Coins) + addCoins, Defs.Coins);
					}
				}
			}
			oldSpisokName[j] = array[j].GetComponent<NetworkStartTable>().NamePlayer;
			if (PlayerPrefs.GetInt("COOP", 0) == 1)
			{
				oldCountLilsSpisok[j] = ((array[j].GetComponent<NetworkStartTable>().score == -1f) ? (string.Empty + array[j].GetComponent<NetworkStartTable>().scoreOld) : (string.Empty + array[j].GetComponent<NetworkStartTable>().score));
			}
			else
			{
				oldCountLilsSpisok[j] = ((array[j].GetComponent<NetworkStartTable>().CountKills == -1) ? (string.Empty + array[j].GetComponent<NetworkStartTable>().oldCountKills) : (string.Empty + array[j].GetComponent<NetworkStartTable>().CountKills));
			}
		}
		oldCountKills = CountKills;
		scoreOld = score;
		score = -1f;
		GlobalGameController.Score = -1;
		CountKills = -1;
		synchState();
		ObjectLabel.currentCamera = tc.GetComponent<Camera>();
		if (PlayerPrefs.GetString("TypeConnect").Equals("local"))
		{
			Object.DestroyObject(_weaponManager.myPlayer);
			Debug.Log("NetworkView.DestroyObject(_weaponManager.myPlayer);" + _weaponManager.myPlayer);
		}
		else
		{
			PhotonNetwork.Destroy(_weaponManager.myPlayer);
			if (PlayerPrefs.GetInt("COOP", 0) == 1)
			{
				GameObject[] array2 = GameObject.FindGameObjectsWithTag("Enemy");
				for (int k = 0; k < array2.Length; k++)
				{
					Object.Destroy(array2[k]);
				}
			}
		}
		if (_cam != null)
		{
			_cam.SetActive(true);
		}
		isShowNickTable = true;
	}

	private void end()
	{
		Debug.Log("end");
		if (PlayerPrefs.GetString("TypeConnect").Equals("local"))
		{
			if (PlayerPrefs.GetString("TypeGame").Equals("server"))
			{
				Network.Disconnect(200);
				GameObject.FindGameObjectWithTag("NetworkTable").GetComponent<LANBroadcastService>().StopBroadCasting();
			}
			else if (Network.connections.Length == 1)
			{
				Debug.Log("Disconnecting: " + Network.connections[0].ipAddress + ":" + Network.connections[0].port);
				Network.CloseConnection(Network.connections[0], true);
			}
			_purchaseActivityIndicator.SetActive(false);
			ConnectGUI.Local();
		}
		else
		{
			PhotonNetwork.LeaveRoom();
		}
	}

	private void finishTable()
	{
		playersTable();
	}

	private void OnGUI()
	{
		Rect position = new Rect(0f, (float)Screen.height * 4f / 5f, Screen.width, (float)Screen.height - (float)Screen.height * 4f / 5f);
		messagesStyle.fontSize = Mathf.RoundToInt((float)(30 * Screen.height) / 768f);
		if (showDisconnectFromServer)
		{
			GUI.Label(position, "Server left the game...", messagesStyle);
		}
		if (showDisconnectFromMasterServer)
		{
			GUI.Label(position, "Master Server error", messagesStyle);
		}
		if (showTable)
		{
			playersTable();
		}
		if (isShowNickTable)
		{
			finishTable();
		}
		if (showMessagFacebook)
		{
			labelStyle.fontSize = Player_move_c.FontSizeForMessages;
			GUI.Label(Player_move_c.SuccessMessageRect(), _SocialSentSuccess("Facebook"), labelStyle);
		}
		if (showMessagTiwtter)
		{
			labelStyle.fontSize = Player_move_c.FontSizeForMessages;
			GUI.Label(Player_move_c.SuccessMessageRect(), _SocialSentSuccess("Twitter"), labelStyle);
		}
	}

	private void OnConnectedToServer()
	{
		Debug.Log("OnConnectedToServer");
	}

	private void OnDestroy()
	{
		CleanFacebookEvents();
	}
}
