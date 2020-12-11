using System.Collections;
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
    private int recoil = 200000;
    // Start is called before the first frame update
    void Start()
    {
       
        body = GameObject.Find("LeftHand").GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(RHand);
        device.TryGetFeatureValue(CommonUsages.trigger, out float triggerValueR);
        // when trigger is pressed start shoot()
        if (triggerValueR >= 0.9f && canShoot)
        {

            Physics.Raycast(this.gameObject.transform.position, this.gameObject.transform.forward, out hit);
            StartCoroutine(shoot());

        }
      
        




    }

    private IEnumerator shoot()
    {
        Debug.Log("Shoot");
        // instantiate a bullethole, set make sure the player doesn't shoot every frame, start the recoil, and play the gunsound. then allow the player to shoot again.
        Instantiate(bulletHole, hit.point, Quaternion.identity);
        canShoot = false;
        gun.Play();
        body.AddForce(transform.up * recoil);
        yield return new WaitForSeconds(0.2f);
        canShoot = true;
       
    }
}
