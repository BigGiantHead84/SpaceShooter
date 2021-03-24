using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private Transform _trans;
    public int bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        _trans = transform;
        if(bulletSpeed==0)
        {
            bulletSpeed = 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        _trans.Translate(Vector2.up * (Time.deltaTime * bulletSpeed));
        float positionY = _trans.position.y;
        if (positionY >= Utilities.yBoundMax)
        {
            gameObject.SetActive(false);
        }
    }

    
}
