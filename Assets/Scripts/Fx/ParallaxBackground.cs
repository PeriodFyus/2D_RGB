using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    private GameObject camare;

    [SerializeField] private float parallaxEffect;

    private float xPosition;
    private float length;
    void Start()
    {
        camare = GameObject.Find("Main Camera");

        length = GetComponent<SpriteRenderer>().bounds.size.x;
        xPosition = transform.position.x;
    }

    void Update()
    {
        float distanceToMove = camare.transform.position.x * parallaxEffect;
        float distanceMoved = camare.transform.position.x * (1 - parallaxEffect);

        transform.position = new Vector3(xPosition + distanceToMove, camare.transform.position.y);

        if (distanceMoved > xPosition + length)
            xPosition += length;
        if (distanceMoved < xPosition - length)
            xPosition -= length;
    }
}
