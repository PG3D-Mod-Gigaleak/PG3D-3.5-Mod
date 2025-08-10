using System.Collections.Generic;

public class VirtualCurrencyHelper
{
	public static int[] coinInappsQuantity;

	public static Dictionary<string, int> prices;

	static VirtualCurrencyHelper()
	{
		coinInappsQuantity = new int[7] { 15, 30, 45, 80, 165, 330, 800 };
		prices = new Dictionary<string, int>();
		prices.Add(StoreKitEventListener.crystalswordID, 75);
		prices.Add(StoreKitEventListener.fullHealthID, 15);
		prices.Add(StoreKitEventListener.bigAmmoPackID, 15);
		prices.Add(StoreKitEventListener.minerWeaponID, 30);
		prices.Add(StoreKitEventListener.elixirID, 30);
		prices.Add(StoreKitEventListener.combatrifle, 75);
		prices.Add(StoreKitEventListener.magicbow, 150);
		prices.Add(StoreKitEventListener.goldeneagle, 30);
		prices.Add(StoreKitEventListener.chief, 45);
		prices.Add(StoreKitEventListener.nanosoldier, 45);
		prices.Add(StoreKitEventListener.endmanskin, 30);
		prices.Add(StoreKitEventListener.spaceengineer, 45);
		prices.Add(StoreKitEventListener.steelman, 45);
		prices.Add(StoreKitEventListener.CaptainSkin, 45);
		prices.Add(StoreKitEventListener.HawkSkin, 45);
		prices.Add(StoreKitEventListener.TunderGodSkin, 45);
		prices.Add(StoreKitEventListener.GreenGuySkin, 45);
		prices.Add(StoreKitEventListener.GordonSkin, 45);
		prices.Add(StoreKitEventListener.axe, 45);
		prices.Add(StoreKitEventListener.spas, 60);
		prices.Add(StoreKitEventListener.armor, 30);
		prices.Add(StoreKitEventListener.chainsaw, 75);
		prices.Add(StoreKitEventListener.famas, 75);
		prices.Add(StoreKitEventListener.glock, 45);
		prices.Add(StoreKitEventListener.scythe, 60);
		prices.Add(StoreKitEventListener.shovel, 30);
		prices.Add(StoreKitEventListener.magicGirl, 45);
		prices.Add(StoreKitEventListener.braveGirl, 45);
		prices.Add(StoreKitEventListener.glamDoll, 45);
		prices.Add(StoreKitEventListener.kittyGirl, 45);
		prices.Add(StoreKitEventListener.famosBoy, 75);
	}
}
