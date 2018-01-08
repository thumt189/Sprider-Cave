using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodScript : MonoBehaviour
{

    private Slider slider;
    private GameObject player;

    public float blood = 170f;
    private float bloodBurn = 1f;

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

        if (blood > 0)
        {
            blood -= bloodBurn * Time.deltaTime;
            slider.value = blood;
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
        slider = GameObject.Find("Blood Slider").GetComponent<Slider>();

        slider.minValue = 0f;
        slider.maxValue = blood;
        slider.value = slider.maxValue;
    }
}
