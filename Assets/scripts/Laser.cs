using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

	LineRenderer line;
	public RaycastHit laserHit;
	public GameManger manager;

	// Use this for initialization
	void Start () {
		line = gameObject.GetComponent<LineRenderer> ();
		//line.enabled = false;
	}

	// Update is called once per frame
	void Update () {
		Ray laser = new Ray (transform.position, transform.up);
		line.SetPosition (0, laser.origin);

		if (Physics.Raycast (laser, out laserHit, 200)) {
			line.SetPosition (1, laserHit.point);	
		} else {
			line.SetPosition (1, laser.GetPoint(200));

		}//else


		//TODO: get button press in addition to collision to trigger actions
		if (laserHit.collider.name == "TriangleBreak Cube") {
			manager.startTriangleBreak ();
		} else if (laserHit.collider.name == "Diamond Break Cube") {
			manager.startDiamondBreak ();
		} else if (laserHit.collider.name == "Scenario1 Cube") {
			manager.startScenario1 ();
		} else if (laserHit.collider.name == "Scenario2 Cube") {
			manager.startScenario2 ();
		}//else ifs
	}
}
