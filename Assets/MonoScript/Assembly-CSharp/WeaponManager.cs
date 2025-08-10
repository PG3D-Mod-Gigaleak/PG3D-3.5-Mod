using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
	public struct infoClient
	{
		public string ipAddress;

		public string name;

		public string coments;
	}

	public UnityEngine.Object[] weapons3 = new UnityEngine.Object[24];

	public static string CrystalSwordTag = "CrystalSword";

	public static string MinersWeaponTag = "MinersWeapon";

	public static string[] multiplayerWeaponTags = new string[24]
	{
		MultiplayerMeleeTag, _initialWeaponName, "FirstShotgun", "UziWeapon", CrystalSwordTag, MinersWeaponTag, "m16", "Eagle 1", MagicBowTag, "GoldenAxe",
		"SPAS", "Glock", "FAMAS", "Chainsaw", "Scythe", "Shovel", "AK47", "M249MachinegunWeapon", "Colt45Weapon", "OGUzi", "Hammer", "Sword_2", "Staff",
		"Red_Stone"
	};

	public string myCAnim(string a){
        return Defs.CAnim(currentWeaponSounds.animationObject, a);
    }

	private static string[] _initialMultiplayerWeaponTags = new string[5]
	{
		multiplayerWeaponTags[0],
		multiplayerWeaponTags[1],
		multiplayerWeaponTags[2],
		multiplayerWeaponTags[3],
		multiplayerWeaponTags[19]
	};

	public HostData hostDataServer;

	public string ServerIp;

	public GameObject myPlayer;

	public GameObject myGun;

	public GameObject myTable;

	private UnityEngine.Object[] _weaponsInGame;

	private ArrayList _playerWeapons = new ArrayList();

	public int CurrentWeaponIndex;

	public Camera useCam;

	private WeaponSounds _currentWeaponSounds = new WeaponSounds();

	private Dictionary<string, Action> _purchaseActinos = new Dictionary<string, Action>();

	public List<infoClient> players = new List<infoClient>();

	public static string _initialWeaponName
	{
		get
		{
			return "FirstPistol";
		}
	}
	public static string _uziWeaponName
	{
		get
		{
			return "Weapon20";
		}
	}

	public static string Sword2WeaponName
	{
		get
		{
			return "Weapon22";
		}
	}

	public static string PickWeaponName
	{
		get
		{
			return "Weapon6";
		}
	}

	public static string MultiplayerMeleeTag
	{
		get
		{
			return "Knife";
		}
	}

	public static string SwordWeaponName
	{
		get
		{
			return "Weapon7";
		}
	}

	public static string CombatRifleWeaponName
	{
		get
		{
			return "Weapon10";
		}
	}

	public static string OGUziName
	{
		get
		{
			return "Weapon20";
		}
	}

	public static string GoldenEagleWeaponName
	{
		get
		{
			return "Weapon11";
		}
	}

	public static string PigHammerWeaponName
	{
		get
		{
			return "Weapon21";
		}
	}

	public static string MagicBowWeaponName
	{
		get
		{
			return "Weapon12";
		}
	}

	public static string SpasWeaponName
	{
		get
		{
			return "Weapon13";
		}
	}

	public static string GoldenAxeWeaponnName
	{
		get
		{
			return "Weapon14";
		}
	}

	public static string ChainsawWN
	{
		get
		{
			return "Weapon15";
		}
	}

	public static string FAMASWN
	{
		get
		{
			return "Weapon16";
		}
	}

	public static string GlockWN
	{
		get
		{
			return "Weapon17";
		}
	}

	public static string ScytheWN
	{
		get
		{
			return "Weapon18";
		}
	}

	public static string ShovelWN
	{
		get
		{
			return "Weapon19";
		}
	}

	public static string MagicBowTag
	{
		get
		{
			return "Bow";
		}
	}

	public UnityEngine.Object[] weaponsInGame
	{
		get
		{
			return _weaponsInGame;
		}
	}

	public ArrayList playerWeapons
	{
		get
		{
			return _playerWeapons;
		}
	}

	public WeaponSounds currentWeaponSounds
	{
		get
		{
			return _currentWeaponSounds;
		}
		set
		{
			_currentWeaponSounds = value;
		}
	}

	private UnityEngine.Object[] GetWeaponPrefabs()
	{
		return Resources.LoadAll("Weapons");
	}

	public void Reset()
	{
		_playerWeapons.Clear();
		CurrentWeaponIndex = 0;
		UnityEngine.Object[] array = weapons3;
		for (int i = 0; i < array.Length; i++)
		{
			GameObject gameObject = array[i] as GameObject;
			if (/*gameObject.CompareTag(_initialWeaponName) || (PlayerPrefs.GetInt("MultyPlayer") == 1 && Array.IndexOf(_initialMultiplayerWeaponTags, gameObject.tag) >= 0)*/true)
			{
				Weapon weapon = new Weapon();
				weapon.weaponPrefab = gameObject;
				weapon.currentAmmoInBackpack = weapon.weaponPrefab.GetComponent<WeaponSounds>().InitialAmmo;
				weapon.currentAmmoInClip = weapon.weaponPrefab.GetComponent<WeaponSounds>().ammoInClip;
				_playerWeapons.Add(weapon);
				if (PlayerPrefs.GetInt("MultyPlayer") != 1)
				{
					break;
				}
			}
		}
		Debug.Log("_playerWeapons.count=" + _playerWeapons.Count);
		AddWeaponIfBought(Defs.MinerWeaponSett, PickWeaponName);
		string swordSett = Defs.SwordSett;
		string swordWeaponName = SwordWeaponName;
		AddWeaponIfBought(swordSett, swordWeaponName);
		AddWeaponIfBought(Defs.GoldenAxeSett, GoldenAxeWeaponnName);
		AddWeaponIfBought(Defs.SPASSett, SpasWeaponName);
		AddWeaponIfBought(Defs.ChainsawS, ChainsawWN);
		AddWeaponIfBought(Defs.GlockSett, GlockWN);
		AddWeaponIfBought(Defs.ScytheSN, ScytheWN);
		AddWeaponIfBought(Defs.ShovelSN, ShovelWN);
		if (PlayerPrefs.GetInt("MultyPlayer") == 1)
		{
			AddWeaponIfBought(Defs.CombatRifleSett, CombatRifleWeaponName);
			AddWeaponIfBought(Defs.GoldenEagleSett, GoldenEagleWeaponName);
			AddWeaponIfBought(Defs.MagicBowSett, MagicBowWeaponName);
			AddWeaponIfBought(Defs.FAMASS, FAMASWN);
		}
		playerWeapons.Sort(new WeaponsComparer());
	}

	private void AddWeaponIfBought(string settName, string prefabName)
	{
		if (Storager.getInt(settName) <= 0)
		{
			return;
		}
		UnityEngine.Object[] array = weapons3;
		for (int i = 0; i < array.Length; i++)
		{
			GameObject gameObject = array[i] as GameObject;
			if (gameObject.name.Equals(prefabName))
			{
				Weapon weapon = new Weapon();
				weapon.weaponPrefab = gameObject;
				weapon.currentAmmoInBackpack = weapon.weaponPrefab.GetComponent<WeaponSounds>().InitialAmmo;
				weapon.currentAmmoInClip = weapon.weaponPrefab.GetComponent<WeaponSounds>().ammoInClip;
				_playerWeapons.Add(weapon);
				break;
			}
		}
	}

	public bool AddWeapon(GameObject weaponPrefab, out int score)
	{
		score = 0;
		foreach (Weapon playerWeapon in playerWeapons)
		{
			if (playerWeapon.weaponPrefab.CompareTag(weaponPrefab.tag))
			{
				int idx = playerWeapons.IndexOf(playerWeapon);
				if (!AddAmmo(idx))
				{
					score += Defs.ScoreForSurplusAmmo;
				}
				return false;
			}
		}
		Weapon weapon2 = new Weapon();
		weapon2.weaponPrefab = weaponPrefab;
		weapon2.currentAmmoInBackpack = weapon2.weaponPrefab.GetComponent<WeaponSounds>().InitialAmmo;
		weapon2.currentAmmoInClip = weapon2.weaponPrefab.GetComponent<WeaponSounds>().ammoInClip;
		playerWeapons.Add(weapon2);
		playerWeapons.Sort(new WeaponsComparer());
		CurrentWeaponIndex = playerWeapons.IndexOf(weapon2);
		return true;
	}

	public GameObject GetPickPrefab()
	{
		UnityEngine.Object[] array = weapons3;
		for (int i = 0; i < array.Length; i++)
		{
			GameObject gameObject = array[i] as GameObject;
			if (gameObject.name.Equals(PickWeaponName))
			{
				return gameObject;
			}
		}
		return null;
	}

	public GameObject GetSwordPrefab()
	{
		UnityEngine.Object[] array = weapons3;
		for (int i = 0; i < array.Length; i++)
		{
			GameObject gameObject = array[i] as GameObject;
			if (gameObject.name.Equals(SwordWeaponName))
			{
				return gameObject;
			}
		}
		return null;
	}

	public GameObject GetCombatRiflePrefab()
	{
		UnityEngine.Object[] array = weapons3;
		for (int i = 0; i < array.Length; i++)
		{
			GameObject gameObject = array[i] as GameObject;
			if (gameObject.name.Equals(CombatRifleWeaponName))
			{
				return gameObject;
			}
		}
		return null;
	}

	public GameObject GetGoldenEaglePrefab()
	{
		UnityEngine.Object[] array = weapons3;
		for (int i = 0; i < array.Length; i++)
		{
			GameObject gameObject = array[i] as GameObject;
			if (gameObject.name.Equals(GoldenEagleWeaponName))
			{
				return gameObject;
			}
		}
		return null;
	}

	public GameObject GetMagicBowPrefab()
	{
		UnityEngine.Object[] array = weapons3;
		for (int i = 0; i < array.Length; i++)
		{
			GameObject gameObject = array[i] as GameObject;
			if (gameObject.name.Equals(MagicBowWeaponName))
			{
				return gameObject;
			}
		}
		return null;
	}

	public GameObject GetSPASPrefab()
	{
		UnityEngine.Object[] array = weapons3;
		for (int i = 0; i < array.Length; i++)
		{
			GameObject gameObject = array[i] as GameObject;
			if (gameObject.name.Equals(SpasWeaponName))
			{
				return gameObject;
			}
		}
		return null;
	}

	public GameObject GetAxePrefab()
	{
		UnityEngine.Object[] array = weapons3;
		for (int i = 0; i < array.Length; i++)
		{
			GameObject gameObject = array[i] as GameObject;
			if (gameObject.name.Equals(GoldenAxeWeaponnName))
			{
				return gameObject;
			}
		}
		return null;
	}

	public GameObject GetChainsawPrefab()
	{
		UnityEngine.Object[] array = weapons3;
		for (int i = 0; i < array.Length; i++)
		{
			GameObject gameObject = array[i] as GameObject;
			if (gameObject.name.Equals(ChainsawWN))
			{
				return gameObject;
			}
		}
		return null;
	}

	public GameObject GetGlockPrefab()
	{
		UnityEngine.Object[] array = weapons3;
		for (int i = 0; i < array.Length; i++)
		{
			GameObject gameObject = array[i] as GameObject;
			if (gameObject.name.Equals(GlockWN))
			{
				return gameObject;
			}
		}
		return null;
	}

	public GameObject GetFAMASPrefab()
	{
		UnityEngine.Object[] array = weapons3;
		for (int i = 0; i < array.Length; i++)
		{
			GameObject gameObject = array[i] as GameObject;
			if (gameObject.name.Equals(FAMASWN))
			{
				return gameObject;
			}
		}
		return null;
	}

	public GameObject GetScythePrefab()
	{
		UnityEngine.Object[] array = weapons3;
		for (int i = 0; i < array.Length; i++)
		{
			GameObject gameObject = array[i] as GameObject;
			if (gameObject.name.Equals(ScytheWN))
			{
				return gameObject;
			}
		}
		return null;
	}

	public GameObject GetShovelPrefab()
	{
		UnityEngine.Object[] array = weapons3;
		for (int i = 0; i < array.Length; i++)
		{
			GameObject gameObject = array[i] as GameObject;
			if (gameObject.name.Equals(ShovelWN))
			{
				return gameObject;
			}
		}
		return null;
	}

	public bool AddAmmo(int idx = -1)
	{
		if (idx == -1)
		{
			idx = CurrentWeaponIndex;
		}
		if (idx == CurrentWeaponIndex && currentWeaponSounds.isMelee)
		{
			return false;
		}
		Weapon weapon = (Weapon)playerWeapons[idx];
		WeaponSounds component = weapon.weaponPrefab.GetComponent<WeaponSounds>();
		if (weapon.currentAmmoInBackpack < component.MaxAmmoWithRespectToInApp)
		{
			weapon.currentAmmoInBackpack += component.ammoInClip;
			if (weapon.currentAmmoInBackpack > component.MaxAmmoWithRespectToInApp)
			{
				weapon.currentAmmoInBackpack = component.MaxAmmoWithRespectToInApp;
			}
			return true;
		}
		return false;
	}

	public void SetMaxAmmoFrAllWeapons()
	{
		foreach (Weapon playerWeapon in playerWeapons)
		{
			playerWeapon.currentAmmoInClip = playerWeapon.weaponPrefab.GetComponent<WeaponSounds>().ammoInClip;
			playerWeapon.currentAmmoInBackpack = playerWeapon.weaponPrefab.GetComponent<WeaponSounds>().MaxAmmoWithRespectToInApp;
		}
	}

	private void Start()
	{
		for (int i = 1; i < 24; i++ )
		{
			weapons3[i - 1] = Resources.Load("Weapons/Weapon" + i);
		}
		weapons3[23] = Resources.Load("Weapons/Weapon24");
		_purchaseActinos.Add(StoreKitEventListener.minerWeaponID, AddMinerWeaponToInventoryAndSaveInApp);
		_purchaseActinos.Add(StoreKitEventListener.crystalswordID, AddSwordToInventoryAndSaveInApp);
		_purchaseActinos.Add(StoreKitEventListener.combatrifle, AddCombatRifle);
		_purchaseActinos.Add(StoreKitEventListener.goldeneagle, AddGoldenEagle);
		_purchaseActinos.Add(StoreKitEventListener.magicbow, AddMagicBow);
		_purchaseActinos.Add(StoreKitEventListener.axe, AddGoldenAxe);
		_purchaseActinos.Add(StoreKitEventListener.spas, AddSPAS);
		_purchaseActinos.Add(StoreKitEventListener.chainsaw, AddChainsaw);
		_purchaseActinos.Add(StoreKitEventListener.glock, AddGlock);
		_purchaseActinos.Add(StoreKitEventListener.famas, AddFAMAS);
		_purchaseActinos.Add(StoreKitEventListener.scythe, AddScythe);
		_purchaseActinos.Add(StoreKitEventListener.shovel, AddShovel);
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		StoreKitManager.purchaseSuccessfulEvent += AddMinerWeapon;
		_weaponsInGame = GetWeaponPrefabs();
		Reset();
	}

	public void AddGoldenAxe()
	{
		Player_move_c.SaveMGoldenAxeInPrefs();
		int score;
		AddWeapon(GetAxePrefab(), out score);
	}

	public void AddSPAS()
	{
		Player_move_c.SaveSPASInPrefs();
		int score;
		AddWeapon(GetSPASPrefab(), out score);
	}

	public void AddChainsaw()
	{
		Player_move_c.SaveChainsawInPrefs();
		int score;
		AddWeapon(GetChainsawPrefab(), out score);
	}

	public void AddGlock()
	{
		Player_move_c.SaveGlockInPrefs();
		int score;
		AddWeapon(GetGlockPrefab(), out score);
	}

	public void AddFAMAS()
	{
		Player_move_c.SaveFAMASPrefs();
		int score;
		AddWeapon(GetFAMASPrefab(), out score);
	}

	public void AddScythe()
	{
		Player_move_c.SaveScytheInPrefs();
		int score;
		AddWeapon(GetScythePrefab(), out score);
	}

	public void AddShovel()
	{
		Player_move_c.SaveShovelPrefs();
		int score;
		AddWeapon(GetShovelPrefab(), out score);
	}

	public void AddMinerWeaponToInventoryAndSaveInApp()
	{
		Player_move_c.SaveMinerWeaponInPrefabs();
		int score;
		AddWeapon(GetPickPrefab(), out score);
	}

	public void AddSwordToInventoryAndSaveInApp()
	{
		Player_move_c.SaveSwordInPrefs();
		int score;
		AddWeapon(GetSwordPrefab(), out score);
	}

	public void AddCombatRifle()
	{
		Player_move_c.SaveCombatRifleInPrefs();
		if (PlayerPrefs.GetInt("MultyPlayer") == 1)
		{
			int score;
			AddWeapon(GetCombatRiflePrefab(), out score);
		}
	}

	public void AddGoldenEagle()
	{
		Player_move_c.SaveGoldenEagleInPrefs();
		if (PlayerPrefs.GetInt("MultyPlayer") == 1)
		{
			int score;
			AddWeapon(GetGoldenEaglePrefab(), out score);
		}
	}

	public void AddMagicBow()
	{
		Player_move_c.SaveMagicBowInPrefs();
		if (PlayerPrefs.GetInt("MultyPlayer") == 1)
		{
			int score;
			AddWeapon(GetMagicBowPrefab(), out score);
		}
	}

	public void AddMinerWeapon(string id)
	{
		if (_purchaseActinos.ContainsKey(id))
		{
			_purchaseActinos[id]();
		}
	}

	private void AddMinerWeapon(StoreKitTransaction tr)
	{
		AddMinerWeapon(tr.productIdentifier);
	}

	private void OnDestroy()
	{
		StoreKitManager.purchaseSuccessfulEvent -= AddMinerWeapon;
	}

	private void Update()
	{
	}

	public void Reload()
	{
		currentWeaponSounds.animationObject.GetComponent<Animation>().Stop(myCAnim("Empty"));
		currentWeaponSounds.animationObject.GetComponent<Animation>().CrossFade(myCAnim("Shoot"));
		currentWeaponSounds.animationObject.GetComponent<Animation>().Play(myCAnim("Reload"));
		int num = currentWeaponSounds.ammoInClip - ((Weapon)playerWeapons[CurrentWeaponIndex]).currentAmmoInClip;
		if (((Weapon)playerWeapons[CurrentWeaponIndex]).currentAmmoInBackpack >= num)
		{
			((Weapon)playerWeapons[CurrentWeaponIndex]).currentAmmoInClip += num;
			((Weapon)playerWeapons[CurrentWeaponIndex]).currentAmmoInBackpack -= num;
		}
		else
		{
			((Weapon)playerWeapons[CurrentWeaponIndex]).currentAmmoInClip += ((Weapon)playerWeapons[CurrentWeaponIndex]).currentAmmoInBackpack;
			((Weapon)playerWeapons[CurrentWeaponIndex]).currentAmmoInBackpack = 0;
		}
	}
}
