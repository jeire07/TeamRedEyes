using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    public GameObject[] itemPrefabs;
    public Transform[] spawnPoints = new Transform[5];
    public float spawnInterval = 1f;
    public int maxItemsPerRoom;

    private void Start()
    {
        Transform SpawnPoint = transform.Find("SpawnPoint");

        for(int i = 0; i < spawnPoints.Length; i++)
        {
            spawnPoints[i] = SpawnPoint.GetChild(i);
        }

        StartCoroutine(SpawnItems());
    }
    private IEnumerator SpawnItems()
    {
        while (true)
        {
            foreach (Transform spawnPoint in spawnPoints)
            {
                int itemsInRoom = CountItemsInRoom(spawnPoint);

                if (itemsInRoom < maxItemsPerRoom)
                {
                    GameObject randomItemPrefab = itemPrefabs[Random.Range(0, itemPrefabs.Length)];
                    GameObject newItem = Instantiate(randomItemPrefab, spawnPoint.position, Quaternion.identity);
                    newItem.transform.parent = transform;
                }
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private int CountItemsInRoom(Transform room)
    {
        int count = 0;
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("Item"))
        {
            if (item.transform.parent == room)
            {
                count++;
            }
        }
        return count;
    }
}