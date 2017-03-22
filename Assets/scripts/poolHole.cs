using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poolHole : MonoBehaviour {
	public GameManger g;
	// Use this for initialization
	void Start () {
		//g = GameObject<GameManger>.Find ("Game Manager");

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "poolBall"){
			g.incScore ();

			Debug.Log ("poolBall entered Hole");
			Destroy (other.gameObject);
		}
	}
}
