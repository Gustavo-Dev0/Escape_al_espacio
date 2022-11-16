using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    [Header("Units")]
    [SerializeField] private Unit _soldierPrefab;
    [SerializeField] private Unit _alienPrefab;
    [SerializeField] private Unit _tankPrefab;

    public Unit SpawnTank(Team team, Vector3 position)
    {
        Unit unit = SimplePool.Spawn(_tankPrefab.gameObject, position, transform.rotation).GetComponent<Unit>();
        unit.InitTeam(team);
        return unit;
    }

    public Unit SpawnSoldier(Team team, Vector3 position)
    {
        Unit unit = SimplePool.Spawn(_soldierPrefab.gameObject, position, transform.rotation).GetComponent<Unit>();
        unit.InitTeam(team);
        return unit;
    }

    public Unit SpawnAlien(Team team, Vector3 position)
    {
        //Debug.Log("Listo para salir");
        Unit unit = SimplePool.Spawn(_alienPrefab.gameObject, position, transform.rotation).GetComponent<Unit>();
        unit.InitTeam(team);
        return unit;
    }
}
