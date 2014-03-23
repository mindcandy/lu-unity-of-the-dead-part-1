using UnityEngine;
using System.Collections;

public class TextRenderer : MonoBehaviour {
	
	void Start () 
	{
		//A magical hack to allow a 3D text object to function within Unity 2Ds sorting layers
		renderer.sortingLayerName = "Foreground";
		renderer.sortingOrder = 1;	
	}
}
