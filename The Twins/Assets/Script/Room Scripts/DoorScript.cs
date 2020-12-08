using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public RoomDoorScript RoomDoor;

    public Sprite doorOpened;
    public Sprite doorClosed;

    private Animator dooranimator;

    public List<GameObject> rooms = new List<GameObject>();

    private void Start()
    {
        dooranimator = GetComponent<Animator>();
    }
    void Update()
    {
        if (RoomDoor.enemiesInside.Count == 0)
        {
            dooranimator.SetBool("open", true);
            Invoke("OpeningDoor", 1f);
        }
        if (RoomDoor.enemiesInside.Count >= 1 && RoomDoor.playerInside == true) 
        {
            dooranimator.SetBool("open", false);
            Invoke("ClosingDoor", 1f);
        }
    }

    public void OpeningDoor()
    {
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
    }

    public void ClosingDoor()
    {
        gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Room")
        {
            RoomDoor = collision.gameObject.GetComponent<RoomDoorScript>();
        }
    }
}
