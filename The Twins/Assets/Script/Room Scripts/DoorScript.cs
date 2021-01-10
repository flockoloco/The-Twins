using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public RoomDoorScript RoomDoor;

    public Sprite doorOpened;
    public Sprite doorClosed;

    private Animator dooranimator;

    public List<ContactPoint2D> bigList;

    public List<GameObject> rooms = new List<GameObject>();

    public bool onlyNow = false;

    private void Start()
    {
        dooranimator = GetComponent<Animator>();
    }
    void Update()
    {
        if (onlyNow)
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
    } 

    public void OpeningDoor()
    {
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
    }

    public void ClosingDoor()
    {
        gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
    }
    public void CheckContacts()
    {
        Debug.Log(rooms.Count);
        foreach (GameObject roomConnect in rooms)
        {
            Debug.Log("Nao queria por isso ca mas coloquei");
            RoomDoor = roomConnect.GetComponent<RoomDoorScript>();
            onlyNow = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Room")
        {
            Debug.Log("AAAAAAAAAABC SAMFADSNF");
            rooms.Add(collision.gameObject);
        }
        
    }
    
}
