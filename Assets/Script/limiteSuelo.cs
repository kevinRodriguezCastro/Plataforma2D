using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class limiteSuelo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     private void OnTriggerEnter2D(Collider2D collider)
    {
        
        Movimiento john = collider.GetComponent<Movimiento>();
      

        if (john != null)
        { //hemos impactado con john
            Debug.Log("Muerto caida");
            john.Hit(99999999);
            
        }

    }
}
