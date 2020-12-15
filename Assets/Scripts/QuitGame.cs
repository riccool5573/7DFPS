using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class QuitGame : MonoBehaviour
{
    [SerializeField]
    XRNode Rhand;
    private void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(Rhand);
        device.TryGetFeatureValue(CommonUsages.trigger, out float triggerValueR);

        // when trigger is pressed start shoot()
        if (triggerValueR >= 0.9f )
        {
            Quit();
        }
    }
    private void Quit()
    {
        Application.Quit();
    }
}
