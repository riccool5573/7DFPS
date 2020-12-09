using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
public class Gun : ControllerInput
{

    [SerializeField]
    private XRNode RHand;
    private Vector3 shotPosition;
    private RaycastHit hit;
    private bool canShoot = true;
    public GameObject bulletHole;
    private Rigidbody body;
    [SerializeField]
    private AudioSource gun;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(RHand);
        device.TryGetFeatureValue(CommonUsages.trigger, out float triggerValueR);
  
        if (triggerValueR >= 0.9f && canShoot)
        {

            Physics.Raycast(this.gameObject.transform.position, this.gameObject.transform.forward, out hit);
            StartCoroutine(shoot());

        }
    }

    private IEnumerator shoot()
    {
        Debug.Log("Shoot");
        Instantiate(bulletHole, hit.point, Quaternion.identity);
        canShoot = false;
        gun.Play(1);
        yield return new WaitForSeconds(0.2f);
        canShoot = true;
        body = this.gameObject.GetComponent<Rigidbody>();
        body.AddForce(Vector3.up * 5);

    }
}
