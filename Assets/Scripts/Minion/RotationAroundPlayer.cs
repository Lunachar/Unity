using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationAroundPlayer : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] float speed;

    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * speed, Space.Self);
    }
}
