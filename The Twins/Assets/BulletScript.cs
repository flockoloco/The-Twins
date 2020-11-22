using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody2D bulletrigidbody;
    void Start()
    {
        bulletrigidbody = GetComponent<Rigidbody2D>();

        bulletrigidbody.velocity = new Vector2(0,0 );
    }
    void Update()
    {
        
    }
}
