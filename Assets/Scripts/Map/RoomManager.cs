using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    #region Floor Rooms
    public GameObject _6F_Rooms;
    public GameObject _5F_Rooms;
    public GameObject _4F_Rooms;
    public GameObject _3F_Rooms;
    public GameObject _2F_Rooms;
    #endregion

    private Dictionary<string, GameObject> floorObjects = new Dictionary<string, GameObject>();
    private void Start()
    {
        floorObjects.Add("6F_Cube", _6F_Rooms);
        floorObjects.Add("5F_Cube", _5F_Rooms);
        floorObjects.Add("4F_Cube", _4F_Rooms);
        floorObjects.Add("3F_Cube", _3F_Rooms);
        floorObjects.Add("2F_Cube", _2F_Rooms);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (var floorObject in floorObjects)
            {
                floorObject.Value.SetActive(false);
            }

            if (floorObjects.ContainsKey(gameObject.tag))
            {
                floorObjects[gameObject.tag].SetActive(true);
            }
        }
    }
}
