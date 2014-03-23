using UnityEngine;
using System.Collections;

public class LootScript : MonoBehaviour {

	public GameObject[] lootList;

	private bool _isShuttingDown = false;

	void OnDestroy()
	{
		if(!_isShuttingDown && !Application.isLoadingLevel)//dont create loot if the game is closed or scene is changed
		{
			Instantiate(lootList[ChooseRandomLootValue()],gameObject.transform.position,Quaternion.identity); 
		}
	}

	void OnApplicationQuit()
	{
		_isShuttingDown = true;
	}

	int ChooseRandomLootValue()
	{
		return Random.Range(0,lootList.Length);
	}
}
