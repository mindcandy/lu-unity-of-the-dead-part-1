using UnityEngine;
using System.Collections;

public class FireScript : MonoBehaviour {

	public WeaponScript _startingWeaponScript;

	private Animator _animator;
	private const string RIGHT = "Right"; 
	private const string LEFT = "Left"; 
	private const string UP = "Up"; 
	private const string DOWN = "Down";
	private const string IDLE_RIGHT = "Right_Idle"; 
	private const string IDLE_LEFT = "Left_Idle"; 
	private const string IDLE_UP = "Up_Idle"; 
	private const string IDLE_DOWN = "Down_Idle";

	private float _bulletSpeed;
	private GameObject _bulletPrefab;
	private float _bulletDamage;
	private bool _canFire = true;
	private int _fireDelay;
	private int _fireDelayCounter = 0;

	// Use this for initialization
	void Start () {
		_animator = GetComponent<Animator>();	
		ChangeWeapon(_startingWeaponScript);
	}
	
	public void ChangeWeapon(WeaponScript weaponScript)
	{
		//Stores a local copy of the weapon parameters for when bullets get fired
		_bulletSpeed = weaponScript.baseSpeed;
		_bulletPrefab = weaponScript.bulletPrefab;
		_fireDelay = weaponScript.fireDelay;
		_bulletDamage = weaponScript.damage;
	}
	
	// Update is called once per frame
	void Update () {	
		if(Input.GetAxis("Fire3") > 0)
		{
			if(_canFire)
			{
				CalculateDirectionAndFire();
			}
		}
		if(_fireDelayCounter > 0)
		{
			_fireDelayCounter--;
		}
		else
		{
			_canFire = true;
		}
	}

	void CalculateDirectionAndFire()
	{
		AnimatorStateInfo currentAnimation = _animator.GetCurrentAnimatorStateInfo(0);
		if(currentAnimation.IsName(RIGHT) || currentAnimation.IsName(IDLE_RIGHT))
		{
			FireBullet(Vector3.right);
		}
		else if(currentAnimation.IsName(LEFT) || currentAnimation.IsName(IDLE_LEFT))
		{			
			FireBullet(Vector3.left);
		}
		else if(currentAnimation.IsName(UP) || currentAnimation.IsName(IDLE_UP))
		{
			FireBullet(Vector3.up);
		}
		else if(currentAnimation.IsName(DOWN) || currentAnimation.IsName(IDLE_DOWN))
		{			
			FireBullet(Vector3.down);
		}
	}

	void FireBullet(Vector2 direction)
	{
		//the direction values are all 1 or 0 this converts 1's into the bullet speed
		direction.Scale(new Vector2(_bulletSpeed,_bulletSpeed));
		//Create the bullet slightly away from the player
		Vector3 bulletPosition = gameObject.transform.position;
		bulletPosition.x += direction.x * 0.1f;
		bulletPosition.y += direction.y * 0.1f;
		GameObject bulletInstance = Instantiate(_bulletPrefab,bulletPosition, Quaternion.identity) as GameObject;
		//set the bullets speed and damage
		bulletInstance.GetComponent<BulletScript>().Setup(direction,_bulletDamage);
		//set the fire delay
		_canFire = false;
		_fireDelayCounter = _fireDelay;
	}
}
