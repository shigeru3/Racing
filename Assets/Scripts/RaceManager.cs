using UnityEngine;
using System.Collections;

public enum RaceStates {
	ready,
	go,
	goal
}

public class RaceManager : MonoBehaviour {
	public float timer = 5;
	public float rap = 0;
	public RaceStates State { get; set; }

	// Use this for initialization
	void Start () {
		State = RaceStates.ready;
	}
	
	// Update is called once per frame
	void Update () {
		switch (State) {
		case RaceStates.ready:
			timer -= Time.deltaTime;
			if (timer <= 0.0f) {
				timer = 0;
				State = RaceStates.go;
			}
			break;
		case RaceStates.go:
			rap += Time.deltaTime;
			break;
		case RaceStates.goal:
			break;
		default:
			break;
		}
	}
	private void OnGUI() {
		GUILayout.BeginVertical (GUILayout.Width (400));
		switch (State) {
		case RaceStates.ready:
			GUILayout.Box (string.Format ("{0}", System.Math.Ceiling (timer % 60f)), GUILayout.Width (400));
			break;
		case RaceStates.go:
		case RaceStates.goal:
			GUILayout.Box (System.Math.Round(rap, 2).ToString(), GUILayout.Width (400));
			break;
		default:
			break;
		}
	}
}
