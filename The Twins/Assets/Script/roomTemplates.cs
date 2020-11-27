using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class roomTemplates : MonoBehaviour
{
    public GameObject[] roomBottom;
    public GameObject[] roomLeft;
    public GameObject[] roomTop;
    public GameObject[] roomRight;

    public GameObject closedRoom;

    public List<GameObject> rooms;

	public float waitTime = 1f;
	private bool spawnedBoss;
	public GameObject boss;

    void Update()
	{
		if (waitTime <= 0 && spawnedBoss == false)
		{
			for (int i = 0; i < rooms.Count; i++)
			{
				if (i == rooms.Count - 1)
				{
					Instantiate(boss, rooms[i].transform.position, Quaternion.identity);
					spawnedBoss = true;
				}
			}
		}
		else
		{
			waitTime -= Time.deltaTime;
		}
	}
}