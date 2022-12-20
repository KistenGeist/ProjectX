using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D characterController;
    private Animator animate;
    float horizontalMovement = 0f;
    bool jump = false;
    bool crouch = false;
    float runSpeed = 500f;
    [SerializeField] Transform hand;
    [SerializeField] AntiflipHand antiflipHand;

    // Start is called before the first frame update
    void Start()
    {
        animate = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        RotateHand();

        horizontalMovement = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump")){
            jump = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

        animate.SetFloat("Speed", Mathf.Abs(horizontalMovement));
    }

    void FixedUpdate ()
    {
        characterController.Move(horizontalMovement * Time.fixedDeltaTime, crouch, jump);
        antiflipHand.antiFlipHand(horizontalMovement * Time.fixedDeltaTime);
        jump = false;
    }

    void RotateHand()
    {
        float angle = Utility.AngleTowardsMouse(hand.position);
        hand.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }
}
