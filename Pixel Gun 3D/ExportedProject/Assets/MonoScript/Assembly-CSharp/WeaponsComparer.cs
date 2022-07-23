using System;
using System.Collections;
using UnityEngine;

public class WeaponsComparer : IComparer
{
	private static int baseLngth = "Weapon".Length;

	private static string[] multiplayerWeaponsOrd = new string[24]
	{
		"Weapon1",
		"Weapon2",
		"Weapon3",
		WeaponManager.OGUziName,
		"Weapon9",
		"Weapon4",
		"Weapon5",
		"Weapon8",
		WeaponManager.GoldenEagleWeaponName,
		WeaponManager.GlockWN,
		WeaponManager.CombatRifleWeaponName,
		WeaponManager.SpasWeaponName,
		WeaponManager.FAMASWN,
		WeaponManager.MagicBowWeaponName,
		"Weapon6",
		"Weapon7",
		WeaponManager.GoldenAxeWeaponnName,
		WeaponManager.ChainsawWN,
		WeaponManager.ScytheWN,
		WeaponManager.ShovelWN,
		WeaponManager.PigHammerWeaponName,
		WeaponManager.Sword2WeaponName,
		"Weapon23",
		"Weapon24"
	};

	public int Compare(object x, object y)
	{
		string name = ((Weapon)x).weaponPrefab.name;
		string name2 = ((Weapon)y).weaponPrefab.name;
		if (PlayerPrefs.GetInt("MultyPlayer", 0) == 1)
		{
			return Array.IndexOf(multiplayerWeaponsOrd, name2).CompareTo(Array.IndexOf(multiplayerWeaponsOrd, name));
		}
		name = name.Substring(baseLngth);
		name2 = name2.Substring(baseLngth);
		int num = int.Parse(name);
		int num2 = int.Parse(name2);
		return num - num2;
	}
}
