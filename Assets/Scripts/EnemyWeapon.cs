using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    Transform barrel;
    [SerializeField] float bulletVelocity;
    private void Start()
    {
        barrel = transform.GetChild(2);
       
    }
    public void Shoot()
    {
        GameObject b= Instantiate(bulletPrefab, barrel.position, barrel.rotation);
        b.GetComponent<ConstantVelocity>().SetVelocity(transform.forward * bulletVelocity/100);
        Destroy(b, 5);
    }
}
