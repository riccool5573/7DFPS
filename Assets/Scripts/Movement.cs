using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Movement : ControllerInput
{

    private Vector2 inputAxis;
    private CharacterController character;
    private float gravity = -9.81f;
    private float fallingSpeed;
    [SerializeField]
    private XRNode lHand;
    [SerializeField]
    private XRNode rHand;
    [SerializeField]
    private LayerMask groundLayer;
    private int speed = 6;
    [SerializeField]
    private Transform Head;


    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();

    }



    // Update is called once per frame
    void Update()
    {
        // get the input from the right joystick
       
    }
    private void FixedUpdate()
    {
        InputDevice deviceL = InputDevices.GetDeviceAtXRNode(lHand);
        InputDevice deviceR = InputDevices.GetDeviceAtXRNode(rHand);
        deviceL.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 inputAxisL);      
        deviceL.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out bool click);
        deviceR.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 inputAxisR);

        //if the joystick is clicked start sprinting.
        if (click)
        {
            speed = 8;
        }
        else
        {
            speed = 6;
        }
        Quaternion headYaw = Quaternion.Euler(0, Head.transform.eulerAngles.y, 0);
        Vector3 direction = headYaw * new Vector3(inputAxisL.x, 0, inputAxisL.y);
        //move the player in the direction you're looking with the joystick
        character.Move(direction * Time.fixedDeltaTime * speed);
        transform.Rotate(0, inputAxisR.x, 0);
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
