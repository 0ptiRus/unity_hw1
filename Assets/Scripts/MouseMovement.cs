using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    private bool isMoving;

    private Vector3 target_pos;

    public float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            target_pos = Camera.current.ScreenToWorldPoint(Input.mousePosition);
            isMoving = true;
        }
        if(isMoving)
        {
            transform.position = Vector2.MoveTowards(target_pos, target_pos, Time.fixedDeltaTime * speed);
            if (transform.position == target_pos)
            {
                isMoving = false;
            }
        }
    }
}
