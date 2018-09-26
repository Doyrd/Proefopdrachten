using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    [SerializeField]
    private int openingDirection;

    private RoomTemplate templates;
    private int randomizer;
    private bool spawned = false;

    [SerializeField]
    private float waitTime;

	void Start ()
    {
        Destroy(gameObject, waitTime);
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplate>();
        Invoke("InitializeRooms", 0.1f);
	}
	
	void InitializeRooms()
    {
        if(spawned == false)
        {
            switch (openingDirection)
            {
                case 1:
                    randomizer = Random.Range(0, templates.leftRooms.Length);
                    Instantiate(templates.leftRooms[randomizer], transform.position, Quaternion.identity);
                    break;
                case 2:
                    randomizer = Random.Range(0, templates.downRooms.Length);
                    Instantiate(templates.downRooms[randomizer], transform.position, Quaternion.identity);
                    break;
                case 3:
                    randomizer = Random.Range(0, templates.rightRooms.Length);
                    Instantiate(templates.rightRooms[randomizer], transform.position, Quaternion.identity);
                    break;
                case 4:
                    randomizer = Random.Range(0, templates.upperRooms.Length);
                    Instantiate(templates.upperRooms[randomizer], transform.position, Quaternion.identity);
                    break;
            }
            spawned = true;
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spawnpoint"))
        {
            if(other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
            spawned = true;
        }
    }
}
