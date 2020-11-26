﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHitBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collided with something");
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "EProjectiles")
        {
            Destroy(collision.gameObject);
        }
    }
}
