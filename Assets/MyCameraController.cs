using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCameraController : MonoBehaviour
{
    public Transform playerTransform;
    float offset;
    float positionY;
    float positionZ;
    // Start is called before the first frame update
    void Awake()
    {
        
        offset = gameObject.transform.position.x - playerTransform.position.x;
        positionY = gameObject.transform.position.y;
        positionZ = gameObject.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {

        gameObject.transform.position = new Vector3(playerTransform.position.x + offset, positionY, positionZ);
    }
}
