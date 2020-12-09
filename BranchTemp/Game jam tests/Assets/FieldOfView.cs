using System.Collections;
using System;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    [SerializeField] float fov;
    public float visionRange;
    [SerializeField] LayerMask Obstacles;
    public event Action OnSpot;
    bool vision;
    bool obstructed;
    Ray rayR;
    Ray rayL;
    public Player p;
    bool active = true;
    // Start is called before the first frame update

    private void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    // Update is called once per frame
    void Update()
    {
        obstructed = false;
        vision = false;
         RaycastHit r;
        if (Physics.Raycast(transform.position, p.transform.position -transform.position, out r, visionRange,Obstacles))
        {
            
            if (r.collider.gameObject != p.gameObject)
            {
                obstructed = true;
            }
        }
        Vector3 targetDir = new Vector3(p.transform.position.x,0,p.transform.position.z) - transform.position;
        
        float angle = Vector3.Angle(targetDir, transform.forward);
       
        

        if (angle < fov / 2&& Vector3.Distance(transform.position,p.transform.position)<visionRange&&obstructed==false)
        {
            vision = true;
        }
        if (vision&&active)
        {
            SpotPlayer();
        }
    }
    void SpotPlayer()
    {
        print("spotted");
        OnSpot?.Invoke();
        active = false;
    }
    private void OnDrawGizmos()
    {
        
            p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        
        if (vision)
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = Color.white;
        }
        Gizmos.DrawRay(transform.position, Quaternion.AngleAxis(fov/2, Vector3.up)*transform.forward*visionRange );
        Gizmos.DrawRay(transform.position, Quaternion.AngleAxis(-fov / 2, Vector3.up) * transform.forward * visionRange);
        if (obstructed)
        {
            Gizmos.color = Color.white;
        }
        else
        {
            Gizmos.color = Color.red;
        }
        Gizmos.DrawLine(transform.position, p.transform.position);
    }
}
