using ProceduralLevelGenerator.Unity.Generators.DungeonGenerator;
using UnityEngine;

public class StairsScript : MonoBehaviour
{
    public bool playerInside;
    private bool used = false;
    private GameObject player;
    private PlayerMovement playerMovement;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (playerInside && Input.GetKey(KeyCode.E))
        {
            Interact();
        }
    }

    public void Interact()
    {
        if (used == false)
        {
            used = true;

            player.transform.position = new Vector3(10000, 0, 0);
            if (GameObject.FindWithTag("Player").GetComponent<PlayerStats>().currentLevel == 0)
            {
                var generator = GameObject.Find("AhhhGenerator").GetComponent<DungeonGenerator>();
                generator.Generate();
                //var generator = GameObject.Find("LevelGenerator").GetComponent<DungeonGenerator>(); //unused, deploy once database is up
                //generator.Generate();
                GameObject.FindWithTag("Player").GetComponent<PlayerStats>().currentLevel = 1;
            }
            else if (GameObject.FindWithTag("Player").GetComponent<PlayerStats>().currentLevel == 1)
            {
               
                GameObject.FindWithTag("Player").GetComponent<PlayerStats>().currentLevel = 2;
            }


                GameObject.FindWithTag("Player").GetComponent<PlayerStats>().shopOpen = false;
            playerMovement.Invoke("PlayerRespawn", 1f);


        }
    }
}