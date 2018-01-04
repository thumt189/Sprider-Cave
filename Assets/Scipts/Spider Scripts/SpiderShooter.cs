using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderShooter : MonoBehaviour
{
    [SerializeField]
    // Set Bullet for Spider
    private GameObject bullet;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(Attrack());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Attrack()
    {
        yield return new WaitForSeconds(Random.Range(2, 7));
        Instantiate(bullet, transform.position, Quaternion.identity);
        StartCoroutine(Attrack());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
    }
}
