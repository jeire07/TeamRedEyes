using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawn : MonoBehaviour
{
    public GameObject[] MonsterPrefabs;
    public Transform[] MonsterSpawnPoints = new Transform[5];
    private bool _IsSpawning = false;

    private void Awake()
    {
        Transform monterSpawnPoint = transform.Find("MonsterSpawnPoint1");

        for (int i = 0; i < MonsterSpawnPoints.Length; i++)
        {
            MonsterSpawnPoints[i] = monterSpawnPoint.GetChild(i);
        }
    }
    private void Start()
    {
        StartSpawning();
    }

    private void StartSpawning()
    {
        _IsSpawning = true;
        StartCoroutine(SpawnMonsters());
    }

    private void StopSpawning()
    {
        _IsSpawning = false;
    }

    private IEnumerator SpawnMonsters()
    {
        while (_IsSpawning)
        {
            foreach (Transform monsterSpawnPoint in MonsterSpawnPoints)
            {
                int monsterCount = CountMonstersWithTag("Enermy1");

                if (monsterCount >= 25)
                {
                    StopSpawning();
                }
                else
                {
                    GameObject randomMonsterPrefab = MonsterPrefabs[Random.Range(0, MonsterPrefabs.Length)];
                    GameObject newMonster = Instantiate(randomMonsterPrefab, monsterSpawnPoint.position, Quaternion.identity);
                    newMonster.transform.parent = transform;
                }
            }
            yield return new WaitForSeconds(48f);
        }
    }
    private int CountMonstersWithTag(string tag)
    {
        GameObject[] monsters = GameObject.FindGameObjectsWithTag(tag);
        return monsters.Length;
    }
}
