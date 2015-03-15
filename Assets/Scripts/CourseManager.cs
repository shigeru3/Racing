using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CourseManager : MonoBehaviour {
	[SerializeField]
	List<Vector3> points;

	// Use this for initialization
	void Start () {
		int i = 0;
		foreach (Vector3 point in points) {
			if (i == points.Count - 1) {
				break;
			}
			GameObject obj = Instantiate(Resources.Load("Plane")) as GameObject;
			obj.transform.rotation = Quaternion.LookRotation (points [i + 1] - points [i]);
			float distance = Vector3.Distance (points [i], points [i + 1]);
			obj.transform.localScale = new Vector3 (0.8f, 1, distance / 10);
			obj.transform.position = (points [i + 1] - points [i]) / 2 + points [i];
			if (i > 0) {
				GameObject corner = Instantiate (Resources.Load ("Corner")) as GameObject;
				corner.transform.position = new Vector3(points[i].x, -1, points[i].z);
			}
			i++;
		}
		/*
		GameObject p = Instantiate(Resources.Load("Plane")) as GameObject;
		p.transform.rotation = Quaternion.LookRotation (points [1] - points [0]);
		float distance = Vector3.Distance (points [0], points [1]);
		p.transform.localScale = new Vector3 (0.8f, 1, distance / 10);
		p.transform.position = (points [1] - points [0]) / 2;

		GameObject p2 = Instantiate (Resources.Load ("Plane")) as GameObject;
		p2.transform.rotation = Quaternion.LookRotation(points[2] - points[1]);
		distance = Vector3.Distance (points [1], points [2]);
		p2.transform.localScale = new Vector3 (0.8f, 1, distance / 10);
		p2.transform.position = (points [2] - points [1]) / 2 + points[1];
		*/
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
