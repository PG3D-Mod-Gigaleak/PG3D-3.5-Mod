using System.Collections.Generic;

public class InAppData
{
	public static Dictionary<int, KeyValuePair<string, string>> inAppData;

	public static Dictionary<string, string> inappReadableNames;

	static InAppData()
	{
		inAppData = new Dictionary<int, KeyValuePair<string, string>>();
		inappReadableNames = new Dictionary<string, string>();
		inAppData.Add(5, new KeyValuePair<string, string>(StoreKitEventListener.endmanskin, Defs.endmanskinBoughtSett));
		inAppData.Add(11, new KeyValuePair<string, string>(StoreKitEventListener.chief, Defs.chiefBoughtSett));
		inAppData.Add(12, new KeyValuePair<string, string>(StoreKitEventListener.spaceengineer, Defs.spaceengineerBoughtSett));
		inAppData.Add(13, new KeyValuePair<string, string>(StoreKitEventListener.nanosoldier, Defs.nanosoldierBoughtSett));
		inAppData.Add(14, new KeyValuePair<string, string>(StoreKitEventListener.steelman, Defs.steelmanBoughtSett));
		inAppData.Add(15, new KeyValuePair<string, string>(StoreKitEventListener.CaptainSkin, Defs.captainSett));
		inAppData.Add(16, new KeyValuePair<string, string>(StoreKitEventListener.HawkSkin, Defs.hawkSett));
		inAppData.Add(17, new KeyValuePair<string, string>(StoreKitEventListener.GreenGuySkin, Defs.spaceengineerBoughtSett));
		inAppData.Add(18, new KeyValuePair<string, string>(StoreKitEventListener.TunderGodSkin, Defs.nanosoldierBoughtSett));
		inAppData.Add(19, new KeyValuePair<string, string>(StoreKitEventListener.GordonSkin, Defs.steelmanBoughtSett));
		inAppData.Add(23, new KeyValuePair<string, string>(StoreKitEventListener.magicGirl, Defs.magicGirlSett));
		inAppData.Add(24, new KeyValuePair<string, string>(StoreKitEventListener.braveGirl, Defs.braveGirlSett));
		inAppData.Add(25, new KeyValuePair<string, string>(StoreKitEventListener.glamDoll, Defs.glamGirlSett));
		inAppData.Add(26, new KeyValuePair<string, string>(StoreKitEventListener.kittyGirl, Defs.kityyGirlSett));
		inAppData.Add(27, new KeyValuePair<string, string>(StoreKitEventListener.famosBoy, Defs.famosBoySett));
		inappReadableNames.Add(StoreKitEventListener.axe, "Golden Axe");
		inappReadableNames.Add(StoreKitEventListener.bigAmmoPackID, "Big Pack of Ammo");
		inappReadableNames.Add(StoreKitEventListener.fullHealthID, "Full Health");
		inappReadableNames.Add(StoreKitEventListener.minerWeaponID, "Miner Weapon");
		inappReadableNames.Add(StoreKitEventListener.crystalswordID, "Crystal Sword");
		inappReadableNames.Add(StoreKitEventListener.spas, "Mega Destroyer");
		inappReadableNames.Add(StoreKitEventListener.elixirID, "Elixir of Resurrection");
		inappReadableNames.Add(StoreKitEventListener.magicbow, "Magic Bow");
		inappReadableNames.Add(StoreKitEventListener.combatrifle, "Combat Rifle");
		inappReadableNames.Add(StoreKitEventListener.goldeneagle, "Golden Eagle");
		inappReadableNames.Add(StoreKitEventListener.armor, "Armor");
		inappReadableNames.Add(StoreKitEventListener.glock, "Fast Death");
		inappReadableNames.Add(StoreKitEventListener.famas, "Elite Rifle");
		inappReadableNames.Add(StoreKitEventListener.chainsaw, "Tiny Chainsaw");
		inappReadableNames.Add(StoreKitEventListener.scythe, "Creeper's Scythe");
		inappReadableNames.Add(StoreKitEventListener.shovel, "Battle Shovel");
		inappReadableNames.Add(StoreKitEventListener.endmanskin, "End Man Skin for 30 coins");
		inappReadableNames.Add(StoreKitEventListener.chief, "Chief Skin for 45 coins");
		inappReadableNames.Add(StoreKitEventListener.spaceengineer, "Space Engineer Skin for 45 coins");
		inappReadableNames.Add(StoreKitEventListener.nanosoldier, "Nano Soldier Skin for 45 coins");
		inappReadableNames.Add(StoreKitEventListener.steelman, "Steel Man Skin for 45 coins");
		inappReadableNames.Add(StoreKitEventListener.CaptainSkin, "Captain Skin for 45 coins");
		inappReadableNames.Add(StoreKitEventListener.HawkSkin, "Hawk Skin for 45 coins");
		inappReadableNames.Add(StoreKitEventListener.TunderGodSkin, "Thunder God Skin for 45 coins");
		inappReadableNames.Add(StoreKitEventListener.GreenGuySkin, "Green Guy Skin for 45 coins");
		inappReadableNames.Add(StoreKitEventListener.GordonSkin, "Gordon Skin for 45 coins");
		inappReadableNames.Add(StoreKitEventListener.magicGirl, "Magic Girl Skin for 45 coins");
		inappReadableNames.Add(StoreKitEventListener.braveGirl, "Brave Girl Skin for 45 coins");
		inappReadableNames.Add(StoreKitEventListener.glamDoll, "Glam Doll Skin for 45 coins");
		inappReadableNames.Add(StoreKitEventListener.kittyGirl, "Kitty Skin for 45 coins");
		inappReadableNames.Add(StoreKitEventListener.famosBoy, "Famos Boy Skin for 45 coins");
	}
}
