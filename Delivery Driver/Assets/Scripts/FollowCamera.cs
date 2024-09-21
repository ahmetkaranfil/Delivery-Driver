using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FollowCamera : MonoBehaviour
{
    // this thing's position (camera) should be the same as the car's position
    // Update is called once per frame

    [SerializeField] GameObject thingToFollow;
    
    void LateUpdate()
    {
        transform.position = thingToFollow.transform.position + new Vector3 (0,0,-10);
    }
}
