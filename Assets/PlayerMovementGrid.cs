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
        Vector3 refPosition = new Vector3(movePoint.position.x, movePoint.position.y+0.5f, movePoint.position.z);
        transform.position = Vector3.MoveTowards(transform.position, refPosition, moveSpeed * Time.deltaTime);
        float distance = AnimationHandler(horizontal, vertical, transform, refPosition);
        MovementHandler(horizontal, vertical, distance);
    }

    void MovementHandler(float horizontal, float vertical, float distance)
    {
        if(distance <= 0.05f)
                {
                    if(Mathf.Abs(horizontal) == 1f)
                    {
                        movePoint.position += new Vector3(horizontal, 0f, 0f);
                    } else if(Mathf.Abs(vertical) == 1f)
                    {
                        movePoint.position += new Vector3(0f, vertical, 0f);
                    }
                }
    }

    float AnimationHandler(float horizontal, float vertical, Transform transform, Vector3 refPosition)
    {
        float distance = Vector3.Distance(transform.position, refPosition);
        if(distance != 0){
            animator.SetFloat("Speed", moveSpeed);
            if(transform.position.x - refPosition.x != 0){
                if(transform.position.x - refPosition.x < 0){
                    animator.SetFloat("Horizontal", 1f);
                } else {
                    animator.SetFloat("Horizontal", -1f);
                }
                animator.SetFloat("Vertical", 0f);
            } else if(transform.position.y - refPosition.y != 0){
                if(transform.position.y - refPosition.y < 0){
                    animator.SetFloat("Vertical", 1f);
                } else {
                    animator.SetFloat("Vertical", -1f);
                }
                animator.SetFloat("Horizontal", 0f);
            }
        } else {
            animator.SetFloat("Speed", 0);
        }
        return distance;
    }
}
