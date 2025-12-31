using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Broomstick : XRBaseInteractable
{
    public bool isHovering;

    public InputActionAsset inputActions;
    private InputAction secButtonAction;
    public InputActionProperty moveActionRight;
    public InputActionProperty moveActionLeft;
    public InputActionProperty unmountAction;
    public Transform player;
    public Transform seat;

    public float forwardSpeed=10f;
    public float turningSpeed = 10f;
    public float liftSpeed = 10f;

    public GameObject locomotion;

    public bool isMounted;


    protected override void Awake()
    {
        base.Awake();
        secButtonAction = inputActions.FindAction("SecButtonPressed");
    }

    public void IsHovering(bool value)
    {

        isHovering = value;
        Debug.Log($"hovering {value}");
    }


    private void Update()
    {
        if (secButtonAction.WasPressedThisFrame() && isHovering)
        {
            Debug.Log("player is on the broomstick");
            player.position = seat.position;

            
            player.rotation = Quaternion.LookRotation(seat.forward, Vector3.up);

             
            player.SetParent(seat, true);
            isMounted = true;
            locomotion.SetActive(false);
            moveActionRight.action.Enable();
            moveActionLeft.action.Enable();
            unmountAction.action.Enable();
        }

        if (unmountAction.action.WasPressedThisFrame() && isMounted)
        {
            Unmount();
        }

        if (isMounted)
        {
            //Debug.Log("readding inputs");
            Vector2 move = moveActionRight.action.ReadValue<Vector2>();
            Vector2 lift = moveActionLeft.action.ReadValue<Vector2>();

            // Forward / backward
            transform.position += transform.forward * (move.y * forwardSpeed * Time.deltaTime);

            // Turn left / right (yaw only)
            transform.Rotate(Vector3.up, move.x * turningSpeed * Time.deltaTime, Space.World);

            transform.Rotate(Vector3.right, -lift.y * liftSpeed * Time.deltaTime, Space.Self);
        }


    }


    public void Unmount()
    {
        moveActionRight.action.Disable();
        moveActionLeft.action.Disable();
        unmountAction.action.Disable();
        Debug.Log("player out of broomstick");
        isMounted = false;
        player.SetParent(null, true);
        locomotion.SetActive(true);
    }
}
