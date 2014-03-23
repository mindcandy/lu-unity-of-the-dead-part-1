using UnityEngine;
using System.Collections;

public class GameOverOnDestroyed : MonoBehaviour {

	private bool _isShuttingDown = false;

	void OnDestroy(){
		if(!_isShuttingDown)
		{
			Application.LoadLevel("GameOver");
		}
	}
	
	void OnApplicationQuit()
	{
		_isShuttingDown = true;
	}
}
