using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	[SerializeField]
	GameObject target = null;
	[SerializeField]
	Vector3 offset = Vector3.zero;

	// Update is called once per frame
	void Update () {
		transform.localPosition = target.transform.localPosition + offset;
	}
}
