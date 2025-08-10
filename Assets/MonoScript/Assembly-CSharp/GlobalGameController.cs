using System.Collections.Generic;
using UnityEngine;

public class GlobalGameController
{
	public static readonly int NumOfLevels;

	private static int _currentLevel;

	private static int _allLevelsCompleted;

	private static int score;

	public static bool isFullVersion;

	public static int numOfCompletedLevels;

	public static int totalNumOfCompletedLevels;

	public static int _currentIndexInMapping;

	public static List<int> levelMapping;

	public static int coinsBase;

	public static int coinsBaseAdding;

	public static int levelsToGetCoins;

	public static int currentLevel
	{
		get
		{
			return _currentLevel;
		}
		set
		{
			_currentLevel = value;
		}
	}

	public static int AllLevelsCompleted
	{
		get
		{
			return _allLevelsCompleted;
		}
		set
		{
			_allLevelsCompleted = value;
		}
	}

	public static int previousLevel
	{
		get
		{
			if (_currentIndexInMapping > 0)
			{
				return levelMapping[_currentIndexInMapping - 1];
			}
			return 0;
		}
	}

	public static int ZombiesInWave
	{
		get
		{
			return 4;
		}
	}

	public static int EnemiesToKill
	{
		get
		{
			return ((currentLevel != levelMapping[0]) ? 30 : 5) + 30 * AllLevelsCompleted;
		}
	}

	public static int Score
	{
		get
		{
			return score;
		}
		set
		{
			score = value;
		}
	}

	public static int SimultaneousEnemiesOnLevelConstraint
	{
		get
		{
			return 20;
		}
	}

	static GlobalGameController()
	{
		NumOfLevels = 11;
		_currentLevel = -1;
		_allLevelsCompleted = 0;
		score = 0;
		isFullVersion = true;
		numOfCompletedLevels = 0;
		totalNumOfCompletedLevels = 0;
		_currentIndexInMapping = 0;
		levelMapping = new List<int>();
		coinsBase = 2;
		coinsBaseAdding = 1;
		levelsToGetCoins = 5;
		for (int i = 0; i < NumOfLevels - 1; i++)
		{
			levelMapping.Add(i);
		}
	}

	private static void Swap(IList<int> list, int indexA, int indexB)
	{
		int value = list[indexA];
		list[indexA] = list[indexB];
		list[indexB] = value;
	}

	public static void reGenerateLevelMapping()
	{
		int num = levelMapping[levelMapping.Count - 1];
		do
		{
			for (int i = 0; i < 100; i++)
			{
				int num2 = Random.Range(0, levelMapping.Count);
				int num3 = num2;
				while (num2 == num3)
				{
					num3 = Random.Range(0, levelMapping.Count);
				}
				Swap(levelMapping, num2, num3);
			}
		}
		while (num == levelMapping[0]);
	}

	public static void decrementLevel()
	{
		if (_currentIndexInMapping > 0)
		{
			_currentIndexInMapping--;
			currentLevel = levelMapping[_currentIndexInMapping];
		}
	}

	public static void setLevelToFirstInMapping()
	{
		_currentIndexInMapping = 0;
		currentLevel = levelMapping[_currentIndexInMapping];
	}

	public static void incrementLevel()
	{
		if (_currentIndexInMapping <= levelMapping.Count - 1)
		{
			_currentIndexInMapping++;
			if (levelMapping.Count >= _currentIndexInMapping + 1)
			{
				currentLevel = levelMapping[_currentIndexInMapping];
			}
		}
	}

	public static void ResetParameters()
	{
		reGenerateLevelMapping();
		currentLevel = ((PlayerPrefs.GetInt(Defs.TrainingComplSett, 0) != 1) ? 101 : levelMapping[0]);
		AllLevelsCompleted = 0;
		numOfCompletedLevels = -1;
		totalNumOfCompletedLevels = -1;
		_currentIndexInMapping = 0;
	}
}
