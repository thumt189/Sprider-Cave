using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{

    private Slider slider;
    private GameObject player;

    public float timer = 170f;
    private float timerBurn = 1f;

    private void Awake()
    {
        GetPrefereces();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!player)
            return;

        if (timer > 0)
        {
            timer -= timerBurn * Time.deltaTime;
            slider.value = timer;
        }
        else
        {
            GetComponent<GameplayCtrlScript>().PlayerDied();
            Destroy(player);
        }
    }

    void GetPrefereces()
    {
        player = GameObject.Find("Player");
        slider = GameObject.Find("Timer Slider").GetComponent<Slider>();

        slider.minValue = 0f;
        slider.maxValue = timer;
        slider.value = slider.maxValue;
    }
}
