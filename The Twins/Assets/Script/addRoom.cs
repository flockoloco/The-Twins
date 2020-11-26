using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addRoom : MonoBehaviour
{
	private roomTemplates roomtemplates;

	void Start()
	{

		roomtemplates = GameObject.FindGameObjectWithTag("rooms").GetComponent<roomTemplates>();
		roomtemplates.rooms.Add(this.gameObject);
	}
}
