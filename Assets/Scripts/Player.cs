using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float regularSpeed = 5, fastSpeed = 10, slowSpeed = 2.5f;
    public LayerMask groundMask;

    CharacterController controller;
    float speed = 1;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Steering();
        GroundCheck();
    }
    bool grounded;
    void GroundCheck()
    {
        RaycastHit hit;
        grounded = Physics.SphereCast(transform.position, 0.5f, Vector3.down, out hit, 1.1f, groundMask);
        if(grounded)
        {
            string tag = hit.collider.gameObject.tag;
            switch (tag)
            {
                case "Fast":
                    speed = fastSpeed;
                    break;

                case "Slow":
                    speed = slowSpeed;
                    break;

                default:
                    speed = regularSpeed;
                    break;
            }
        }
    }

    void Steering()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector3 translation = transform.right * inputX + transform.forward * inputY;
        translation *= Time.deltaTime * speed;
        controller.Move(translation);
    }
}
