using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMonsterSpawn : MonoBehaviour
{
    public GameObject[] MonsterPrefabs;
    public Transform[] MonsterSpawnPoints = new Transform[2];
    public float MonsterLastSpawnTime = 0f;
    private bool _IsMonsterSpawned = false;
    public float RespawnTime = 48f;

    private void Awake()
    {
        Transform monterSpawnPoint = transform.Find("MonsterSpawnPoint");

        for (int i = 0; i < MonsterSpawnPoints.Length; i++)
        {
            MonsterSpawnPoints[i] = monterSpawnPoint.GetChild(i);
        }
    }

    private void OnEnable()
    {
        if (_IsMonsterSpawned == false || Time.time - MonsterLastSpawnTime >= RespawnTime)
        {
            StartCoroutine(SpawnMonsters());
        }
    }
    public IEnumerator SpawnMonsters()
    {
        while (true)
        {
            foreach (Transform monsterSpawnPoint in MonsterSpawnPoints)
            {
                int monsterCount = CountMonstersWithTag("Enemy");

                if (monsterCount >= 30)
                {
                    yield break;
                }

                GameObject randomMonsterPrefab = MonsterPrefabs[Random.Range(0, MonsterPrefabs.Length)];
                GameObject newMonster = Instantiate(randomMonsterPrefab, monsterSpawnPoint.position, Quaternion.identity);
                newMonster.transform.parent = transform;
                _IsMonsterSpawned = true;
                MonsterLastSpawnTime = Time.time;
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
