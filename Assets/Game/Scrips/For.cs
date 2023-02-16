using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class For : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int MaxInteger = 6;
        for(int i = 0; i < MaxInteger; i++)
        {
            Spawn(i);
        }   
       
    }
    void Spawn(int a)
    {
        Debug.Log("Spawn");
    }

}
