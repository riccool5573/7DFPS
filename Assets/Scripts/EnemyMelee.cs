using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : Enemy
{
    

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
    }
    
    protected override void PerformAttack()
    {
        base.PerformAttack();
        print("slash");
    }
}
