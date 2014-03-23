using UnityEngine;
using System.Collections;

public class DamagingCollider : MonoBehaviour {	

	public float _damage = 0.01f;

	void OnCollisionEnter2D(Collision2D collision) 
	{
		//If this object touches another object with Destroyable component attached it keeps applying damage until the 2 are no longer touching
		Destroyable destroyable = collision.gameObject.GetComponent<Destroyable>();
		if(destroyable)
		{
			destroyable.Damage(_damage);
		}
	}
}
