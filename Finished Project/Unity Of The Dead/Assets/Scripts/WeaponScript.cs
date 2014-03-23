using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {

	public GameObject bulletPrefab;
	public float baseSpeed;
	public int fireDelay;
	public float damage;

	void Start()
	{
		//create a self destruct timer for the weapon pickup
 		Destroy(gameObject,5);
	}


 	void OnCollisionEnter2D(Collision2D collider)
	{
		//Need to set the weapon as obtained
		GameObject.Find("Player").GetComponent<FireScript>().ChangeWeapon(this);
		Destroy(gameObject);
	}

}
