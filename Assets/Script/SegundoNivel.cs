using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SegundoNivel : MonoBehaviour
{
   
    public void PasarNivel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

       private void OnTriggerEnter2D(Collider2D collider)
    {
        Movimiento john = collider.GetComponent<Movimiento>();
        

        if (john != null)
        { //hemos impactado con john
            PasarNivel();  
        }

    }
}
