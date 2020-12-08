using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDoorScript : MonoBehaviour
{
    public List<GameObject> enemiesInside = new List<GameObject>();
    public bool playerInside;

    private void Update()
    {
        enemiesInside.RemoveAll(i => i == null);
    }

    public void OnTriggerStay2D(Collider2D collision)
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerInside = true;
        }

        if(collision.tag == "Enemy")
        {
            enemiesInside.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerInside = false;
        }
    }
}
