using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public float damping = 1.5f;
    public Vector2 offset = new(2f, 1f);
    public bool faceLeft;
    Transform player;
    int lastX;
    
    void Start()
    {
        offset = new Vector2(Mathf.Abs(offset.x), offset.y);
        FindPlayer(faceLeft);
    }

    public void FindPlayer(bool playerFaceLeft)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lastX = Mathf.RoundToInt(player.position.x);
        if (playerFaceLeft)
        {
            transform.position = new Vector3(player.position.x - offset.x, player.position.y + offset.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            int currentX = Mathf.RoundToInt(player.position.x);
            if (currentX > lastX) faceLeft = false;
            else if (currentX < lastX) faceLeft = true;

            lastX = Mathf.RoundToInt(player.position.x);

            Vector3 target;
            if (faceLeft) 
            {
                target = new (player.position.x - offset.x, player.position.y + offset.y, transform.position.z);
            }
            else
            {
                target = new (player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
            }

            Vector3 current_position = Vector3.Lerp(transform.position, target, damping * Time.deltaTime);
            transform.position = current_position;
        }
    }
}
