using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomSpawn : MonoBehaviour
{
    public int doorDirection;
    /*
     * 1 -> bottom
     * 2 -> left
     * 3 -> up
     * 4 -> right
    */

    private roomTemplates roomtemplates;
    private int random;
    public bool spawned = false;
    public float waitTime = 4f;

    private void Start()
    {
        Destroy(gameObject, waitTime);
        roomtemplates = GameObject.FindGameObjectWithTag("rooms").GetComponent<roomTemplates>();
        Invoke("Spawn", 0.1f);
    }

    void Spawn()
    {
        if (spawned == false)
        {
            if (doorDirection == 1)
            {
                random = Random.Range(0, roomtemplates.roomBottom.Length);
                Instantiate(roomtemplates.roomBottom[random], transform.position, roomtemplates.roomBottom[random].transform.rotation);
            }
            else if (doorDirection == 2)
            {
                random = Random.Range(0, roomtemplates.roomLeft.Length);
                Instantiate(roomtemplates.roomLeft[random], transform.position, roomtemplates.roomLeft[random].transform.rotation);
            }
            else if (doorDirection == 3)
            {
                random = Random.Range(0, roomtemplates.roomTop.Length);
                Instantiate(roomtemplates.roomTop[random], transform.position, roomtemplates.roomTop[random].transform.rotation);
            }
            else if (doorDirection == 4)
            {
                random = Random.Range(0, roomtemplates.roomRight.Length);
                Instantiate(roomtemplates.roomRight[random], transform.position, roomtemplates.roomRight[random].transform.rotation);
            }
            spawned = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("spawnPoint"))
        {
            if (other.GetComponent<roomSpawn>().spawned == false && spawned == false)
            {
                Instantiate(roomtemplates.closedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            spawned = true;
        }
    }
}
