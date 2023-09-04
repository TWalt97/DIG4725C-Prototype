using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
	public Rigidbody playerRigid;
	public float movementSpeed = 5f;
	public bool walking;
	public Transform playerTrans;

	void FixedUpdate()
	{
		float horizontalInput = Input.GetAxisRaw("Horizontal");
		float verticalInput = Input.GetAxisRaw("Vertical");

		Vector3 inputVector = new Vector3(horizontalInput, 0, verticalInput);
		inputVector = Vector3.ClampMagnitude(inputVector, 1);

		Vector3 movement = Quaternion.Euler(0, 45f, 0) * inputVector;
		playerRigid.velocity = movement * movementSpeed * Time.fixedDeltaTime;
	}
}
