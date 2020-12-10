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
    private float recoil = 0.1f;
    private float currentRecoil;
    [SerializeField]
    private AudioSource gun;
    [SerializeField]
    private Transform originPos;
    private bool recoiling;
    private int counter;
    // Start is called before the first frame update
    void Start()
    {
        originPos = GameObject.Find("Rhand").transform; //get the original position of the hand
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
        Debug.Log(transform.position.y - originPos.position.y);
        if (recoiling && counter < 6)
        {
            // add the recoil gradually to the position and rotation of the hand
            transform.position = transform.position + new Vector3(0, currentRecoil * Time.fixedDeltaTime, 0);
            Quaternion target = Quaternion.Euler(0, 0, 15);
            this.transform.Rotate(-8f, 0, 0);
            counter++;
        }
        else
        {
            counter = 0;
            recoiling = false;
            currentRecoil = 0;
        }
        if(transform.position.y > originPos.position.y && !recoiling)
        {
            //return the hand gradually to the original position
            transform.position = transform.position - new Vector3(0, 0.5f * Time.fixedDeltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, originPos.rotation, 8);
        }




    }

    private IEnumerator shoot()
    {
        Debug.Log("Shoot");
        // instantiate a bullethole, set make sure the player doesn't shoot every frame, start the recoil, and play the gunsound. then allow the player to shoot again.
        Instantiate(bulletHole, hit.point, Quaternion.identity);
        canShoot = false;
        currentRecoil += recoil;
        recoiling = true;
        gun.Play();
        originPos = GameObject.Find("Rhand").transform; //get the original position of the hand
        yield return new WaitForSeconds(0.2f);
        canShoot = true;
       
    }
}
