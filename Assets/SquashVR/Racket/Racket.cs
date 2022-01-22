using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racket : MonoBehaviour
{
	[SerializeField]
	private Vector3 box = Vector3.zero;

	private Transform racketTransform = null;
	private Rigidbody racketRigidbody = null;

	private RaycastHit hitInfo;

	private void Start()
	{
		racketTransform = transform;
		racketRigidbody = GetComponent<Rigidbody>();
	}

	private void FixedUpdate()
	{
		Vector3 RacketDirection()
		{
			return racketTransform.up;
		}
		var racketDirection = RacketDirection();

		if (Physics.BoxCast(racketTransform.position, box, racketDirection, out RaycastHit hitInfo))
		{
			var ballRigidbody = hitInfo.rigidbody;
			static bool RacketHitsNotBall(Rigidbody ball)
			{
				return ball == null;
			}
			if (RacketHitsNotBall(ballRigidbody))
			{
				Debug.Log("Racket hits no ball");
				return;
			}

			bool RacketHitsBallOnFront(Rigidbody ballRigidbody)
			{
				return Vector3.Dot(racketRigidbody.velocity, ballRigidbody.velocity) < 0f;
			}
			if (!RacketHitsBallOnFront(ballRigidbody))
			{
				Debug.Log("Racket hits ball on not front");
				//return;
			}

			var reclectedBallVelocity = ballRigidbody.velocity * (-1f);
			var smashedVelocity = Vector3.Dot(racketRigidbody.velocity, racketDirection) * racketRigidbody.velocity.normalized;

			ballRigidbody.velocity = reclectedBallVelocity + smashedVelocity;

			Debug.Log("Racket manually hits ball");
		}

	}
}
