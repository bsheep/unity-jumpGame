using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    GameObject mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var blockPosY = this.transform.localPosition.y;
        var cameraPosY = mainCamera.transform.localPosition.y;
        if (blockPosY - cameraPosY < 12)
        {
            transform.localScale = Vector3.one;
        }
        else
        {
            transform.localScale = Vector3.zero;
        }
    }

    public void setCamera(GameObject camera)
    {
        mainCamera = camera;
    }
}
