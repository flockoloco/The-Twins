using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramovement : MonoBehaviour
{
    public Vector2 mousePos;
    private GameObject player;
    public Vector2 playerPos;
    private Camera cam;
    public Vector2 finalvector;
    public Vector2 mouseDir;
    public float mouseDist;
    void Start()
    {
        cam = gameObject.GetComponent<Camera>();
        player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        playerPos = player.transform.position;
        mouseDir = new Vector2(mousePos.x-playerPos.x, mousePos.y-playerPos.y).normalized;
        mouseDist = Mathf.Sqrt((mousePos.x-playerPos.x)*(mousePos.x-playerPos.x) + (mousePos.y-playerPos.y)*(mousePos.y-playerPos.y));
        finalvector = mouseDir * mouseDist/5;
        gameObject.transform.position = new Vector3(finalvector.x + playerPos.x,finalvector.y + playerPos.y,-10);
    }
}
