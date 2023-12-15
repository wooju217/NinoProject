using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Slider TradeWindSlider;
    public Transform Ocean;
    public Transform Cloud;

    public Text WestText;
    public Text EaseText;

    private Tween sliderTween;
    
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        int dir = 0;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            dir = -1;
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            dir = 1;

        if (dir != 0)
        {
            var targetValue = Mathf.Clamp(TradeWindSlider.value + dir * 0.1f, 0, 1);
            sliderTween = DOTween.To(() => TradeWindSlider.value, x => TradeWindSlider.value = x, targetValue, 0.1f)
                .SetEase(Ease.OutSine);     
        }
       
        
        //0.5, 0.97
        Ocean.rotation = Quaternion.Euler(0, 0, GetValue());
        
        //0.5 -45
        //0, 10
        Cloud.transform.position = new Vector3(GetCloudX(), 30, -5);
        
        UpdateText();
    }

    float GetValue()
    {
        var value = TradeWindSlider.value;
        return (1-value) * 2 * 0.97f;
    }

    float GetCloudX()
    {
        var value = TradeWindSlider.value;
        if (value < 0.5f)
        {
            //엘니뇨
            return (value * 2 * -68);
        }
        else
        {
            //평상시
            return -68;
        }
    }


    void UpdateText()
    {
        
    }
}
