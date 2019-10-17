using UnityEngine;
using System.Collections;

public class Position : MonoBehaviour {

	void OnDrawGizmos(){ // gizmos are shown within the editor, not within the game itself. 
							//waypoints are well used for waypoints, for example. Click Gizmos in the developer screen by Camera button
		Gizmos.DrawWireSphere(transform.position, 1);
	}
}
