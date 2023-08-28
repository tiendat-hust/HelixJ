using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float angle;
    void OnMouseDrag()
    {
        float x = Input.GetAxis("Mouse X");

        transform.GetChild(0).transform.RotateAround(transform.position, new Vector3(0, 1, 0) * Time.deltaTime* x*-1, angle);
    }
}
