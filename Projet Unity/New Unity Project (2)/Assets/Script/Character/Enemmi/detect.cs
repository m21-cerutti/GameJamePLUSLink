using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detect : MonoBehaviour {

	Mutant parent;

	void Start()
	{
		parent = GetComponentInParent<Mutant>();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Player")
		{
			parent.player = col.gameObject;
			parent.follow_player = true;
			//Debug.Log("Detect player");
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.tag == "Player")
		{
			parent.follow_player = false;
			//Debug.Log("Lost player");
		}
	}
}
