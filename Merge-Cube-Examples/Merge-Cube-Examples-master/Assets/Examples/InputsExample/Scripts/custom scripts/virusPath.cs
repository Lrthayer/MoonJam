using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class virusPath : MonoBehaviour {

	public GameObject nodeUser;
	//public GameObject player;
	public Transform[] nodes;
	private int currentNode;
	public float reachDistance = 1.0f;
	public float speed = 1;
	// Use this for initialization
	void Start () {
		currentNode = 0;
	}

	// Update is called once per frame
	void Update () {
		Debug.Log(currentNode);
		Vector3 dir = nodes [currentNode].position - nodeUser.transform.position;

		nodeUser.transform.position += dir * speed;// * Time.deltaTime;

		//if reached node goto next node
		if (dir.magnitude <= reachDistance) {
			currentNode++;
			Debug.Log( (currentNode - 1) +"going to next node");
		}

		//if reaches final node game over
		if (currentNode == nodes.Length)
		{
			currentNode = 0;
			Debug.Log("Player Lost");
		}

	}

}
