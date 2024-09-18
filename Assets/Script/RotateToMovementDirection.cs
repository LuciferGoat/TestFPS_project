using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class RotateToMovementDirection : MonoBehaviour
{

    private Transform _transform;
    private UnityEngine.Vector3 _prevPosition;

    // Start is called before the first frame update
    void Start()
    {
        _transform = transform;

        _prevPosition = _transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var position = transform.position;

        var delta = position - _prevPosition;

        _prevPosition = position;

        if(delta == UnityEngine.Vector3.zero)
        {
            return;
        }
        var rotation = UnityEngine.Quaternion.LookRotation(delta, UnityEngine.Vector3.up);

        _transform.rotation = rotation;
    }
}
