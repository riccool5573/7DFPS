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



        if(newPos != null)
        {
            oldPos = newPos;
        }

        newPos = this.gameObject.transform.position;





    }


    private void OnCollisionStay(Collision collision)
    {
        
        if (collision.gameObject.tag == "Enemy")
        {
            xDiff = oldPos.x - newPos.x;
            yDiff = oldPos.y - newPos.y;
            zDiff = oldPos.z - newPos.z;
            
            if (xDiff >= threshHold || yDiff >= threshHold || zDiff >= threshHold)
            {
                Rigidbody enemy = collision.gameObject.GetComponent<Rigidbody>();
                enemy.freezeRotation = false;
            }
        }
    }
}
