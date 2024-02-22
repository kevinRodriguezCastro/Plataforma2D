using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    private Animator animator;
    private float horizontal;
    
    public float Speed;
    public float JumpForce;

    public GameObject prefabBullet;
    //si esta en el aire
    bool Grounded;

    private float LastShoot;

    private int Health = 5;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        animator.SetBool("running",horizontal != 0.0f);

        // Controlamos la dirección donde mira el Personaje cuando
        // cambia de dirección izquierda o derecha
        if(horizontal < 0.0f) transform.localScale = new Vector3(-1.0f,1.0f,1.0f);
        else if (horizontal > 0.0f) transform.localScale = new Vector3(1.0f,1.0f,1.0f);

        if(Physics2D.Raycast(transform.position, Vector3.down,0.1f)){
            Grounded = true;
        }else{
            Grounded = false;
        }

        if(Input.GetKeyDown(KeyCode.W) && Grounded){
            Jump();
        }

        if(Input.GetKeyDown(KeyCode.Space)&& Time.time > LastShoot + 0.25f){
            Shoot();
            LastShoot = Time.time;
        }

        Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);
    }

    private void Jump(){
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }
    private void Shoot(){
       Vector3 direction;

        if ( transform.localScale.x == 1.0f ) direction = Vector3.right;
        else direction = Vector3.left;

        // Pintamos el Prefab en scena, en la posición indicada y la rotación=0
        // La posición se calcula: 
        // transform.position -> centro de John
        // direction *0.1f -> offset de desplazamiento
        GameObject bullet = Instantiate(prefabBullet,transform.position + direction *0.1f, Quaternion.identity);

        bullet.GetComponent<BulletScript>().SetDirection(direction);
    }

    public void Hit(){
        Health = Health - 1;
        if(Health == 0)Destroy(gameObject);
    }
    
    void FixedUpdate(){
        Rigidbody2D.velocity = new Vector2(horizontal,Rigidbody2D.velocity.y);
    }
}
