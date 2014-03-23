using UnityEngine;
using System.Collections;

public class Destroyable : MonoBehaviour {

	public float toughness = 1.0f;
	private float _health;

	void Start()
	{
		_health = toughness;
	}

	public void Damage(float damage)
	{
		//Reduce health by the damage amount and destroy when no health is left
		_health -= damage;
		if(_health <= 0)
		{
			Destroy(gameObject);
		}

		//If the object has a health bar component, tell it the new health value (0 - 1)
		HealthBarScript healthBar = GetComponent<HealthBarScript>();
		if(healthBar)
		{
			healthBar.SetHealth(Mathf.Clamp(_health/toughness,0,1));
		}

	}

}
