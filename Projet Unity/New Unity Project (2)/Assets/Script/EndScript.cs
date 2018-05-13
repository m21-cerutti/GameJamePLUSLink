using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Player" && (PlayerMotor.nbEnemies <= 0))
		{
			HUDManager.Instance.Win();
		}
	}

}
