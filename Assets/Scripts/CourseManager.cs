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
		GameObject goal = Instantiate (Resources.Load ("Goal")) as GameObject;
		goal.transform.position = new Vector3 (points [i].x, 0.04f, points [i].z);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
