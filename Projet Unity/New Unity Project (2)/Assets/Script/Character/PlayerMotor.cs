using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : CharacterObj {


	public void die()
	{
		destroy();
		HUDManager.Instance.GameOver();

	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
