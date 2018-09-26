using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplate : MonoBehaviour
{
    public GameObject[] leftRooms;
    public GameObject[] downRooms;
    public GameObject[] rightRooms;
    public GameObject[] upperRooms;

    public GameObject closedRoom;

    public List<GameObject> rooms;

    public float waitTime;
    private bool enemySpawned;
    public GameObject enemy;

    void Update()
    {

        if (waitTime <= 0 && enemySpawned == false)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if (i == rooms.Count - 1)
                {
                    Instantiate(enemy, rooms[i].transform.position, Quaternion.identity);
                    enemySpawned = true;
                }
            }
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }
}
