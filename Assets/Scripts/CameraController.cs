using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    private GameObject camera;

    private float minLimit = -45f;
    private float maxLimit = 80f;

    private Vector2 viewValue;

    public void Awake()
    {
        camera = GameObject.Find("Main Camera");
    }
    public void Update()
    {
        UpdateView();
        LimitRotation();
    }
    public void OnView(InputAction.CallbackContext context)
    {
        viewValue = context.ReadValue<Vector2>();
    }
    private void UpdateView()
    {
        transform.Rotate(0, viewValue.x, 0);
        camera.transform.Rotate(viewValue.y, 0, 0);
    }
    private void LimitRotation()
    {
        Vector3 playerEulerAngles = camera.transform.rotation.eulerAngles;

        playerEulerAngles.x = (playerEulerAngles.x > 180) ? playerEulerAngles.x - 360 : playerEulerAngles.x;
        playerEulerAngles.x = Mathf.Clamp(playerEulerAngles.x, minLimit, maxLimit);

        camera.transform.rotation = Quaternion.Euler(playerEulerAngles);
    }
}
