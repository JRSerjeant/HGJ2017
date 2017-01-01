using Entitas;
using UnityEngine;

public class SystemLoad : MonoBehaviour
{

    Systems _systems;

    // Use this for initialization
    void Start()
    {
        var pools = Pools.sharedInstance;
        pools.SetAllPools();
        _systems = createSystems(pools.pool);
        _systems.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        _systems.Execute();
    }

    Systems createSystems(Pool pool)
    {

        return new Feature("Systems")
            .Add(pool.CreateSystem(new CreateButtonSystem()))
            .Add(pool.CreateSystem(new CreateHumorsBarSystem()))
            ;
    }
}
