using System;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using UnityEngine.UI;

public class PatientSystem : IInitializeSystem, ISetPool, IReactiveSystem
{
    Pool _pool;
    Group _group;

    Text currentPatientNameText;
    Text currentPatientMessageText;


    public void Initialize()
    {
        currentPatientNameText = GameObject.FindGameObjectWithTag("PatientName").GetComponent<Text>();
        currentPatientMessageText = GameObject.FindGameObjectWithTag("PatientMessage").GetComponent<Text>();

        GeneratePatient();

    }
    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.NewPatient.OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach (var e in entities)
        {
            _pool.DestroyEntity(e);
        }
        GeneratePatient();

    }

    

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }


    public void GeneratePatient()
    {

        _group = _pool.GetGroup(Matcher.Patient);

        foreach (var e in _group.GetEntities())
        {
            e.destroy();
        }

        float rand = UnityEngine.Random.Range(1f, 100f);

        var Patient = _pool.CreateEntity().AddPatient(GeneratePatientName() + rand, GeneratePatientMessage() + rand);

        currentPatientNameText.text = Patient.patient.name;
        currentPatientMessageText.text = Patient.patient.message;


    }

    public string GeneratePatientName()
    {
        return "Name";
    }

    public string GeneratePatientMessage()
    {
        return "Message";
    }
}
