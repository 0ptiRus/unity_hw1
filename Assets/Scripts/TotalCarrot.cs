using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalCarrot : MonoBehaviour
{
    public Text total_carrot;
    public int carrots = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Carrot"))
        {
            carrots++;
            Destroy(collision.gameObject);
            total_carrot.text = $"Carrots: {carrots}";
        }
    }
}
