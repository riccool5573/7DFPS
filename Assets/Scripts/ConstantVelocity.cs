using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantVelocity : MonoBehaviour
{
     Vector3 velocity;
    private void Update()
    {
        transform.position += velocity;
    }
    public void SetVelocity(Vector3 v)
    {
        velocity = v;
    }
    public Vector3 GetVelocity()
    {
        return velocity;
    }
}
