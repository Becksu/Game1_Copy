using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IldeState : IState
{
    float timer;
    float randomtime;
    public void OnEnter(Enemy enemy)
    {
        enemy.StopMoving();
        timer = 0;
        randomtime = Random.Range(2f, 4f);
       
    }
    public void OnExecute(Enemy enemy)
    {
        if(timer < randomtime)
        {
            enemy.ChangState(new PatrolState());
        }
        timer += Time.deltaTime;
    }

    public void OnExit(Enemy enemy)
    {

    }

}
