using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BulletFiring : MonoBehaviour
{
    [FormerlySerializedAs("firerate")] public float fireRate;

    // Start is called before the first frame update
    void Start()
    {
        if (fireRate == 0)
        {
            fireRate = 2f;
        }

        StartCoroutine(Fire());

    }

    IEnumerator Fire()
    {
        while (true)
        {
            GameObject bullet = ObjectPool.SharedInstance.GetPooledObject();
            if (bullet != null)
            {
                bullet.transform.position = transform.position;
                bullet.transform.rotation = transform.rotation;
                bullet.SetActive(true);
                yield return null;
            }
            yield return new WaitForSeconds(fireRate);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
