using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
public class ControllerInput : MonoBehaviour
{
    // this script recognizes the controllers and sets them to the InputDevice
    // just so i don't have to do that for every script wanting input from the controllers
    public InputDevice leftHand;
    public InputDevice rightHand;
    protected List<InputDevice> devices;
    private Vector2 joyL;
    protected void InitializeControllers()
    {
        
        devices = new List<InputDevice>(); // get a list of VR devices
        InputDevices.GetDevices(devices);
        if (devices.Count > 0)
        {
            leftHand = devices[1];
            rightHand = devices[2]; //assign the controllers to leftHand and rightHand respectively
        }
        foreach (var item in devices)
        {
            Debug.Log(item);
        }


    }
    // Update is called once per frame
    void Update()
    {
        // make sure both hands are valid, and if they aren't, try to reinitialize them
        if (!leftHand.isValid)
        {
            InitializeControllers();
            Debug.Log("left not valid");
        }
        if (!rightHand.isValid)
        {
            InitializeControllers();
            Debug.Log("right not valid");
        }

    }
    protected Vector2 GetJoystick()
    {
        // get the output of the left joystick, for debug purposes
        leftHand.TryGetFeatureValue(CommonUsages.primary2DAxis, out joyL);
        Debug.Log(joyL);
        return joyL;
    }
}
