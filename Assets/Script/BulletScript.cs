using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Vector2 Direction;

    public float Speed;
    private Rigidbody2D Rigidbody2D;
    public AudioClip sonido;


    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(sonido);
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D.velocity = Vector2.right * Speed;

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Movimiento john = collider.GetComponent<Movimiento>();
        GruntScript grunt = collider.GetComponent<GruntScript>();
        BulletScript bala = collider.GetComponent<BulletScript>();

        if (john != null)
        { //hemos impactado con john
            john.Hit();
        }
        if (grunt != null)
        {//hemos impactado con grunt
            grunt.Hit();
        }
        if (bala == null)
        {
            DestroyBullet();
        }

    }

    public void DestroyBullet()
    {
        Destroy(gameObject);

    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = Direction * Speed;
    }

    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
    }
}
