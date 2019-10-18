using UnityEngine;
using System.Collections;

public class BossShip : MonoBehaviour {
	
	private ScoreKeeper scoreK;
	public Explosion shipExplosion;
	public int scoreValue = 696969;
	public float shipHealth = 10050f;
	public GameObject bossLaserPrefab;
	public float laserSpeed;
	public float nextFire;
	// my solution: 
	public int firingRate = 20;
	
	public AudioClip explosion;
	public AudioClip enemyShoot;
	
	
	// their solution:
	public float shotsPerSeconds = 0.5f;
	
	
	void Start () {
		nextFire = Time.time + (Random.Range (0, firingRate));
		scoreK = GameObject.Find ("ScoreText").GetComponent<ScoreKeeper>();
		
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
				Die ();
			}
		}
	}
	
	public void Die(){
		AudioSource.PlayClipAtPoint(explosion, transform.position);
		Instantiate(shipExplosion, transform.position, Quaternion.identity);
		Destroy (gameObject);
		scoreK.Score(scoreValue);
		LevelManager levelManager = GameObject.Find ("LevelManager").GetComponent<LevelManager>();
		levelManager.LoadLevel("Win Screen");
		     
	}
	
	public void Fire(){
		AudioSource.PlayClipAtPoint(enemyShoot, transform.position);
		Vector3 enemyPos = transform.position + new Vector3(0, -2.3f, 0);
		//enemyPos.y -= 0.78f; // my old offset method
		GameObject laser = Instantiate (bossLaserPrefab, enemyPos, Quaternion.identity) as GameObject; //quaternion is rotations I think.
		laser.transform.Rotate(new Vector3(0,0,1*Time.deltaTime));
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
