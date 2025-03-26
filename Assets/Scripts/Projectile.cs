using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float time_to_destroy = 3f;
    public float speed = 10f;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        Invoke("DestroyBullet", time_to_destroy);
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
