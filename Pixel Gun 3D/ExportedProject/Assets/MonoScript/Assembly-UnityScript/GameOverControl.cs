using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class GameOverControl : MonoBehaviour
{

	public GameObject explosion;

	public float startingShakeDistance;

	public float decreasePercentage;

	public float shakeSpeed;

	public int numberOfShakes;

	public GameOverControl()
	{
		startingShakeDistance = 0.4f;
		decreasePercentage = 0.5f;
		shakeSpeed = 40f;
		numberOfShakes = 3;
	}
	public void Main()
	{
	}
}
