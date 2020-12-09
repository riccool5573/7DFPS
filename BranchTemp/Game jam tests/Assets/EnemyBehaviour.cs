using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public FieldOfView fov;
    Enemy e;
    private void Start()
    {
        fov.OnSpot += InitiateChase;
        e = GetComponent<Enemy>();
    }
    
    void InitiateChase()
    {
        print("Initiating chase");
        e.StartCombat(fov);
    }
}
