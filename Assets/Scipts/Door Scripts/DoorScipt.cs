using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScipt : MonoBehaviour
{

    public static DoorScipt instance;

    private Animator anim;
    private BoxCollider2D box;

    [HideInInspector]
    public int collectablesCount;

    private void Awake()
    {
        MakeInstance();
        anim = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator OpenDoor()
    {
        anim.Play("Open");
        yield return new WaitForSeconds(.7f);
        box.isTrigger = true;
    }

    // Ăn điểm
    public void DecrementCollectables()
    {
        collectablesCount--;

        if (collectablesCount == 0)
        {
            // Start anim
            StartCoroutine(OpenDoor());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Win");
        }
    }


}
