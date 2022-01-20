using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RigController : MonoBehaviour
{
    [SerializeField]
    private Transform rig = null;

	private float speed = 10f;

	public void RotateRight()
	{
		rig.Rotate(Vector3.up, 90f);
	}

    public void RotateLeft()
	{
		rig.Rotate(Vector3.up, -90f);
	}

	public void Move(InputAction.CallbackContext context) 
	{
		var direction = context.ReadValue<Vector2>();

		Move(direction);
	}
	private void Move(Vector2 direction)
	{
		rig.TransformVector(new Vector3(direction.x, 0f, direction.y) * speed * Time.deltaTime);
	}
}
