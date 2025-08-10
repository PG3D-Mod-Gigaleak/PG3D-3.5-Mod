using System.Collections;
using UnityEngine;

public class ZombiUpravlenie : MonoBehaviour
{
	public delegate void DelayedCallback();

	public GameObject playerKill;

	private Player_move_c healthDown;

	private GameObject player;

	private float CurLifeTime;

	private string idleAnim = "Idle";

	private string normWalkAnim = "Norm_Walk";

	private string zombieWalkAnim = "Zombie_Walk";

	private string offAnim = "Zombie_Off";

	private string deathAnim = "Zombie_Dead";

	private string onAnim = "Zombie_On";

	private string attackAnim = "Zombie_Attack";

	private string shootAnim;

	private GameObject _modelChild;

	private Sounds _soundClips;

	private bool falling;

	private UnityEngine.AI.NavMeshAgent _nma;

	private BoxCollider _modelChildCollider;

	private ZombiManager _gameController;

	private bool deaded;

	public Transform target;

	public float health;

	private PhotonView photonView;

	public Texture hitTexture;

	private Texture _skin;

	private static SkinsManagerPixlGun _skinsManager;

	private bool _flashing;

	public int typeZombInMas;

	private float timeToUpdateTarget = 5f;

	private float timeToUpdateNavMesh;

	public int tekAnim = -1;

		public string myCAnim(string a){
        return Defs.CAnim(base.transform.GetChild(0).gameObject, a);
    }

	private void Awake()
	{
		_modelChild = base.transform.GetChild(0).gameObject;
		health = _modelChild.GetComponent<Sounds>().health;
		if (PlayerPrefs.GetInt("COOP") != 1)
		{
			base.enabled = false;
		}
	}

	[RPC]
	private void setHealthRPC(float _health)
	{
		health = _health;
	}

	[RPC]
	private void flashRPC()
	{
	}

	public void setHealth(float _health, bool isFlash)
	{
		photonView.RPC("setHealthRPC", PhotonTargets.All, _health);
		Debug.Log("setHealth=" + _health);
		if (isFlash && !_flashing)
		{
			StartCoroutine(Flash());
			photonView.RPC("flashRPC", PhotonTargets.Others);
		}
	}

	public static Texture SetSkinForObj(GameObject go)
	{
		if (!_skinsManager)
		{
			_skinsManager = GameObject.FindGameObjectWithTag("SkinsManager").GetComponent<SkinsManagerPixlGun>();
		}
		Texture texture = null;
		string text = SkinNameForObj(go.name);
		if (!(texture = _skinsManager.skins[text] as Texture))
		{
			Debug.Log("No skin: " + text);
		}
		SetTextureRecursivelyFrom(go, texture);
		return texture;
	}

	public static string SkinNameForObj(string objName)
	{
		return objName;
	}

	public static void SetTextureRecursivelyFrom(GameObject obj, Texture txt)
	{
		foreach (Transform item in obj.transform)
		{
			if ((bool)item.gameObject.GetComponent<Renderer>() && (bool)item.gameObject.GetComponent<Renderer>().material)
			{
				if (item.gameObject.GetComponent<Renderer>().materials.Length > 1 && item.gameObject.name.Equals("raven_head"))
				{
					Material[] materials = item.gameObject.GetComponent<Renderer>().materials;
					foreach (Material material in materials)
					{
						if (material.name.Equals("raven_eye (Instance)"))
						{
							if (GlobalGameController.currentLevel == 6)
							{
								material.color = new Color(0.32156864f, 0f, 44f / 85f);
							}
						}
						else
						{
							material.mainTexture = txt;
						}
					}
				}
				else
				{
					item.gameObject.GetComponent<Renderer>().material.mainTexture = txt;
				}
			}
			SetTextureRecursivelyFrom(item.gameObject, txt);
		}
	}

	private IEnumerator Flash()
	{
		_flashing = true;
		SetTextureRecursivelyFrom(_modelChild, hitTexture);
		yield return new WaitForSeconds(0.125f);
		SetTextureRecursivelyFrom(_modelChild, _skin);
		_flashing = false;
	}

	private void Start()
	{
		_skin = SetSkinForObj(_modelChild);
		_nma = GetComponent<UnityEngine.AI.NavMeshAgent>();
		_modelChildCollider = _modelChild.GetComponent<BoxCollider>();
		shootAnim = offAnim;
		player = GameObject.FindGameObjectWithTag("Player");
		_gameController = GameObject.FindGameObjectWithTag("ZombiCreator").GetComponent<ZombiManager>();
		_soundClips = _modelChild.GetComponent<Sounds>();
		CurLifeTime = _soundClips.timeToHit;
		target = null;
		_modelChild.GetComponent<Animation>().Stop();
		Walk();
		_soundClips.attackingSpeed += Random.Range(0f - _soundClips.attackingSpeedRandomRange[0], _soundClips.attackingSpeedRandomRange[1]);
		photonView = PhotonView.Get(this);
		_skin = SetSkinForObj(_modelChild);
		if (photonView.isMine)
		{
			photonView.RPC("setHealthRPC", PhotonTargets.All, _soundClips.health);
		}
	}

	private void Update()
	{
		if (!photonView.isMine)
		{
			return;
		}
		if (!deaded)
		{
			if (target != null && timeToUpdateTarget > 0f)
			{
				timeToUpdateTarget -= Time.deltaTime;
				float num = Vector3.Distance(target.position, base.transform.position);
				Vector3 vector = new Vector3(target.position.x, base.transform.position.y, target.position.z);
				if (num >= _soundClips.attackDistance)
				{
					timeToUpdateNavMesh -= Time.deltaTime;
					if (timeToUpdateNavMesh < 0f)
					{
						_nma.SetDestination(vector);
						_nma.speed = _soundClips.attackingSpeed * Mathf.Pow(1.05f, GlobalGameController.AllLevelsCompleted);
						timeToUpdateNavMesh = 0.5f;
					}
					CurLifeTime = _soundClips.timeToHit;
					PlayZombieRun();
				}
				else
				{
					if (_nma.path != null)
					{
						_nma.ResetPath();
					}
					CurLifeTime -= Time.deltaTime;
					base.transform.LookAt(vector);
					if (CurLifeTime <= 0f)
					{
						CurLifeTime = _soundClips.timeToHit;
						if (PlayerPrefsX.GetBool(PlayerPrefsX.SndSetting, true))
						{
							base.GetComponent<AudioSource>().PlayOneShot(_soundClips.bite);
						}
						target.transform.Find("GameObject").GetComponent<Player_move_c>().minusLiveFromZombi(_soundClips.damagePerHit);
					}
					PlayZombieAttack();
				}
			}
			else
			{
				GameObject[] array = GameObject.FindGameObjectsWithTag("Player");
				if (array.Length > 0)
				{
					Debug.Log("new target");
					timeToUpdateTarget = 5f;
					float num2 = Vector3.Distance(base.transform.position, array[0].transform.position);
					target = array[0].transform;
					GameObject[] array2 = array;
					foreach (GameObject gameObject in array2)
					{
						float num3 = Vector3.Distance(base.transform.position, gameObject.transform.position);
						Debug.Log(string.Concat("player", player, " dist=", num3));
						if (num3 < num2)
						{
							num2 = Vector3.Distance(base.transform.position, gameObject.transform.position);
							target = gameObject.transform;
						}
					}
				}
			}
			if (health <= 0f)
			{
				photonView.RPC("Death", PhotonTargets.AllBuffered);
			}
		}
		else if (falling)
		{
			float num4 = 7f;
			base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y - num4 * Time.deltaTime, base.transform.position.z);
		}
	}

	[RPC]
	private void Death()
	{
		if (PlayerPrefs.GetInt("COOP", 0) == 1)
		{
			if (_nma != null)
			{
				_nma.enabled = false;
			}
			float num = 0.1f;
			if (PlayerPrefsX.GetBool(PlayerPrefsX.SndSetting, true) && _soundClips != null)
			{
				base.GetComponent<AudioSource>().PlayOneShot(_soundClips.death);
				num = _soundClips.death.length;
			}
			_modelChild.GetComponent<Animation>().Stop();
			if ((bool)_modelChild.GetComponent<Animation>()[myCAnim(deathAnim)])
			{
				_modelChild.GetComponent<Animation>().Play(myCAnim(deathAnim));
				num = Mathf.Max(num, _modelChild.GetComponent<Animation>()[myCAnim(deathAnim)].length);
				CodeAfterDelay(_modelChild.GetComponent<Animation>()[myCAnim(deathAnim)].length * 1.25f, StartFall);
			}
			else
			{
				StartFall();
			}
			CodeAfterDelay(num, DestroySelf);
			_modelChild.GetComponent<BoxCollider>().enabled = false;
			deaded = true;
			SpawnMonster component = GetComponent<SpawnMonster>();
			component.ShouldMove = false;
		}
	}

	private void DestroySelf()
	{
		Object.Destroy(base.gameObject);
	}

	private void StartFall()
	{
		falling = true;
	}

	private void Walk()
	{
		_modelChild.GetComponent<Animation>().Stop();
		if ((bool)_modelChild.GetComponent<Animation>()[myCAnim(normWalkAnim)])
		{
			_modelChild.GetComponent<Animation>().CrossFade(myCAnim(normWalkAnim));
		}
		else
		{
			_modelChild.GetComponent<Animation>().CrossFade(myCAnim(zombieWalkAnim));
		}
	}

	public void PlayZombieRun()
	{
		if (tekAnim != 1 && PlayerPrefs.GetInt("COOP", 0) == 1)
		{
			if ((bool)_modelChild.GetComponent<Animation>()[myCAnim(zombieWalkAnim)])
			{
				_modelChild.GetComponent<Animation>().CrossFade(myCAnim(zombieWalkAnim));
			}
			photonView.RPC("PlayZombieRunRPC", PhotonTargets.Others);
		}
		tekAnim = 1;
	}

	public void PlayZombieAttack()
	{
		if (tekAnim != 2 && PlayerPrefs.GetInt("COOP", 0) == 1)
		{
			if ((bool)_modelChild.GetComponent<Animation>()[myCAnim(attackAnim)])
			{
				_modelChild.GetComponent<Animation>().CrossFade(myCAnim(attackAnim));
			}
			else if ((bool)_modelChild.GetComponent<Animation>()[myCAnim(shootAnim)])
			{
				_modelChild.GetComponent<Animation>().CrossFade(myCAnim(shootAnim));
			}
			photonView.RPC("PlayZombieAttackRPC", PhotonTargets.Others);
		}
		tekAnim = 2;
	}

	[RPC]
	public void PlayZombieRunRPC()
	{
		if ((bool)_modelChild.GetComponent<Animation>()[myCAnim(zombieWalkAnim)])
		{
			_modelChild.GetComponent<Animation>().CrossFade(myCAnim(zombieWalkAnim));
		}
		tekAnim = 1;
	}

	[RPC]
	public void PlayZombieAttackRPC()
	{
		if ((bool)_modelChild.GetComponent<Animation>()[myCAnim(attackAnim)])
		{
			_modelChild.GetComponent<Animation>().CrossFade(myCAnim(attackAnim));
		}
		else if ((bool)_modelChild.GetComponent<Animation>()[myCAnim(shootAnim)])
		{
			_modelChild.GetComponent<Animation>().CrossFade(myCAnim(shootAnim));
		}
		tekAnim = 2;
	}

	public void CodeAfterDelay(float delay, DelayedCallback callback)
	{
		StartCoroutine(___DelayedCallback(delay, callback));
	}

	private IEnumerator ___DelayedCallback(float time, DelayedCallback callback)
	{
		yield return new WaitForSeconds(time);
		callback();
	}
}
