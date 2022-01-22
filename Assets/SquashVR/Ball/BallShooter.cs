using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShooter : MonoBehaviour
{
    [SerializeField]
    private GameObject ballPrefab = null;
	[SerializeField]
	private float speed = 1f;
	[SerializeField]
	private int shootFrameCount = 300;

	private Transform myTransform = null;

	private int frameCount = 0;

	private void Start()
	{
		myTransform = transform;
	}

	private void FixedUpdate()
	{
		frameCount++;

		if (frameCount < shootFrameCount)
		{
			return;
		}

		ShootBall();
		frameCount = 0;
	}

	public void ShootBall()
	{
        var ball = GameObject.Instantiate(ballPrefab, myTransform.position, myTransform.rotation)
			.GetComponent<Rigidbody>();

		ball.velocity = speed * myTransform.forward;
	}
}
