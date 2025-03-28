using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public float max = 100f;
    public Color Color = Color.red;
    public int width = 4;
    public Slider slider;
    public bool IsRight;

    private static float current;
    // Start is called before the first frame update
    void Start()
    {
        slider.fillRect.GetComponent<Image>().color = Color;
        slider.maxValue = max;
        slider.minValue = 0;
        current = max;
        slider.value = current_health;
        
        UpdateUi();
    }

    private void UpdateUi()
    {
        RectTransform rect = slider.GetComponent<RectTransform>();
        int rect_delta_x = Screen.width / width;
        float rect_pos_x = 0;

        if (IsRight)
        {
            rect_pos_x = rect.position.x + (rect_delta_x - rect.sizeDelta.x) / 2;
            slider.direction = Slider.Direction.RightToLeft;
        }
        else
        {
            rect_pos_x = rect.position.x + (rect_delta_x - rect.sizeDelta.x) / 2;
            slider.direction = Slider.Direction.LeftToRight;
        }
        rect.sizeDelta = new Vector2(rect_delta_x, rect.sizeDelta.y);
        rect.position = new Vector3(rect_pos_x, rect.position.y, rect.position.z);
    }

    public static float current_health
    {
        get => current;
        set => current = value;
    }

    // Update is called once per frame
    void Update()
    {
        if (current_health < 0)
        {
            current = 0;
        }

        if (current_health > max)
        {
            current = max;
        }
        slider.value = current_health;
    }

    public static void AdjustHealth(float amount)
    {
        current += amount;
    }
}
