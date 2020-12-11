using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float effectiveRange;
    [SerializeField] protected float attackStartupTime;
    [SerializeField] protected float attackEndLag;
    protected Vector3 startPos;
    protected Vector3 startRot;
    protected bool active = false;
    protected FieldOfView f;
    EnemyMovement em;
     protected enum state
    {
        NEUTRAL,
        ATTACKING,
        CHASING,
        STUNNED
    }
    [SerializeField] state currentState =0;
    virtual protected void Start()
    {
        em = GetComponent<EnemyMovement>();
        startPos = transform.position;
        print(startPos);
        startRot = transform.localEulerAngles;
    }
    virtual public void StartCombat(FieldOfView _f)
    {
        active = true;
        f = _f;
    }
    virtual protected void Update()
    {
        if (active)
        {
            if (Vector3.Distance(transform.position, f.p.transform.position) > effectiveRange)
            {
                DashToTarget();
            }
            else
            {
                if (currentState == state.NEUTRAL)
                {
                    ChangeState(state.ATTACKING);
                    Attack();
                }
                if (currentState == state.ATTACKING)
                {
                    Vector3 angle = f.p.transform.position - transform.position;


                    Quaternion rot = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(angle), 10 * Time.deltaTime);

                    transform.rotation = rot;
                    transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

                }
            }
        }
    }
    virtual protected void DashToTarget()
    {
        print(em.speed);
        transform.position = Vector3.MoveTowards(transform.position, f.p.transform.position, em.speed / 1000 * 2);
        print("flanking");
        Vector3 angle = f.p.transform.position - transform.position;


        Quaternion rot = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(angle), 10 * Time.deltaTime);

        transform.rotation = rot;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

    }
    virtual protected void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, effectiveRange);
    }
    virtual protected void Attack()
    {
        StartCoroutine(InitiateAttack());
        
    }
    virtual protected IEnumerator InitiateAttack()
    {
        yield return new WaitForSeconds(attackStartupTime);
        PerformAttack();
        //add a wait for seconds(animation length)
        yield return new WaitForSeconds(attackEndLag);
        ChangeState(state.NEUTRAL);
    }
    virtual protected void PerformAttack()
    {
        
    }
    virtual protected void ChangeState(state s)
    {
        currentState = s;
    }
    public void Respawn()
    {

        GetComponent<EnemyPatrol>().enabled = true;
        GetComponent<EnemyPatrol>().index = 0;
        transform.position = startPos;
        ChangeState(state.NEUTRAL);
        active = false;
        transform.GetChild(0).GetComponent<FieldOfView>().active = true;
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            Die();
        }
    }
    virtual public void Die()
    {
        transform.localEulerAngles = startRot;
        gameObject.SetActive(false);
    }
}
