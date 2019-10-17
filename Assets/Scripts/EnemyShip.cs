using UnityEngine;
using System.Collections;

public class EnemyShip : MonoBehaviour {

	public float shipHealth = 100f;
	void Start () {
	
	}
	
	void OnTriggerEnter2D(Collider2D col){
		
		print("I've been hit!!!" + col);
		Projectile projectile = col.gameObject.GetComponent<Projectile>();
		
		if (projectile){
			Hit ();
			Debug.Log ("Hit by a projectile");
		}
	}
	// Update is called once per frame
	void Hit () {
	
	}
}
