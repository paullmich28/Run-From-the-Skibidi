using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Time;

public class Drive : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5.0f;
    // public float jumpSpeed = 5.0f;
    public float runSpeed = 7.0f;
    public float rotationSpeed = 100.0f;
    Animator anim;
    void Awake()
    {
        anim = this.GetComponent<Animator>();
        SceneValue.sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    void FixedUpdate()
    {

        float translation = Input.GetAxis("Vertical") * speed;
        bool jump = Input.GetKey(KeyCode.Space);
        // float jump = Input.GetAxis("Jump") * jumpSpeed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        float run = Input.GetAxis("Fire3") * runSpeed;
        translation *= Time.fixedDeltaTime;
        rotation *= Time.fixedDeltaTime;
        run *= Time.fixedDeltaTime;
        // jump *= Time.fixedDeltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);
        // transform.Translate(0, jump, 0);
        if(translation !=0 && run == 0){
            anim.SetBool("isWalking", true);
            anim.SetFloat("characterSpeed", translation);
        }
        else if(jump == true){
            anim.SetBool("isJump", true);
        }
        // else if(jump == true && translation !=0){
        //     anim.SetBool("isJump", true);
        //     anim.SetFloat("characterSpeed", translation);
        // }
        else if(run !=0 && translation !=0){
            anim.SetBool("isRunning", true);
            anim.SetFloat("characterSpeed", run);
        }
        else{
            anim.SetBool("isWalking", false);
            anim.SetBool("isRunning", false);
            anim.SetBool("isJump", false);
            anim.SetFloat("characterSpeed", 0);
        }

    }
}
