using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities : MonoBehaviour
{
    Camera _cam;
    private Vector2 _cameraBoundsMin;
    private Vector2 _cameraBoundsMax;
    public static float xBoundMin;
    public static float xBoundMax;
    public static float yBoundMax;
    public static float yBoundMin;

    public GameObject player;

    Sprite _plane;

    float _planeWidth;
    float _planeHeight;

    /*
    public float MinX { get => minX; }
    public float MaxX { get => maxX; }
    public float MaxY { get => maxY; }
    public float MinY { get => minY; }
    */
    private void Awake()
    {
        _cam = Camera.main;

        if (!player)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        if (!_plane)
        {
            _plane= player.GetComponent<SpriteRenderer>().sprite;
        }
    }
    void Start()
    {

        _cameraBoundsMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0));
        _cameraBoundsMax = Camera.main.ViewportToWorldPoint(new Vector3(1, 1));
        CalculateScreenBounds();
    }

    private void CalculateScreenBounds()
    {
        xBoundMin = _cameraBoundsMin.x;
        xBoundMax = _cameraBoundsMax.x;
        yBoundMin = _cameraBoundsMin.y;
        yBoundMax = _cameraBoundsMax.y;

        _planeWidth = _plane.bounds.size.x;
        _planeHeight = _plane.bounds.size.y;

        xBoundMax = xBoundMax - _planeWidth / 2;
        xBoundMin = xBoundMin + _planeWidth / 2;
        yBoundMin = yBoundMin + _planeHeight / 2;
        yBoundMax = yBoundMax - _planeHeight / 2;

    }

    public static Vector2 CalculateScreenToWorld(Vector2 screenpos)
    {
        return Camera.main.ScreenToWorldPoint(screenpos);
    }
}
