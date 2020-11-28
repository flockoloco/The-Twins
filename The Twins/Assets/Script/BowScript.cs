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

    public float bowTimer;
    public GameObject arrowPrefab;


    void Awake()
    {
        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        player = GameObject.FindWithTag("Player");
        bowAnimator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        bowTimer += Time.deltaTime;
        if (Input.GetKey(KeyCode.Mouse1) && (bowTimer > 0.5))
        {
            bowAnimator.SetBool("Attack", true);
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
            bowrotatorotato = Mathf.Atan2(mouseDir.y, mouseDir.x) * Mathf.Rad2Deg;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, bowrotatorotato);
            gameObject.transform.position = new Vector3(finalvector.x + playerPos.x, finalvector.y + playerPos.y - 0.25f, 0);
        }
    }
    public void SpawnArrow()
    {
        Vector2 direction = -UsefulllFs.Dir(playerPos, transform.position, true);
        float arrowSpeed = 10f;
        GameObject arrow = Instantiate(arrowPrefab, transform.position, transform.rotation);
        arrow.GetComponent<ArrowScript>().ArrowDamage(gameObject.GetComponent<PlayerStats>().bowDamage);
        arrow.GetComponent<Rigidbody2D>().velocity = direction * arrowSpeed;


    }
}
