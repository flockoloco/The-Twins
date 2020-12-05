using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowScript : MonoBehaviour
{
    private Vector2 mousePos;
    private GameObject player;
    private Vector2 playerPos;
    private Camera cam;
    private Vector2 finalvector;
    private Vector2 mouseDir;
    private float bowrotatorotato;
    public bool rotatoFrezeto;
    private Animator bowAnimator;

    private Vector2 mouseDirection;
    

    public float bowTimer;
    public GameObject arrowPrefab;


    void Awake()
    {
        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        player = GameObject.FindWithTag("Player");
        bowAnimator = GetComponent<Animator>();
    }
 
    private void Update()
    {
        bowTimer += Time.deltaTime;
        
        if (Input.GetKey(KeyCode.Mouse0) && (bowTimer > 0.5))
        {
            bowTimer = 0;
            bowAnimator.SetBool("Fire", true);
            rotatoFrezeto = true;
            mouseDirection = mousePos;
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
            bowrotatorotato = Mathf.Atan2(mouseDir.y, mouseDir.x) * Mathf.Rad2Deg;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, bowrotatorotato);
            gameObject.transform.position = new Vector3(finalvector.x + playerPos.x, finalvector.y + playerPos.y - 0.25f, 0);
        }
    }
    public void SpawnArrow()
    {
        
        Vector2 direction = -UsefulllFs.Dir(mouseDirection, transform.parent.gameObject.transform.position, true);
        float arrowSpeed = 10f;
        GameObject arrow = Instantiate(arrowPrefab, transform.position, transform.rotation);
        //if (arrowEquiped) fazer a diferenca de flechas , meter input para trocar entre flechas usadas, fazer um if para se o player nao tiver flechas, fazer o player perder flechas.
        arrow.GetComponent<ArrowScript>().ArrowDamage(transform.parent.gameObject.GetComponent<PlayerStats>().bowDamage);//por esta linha dentro do if e meter orearrowdamage / normalarrowdamage

        arrow.GetComponent<Rigidbody2D>().velocity = direction * arrowSpeed;
        
    }
    
    public void StopBowAnimation()
    {
        bowAnimator.SetBool("Fire", false);
        rotatoFrezeto = false;
        SpawnArrow();
    }
}
