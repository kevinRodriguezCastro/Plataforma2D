using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    private float horizontal;
    
    public float Speed;
    public float JumpForce;
    //si esta en el aire
    bool Grounded;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if(Physics2D.Raycast(transform.position, Vector3.down,0.1f)){
            Grounded = true;
        }else{
            Grounded = false;
        }

        if(Input.GetKeyDown(KeyCode.W) && Grounded){
            Jump();
        }
    }

    private void Jump(){
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    void FixedUpdate(){
        Rigidbody2D.velocity = new Vector2(horizontal,Rigidbody2D.velocity.y);
    }
}
