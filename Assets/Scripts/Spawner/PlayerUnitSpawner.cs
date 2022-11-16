using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using Util;

public class PlayerUnitSpawner : MonoBehaviour
{
    [SerializeField] protected UnitSpawner _unitSpawner;
    [SerializeField] protected Team _team;

    [SerializeField] private Transform _tankSpawnPoint;
    [SerializeField] private Transform _soldierSpawnPoint;

    [SerializeField] private SoundEffect _spawnSound;

    private int _soldierCost = 100;
    private int _tankCost = 400;
    private int _workerCost = 200;

    private static string NOT_ENOUGH_MONEY_STRING = "Not enough money to spawn unit.";

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SpawnSoldier();
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SpawnTank();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SpawnWorker();
        }
    }
    
    public virtual void SpawnTank()
    {
        //bool success = PlayerMoneyManager.Instance.Remove(_tankCost);
        bool success = true;
        if (!success)
        {
            UIManager.Instance.ShowMessagePopup(NOT_ENOUGH_MONEY_STRING);
            return;
        }
        Unit unit = _unitSpawner.SpawnTank(_team, _tankSpawnPoint.position);
        PlayerUnitsManager.Instance.Register(unit);
        _spawnSound.Play();
    }

    public virtual void SpawnSoldier()
    {
        Debug.Log("ASSDIFwje");
        //bool success = PlayerMoneyManager.Instance.Remove(_soldierCost);
        bool success = true;
        if (!success)
        {
            UIManager.Instance.ShowMessagePopup(NOT_ENOUGH_MONEY_STRING);
            return;
        }
        Unit unit = _unitSpawner.SpawnSoldier(_team, _soldierSpawnPoint.position);
        Debug.Log(unit);
        PlayerUnitsManager.Instance.Register(unit);
        Debug.Log("unit s");
        _spawnSound.Play();
    }
    
    public void SpawnWorker()
    {
        //bool success = PlayerMoneyManager.Instance.Remove(_workerCost);
        bool success = true;
        if (!success)
        {
            UIManager.Instance.ShowMessagePopup(NOT_ENOUGH_MONEY_STRING);
            return;
        }
        PlayerMoneyManager.Instance.AddWorker();
        _spawnSound.Play();
    }
}
