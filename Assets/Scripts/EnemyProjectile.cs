using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float time_to_destroy = 3f;
    public float speed = 10f;
    public Vector2 target_pos;
    public bool IsGoingToHover = false;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (!IsGoingToHover)
        {
            Vector2 direction = (target_pos - (Vector2)transform.position).normalized;
            rb.velocity = direction * speed;   
        }
        
        Invoke("DestroyBullet", time_to_destroy);
    }
    public void SetTarget(Vector2 target)
    {
        target_pos = target;
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
