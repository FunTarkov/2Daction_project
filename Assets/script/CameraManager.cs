using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraManager : MonoBehaviour
{
    public float cameraRangeX = 4;
    public float cameraRangeY = 6;

    public GameObject playerObj;
    

    void Start()
    {
    }

    void LateUpdate()
    {
        MoveCamera();
    }

    void MoveCamera()
    {

        //‰¡•ûŒü‚¾‚¯’Ç]
        if (transform.position.x > playerObj.transform.position.x + cameraRangeX) {
            transform.position = new Vector3(playerObj.transform.position.x+cameraRangeX, transform.position.y, transform.position.z);
        }
        if (transform.position.x < playerObj.transform.position.x - cameraRangeX)
        {
            transform.position = new Vector3(playerObj.transform.position.x - cameraRangeX, transform.position.y, transform.position.z);
        }
        if (transform.position.y > playerObj.transform.position.y + cameraRangeY)
        {
            transform.position = new Vector3(transform.position.x, playerObj.transform.position.y+cameraRangeY, transform.position.z);
        }
        if (transform.position.y < playerObj.transform.position.y - cameraRangeY)
        {
            transform.position = new Vector3(transform.position.x, playerObj.transform.position.y-cameraRangeY, transform.position.z);
        }
    }

}