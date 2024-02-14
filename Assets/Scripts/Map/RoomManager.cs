using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public Transform Player;
    public Transform RoomCenter;
    public GameObject RoomPrefab;

    public float activationDistance = 10f;

    private void Start()
    {
        GameObject loadedPrefab = Resources.Load<GameObject>("Prefabs/Room/Room_Test");
        RoomPrefab = Instantiate(loadedPrefab);
        RoomCenter = RoomPrefab.transform.Find("RoomCenter");
    }
    private void Update()
    {
        float distance = Vector3.Distance(Player.position, RoomCenter.position);

        if (distance <= activationDistance)
        {
            RoomPrefab.SetActive(true);
        }
        else
        {
            RoomPrefab.SetActive(false);
        }
    }
}
