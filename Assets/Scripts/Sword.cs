using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{

    private Vector3 oldPos;
    private Vector3 newPos;

    private float xDiff;
    private float yDiff;
    private float zDiff;
    [SerializeField]
    private float threshHold;

    void Update()
    {


        // keep track of where it was last frame, and where it is now.
        if(newPos != null)
        {
            oldPos = newPos;
        }

        newPos = this.gameObject.transform.position;





    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyBullet"))
        {

            Destroy(other.gameObject);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        
        if (collision.gameObject.tag == "Enemy")
        {
            // take the difference between where it was last frame and where it is now, if its above the threshhold then do damage to enemy
            xDiff = oldPos.x - newPos.x;
            yDiff = oldPos.y - newPos.y;
            zDiff = oldPos.z - newPos.z;
            Debug.Log(yDiff);
            Debug.Log(xDiff);
            Debug.Log(zDiff);

            if (xDiff >= threshHold || yDiff >= threshHold || zDiff >= threshHold)
            {
                Rigidbody enemy = collision.gameObject.GetComponent<Rigidbody>();
                enemy.freezeRotation = false;
               
            }
        }
    }
}
