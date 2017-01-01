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

    public void Execute()
    {
        
        _group = _pool.GetGroup(Matcher.Button);

        foreach (var e in _group.GetEntities())
        {
            if (e.button.buttonText == "New Patient")
            {
                if ( ! e.isEvent)
                {
                    e.gameObject.gameObject.GetComponent<Button>().onClick.AddListener(CreateNewPatientEntity);
                    e.isEvent = true;
                }
            }
        }
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }

    public void CreateNewPatientEntity()
    {
        _pool.CreateEntity().IsNewPatient(true);
    }

}
