using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MenuCameraMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector3[] wayPointArray;
    public int currentWayPoint = 0;
    void Start()
    {
        Time.timeScale =0.25f;
        wayPointArray = new Vector3[4];
        wayPointArray[0] = new Vector3(-15, 0,-10);
        wayPointArray[1] = new Vector3(-30, 0,-10);
        wayPointArray[2] = new Vector3(-30, -15,-10);
        wayPointArray[3] = new Vector3(-15, -15,-10);
    }
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, wayPointArray[currentWayPoint], 1 * Time.deltaTime);
        
        if (Vector2.Distance(transform.position, wayPointArray[currentWayPoint]) < 0.5f)
        {
            currentWayPoint = NewWayPoint( currentWayPoint, wayPointArray.Length);
        }
    }
    public int NewWayPoint( int cWayNumber,int maxcount)
    {
        Debug.Log("current number" + cWayNumber);
        Debug.Log("max count " +  maxcount);
        int newnumber;
        if(cWayNumber >= maxcount - 1)
        {
            newnumber = 0;
        }
        else
        {
            newnumber = cWayNumber + 1;
        }
        Debug.Log("new number"+ newnumber);
        return newnumber;
    }
}