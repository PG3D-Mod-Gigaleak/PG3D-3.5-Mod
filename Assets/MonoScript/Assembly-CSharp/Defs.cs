using System.Collections.Generic;
using UnityEngine;

public class Defs
{
	public static Dictionary<string, string> mapNamesForUser;

	public static Dictionary<string, int> levelNumsForMusicInMult;

	public static List<int> levelsWithVarY;

	public static int NumberOfElixirs;

	public static float HalfLength
	{
		get
		{
			return 17f;
		}
	}

	public static string CAnim(GameObject animator, string con){
        foreach (AnimationState ac in animator.GetComponent<Animation>()){
            string nm = ac.name.ToString();
            if (nm.Contains(con) || nm.StartsWith(con) || nm == con){            
                return nm;
            }
        }
        return null;
    }

	public static string BestScoreSett
	{
		get
		{
			return "BestScoreSett";
		}
	}

	public static string InAppBoughtSett
	{
		get
		{
			return "BigAmmoPackBought";
		}
	}

	public static string CurrentWeaponSett
	{
		get
		{
			return "CurrentWeapon";
		}
	}

	public static string MinerWeaponSett
	{
		get
		{
			return "MinerWeaponSett";
		}
	}

	public static string SwordSett
	{
		get
		{
			return "SwordSett";
		}
	}

	public static int ScoreForSurplusAmmo
	{
		get
		{
			return 50;
		}
	}

	public static string CurrentHealthSett
	{
		get
		{
			return "CurrentHealthSett";
		}
	}

	public static string CurrentArmorSett
	{
		get
		{
			return "CurrentArmorSett";
		}
	}

	public static string NumberOfElixirsSett
	{
		get
		{
			return "NumberOfElixirsSett";
		}
	}

	public static float Coef
	{
		get
		{
			return (float)Screen.height / 768f;
		}
	}

	public static string SkinEditorMode
	{
		get
		{
			return "SkinEditorMode";
		}
	}

	public static string SkinNameMultiplayer
	{
		get
		{
			return "SkinNameMultiplayer";
		}
	}

	public static string SkinIndexMultiplayer
	{
		get
		{
			return "SkinIndexMultiplayer";
		}
	}

	public static string SkinBaseName
	{
		get
		{
			return "multi_skin_";
		}
	}

	public static string MultSkinsDirectoryName
	{
		get
		{
			return "Multiplayer Skins";
		}
	}

	public static string CombatRifleSett
	{
		get
		{
			return "CombatRifleSett";
		}
	}

	public static string GoldenEagleSett
	{
		get
		{
			return "GoldenEagleSett";
		}
	}

	public static string MagicBowSett
	{
		get
		{
			return "MagicBowSett";
		}
	}

	public static string SPASSett
	{
		get
		{
			return "SPASSett";
		}
	}

	public static string GoldenAxeSett
	{
		get
		{
			return "GoldenAxeSett";
		}
	}

	public static string ChainsawS
	{
		get
		{
			return "ChainsawS";
		}
	}

	public static string FAMASS
	{
		get
		{
			return "FAMASS";
		}
	}

	public static string GlockSett
	{
		get
		{
			return "GlockSett";
		}
	}

	public static string ScytheSN
	{
		get
		{
			return "ScytheSN";
		}
	}

	public static string ShovelSN
	{
		get
		{
			return "ShovelSN";
		}
	}

	public static string endmanskinBoughtSett
	{
		get
		{
			return "endmanskinBoughtSett";
		}
	}

	public static string chiefBoughtSett
	{
		get
		{
			return "chiefBoughtSett";
		}
	}

	public static string spaceengineerBoughtSett
	{
		get
		{
			return "spaceengineerBoughtSett";
		}
	}

	public static string nanosoldierBoughtSett
	{
		get
		{
			return "nanosoldierBoughtSett";
		}
	}

	public static string steelmanBoughtSett
	{
		get
		{
			return "steelmanBoughtSett";
		}
	}

	public static string captainSett
	{
		get
		{
			return "captainSett";
		}
	}

	public static string hawkSett
	{
		get
		{
			return "hawkSett";
		}
	}

	public static string greenGuySett
	{
		get
		{
			return "greenGuySett";
		}
	}

	public static string TunderGodSett
	{
		get
		{
			return "TunderGodSett";
		}
	}

	public static string gordonSett
	{
		get
		{
			return "gordonSett";
		}
	}

	public static string animeGirlSett
	{
		get
		{
			return "animeGirlSett";
		}
	}

	public static string emoGirlSett
	{
		get
		{
			return "emoGirlSett";
		}
	}

	public static string nurseSett
	{
		get
		{
			return "nurseSett";
		}
	}

	public static string magicGirlSett
	{
		get
		{
			return "magicGirlSett";
		}
	}

	public static string braveGirlSett
	{
		get
		{
			return "braveGirlSett";
		}
	}

	public static string glamGirlSett
	{
		get
		{
			return "glamGirlSett";
		}
	}

	public static string kityyGirlSett
	{
		get
		{
			return "kityyGirlSett";
		}
	}

	public static string famosBoySett
	{
		get
		{
			return "famosBoySett";
		}
	}

	public static string defaultPlayerName
	{
		get
		{
			return "Player";
		}
	}

	public static string Coins
	{
		get
		{
			return "Coins";
		}
	}

	public static string FirstLaunch
	{
		get
		{
			return "FirstLaunch";
		}
	}

	public static string inappsRestored_3_1
	{
		get
		{
			return "inappsRestored_3_1";
		}
	}

	public static string restoreWindowShownProfile
	{
		get
		{
			return "restoreWindowShownProfile";
		}
	}

	public static string restoreWindowShownSingle
	{
		get
		{
			return "restoreWindowShownSingle";
		}
	}

	public static string restoreWindowShownMult
	{
		get
		{
			return "restoreWindowShownMult";
		}
	}

	public static string initValsInKeychain
	{
		get
		{
			return "initValsInKeychain";
		}
	}

	public static string initValsInKeychain2
	{
		get
		{
			return "initValsInKeychain2";
		}
	}

	public static string initValsInKeychain3
	{
		get
		{
			return "initValsInKeychain3";
		}
	}

	public static string TrainingComplSett
	{
		get
		{
			return "TrainingComplSett";
		}
	}

	public static string EarnedCoins
	{
		get
		{
			return "EarnedCoins";
		}
	}

	public static string COOPScore
	{
		get
		{
			return "COOPScore";
		}
	}

	public static float screenRation
	{
		get
		{
			return (float)Screen.width / (float)Screen.height;
		}
	}

	static Defs()
	{
		mapNamesForUser = new Dictionary<string, string>();
		levelNumsForMusicInMult = new Dictionary<string, int>();
		levelsWithVarY = new List<int>();
		NumberOfElixirs = 1;
		mapNamesForUser.Add("Maze", "Temple");
		mapNamesForUser.Add("Cementery", "Graveyard");
		mapNamesForUser.Add("City", "Dead City");
		mapNamesForUser.Add("Gluk", "END World");
		mapNamesForUser.Add("Jail", "Prison");
		mapNamesForUser.Add("Hospital", "Hospital");
		mapNamesForUser.Add("Pool", "Pool");
		mapNamesForUser.Add("Assault", "Warehouse Assault");
		mapNamesForUser.Add("Level3_city", "2.1 City");
		mapNamesForUser.Add("Level2_maze", "2.1 Desert");
		mapNamesForUser.Add("Level3_city25", "2.5 City");
		mapNamesForUser.Add("Winter", "Winter Wonderland");
		mapNamesForUser.Add("Slender", "Forest");
		mapNamesForUser.Add("Castle", "Hell");
		mapNamesForUser.Add("Ranch", "Shooting Range");
		mapNamesForUser.Add("Arena_MP", "Deadly Arena");
		mapNamesForUser.Add("Sky_islands", "Sky Islands");
		mapNamesForUser.Add("Dust", "Arabian City");
		mapNamesForUser.Add("Bridge", "Bridge");
		mapNamesForUser.Add("Farm", "Farm Assault");
		mapNamesForUser.Add("Utopia", "Utopia");
		mapNamesForUser.Add("Arena", "Arena");
		levelNumsForMusicInMult.Add("Maze", 2);
		levelNumsForMusicInMult.Add("Cementery", 1);
		levelNumsForMusicInMult.Add("City", 3);
		levelNumsForMusicInMult.Add("Gluk", 6);
		levelNumsForMusicInMult.Add("Jail", 5);
		levelNumsForMusicInMult.Add("Hospital", 4);
		levelNumsForMusicInMult.Add("Pool", 1001);
		levelNumsForMusicInMult.Add("Assault", 4003);
		levelNumsForMusicInMult.Add("Level3_city", 4004);
		levelNumsForMusicInMult.Add("Level2_maze", 4005);
		levelNumsForMusicInMult.Add("Level3_city25", 4006);
		levelNumsForMusicInMult.Add("Winter", 4007);
		levelNumsForMusicInMult.Add("Slender", 10);
		levelNumsForMusicInMult.Add("Castle", 1002);
		levelNumsForMusicInMult.Add("Ranch", 1003);
		levelNumsForMusicInMult.Add("Arena_MP", 1004);
		levelNumsForMusicInMult.Add("Sky_islands", 1005);
		levelNumsForMusicInMult.Add("Dust", 1006);
		levelNumsForMusicInMult.Add("Bridge", 1007);
		levelNumsForMusicInMult.Add("Farm", 4001);
		levelNumsForMusicInMult.Add("Utopia", 4002);
		levelNumsForMusicInMult.Add("Arena", 7);
		levelsWithVarY.Add(8);
		levelsWithVarY.Add(10);
		levelsWithVarY.Add(1005);
		levelsWithVarY.Add(1006);
		levelsWithVarY.Add(1007);
		levelsWithVarY.Add(4001);
		levelsWithVarY.Add(4002);
	}
}
