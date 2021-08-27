using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public Vector3 distance = new Vector3(0, 5, 0);
    public float speed = 0.5f;

    Vector3 startPosition;
    Vector3 endPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.localPosition;
        endPosition = startPosition + distance;
    }

    // Update is called once per frame
    void Update()
    {
        var t = Mathf.PingPong(Time.time * speed, 1);
        var newPosition = Vector3.Lerp(startPosition, endPosition, t);
        transform.localPosition = newPosition;
    }
}
