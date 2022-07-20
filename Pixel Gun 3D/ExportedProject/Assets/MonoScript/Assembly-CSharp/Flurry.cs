using UnityEngine;

public class Flurry : MonoBehaviour
{
	private string FLURRY_API_KEY = "HZF54B6G6GQVDWXYKPMX";

	private NerdFlurry mNerdFlurry;

	private void Start()
	{
		Object.DontDestroyOnLoad(base.gameObject);
		mNerdFlurry = new NerdFlurry();
		mNerdFlurry.StartSession(FLURRY_API_KEY);
	}

	private void Update()
	{
	}
}
