using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
public class Gun : ControllerInput
{

    [SerializeField]
    private XRNode RHand;
    [SerializeField]
    private bool canShoot = true;
    public GameObject bulletPrefab;
    [SerializeField]
    private AudioSource gun;
    [SerializeField] float bulletVelocity;

    [SerializeField] Transform barrel;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(RHand);
        device.TryGetFeatureValue(CommonUsages.trigger, out float triggerValueR);

        // when trigger is pressed start shoot()
        if (triggerValueR >= 0.9f && canShoot)
        {
            StartCoroutine(shoot());
        }



    }

    private IEnumerator shoot()
    {
        // instantiate a bullethole, set make sure the player doesn't shoot every frame, start the recoil, and play the gunsound. then allow the player to shoot again.
        GameObject bullet = Instantiate(bulletPrefab, barrel.position, transform.rotation);
        bullet.GetComponent<ConstantVelocity>().SetVelocity(transform.forward * bulletVelocity / 100);
        Destroy(bullet, 4f);
        canShoot = false;
        gun.Play();
        yield return new WaitForSeconds(0.2f);
        canShoot = true;
    }
}
