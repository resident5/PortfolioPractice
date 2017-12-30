using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleControl : MonoBehaviour {

	public Transform target;

	public GameObject shotPrefab;

	void Update()
	{
		PlayerInput ();
	}

	public void Shoot()
	{
		GameObject thisShot = Instantiate (shotPrefab,this.gameObject.transform.position,Quaternion.identity);
		thisShot.transform.LookAt (target.position);
	}

	void PlayerInput()
	{
		if (Input.GetKeyDown (KeyCode.Z))
		{
			Shoot ();
		}
	}
}
