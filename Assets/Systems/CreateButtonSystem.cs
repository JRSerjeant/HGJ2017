using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Entitas;

public class CreateButtonSystem : IInitializeSystem, ISetPool, IReactiveSystem
{
    Pool _pool;

    public void Initialize()
    {
        _pool.CreateEntity().AddButton("pfb_Button","Bleed").AddPosition(-160,-50,0).IsBlood(true);
        _pool.CreateEntity().AddButton("pfb_Button", "Vomit").AddPosition(0, -50, 0);
        _pool.CreateEntity().AddButton("pfb_Button", "Blistering ").AddPosition(160, -50, 0);
        _pool.CreateEntity().AddButton("pfb_Button", "TBC").AddPosition(-160, -90, 0);
        _pool.CreateEntity().AddButton("pfb_Button", "TBC").AddPosition(0, -90, 0);
        _pool.CreateEntity().AddButton("pfb_Button", "TBC").AddPosition(160, -90, 0);
        _pool.CreateEntity().AddButton("pfb_Button", "New Patient").AddPosition(240, 0, 0);
    }

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.Button.OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach (var e in entities)
        {
            if ( ! e.hasGameObject)
            {
                GameObject go = UnityEngine.GameObject.Instantiate<GameObject>(Resources.Load(e.button.prefabName) as GameObject);
                go.GetComponentInChildren<Text>().text = e.button.buttonText;
                go.transform.SetParent(GameObject.Find("Canvas").transform, false);
                go.transform.localPosition = new Vector3(e.position.x, e.position.y, e.position.z);
                go.name = e.button.buttonText;
                e.AddGameObject(go);
            }
        }
    }



    public void SetPool(Pool pool)
    {
        _pool = pool;
    }
}
