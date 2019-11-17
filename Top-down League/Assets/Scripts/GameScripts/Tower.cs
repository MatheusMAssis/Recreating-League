using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject target;
    public GameObject bullet;

    private bool firing = false;

    void Start()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Minion"))
        {
            if (target == null)
            {
                target = collision.gameObject;
            }

            if (target != null && !firing)
            {
                Debug.Log("here");
                firing = true;
                StartCoroutine(shoot());
            }
        }
    }

    IEnumerator shoot()
    {
        yield return new WaitForSeconds(1);
        Instantiate(bullet, transform.position, Quaternion.identity);
        firing = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        target = null;
    }

    void Update()
    {
        
    }
}
