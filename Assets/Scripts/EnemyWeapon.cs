using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    Transform barrel;
    private void Start()
    {
        barrel = transform.GetChild(2);
       
    }
    public void Shoot()
    {
        GameObject b= Instantiate(bulletPrefab, barrel.position, Quaternion.identity);
        b.GetComponent<ConstantVelocity>().SetVelocity(transform.forward * Random.Range(100,200)/1000);
        Destroy(b, 5);
    }
}
