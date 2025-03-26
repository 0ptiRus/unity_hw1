using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FireControl : MonoBehaviour
{
    public GameObject bullet;
    public Transform bullet_pos;
    private float cd = 0.5f;
    private bool IsOnCd = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !IsOnCd)
        {
            print("Fire");
            Instantiate(bullet, bullet_pos.position, bullet_pos.rotation);
            StartCoroutine(Cooldown(cd));
        }
    }

    IEnumerator Cooldown(float cd_time)
    {
        IsOnCd = true;
        yield return new WaitForSeconds(cd_time);
        IsOnCd = false;
    }
    
}
