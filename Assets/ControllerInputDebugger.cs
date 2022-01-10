using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInputDebugger : MonoBehaviour
{
    public void Debug(UnityEngine.InputSystem.InputAction.CallbackContext context)
	{
		UnityEngine.Debug.Log($"Debug Input {context.ReadValueAsButton()}");
	}
}
