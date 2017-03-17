using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

	//ray cast
	LineRenderer line;
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
	//cube array for shorter code
	GameObject[] cubes;


	// Use this for initialization
	void Start () {
		line = gameObject.GetComponent<LineRenderer> ();
		//line.enabled = false;
		cubes = new GameObject[] {triangleBreakCube, diamondBreakCube, scenario1Cube, scenario2Cube};
	}


	// Update is called once per frame
	void Update () {
		Ray laser = new Ray (transform.position, transform.up);
		line.SetPosition (0, laser.origin);

		if (Physics.Raycast (laser, out laserHit, 200)) {
			line.SetPosition (1, laserHit.point);	
		} else {
			line.SetPosition (1, laser.GetPoint(200));
			//change cubes to default material if nothing is selected
			for(int i = 0; i < cubes.Length; i++) {
				cubes[i].GetComponent<Renderer>().material = defaultMat;
			}
		}//else


		//TODO: get button press in addition to collision to trigger actions
		if (laserHit.collider.name == "TriangleBreak Cube") {
			
			for(int i = 0; i < cubes.Length; i++) {
				if(i == 0) cubes[i].GetComponent<Renderer>().material = selected;
				else cubes[i].GetComponent<Renderer>().material = defaultMat;
			}
			//set up scene
			manager.startTriangleBreak ();
		} else if (laserHit.collider.name == "Diamond Break Cube") {
			for(int i = 0; i < cubes.Length; i++) {
				if(i == 1) cubes[i].GetComponent<Renderer>().material = selected;
				else cubes[i].GetComponent<Renderer>().material = defaultMat;
			}
			//set up scene
			manager.startDiamondBreak ();
		} else if (laserHit.collider.name == "Scenario1 Cube") {
			for(int i = 0; i < cubes.Length; i++) {
				if(i == 2) cubes[i].GetComponent<Renderer>().material = selected;
				else cubes[i].GetComponent<Renderer>().material = defaultMat;
			}
			//set up scene
			manager.startScenario1 ();
		} else if (laserHit.collider.name == "Scenario2 Cube") {
			for(int i = 0; i < cubes.Length; i++) {
				if(i == 3) cubes[i].GetComponent<Renderer>().material = selected;
				else cubes[i].GetComponent<Renderer>().material = defaultMat;
			}
			//set up scene
			manager.startScenario2 ();
		} else {
			//remove material from all cubes
			for(int i = 0; i < cubes.Length; i++) {
				cubes[i].GetComponent<Renderer>().material = defaultMat;
			}//for
			
		}//else
	}//Update
}//Class
