using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {
		
	private float _damage;

	public void Setup(Vector2 speed, float damage) 
	{
		//set the speed and damage of the bullet
		rigidbody2D.velocity = speed;
		_damage = damage;
		//create a timed self destruct so the bullet destroys itself if it hits nothing
		Destroy(gameObject, 2);
	}


	void OnCollisionEnter2D(Collision2D collision)
	{
		Destroyable destroyable = collision.gameObject.GetComponent<Destroyable>();
		//If the bullet collides with something that can be destroyed... then call Damage on that script and destroy this bullet
		if(destroyable)
		{
			destroyable.Damage(_damage);
			Destroy(gameObject);
		}
	}

}
