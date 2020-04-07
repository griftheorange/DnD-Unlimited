using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementGrid : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
        {
            animator.SetFloat("Speed", 0);
            if(Mathf.Abs(horizontal) == 1f)
            {
                animator.SetFloat("Horizontal", horizontal);
                movePoint.position += new Vector3(horizontal, 0f, 0f);
            } else if(Mathf.Abs(vertical) == 1f)
            {
                animator.SetFloat("Vertical", vertical);
                movePoint.position += new Vector3(0f, vertical, 0f);
            }
        } else
        {
            animator.SetFloat("Speed", moveSpeed);
        }
    }
}
