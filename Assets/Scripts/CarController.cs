using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour {
	public float speed = 3.0f;
	public float rotateSpeed = 3.0f;
	public float gravity = 20.0f;
	private Vector3 moveDirection = Vector3.zero;
	private CharacterController controller;
	[SerializeField]
	private GameObject manager;
	private RaceManager raceManager;
	private NavMeshAgent agent;
	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
		raceManager = manager.GetComponent<RaceManager> ();
		agent = GetComponent<NavMeshAgent> ();
		//agent.destination = new Vector3 (150, 0, 8);
	}

	// Update is called once per frame
	void Update () {
		if (raceManager.State != RaceStates.go) {
			return;
		}

		if (controller.isGrounded) {
			transform.Rotate (0, Input.GetAxis ("Horizontal") * rotateSpeed, 0);

			float curSpeed = speed * Input.GetAxis ("Vertical");
			controller.SimpleMove (transform.forward * curSpeed);
		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move (moveDirection * Time.deltaTime);
	}

	void OnControllerColliderHit(ControllerColliderHit collision) {
		if (collision.gameObject.name == "goal") {
			raceManager.State = RaceStates.goal;
		}
	}
}
