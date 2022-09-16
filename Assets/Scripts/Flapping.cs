using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flapping : MonoBehaviour
{
	float smooth = 5.0f;
	float tiltAngle = 60.0f;
	[SerializeField] Transform wingRight;
	[SerializeField] Transform wingLeft;

	// Update is called once per frame
	void Update()
	{

		Quaternion leftTarget = Quaternion.Euler(-tiltAngle, 0, 0);
		Quaternion rightTarget = Quaternion.Euler(tiltAngle, 0, 0);


		if (Input.GetKey(KeyCode.Space))
		{
			// Dampen towards the target rotation
			wingRight.rotation = Quaternion.Slerp(wingRight.rotation, rightTarget, Time.deltaTime * smooth);
			wingLeft.rotation = Quaternion.Slerp(wingLeft.rotation, leftTarget, Time.deltaTime * smooth);

		}
		else
		{
			wingRight.rotation = Quaternion.Slerp(wingRight.rotation, Quaternion.Euler(-tiltAngle, 0, 0), Time.deltaTime * smooth);
			wingLeft.rotation = Quaternion.Slerp(wingLeft.rotation, Quaternion.Euler(tiltAngle, 0, 0), Time.deltaTime * smooth);
		}






	}
}
