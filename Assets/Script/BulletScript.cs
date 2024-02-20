using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Vector2 Direction;

    public float Speed;
    private Rigidbody2D Rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D.velocity = Vector2.right * Speed;    
    }

    public void DestroyBullet(){
        Destroy(gameObject);
    }

    private void FixedUpdate(){
        Rigidbody2D.velocity = Direction * Speed;
    }
    
    public void SetDirection(Vector2 direction){
        Direction = direction;
    }
}
