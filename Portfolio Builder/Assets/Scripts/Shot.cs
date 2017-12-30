using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]

public class Shot : MonoBehaviour
{
	public ParticleControl player;

	public Rigidbody rb;

	public float speed = 20f;
	public float rotateSpeed = 200f;

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		player = FindObjectOfType<ParticleControl> ().GetComponent<ParticleControl> ();
	}

	void FixedUpdate ()
	{
		Vector3 dir = player.target.position - rb.position;//player.transform.position, player.target.transform.position;

		dir.Normalize ();

		Quaternion rotationVect = Quaternion.LookRotation (dir);

		rb.MoveRotation (Quaternion.RotateTowards (transform.rotation, rotationVect, 20f));

		rb.velocity = transform.forward * speed;

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == player.target.gameObject)
		{
			Destroy (gameObject);
		}
	}
}
