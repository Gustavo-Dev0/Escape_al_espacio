using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : PlayerUnitSpawner
{
    [SerializeField] private List<Transform> _spawnPoints;

    private float _timeToSpawnTank;
    private float _timeToSpawnSoldier;
    private int _quantitySoldiers;
    private int _quantityTanks;


    [Header("Waypoints")] 
    [SerializeField] protected GameObject[] waypoints;


    void Start()
    {
        /*Difficulty difficulty = DifficultyManager.Instance.Difficulty;
        _timeToSpawnTank = difficulty.TimeToSpawnTank;
        _timeToSpawnSoldier = difficulty.TimeToSpawnSoldier;
        _quantitySoldiers = difficulty.QuantitySoldiers;
        _quantityTanks = difficulty.QuantityTanks;*/

        _timeToSpawnSoldier = 10f;
        _quantitySoldiers =1;

        //InvokeRepeating("SpawnTank", _timeToSpawnTank, _timeToSpawnTank);
        InvokeRepeating("SpawnSoldier", _timeToSpawnSoldier, _timeToSpawnSoldier);
        //InvokeRepeating("IncreaseQuantity", difficulty.TimeToMultiplyQuantity,difficulty.TimeToMultiplyQuantity);
    }

    void Update()
    {
    }

    /*public override void SpawnTank()
    {
        if (!GameManager.Instance.IsActive) return;
        for (int i = 0; i < _quantityTanks; i++)
        {
            Unit unit = _unitSpawner.SpawnTank(_team, GetSpawnPoint().position);
            unit.gameObject.AddComponent<AIUnitController>();
        }
    }*/

    public override void SpawnSoldier()
    {
        //Debug.Log("1xd");
        if (!GameManager.Instance.IsActive) return;
        //Debug.Log("2xd");
        for (int i = 0; i < _quantitySoldiers; i++)
        {
            Unit unit = _unitSpawner.SpawnAlien(_team, GetSpawnPoint().position);
            unit.gameObject.AddComponent<AIUnitController>();
            //unit.waypoints = waypoints;
            //Debug.Log(unit.waypoints.Length);
        }
    }

    /*private void IncreaseQuantity()
    {
        Difficulty difficulty = DifficultyManager.Instance.Difficulty;
        _quantitySoldiers += difficulty.QuantitySoldiers;
        _quantityTanks += difficulty.QuantityTanks;
    }*/
    
    protected Transform GetSpawnPoint()
    {
        int index = Random.Range(0, _spawnPoints.Count);
        return _spawnPoints[index];
    }
    
}