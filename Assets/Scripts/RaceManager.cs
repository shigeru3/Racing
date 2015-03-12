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
}
