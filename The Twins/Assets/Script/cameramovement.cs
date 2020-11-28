using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramovement : MonoBehaviour
{
    private Vector2 mousePos;
    private GameObject player;
    private Vector2 playerPos;
    private Camera cam;
    private Vector2 finalvector;
    private Vector2 mouseDir;
    private float mouseDist;

    void Start()
    {
        cam = gameObject.GetComponent<Camera>();
        player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        if (!PauseMenu.gameIsPaused)
        {
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            playerPos = player.transform.position;
            mouseDir = new Vector2(mousePos.x - playerPos.x, mousePos.y - playerPos.y).normalized;
            mouseDist = Mathf.Sqrt((mousePos.x - playerPos.x) * (mousePos.x - playerPos.x) + (mousePos.y - playerPos.y) * (mousePos.y - playerPos.y));
            finalvector = mouseDir * mouseDist / 8;
            gameObject.transform.position = new Vector3(finalvector.x + playerPos.x, finalvector.y + playerPos.y, -10);
        }
    }
}
