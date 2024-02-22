using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawn : MonoBehaviour
{
    public GameObject[] ItemPrefabs;
    public GameObject[] MonsterPrefabs;
    public Transform[] ItemSpawnPoints = new Transform[5];
    public Transform[] MonsterSpawnPoints = new Transform[2];
    public float LastSpawnTime = 0f;
    private bool _IsItemSpawned = false;
    private bool _IsMonsterSpawned = false;
    public float RespawnTime = 48f;

    private void Awake()
    {
        Transform itemSpawnPoint = transform.Find("ItemSpawnPoint");
        Transform monterSpawnPoint = transform.Find("MonsterSpawnPoint");

        for (int i = 0; i < ItemSpawnPoints.Length; i++)
        {
            ItemSpawnPoints[i] = itemSpawnPoint.GetChild(i);
        }
        
        for (int i = 0; i < MonsterSpawnPoints.Length; i++)
        {
            MonsterSpawnPoints[i] = monterSpawnPoint.GetChild(i);
        }
    }

    private void OnEnable()
    {
        if (_IsItemSpawned == false || Time.time - LastSpawnTime >= RespawnTime)
        {
            StartCoroutine(SpawnItems());
            StartCoroutine(SpawnMonsters());
        }
    }

    public IEnumerator SpawnItems()
    {
        while (true)
        {
            foreach (Transform itemSpawnPoint in ItemSpawnPoints)
            {
                int itemCount = CountItemsWithTag("Item");

                if (itemCount >= 25)
                {
                    yield break;
                }

                GameObject randomItemPrefab = ItemPrefabs[Random.Range(0, ItemPrefabs.Length)];
                GameObject newItem = Instantiate(randomItemPrefab, itemSpawnPoint.position, Quaternion.identity);
                newItem.transform.parent = transform;
                _IsItemSpawned = true;
                LastSpawnTime = Time.time;
            }
            yield return new WaitForSeconds(48f);
        }
    }
    private int CountItemsWithTag(string tag)
    {
        GameObject[] items = GameObject.FindGameObjectsWithTag(tag);
        return items.Length;
    }

    public IEnumerator SpawnMonsters()
    {
        while (true)
        {
            foreach (Transform monsterSpawnPoint in MonsterSpawnPoints)
            {
                int monsterCount = CountMonstersWithTag("Monster");

                if (monsterCount >= 10)
                {
                    yield break;
                }

                GameObject randomMonsterPrefab = MonsterPrefabs[Random.Range(0, MonsterPrefabs.Length)];
                GameObject newMonster = Instantiate(randomMonsterPrefab, monsterSpawnPoint.position, Quaternion.identity);
                newMonster.transform.parent = transform;
                _IsMonsterSpawned = true;
                LastSpawnTime = Time.time;
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