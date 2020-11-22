using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    private Vector2 mousePos;
    private GameObject player;
    private Vector2 playerPos;
    private Camera cam;
    private Vector2 finalvector;
    private Vector2 mouseDir;
    private float swordrotatorotato;

    private bool rotatoFrezeto;

    private Animator swordAnimator;
    void Awake()
    {
        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        player = GameObject.FindWithTag("Player");
        swordAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            swordAnimator.SetBool("Attack", true);
            rotatoFrezeto = true;
        }
    }

    void FixedUpdate()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        playerPos = player.transform.position;
        mouseDir = new Vector2(mousePos.x - playerPos.x, mousePos.y - playerPos.y).normalized;

        finalvector = mouseDir * 1.25f;
        if (!rotatoFrezeto)
        {
            swordrotatorotato = Mathf.Atan2(mouseDir.y, mouseDir.x) * Mathf.Rad2Deg;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, swordrotatorotato);
            gameObject.transform.position = new Vector3 (finalvector.x + playerPos.x, finalvector.y + playerPos.y - 0.25f, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EProjectiles")
        {
            Destroy(collision.gameObject);
        }
    }


    //So call out my name (call out my name)
    //Call out my name when I kiss you so gently
    //I want you to stay(I want you to stay)
    void stopSwordAttackAnimation()
    {
        swordAnimator.SetBool("Attack", false);
        rotatoFrezeto = false;
    }
}
