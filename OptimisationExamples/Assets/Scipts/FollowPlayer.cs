using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public Transform playerToFollow;
    private Vector3 offset;


    private void Awake()
    {
        offset = gameObject.transform.position;
    }
    private void LateUpdate()
    {
        gameObject.transform.position = playerToFollow.transform.position + offset;
    }
}
