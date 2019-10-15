using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;
	
	public float width = 10f;
	public float height = 5f;
	public float speed = 1.5f;
	float xmin = -5;
	float xmax = 5;
	//public float padding = 1f;
	
	public bool moveLeft = false;
	 
	void Start () {
		// send boundaries for enemy spawner
		float distance = transform.position.z - Camera.main.transform.position.z; 
		Vector3 leftEdge = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance)); // gets the furthest left position
		Vector3 rightEdge = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance)); // gets the furthest right position
		// if camera viewport is 0 - 1, then .5 is the center.
		xmin = leftEdge.x;
		xmax = rightEdge.x;
		

		foreach(Transform child in transform){
			GameObject enemy = Instantiate (enemyPrefab, child.transform.position, Quaternion.identity) as GameObject; // instantiate creates an object, so we're going to consider it as a GameObject
			// below I'll attach the enemy so he's instantiated inside of the spawner
			enemy.transform.parent = child; // this says you'll be a child of our parent (whatever this script is attached to) transform
		}
	}
	
	public void OnDrawGizmos() {
		Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
	}
	// Update is called once per frame
	void Update () {
		MoveEnemies();
	}
	
	public void MoveEnemies(){
		if (!moveLeft){
			transform.position += Vector3.right * speed * Time.deltaTime;
		} else if (moveLeft){
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		if((transform.position.x + (0.5f * width)) >= xmax) {
			moveLeft = true;
		}else if ((transform.position.x - (0.5f * width)) <= xmin){
			moveLeft = false;
		} 
		
		float newX = Mathf.Clamp (transform.position.x, xmin, xmax); 
		transform.position = new Vector3(newX, transform.position.y, transform.position.z);
	}
}
