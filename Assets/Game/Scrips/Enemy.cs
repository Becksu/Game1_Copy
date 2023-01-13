using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField] private float attackRange;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Rigidbody2D rb;
    private IState currenState;
    private void Update()
    {
       if(currenState!= null)
        {
            currenState.OnExecute(this);
        }
    }
    public override void OnDespawn()
    {
        base.OnDespawn();
        Destroy(gameObject);
    }
    public override void OnInit()
    {
        base.OnInit();
        ChangState(new IldeState());
    }
    protected override void OnDeath()
    {
        ChangState(null);
        base.OnDeath();

    }

    public void ChangState(IState newState)
    {
        if(currenState != null)
        {
            currenState.OnEnter(this);
        }
    }
    public void Moving()
    {
        ChangAnim("run");
        rb.velocity = transform.right * moveSpeed;
    } 
    public void StopMoving()
    {
        ChangAnim("idle"); 
        rb.velocity = Vector2.zero;
    }
    public void Attack()
    {

    }
    public bool IsTargetInRange()
    {
        return false;
    }
}
