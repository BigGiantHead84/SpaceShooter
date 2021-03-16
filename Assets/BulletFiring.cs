using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFiring : MonoBehaviour
{
    public GameObject bullet;
    public float firerate;

    // Start is called before the first frame update
    void Start()
    {
        if (bullet == null)
        {
            Debug.Log("Bullet is null!");
            bullet = GameObject.FindGameObjectWithTag("bullet");
        }
        if (firerate == 0)
        {
            firerate = 2f;
        }

        StartCoroutine(Fire(bullet));

    }

    IEnumerator Fire(GameObject bullet)
    {
        while (true)
        {

            if (bullet != null)
            {
                bullet.transform.position = transform.position;
                Instantiate(bullet);

            }
            yield return new WaitForSeconds(firerate);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
