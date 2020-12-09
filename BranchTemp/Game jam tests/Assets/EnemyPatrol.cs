using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : EnemyMovement
{
    [SerializeField] List<Vector3> patrol;int index = 0;
    Vector3 nextWayPoint;
    bool to = true;
    [SerializeField] float rotSpeed = 10;
    [SerializeField] float timePause;
    bool isMoving = true;
    private void Start()
    {
        f.OnSpot += StopPatrol;
    }
    private void Update()
    {
        
        nextWayPoint = patrol[index];
        nextWayPoint.y = transform.position.y;
        if(isMoving)
        MoveTowards(nextWayPoint);
        if (to)
        {
            if (Vector3.Distance(transform.position, nextWayPoint)==0)
            {
                index++;
                if (index == patrol.Count)
                {
                    print("turning");
                    to = false;
                    index--;
                }
                HoldAtPoint(timePause);
                
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, nextWayPoint) == 0)
            {
                index--;
                if (index == 0)
                {
                    print("turning");
                    to = true;
                    HoldAtPoint(timePause);
                }
            }
            
        }
        
        
    }
    void StopPatrol()
    {
        this.enabled = false;
    }
    void HoldAtPoint(float t)
    {
        isMoving = false;
        Invoke("NextWayPoint", t);
    }
    void NextWayPoint()
    {
        isMoving = true;
    }
    void MoveTowards(Vector3 target)
    {

        Vector3 angle = nextWayPoint - transform.position;


        Quaternion rot = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(angle), rotSpeed * Time.deltaTime);

        transform.rotation = rot;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

        transform.position = Vector3.MoveTowards(transform.position, nextWayPoint, speed / 1000);
        print("moving");
    }
    private void OnDrawGizmos()
    {
        foreach(Vector3 v  in patrol)
        {
            Gizmos.DrawWireCube(v, Vector3.one / 2);
        }
    }
}
