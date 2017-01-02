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
            .Add(pool.CreateSystem(new PatientSystem()))
            .Add(pool.CreateSystem(new NewPatientSystem()))
            .Add(pool.CreateSystem(new BleedSystem()))
            .Add(pool.CreateSystem(new VomitSystem()))
            .Add(pool.CreateSystem(new BlisteringSystem()))
            .Add(pool.CreateSystem(new RestSystem()))
            .Add(pool.CreateSystem(new DryFoodSystem()))
            .Add(pool.CreateSystem(new ResetBarSystem()))
            .Add(pool.CreateSystem(new ResetGameSystem()))
            ;
    }
}
