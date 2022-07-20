using UnityEngine;

public class SkinName : MonoBehaviour
{
	public GameObject playerGameObject;

	public string skinName;

	public string NickName;

	public GameObject camPlayer;

	public CharacterController character;

	public PhotonView photonView;

	public int typeAnim;

	public WeaponManager _weaponManager;

	[RPC]
	private void setAnim(NetworkViewID id, int _typeAnim)
	{
		GameObject[] array = GameObject.FindGameObjectsWithTag("Player");
		GameObject[] array2 = array;
		foreach (GameObject gameObject in array2)
		{
			if (!id.Equals(gameObject.GetComponent<NetworkView>().viewID))
			{
				continue;
			}
			{
				foreach (Transform item in gameObject.transform)
				{
					if (item.gameObject.name.Equals("FPS_Player"))
					{
						string text;
						switch (_typeAnim)
						{
						case 0:
							text = "Idle";
							break;
						case 1:
							text = "Walk";
							break;
						case 2:
							text = "Jump";
							break;
						default:
							text = "Dead";
							break;
						}
						item.GetComponent<Animation>().Play(text);
						break;
					}
				}
				break;
			}
		}
	}

	[RPC]
	private void setAnimPhoton(int id, int _typeAnim)
	{
		GameObject[] array = GameObject.FindGameObjectsWithTag("Player");
		GameObject[] array2 = array;
		foreach (GameObject gameObject in array2)
		{
			if (id != gameObject.GetComponent<PhotonView>().viewID)
			{
				continue;
			}
			{
				foreach (Transform item in gameObject.transform)
				{
					if (item.gameObject.name.Equals("FPS_Player"))
					{
						string text;
						switch (_typeAnim)
						{
						case 0:
							text = "Idle";
							break;
						case 1:
							text = "Walk";
							break;
						case 2:
							text = "Jump";
							break;
						default:
							text = "Dead";
							break;
						}
						item.GetComponent<Animation>().Play(text);
						break;
					}
				}
				break;
			}
		}
	}

	private void Start()
	{
		_weaponManager = GameObject.FindGameObjectWithTag("WeaponManager").GetComponent<WeaponManager>();
		character = base.transform.GetComponent<CharacterController>();
		photonView = PhotonView.Get(this);
		if (((PlayerPrefs.GetString("TypeConnect").Equals("local") && !base.GetComponent<NetworkView>().isMine) || (PlayerPrefs.GetString("TypeConnect").Equals("inet") && !photonView.isMine)) && PlayerPrefs.GetInt("MultyPlayer") == 1)
		{
			camPlayer.active = false;
			character.enabled = false;
		}
		else
		{
			base.transform.Find("FPS_Player").gameObject.SetActive(false);
		}
	}

	private void Update()
	{
		if (PlayerPrefs.GetInt("MultyPlayer") != 1 || ((!PlayerPrefs.GetString("TypeConnect").Equals("local") || !base.GetComponent<NetworkView>().isMine) && (!PlayerPrefs.GetString("TypeConnect").Equals("inet") || !photonView.isMine)))
		{
			return;
		}
		int num = 0;
		if (character.velocity.y > 0.01f || character.velocity.y < -0.01f)
		{
			num = 2;
		}
		else if (character.velocity.x != 0f || character.velocity.z != 0f)
		{
			num = 1;
		}
		if (num != typeAnim)
		{
			typeAnim = num;
			if (PlayerPrefs.GetString("TypeConnect").Equals("local") && base.GetComponent<NetworkView>().isMine)
			{
				Debug.Log("send setAnim " + typeAnim);
				base.GetComponent<NetworkView>().RPC("setAnim", RPCMode.All, GetComponent<NetworkView>().viewID, typeAnim);
			}
			if (PlayerPrefs.GetString("TypeConnect").Equals("inet") && photonView.isMine)
			{
				photonView.RPC("setAnimPhoton", PhotonTargets.All, GetComponent<PhotonView>().viewID, typeAnim);
			}
		}
	}

	private void OnControllerColliderHit(ControllerColliderHit col)
	{
		if (PlayerPrefs.GetInt("MultyPlayer") == 1 && ((PlayerPrefs.GetString("TypeConnect").Equals("local") && base.GetComponent<NetworkView>().isMine) || (PlayerPrefs.GetString("TypeConnect").Equals("inet") && photonView.isMine)) && col.collider.gameObject.name.Equals("DeadCollider") && playerGameObject.GetComponent<Player_move_c>().CurHealth > 0f)
		{
			playerGameObject.GetComponent<Player_move_c>().curArmor = 0f;
			playerGameObject.GetComponent<Player_move_c>().CurHealth = 0f;
			if (playerGameObject.GetComponent<Player_move_c>().countKills > 0)
			{
				playerGameObject.GetComponent<Player_move_c>().countKills--;
			}
			_weaponManager.myTable.GetComponent<NetworkStartTable>().CountKills = playerGameObject.GetComponent<Player_move_c>().countKills;
			_weaponManager.myTable.GetComponent<NetworkStartTable>().synchState();
			playerGameObject.GetComponent<Player_move_c>().sendImDeath(NickName);
			Debug.Log("DeadCollider");
		}
	}
}
