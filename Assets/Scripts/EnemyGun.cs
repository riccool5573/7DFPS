using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : Enemy
{
    [SerializeField] EnemyWeapon myGun;
    [SerializeField] GameObject arm;
    Vector3 armRot;
    protected override void Start()
    {
        base.Start();
        armRot = arm.transform.localEulerAngles;
    }
    // Start is called before the first frame update
    public override void StartCombat(FieldOfView f)
    {
        base.StartCombat(f);
        effectiveRange = f.visionRange * 2;
    }

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
        Vector3 angle = f.p.transform.position - arm.transform.position;


        Quaternion rot = Quaternion.LookRotation(angle);

        arm.transform.rotation = rot;
        arm.transform.eulerAngles = new Vector3(0, arm.transform.eulerAngles.y+90, arm.transform.eulerAngles.z-85);

        myGun.Shoot();
    }
    public override void Die()
    {
        base.Die();
        arm.transform.localEulerAngles = armRot;
    }
   

}
