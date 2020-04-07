using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementGrid : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint;

    // Update is called once per frame
    void Update()
    {
        Vector3 motion = new Vector3(movePoint.position.x, movePoint.position.y, -10f);
        transform.position = Vector3.MoveTowards(transform.position, motion, moveSpeed * Time.deltaTime);
    }
}
