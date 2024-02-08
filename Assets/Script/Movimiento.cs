using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    private float horizontal;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
    }
    void FixedUpdate(){
        Rigidbody2D.velocity = new Vector2(horizontal,Rigidbody2D.velocity.y);
    }
}
