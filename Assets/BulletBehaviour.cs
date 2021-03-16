using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public int bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        if(bulletSpeed==0)
        {
            bulletSpeed = 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * Time.deltaTime * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Bullet collided with " + collision.name);
        if (collision.name != "Player")
        {
            Debug.Log("We're gonna destroy!");
            Destroy(this.gameObject);
        }
    }
}
