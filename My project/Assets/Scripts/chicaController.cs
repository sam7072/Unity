using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chicaController : MonoBehaviour
{
    public float speed = 5.0f;
    public float rotartionSpeed = 200.0f;
    private Animator animator;


    public Rigidbody rb;
    public float fuerzaDeSalto = 3;

    public Transform groundCheck;
    public float groundDistance = 0.1f;
    public LayerMask groundMask;

    bool isGrounded;




    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Vertical");
        float rotation = Input.GetAxis("Horizontal");

        float desplazamiento = translation * speed * Time.deltaTime;
        float rotacion = rotation * rotartionSpeed * Time.deltaTime;

        //detemer al persomaje
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) ||
            Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            animator.SetBool("Correr", false);
        }



        //correr adelante y atras 
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetBool("Correr", true);
            transform.Translate(0, 0, desplazamiento);
        }


        //girar izquierda o derecha
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetBool("Correr", true);
            transform.Rotate(0, rotacion, 0);
        }



        //saltar
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (Input.GetKey("space") && isGrounded)
        {
            animator.Play("jump");

        }
        
        
       }
   
}
