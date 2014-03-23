using UnityEngine;
using System.Collections;

public class FollowTargetScript : MonoBehaviour {
	public GameObject target;
	public float followSpeed = 0.02f;
	
	// Update is called once per frame
	void Update () {
		if(target)
		{
			transform.position = Vector3.MoveTowards(transform.position,target.transform.position,followSpeed);
		}
	}
}
