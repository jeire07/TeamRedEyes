using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomItemSpawn : MonoBehaviour
{
    public GameObject[] ItemPrefabs;
    public Transform[] ItemSpawnPoints = new Transform[5];
    public float ItemLastSpawnTime = 0f;
    private bool _IsItemSpawned = false;
    public float RespawnTime = 48f;

    private void Awake()
    {
        Transform itemSpawnPoint = transform.Find("ItemSpawnPoint");

        for (int i = 0; i < ItemSpawnPoints.Length; i++)
        {
            ItemSpawnPoints[i] = itemSpawnPoint.GetChild(i);
        }
    }

    private void OnEnable()
    {
        if (_IsItemSpawned == false || Time.time - ItemLastSpawnTime >= RespawnTime)
        {
            StartCoroutine(SpawnItems());
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
                ItemLastSpawnTime = Time.time;
            }
            yield return new WaitForSeconds(48f);
        }
    }
    private int CountItemsWithTag(string tag)
    {
        GameObject[] items = GameObject.FindGameObjectsWithTag(tag);
        return items.Length;
    }
}