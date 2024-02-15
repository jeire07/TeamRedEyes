using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public Transform[] RoomSpawnPoints = new Transform[25];
    public GameObject[] RoomPrefabs = new GameObject[25];

    private void Start()
    {
        for (int i = 0; i < 25; i++)
        {
            string roomName = string.Format("Prefabs/Room/Room_{0}", i);
            RoomPrefabs[i] = Resources.Load<GameObject>(roomName);
            Instantiate(RoomPrefabs[i], RoomSpawnPoints[i].position, Quaternion.identity);
            RoomPrefabs[i].SetActive(false);
        }
    }
}
