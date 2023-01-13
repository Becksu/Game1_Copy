using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private Animator anim;
    private float hp;
    private string curenAnim;
    public bool IsDead => hp <= 0;

    private void Start()
    {
        OnInit();
    }
    public virtual void OnInit()
    {
        hp = 100;
    }
    public virtual void OnDespawn()
    {

    }
    protected virtual void OnDeath()
    {
        ChangAnim("die");
        Invoke(nameof(OnDespawn), 2f);
    }
    protected void ChangAnim(string animName)
    {
        Debug.Log(animName);
        if (curenAnim != animName)
        {
            anim.ResetTrigger(animName);
            curenAnim = animName;
            anim.SetTrigger(curenAnim);
        }
    }
    public void OnHit(float damage)
    {
        if (IsDead)
        {
            hp -= damage;
            if (IsDead)
            {
                OnDeath();
            }
        }
    }



    
}
