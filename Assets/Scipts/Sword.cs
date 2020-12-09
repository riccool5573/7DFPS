using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{

    private Vector3 oldPos;
    private Vector3 newPos;
    private int check;
    private float xDiff;
    private float yDiff;
    private float zDiff;
    [SerializeField]
    private float threshHold;
    private void Start()
    {
        check = 0;
    }
    void Update()
    {
        if(check == 0)
        {
            oldPos = this.gameObject.transform.position;
            check = 1;
        }
       else if(check == 1)
        {
            newPos = this.gameObject.transform.position;
            check = 0;
        }
    }


    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("hit");
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
