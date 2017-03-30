using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poolHole : MonoBehaviour {
	public GameManger g;
	Vector3 cueSpawn;
	// Use this for initialization
	void Start () {
		//g = GameObject<GameManger>.Find ("Game Manager");
		cueSpawn = new Vector3 (2.8f, 4.110433f, -0.1535576f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "poolBall" && other.gameObject.name != "cueBall") {
			g.incScore ();

			Debug.Log ("poolBall entered Hole");
			Destroy (other.gameObject);
		} else if (other.gameObject.name == "cueBall") {
			other.gameObject.GetComponent<Rigidbody> ().velocity = Vector3.zero;
			other.gameObject.GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;
			other.gameObject.transform.position = cueSpawn;
		}
	}
}
