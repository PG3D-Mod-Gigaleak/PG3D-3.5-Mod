using System;
using UnityEngine;

[Serializable]
public class Instantiate : MonoBehaviour
{
	public GameObject SpaceCraft;

	public void Start()
	{
	}

	public void Update()
	{
	}

	public void OnNetworkLoadedLevel()
	{
		Network.Instantiate(SpaceCraft, transform.position, transform.rotation, 0);
		Debug.Log("Network.Instantiate");
	}

	public void OnPlayerDisconnected(NetworkPlayer player)
	{
		Network.RemoveRPCs(player, 0);
		Network.DestroyPlayerObjects(player);
	}

	public void OnNetworkInstantiate(NetworkMessageInfo info)
	{
		NetworkView[] array = (NetworkView[])GetComponents(typeof(NetworkView));
		Debug.Log("New prefab network instantiated with views - ");
		int i = 0;
		NetworkView[] array2 = array;
		for (int length = array2.Length; i < length; i++)
		{
			Debug.Log("- " + array2[i].viewID);
		}
	}

	public void Main()
	{
	}
}
