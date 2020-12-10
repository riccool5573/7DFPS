using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
public class Movement : ControllerInput
{

    private Vector2 inputAxis;
    private CharacterController character;
    private float gravity = -9.81f;
    private float fallingSpeed;
    [SerializeField]
    private XRNode lHand;
    private XRRig rig;
    [SerializeField]
    private LayerMask groundLayer;
    private int speed = 1;


    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        rig = GetComponent<XRRig>();
    }



    // Update is called once per frame
    void Update()
    {
        // get the input from the right joystick
        InputDevice device = InputDevices.GetDeviceAtXRNode(lHand);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
        device.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out bool click);
        //if the joystick is clicked start sprinting.
        if (click)
        {
            speed = 2;
        }
        else
        {
            speed = 1;
        }
    }
    private void FixedUpdate()
    {
        Quaternion headYaw = Quaternion.Euler(0, rig.cameraGameObject.transform.eulerAngles.y, 0);
        Vector3 direction = headYaw * new Vector3(inputAxis.x, 0, inputAxis.y);
        // move the player in the direction you're looking with the joystick
        character.Move(direction * Time.fixedDeltaTime * speed);
        // if the player is not grounded start accelerating towards the ground
        bool isGrounded = GroundCheck();
        if (isGrounded)
            fallingSpeed = 0;
        else
            fallingSpeed += gravity * Time.fixedDeltaTime;


        character.Move(Vector3.up * fallingSpeed * Time.fixedDeltaTime);
    }

    bool GroundCheck()
    {
        //check if player is on the ground.
        Vector3 rayStart = transform.TransformPoint(character.center);
        float rayLength = character.center.y + 0.01f;
        bool hasHit = Physics.SphereCast(rayStart, character.radius, Vector3.down, out RaycastHit info, rayLength, groundLayer);
        return hasHit;
    }
}
