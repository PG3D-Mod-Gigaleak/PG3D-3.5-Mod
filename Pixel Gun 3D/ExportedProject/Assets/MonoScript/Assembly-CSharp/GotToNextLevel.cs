using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GotToNextLevel : MonoBehaviour
{
	private Action OnPlayerAddedAct;

	private GameObject _player;

	private Player_move_c _playerMoveC;

	private bool runLoading;

	private void Awake()
	{
		OnPlayerAddedAct = _003CAwake_003Em__3;
		Initializer.PlayerAddedEvent += OnPlayerAddedAct;
	}

	private void OnDestroy()
	{
		Initializer.PlayerAddedEvent -= OnPlayerAddedAct;
	}

	private void Update()
	{
		if (!(_player == null) && !(_playerMoveC == null) && !runLoading && Vector3.Distance(base.transform.position, _player.transform.position) < 1.5f)
		{
			PlayerPrefs.SetFloat(Defs.CurrentHealthSett, _playerMoveC.CurHealth);
			PlayerPrefs.SetFloat(Defs.CurrentArmorSett, _playerMoveC.curArmor);
			runLoading = true;
			Debug.Log("end GlobalGameController.currentLevel " + GlobalGameController.currentLevel);
			if (PlayerPrefs.GetInt("FullVersion", 0) == 0 && GlobalGameController.currentLevel == 5)
			{
				GameObject.FindGameObjectWithTag("PlayerGun").GetComponent<Player_move_c>().showGUIUnlockFullVersion = true;
			}
			else
			{
				AutoFade.LoadLevel("Loading", 0.5f, 0.5f, Color.white);
			}
		}
	}

	[CompilerGenerated]
	private void _003CAwake_003Em__3()
	{
		_player = GameObject.FindGameObjectWithTag("Player");
		_playerMoveC = GameObject.FindGameObjectWithTag("PlayerGun").GetComponent<Player_move_c>();
	}
}
