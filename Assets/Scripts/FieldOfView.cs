using System.Collections;
using System;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    [SerializeField] float fov;
    public float visionRange;
    [SerializeField] LayerMask Obstacles;
    public event Action OnSpot;
    [SerializeField]bool vision;
    [SerializeField]bool obstructed;
    Ray rayR;
    Ray rayL;
    [HideInInspector]
    public Player p;
    public bool active = true;
    // Start is called before the first frame update

    private void Start()
    {
        p = GameObject.FindObjectOfType<Player>();
    }
    // Update is called once per frame
    void Update()
    {
        obstructed = false;
        vision = false;
        RaycastHit r;
        if (Physics.Raycast(transform.position, p.transform.position - transform.position, out r, visionRange, Obstacles))
        {

            if (r.collider.gameObject != p.gameObject)
            {
                obstructed = true;
            }
        }



        if (Vector3.Distance(transform.position, p.transform.position) < visionRange && obstructed == false)
        {
            vision = true;
        }
        if (vision && active)
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

        Gizmos.DrawWireSphere(transform.position, visionRange);
    }
}
