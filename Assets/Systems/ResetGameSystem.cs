using System;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using UnityEngine.UI;

public class ResetGameSystem : ISetPool, IExecuteSystem
{
    Pool _pool;
    Group _groupHumorsBar;
    Systems _systems;


    public bool GameOver;
    int ResetCount;

    bool subscribedToNewPatientEvent;



    public void Execute()
    {
        if( ! subscribedToNewPatientEvent)
        {
            EventSystem._NewPatientEvent += ResetGameOverBool;
            subscribedToNewPatientEvent = true;
        }


        ResetCount = 0;
        foreach (var e in _groupHumorsBar.GetEntities())
        {
            if(e.gameObject.gameObject.GetComponent<Scrollbar>().size > 0.43f && e.gameObject.gameObject.GetComponent<Scrollbar>().size < 0.57f)
            {
                ResetCount++;
            }
        }
        if (ResetCount == 4)
        {
            if ( ! GameOver)
            {
                EventSystem.InvokeEventHandlerResetGame();
                GameObject.FindGameObjectWithTag("Cured").GetComponent<Image>().enabled = true;
                ResetCount = 0;
                GameOver = true;
            }
        }
    }

   

    public void SetPool(Pool pool)
    {
        _pool = pool;
        _groupHumorsBar = _pool.GetGroup(Matcher.HumorsBar);


    }

    public float NewSize()
    {
        return UnityEngine.Random.Range(0f, 1f);
    }

    public void ResetGameOverBool()
    {
        GameOver = false;
    }


}
