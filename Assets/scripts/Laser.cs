using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

	//ray cast
	/*public*/ LineRenderer line;
	public RaycastHit laserHit;
	public GameManger manager;
	//cubes
	public GameObject triangleBreakCube;
	public GameObject diamondBreakCube;
	public GameObject scenario1Cube;
	public GameObject scenario2Cube;
	//materials
	public Material selected;
	public Material defaultMat;
	public Vector3 stickVelocity;
	//cube array for shorter code
	public SteamVR_TrackedObject trackedObj;
	public SteamVR_Controller.Device device;
	/*public*/ GameObject[] cubes;

	// Use this for initialization
	void Start () {
		line = gameObject.GetComponent<LineRenderer> ();
		//line.enabled = false;

		cubes = new GameObject[] {triangleBreakCube, diamondBreakCube, scenario1Cube, scenario2Cube};
	}


	// Update is called once per frame
	void Update () {
		device = SteamVR_Controller.Input ((int)trackedObj.index);
		Ray laser = new Ray (transform.position, transform.up);
		line.SetPosition (0, laser.origin);

		if (Physics.Raycast (laser, out laserHit, 200)) {
			line.SetPosition (1, laserHit.point);	

			//TODO: get button press in addition to collision to trigger actions
			if (laserHit.collider.name == "TriangleBreak Cube") {

				for(int i = 0; i < cubes.Length; i++) {
					if(i == 0) cubes[i].GetComponent<Renderer>().material = selected;
					else cubes[i].GetComponent<Renderer>().material = defaultMat;
				}
				//set up scene
				if (device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad) ){
					manager.startTriangleBreak ();
					manager.score = 0;
				}
			} else if (laserHit.collider.name == "Diamond Break Cube") {
				for(int i = 0; i < cubes.Length; i++) {
					if(i == 1) cubes[i].GetComponent<Renderer>().material = selected;
					else cubes[i].GetComponent<Renderer>().material = defaultMat;
				}
				//set up scene
				if (device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad)){
					manager.startDiamondBreak ();
					manager.score = 0;

				}
			} else if (laserHit.collider.name == "Scenario1 Cube") {
				for(int i = 0; i < cubes.Length; i++) {
					if(i == 2) cubes[i].GetComponent<Renderer>().material = selected;
					else cubes[i].GetComponent<Renderer>().material = defaultMat;
				}
				//set up scene
				if (device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad)){
					manager.startScenario1 ();
					manager.score = 0;

				}
			} else if (laserHit.collider.name == "Scenario2 Cube") {
				for(int i = 0; i < cubes.Length; i++) {
					if(i == 3) cubes[i].GetComponent<Renderer>().material = selected;
					else cubes[i].GetComponent<Renderer>().material = defaultMat;
				}
				//set up scene
				if (device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad)){
					manager.startScenario2 ();
					manager.score = 0;

				}
			} else {
				//remove material from all cubes
				for(int i = 0; i < cubes.Length; i++) {
					cubes[i].GetComponent<Renderer>().material = defaultMat;
				}//for

			}//else
		} else {
			line.SetPosition (1, laser.GetPoint(200));
			//change cubes to default material if nothing is selected
			for(int i = 0; i < cubes.Length; i++) {
				cubes[i].GetComponent<Renderer>().material = defaultMat;
			}
		}//else

	}//Update
	void OnTriggerEnter(Collider other){
		
		if(other.gameObject.tag == "poolBall"){
			//Debug.Log ("I hit a pool Ball");

			Debug.Log ("other: " + other.transform.position);
			Debug.Log ("laser hit: " + laserHit.point);
			Vector3 v1;

			v1.x = -device.velocity.x;
			v1.y = device.velocity.y;
			v1.z = -device.velocity.z;

			//Debug.Log (device.angularVelocity);

			//other.GetComponent<Rigidbody> ().velocity = v1 * 15;
			other.GetComponent<Rigidbody>().AddForceAtPosition(v1*700,laserHit.point);
			other.GetComponent<Rigidbody> ().angularVelocity = device.angularVelocity*15;
		}
	}

}//Class
