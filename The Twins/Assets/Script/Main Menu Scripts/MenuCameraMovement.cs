using UnityEngine;

public class MenuCameraMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector3[] wayPointArray;
    public int currentWayPoint = 0;

    private void Start()
    {
        Screen.SetResolution(1920, 1080, true);

        wayPointArray = new Vector3[4];
        wayPointArray[0] = new Vector3(-15, 0, -10);
        wayPointArray[1] = new Vector3(-30, 0, -10);
        wayPointArray[2] = new Vector3(-30, -15, -10);
        wayPointArray[3] = new Vector3(-15, -15, -10);
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, wayPointArray[currentWayPoint], 0.25f * Time.deltaTime);

        if (Vector2.Distance(transform.position, wayPointArray[currentWayPoint]) < 0.5f)
        {
            currentWayPoint = NewWayPoint(currentWayPoint, wayPointArray.Length);
        }
    }

    public int NewWayPoint(int cWayNumber, int maxcount)
    {
        int newnumber;
        if (cWayNumber >= maxcount - 1)
        {
            newnumber = 0;
        }
        else
        {
            newnumber = cWayNumber + 1;
        }
        return newnumber;
    }
}