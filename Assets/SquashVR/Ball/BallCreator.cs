using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCreator : MonoBehaviour
{
    [SerializeField]
    private GameObject ballPrefab = null;

    private Transform myTransform = null;

	private void Start()
	{
		myTransform = transform;
	}

	public void CreateBall()
	{
        GameObject.Instantiate(ballPrefab, myTransform.position, myTransform.rotation);
	}
}
