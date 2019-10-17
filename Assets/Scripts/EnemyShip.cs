using UnityEngine;
using System.Collections;

public class EnemyShip : MonoBehaviour {

	public float shipHealth = 150;
	
	public GameObject redLaserPrefab;
	public float laserSpeed;
	public float nextFire;
	// my solution: 
	public int firingRate = 20;
	
	// their solution:
	public float shotsPerSeconds = 0.5f;
	
	
	void Start () {
		nextFire = Time.time + (Random.Range (0, firingRate));
	}
	
	void Update () {
		ShootLaserHandler ();
	}
	
	void OnTriggerEnter2D(Collider2D col){
		
		print("I've been hit!!!" + col);
		Projectiles projectile = col.gameObject.GetComponent<Projectiles>();
		
		print(projectile.GetDamage());
		if (projectile){
			
			projectile.Hit ();
			shipHealth -= projectile.GetDamage();
			
			if (shipHealth <= 0){
				Destroy (gameObject);
			}
		}
	}
	
	public void Fire(){

		Vector3 enemyPos = transform.position + new Vector3(0, -0.70f, 0);
		//enemyPos.y -= 0.78f; // my old offset method
		GameObject laser = Instantiate (redLaserPrefab, enemyPos, Quaternion.identity) as GameObject; //quaternion is rotations I think.
		laser.rigidbody2D.velocity = new Vector3(0, -laserSpeed, 0); // could also use a vector2, but I just set the Z cord to 0;
		
	}
	
	public void ShootLaserHandler(){
		// my solution
/*		if (Time.time > nextFire) {
			nextFire = Time.time + Random.Range (Time.deltaTime + 0, Time.deltaTime + firingRate);
			Fire ();
		}*/
		
		// their solution: 
		float probability = Time.deltaTime * shotsPerSeconds;
		if (Random.value < probability) {
			Fire ();
		}
	}

}
