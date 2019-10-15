using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 1.5f;
	float xmin = -5;
	float xmax = 5;
	public float padding = 1f;
	
	void Start () {
		float distance = transform.position.z - Camera.main.transform.position.z; 
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance)); // gets the furthest left position
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance)); // gets the furthest right position
		// if camera viewport is 0 - 1, then .5 is the center.
		xmin = leftmost.x + padding;
		xmax = rightmost.x - padding;
	}
	
	// Update is called once per frame
	void Update () {
		ShipControls();
	}
	
	void ShipControls(){
		//if(Input.GetKey("up")){ 
		//	transform.position += Vector3.up * speed * Time.deltaTime;
		//	print ("Up pressed");
		//}
		//if(Input.GetKey ("up")){ // alternative speed method
		//	transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
		//}
		
		if(Input.GetKey ("left")){
			transform.position += Vector3.left * speed * Time.deltaTime;
			print ("Left arrow pressed");
		}
		if(Input.GetKey ("right")){
			transform.position += Vector3.right * speed * Time.deltaTime;
			print ("Right arrow pressed");
		}
		//if(Input.GetKey ("down")){
		//	transform.position += Vector3.down * speed * Time.deltaTime;
		//	print ("Down arrow pressed");
		//}
		
		// restrict the player to the gamespace
		float newX = Mathf.Clamp (transform.position.x, xmin, xmax); // clamp means you can't leave the constraints of the clamped area
		transform.position = new Vector3(newX, transform.position.y, transform.position.z);
	}
}
