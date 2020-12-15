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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerInside = true;
            EnemyTriggerCheck(playerInside, enemiesInside);
        }
        if (collision.tag == "Enemy")
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
    void EnemyTriggerCheck(bool playercheck, List<GameObject> enemies)
    {
        if (playercheck == true && enemies.Count > 0)
        {
            foreach (GameObject enemy in enemies)
            {
                if (enemy.name.Contains("Normal"))
                {
                    enemy.GetComponent<NormalAI>().triggered = true;
                }
                else if (enemy.name.Contains("Tank"))
                {
                    enemy.GetComponent<TankAI>().triggered = true;
                }
                else if (enemy.name.Contains("Shotty"))
                {
                    enemy.GetComponent<ShottyAI>().triggered = true;
                }
                else if (enemy.name.Contains("Runner"))
                {
                    enemy.GetComponent<RunnerAI>().triggered = true;
                }
                else if (enemy.name.Contains("Boss"))
                {

                }
            }
        }
        else
        {
            foreach (GameObject enemy in enemies)
            {
                if (enemy.name.Contains("Normal"))
                {
                    enemy.GetComponent<NormalAI>().triggered = false;
                }
                else if (enemy.name.Contains("Tank"))
                {
                    enemy.GetComponent<TankAI>().triggered = false;
                }
                else if (enemy.name.Contains("Shotty"))
                {
                    enemy.GetComponent<ShottyAI>().triggered = false;
                }
                else if (enemy.name.Contains("Runner"))
                {
                    enemy.GetComponent<RunnerAI>().triggered = false;
                }
                else if (enemy.name.Contains("Boss"))
                {

                }
            }
        }
    }
}