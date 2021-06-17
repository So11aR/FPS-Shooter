using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    private CharacterController cc;
    private Transform playerCamera;
    private float camRotate = 0f;
    
    public float speed = 5f;
    public float rotSpeed = 5f;
    public float camSpeed = -5f;

    public float jumpHeight = 3f;
    public float gravity = -9.8f;
    private bool isCrouch = false;
    private Vector3 velocity;

    // Oxygen
    public Image oxyBar;
    public float maxOxy = 1000f;
    public float currentOxy;

    

    void Start()
    {
        cc = GetComponent<CharacterController>();
        playerCamera = Camera.main.transform;
        currentOxy = maxOxy;
    }

    public void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("MarsGround"))
        {
            ChangeOxy(-0.5f);
            if(currentOxy <= 0)
            {
                print("вот и конец");
            }
            print("Удачной прогулки");

            //gravity = 0f;
        }

        if (other.CompareTag("SpaceBase"))
        {
            currentOxy = maxOxy;
            //ChangeOxy(100f);
            print("Добро пожаловать домой!");

            //gravity = -9.8f;
        }
    }
   

    public void ChangeOxy(float amount)
    {
        currentOxy = Mathf.Clamp(currentOxy + amount, 0, maxOxy);
        oxyBar.fillAmount = 1.0f * currentOxy / maxOxy;
    }

    void Update()
    {
        Vector3 move = transform.forward * Input.GetAxis("Vertical") +
                        transform.right * Input.GetAxis("Horizontal");

        if(move.magnitude > 1)
        {
            move.Normalize();
        }

        

        //Crouch
        if (Input.GetKeyDown(KeyCode.C))
        {
            transform.localScale = new Vector3(1, isCrouch ? 1f : 0.5f, 1);
            transform.position += Vector3.up * 0.5f * (isCrouch ? 1 : -1);
            isCrouch = !isCrouch;
        }

        //Sprint
        float sprint = Input.GetKey(KeyCode.LeftShift) && !isCrouch ? 2 : 1;

        //Jump
        if(cc.isGrounded)
        {
            velocity.y = 0f;
        }

        if(Input.GetButtonDown("Jump") && cc.isGrounded)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;

        //Moving
        cc.Move((move * speed * sprint + velocity) * Time.deltaTime);

        transform.Rotate(0, rotSpeed * Input.GetAxis("Mouse X"), 0);

        camRotate = Mathf.Clamp(camRotate + Input.GetAxis("Mouse Y") * camSpeed, -89f, 89f);
        playerCamera.localEulerAngles = new Vector3(camRotate, 0, 0);
    }
}
