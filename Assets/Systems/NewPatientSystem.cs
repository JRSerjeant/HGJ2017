using System;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using UnityEngine.UI;

public class NewPatientSystem : IExecuteSystem, ISetPool
{
    Pool _pool;
    Group _group;

    Button NewPatientButton;



    bool started;

    public void Execute()
    {


        _group = _pool.GetGroup(Matcher.Button);

        foreach (var e in _group.GetEntities())
        {
            if (e.button.buttonText == "New Patient")
            {
                if ( ! e.isEvent)
                {
                    NewPatientButton = e.gameObject.gameObject.GetComponent<Button>();
                    e.gameObject.gameObject.GetComponent<Button>().onClick.AddListener(delegate { CreateNewPatientEntity(true); });
                    e.isEvent = true;
                    if (! started)
                    {
                        CreateNewPatientEntity(false);
                        started = true;
                        EventSystem._ResetGame += MakeNewPatientButtonInteractable;
                    }
                }
            }
        }
    }


    public void SetPool(Pool pool)
    {
        _pool = pool;
    }

    public void CreateNewPatientEntity(bool includeEvent)
    {
        _pool.CreateEntity().IsNewPatient(true);
        NewPatientButton.interactable = true;
        GameObject.FindGameObjectWithTag("Cured").GetComponent<Image>().enabled = false;
        if (includeEvent)
        {
            EventSystem.InvokeEventHandlerNewPatientEvent();
        }

    }

    public void MakeNewPatientButtonInteractable()
    {
        NewPatientButton.interactable = true;
    }
}
