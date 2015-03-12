using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	[SerializeField]
	RaceManager raceManager;
	[SerializeField]
	Text countDown;
	[SerializeField]
	Text stopWatch;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		switch (raceManager.State) {
		case RaceStates.ready:
			countDown.text = string.Format ("{0}", System.Math.Ceiling (raceManager.timer % 60f));
			break;
		case RaceStates.go:
			GetComponent<Image> ().enabled = false;
			countDown.enabled = false;
			stopWatch.text = System.Math.Round (raceManager.rap, 2).ToString ();
			break;
		case RaceStates.goal:
			GetComponent<Image> ().enabled = true;
			countDown.enabled = true;
			countDown.text = System.Math.Round (raceManager.rap, 2).ToString ();
			break;
		default:
			break;
		}
	}
}
