using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class Boss : MonoBehaviour
{
    public GameObject projectile;
    public GameObject special_projectile;
    public Transform main_fire_point;
    public Transform[] fire_points;
    
    public float fire_rate = 2f; 
    public float fire_point_delay = 0.5f; 
    public int shots_before_special = 5;

    private int shot_count = 0;
    private float nextFireTime = 0f;
    private Transform player;
    private Vector2 last_known_pos;
    
    private Vector2[] starDirections = {
        new Vector2(0.7f, 0.7f), 
        new Vector2(0, 1),
        new Vector2(-0.7f, 0.7f),
        new Vector2(-1, 0),
        // new Vector2(1, 0),  // Right
        // new Vector2(-1, 0), // Left
        // new Vector2(0, 1),  // Up
        // new Vector2(0, -1), // Down
        // new Vector2(0.7f, 0.7f),   // Diagonal up-right
        // new Vector2(-0.7f, 0.7f),  // Diagonal up-left
        // new Vector2(0.7f, -0.7f),  // Diagonal down-right
        // new Vector2(-0.7f, -0.7f)  // Diagonal down-left
    };

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player)
        {
            last_known_pos = player.position;
        }

        if (Time.time >= nextFireTime)
        {
            StartCoroutine(FireSequence());
            nextFireTime = Time.time + fire_rate;
        }
    }

    IEnumerator FireSequence()
    {
        if (shot_count < shots_before_special)
        {
            FireNormal(main_fire_point);
            yield return new WaitForSeconds(fire_point_delay);
            shot_count++;
        }
        else
        {
            FireSpecial();
            shot_count = 0; 
        }
    }

    void FireNormal(Transform firePoint)
    {
        GameObject projectile = Instantiate(this.projectile, firePoint.position, Quaternion.identity);
        EnemyProjectile projScript = projectile.GetComponent<EnemyProjectile>();

        if (projScript)
        {
            projScript.SetTarget(last_known_pos);
        }
    }

    void FireSpecial()
    {
        for (int i = 0; i < fire_points.Length; i++)
        {
            GameObject spawnedProjectile = Instantiate(special_projectile, fire_points[i].position, Quaternion.identity);
            Rigidbody2D rb = spawnedProjectile.GetComponent<Rigidbody2D>(); 

            if (rb)
            {
                rb.velocity = starDirections[i].normalized * 10f; 
            }
        }
    }

}
