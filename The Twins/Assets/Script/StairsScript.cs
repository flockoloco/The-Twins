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

            var generator = GameObject.Find("LevelGenerator").GetComponent<DungeonGenerator>();
            generator.Generate();
            GameObject.FindWithTag("MainCamera").GetComponent<cameramovement>().shopOpen = false;
            playerMovement.Invoke("PlayerRespawn", 1f);

            //go to next level (generate a new one maybe in a new scene?)
        }
    }
}