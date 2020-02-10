using System;
using UnityEngine;
public class Follower : MonoBehaviour
{
    public Transform target;

    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - target.position;
    }

    private void Update()
    {
        throw new NotImplementedException();
    }

    private void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}