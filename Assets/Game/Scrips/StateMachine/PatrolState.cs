using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IState
{
    float timer;
    float randomtime;
    public void OnEnter(Enemy enemy)
    {
        timer = 0;
        randomtime = Random.Range(3f, 6f);
    }
    public void OnExecute(Enemy enemy)
    {
        timer += Time.deltaTime;
        if (timer < randomtime)
        {
            enemy.Moving();
        }

        timer += Time.deltaTime;
        else
        {
            enemy.ChangState(new IldeState());
        }
       
      
    }

    public void OnExit(Enemy enemy)
    {
        
    }

}
