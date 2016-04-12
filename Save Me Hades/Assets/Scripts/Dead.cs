using UnityEngine;
using System.Collections;

public class Dead : MonoBehaviour {
	public GameObject head;
	Vector3 curPosition;
	Rigidbody deadRigidBody;
	float speed = 0.1f;
	float minDistance = 2f;
	float maxForce = 20f;
	float force = 1f;

	Vector3 currentPosition;

	void Start()
	{
		if (!head)
		{
			head = FindObjectOfType<CardboardHead>().gameObject;
		}

		deadRigidBody = transform.GetComponent<Rigidbody>();
	}

	void Update ()
	{
		if (curPosition != transform.position)
			curPosition = transform.position;

		Debug.Log (curPosition);
	}

	public void DragDead ()
	{
		transform.SetParent (head.transform);
		deadRigidBody.useGravity = false;
	}

	public void ThrowDead ()
	{
		transform.parent = null;
		deadRigidBody.useGravity = true;
		deadRigidBody.AddForce (transform.forward * 10f, ForceMode.Impulse);
	}
}
