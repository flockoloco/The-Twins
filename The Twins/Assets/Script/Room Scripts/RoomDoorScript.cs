using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDoorScript : MonoBehaviour
{
    public List<GameObject> enemiesInside = new List<GameObject>();
    public bool playerInside;


    public void RemoveEnemy(GameObject enemyIndex)
    {
        enemiesInside.Remove(enemyIndex);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerInside = false;
        }
    }
    public void EnemyTriggerCheck()
    {
        if (playerInside == true && enemiesInside.Count > 0)
        {
            Debug.Log(enemiesInside.Count);
            foreach (GameObject enemy in enemiesInside)
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
                    GameObject.FindWithTag("UICanvas").GetComponent<UITextManager>().EnteredABossRoom(enemy);
                }
            }
        }
    }
}