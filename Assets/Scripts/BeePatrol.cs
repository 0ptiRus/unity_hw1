using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeePatrol : MonoBehaviour
{
    public float speed = 5f;
    public int spot = 0;
    public int next = 1;
    public Transform[] move_spots;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, move_spots[spot].position, speed * Time.deltaTime);
        if(Vector2.Distance(transform.position, move_spots[spot].position) < 0.2f)
        {
            if(spot == move_spots.Length-1)
            {
                next = -1;
            }
            if(spot == 0)
            {
                next = 1;
            }
            spot += next;
        }
        StartCoroutine(Wait(2f));
    }

    private IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
}
