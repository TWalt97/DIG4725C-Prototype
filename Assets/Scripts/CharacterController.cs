using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterController : MonoBehaviour
{
	public Rigidbody playerRigid;
	public float movementSpeed = 5f;
	public bool walking;
	public Transform playerTrans;

	//FloatReference stores scriptable objects that can represent any value
	public FloatReference MaxHP;

	public UnityEvent OnDamaged;

	void FixedUpdate()
	{
		float horizontalInput = Input.GetAxisRaw("Horizontal");
		float verticalInput = Input.GetAxisRaw("Vertical");

		Vector3 inputVector = new Vector3(horizontalInput, 0, verticalInput);
		inputVector = Vector3.ClampMagnitude(inputVector, 1);

		Vector3 movement = Quaternion.Euler(0, 45f, 0) * inputVector;
		playerRigid.velocity = movement * movementSpeed * Time.fixedDeltaTime;
	}

	private void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.tag == "Enemy")
		{
			TakeDamage(1);
			Invoke("OnDamaged", 0f);
		}
	}

	public void TakeDamage(int damage)
	{
		//We modify the scriptable object value, which is not stored on the player
		//This way we can access that value from anywhere else without being dependent on the player existing
		MaxHP.Value -= damage;
	}
}
