using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] XRNode xr;
    [SerializeField] XRNode xl;
    private void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(xr);
        device.TryGetFeatureValue(CommonUsages.trigger, out float triggerValueR);
        InputDevice device1 = InputDevices.GetDeviceAtXRNode(xl);
        device.TryGetFeatureValue(CommonUsages.trigger, out float triggerValueL);

        // when trigger is pressed start shoot()
        if (triggerValueR >= 0.9f ||triggerValueL>=0.9f)
        {
            StartGame();
        }
    }
    private void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
