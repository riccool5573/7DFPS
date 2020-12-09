using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    protected FieldOfView f;
    private void Awake()
    {
        f = GetComponent<EnemyBehaviour>().fov;
    }
}
