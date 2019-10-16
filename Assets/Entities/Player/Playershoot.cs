using UnityEngine;
using System.Collections;

public class Playershoot : MonoBehaviour {
	
	public GameObject laserPrefab;
	public PlayerController player;
	public float laserSpeed;
	public float firingRate = 0.2f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		ShootLaser();
	}
	
	public void SpamFire(){
		Vector3 playerPos = player.transform.position;
		playerPos.y += 0.78f;
		GameObject laser = Instantiate (laserPrefab, playerPos, Quaternion.identity) as GameObject; //quaternion is rotations I think.
		laser.rigidbody2D.velocity = new Vector3(0, laserSpeed, 0);
		
	}
	
	public void ShootLaser(){
		if(Input.GetKeyDown("space")){
			InvokeRepeating ("SpamFire", 0.000001f, firingRate); // .00001 protects against a multi shoot 
		}
		if(Input.GetKeyUp ("space")){
			CancelInvoke("SpamFire");
		}
	}
}
