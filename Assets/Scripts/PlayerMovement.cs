using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;

    public SpriteRenderer renderer;
    public ParticleSystem partSys;

    public float runSpeed = 40f;



    bool jump = false;
    bool crouch = false;
    bool learnedJump = false;

    float horizontalMove = 0f;


    // Update is called once per frame
    void Update() {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        
        if (learnedJump && Input.GetButtonDown("Jump")) {
            partSys.startColor = new Color(1, 175f / 255f, 19f / 255f, 1);
            renderer.color = new Color(1, 175f / 255f, 19f / 255f, 1);

            jump = true;
            animator.SetBool("IsJumping", true);
        }
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch")){
            crouch = false;
        }


    }

    public void  OnLanding() {
        animator.SetBool("IsJumping", false);
        partSys.startColor = new Color(1, 1, 1, 1);
        renderer.color = new Color(1, 1, 1, 1);
    }

    public void OnCrouching (bool isCrouching) {
        animator.SetBool("IsCrouching", isCrouching);
    }

    void FixedUpdate() {

        //Move Character

        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch , jump);
        jump = false;

    }

    public void LearnJump()
    {
        learnedJump = true;
    }
}
