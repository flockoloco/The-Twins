using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDoorScript : MonoBehaviour
{
    public List<GameObject> enemiesInside = new List<GameObject>();
    public bool playerInside;

    private void Update()
    {
    }

    public void RemoveEnemy(GameObject enemyIndex)
    {
        enemiesInside.Remove(enemyIndex);
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
            Debug.Log(enemies.Count);
            foreach (GameObject enemy in enemies)
            {
                if (enemy.name.Contains("Normal")|| enemy.name.Contains("MachineGun"))
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
                    if (enemy.name == "Boss1")
                    {
                        enemy.GetComponent<Boss1Ai>().triggered = true;
                    }
                    if (enemy.name == "Boss2")
                    {
                        enemy.GetComponent<Boss2Ai>().triggered = true;
                    }
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