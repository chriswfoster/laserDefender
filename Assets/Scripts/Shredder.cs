using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {


	void OnTriggerEnter2D(Collider2D col){
		Destroy(col.gameObject); // col is the item that collides with this, we grab it then destroy it!
	}
}
