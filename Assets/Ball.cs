using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ball : MonoBehaviour
{
    public float speed = 100.0f;

    public AudioSource audioBloque;
    public AudioSource audioPared;
    private int count;
    public TextMeshPro texto;
    public TextMeshPro textoFinPartida;
    
    // Update is called once per frame
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
        count = 0;
        texto.text = "Puntos: 0";
        textoFinPartida.text = "";
    }
    
    float hitFactor(Vector2 ballPos, Vector2 racketPos,
        float racketWidth) {
        return (ballPos.x - racketPos.x) / racketWidth;
    }
    
    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.name == "racket") {       
            float x=hitFactor(transform.position,      
            col.transform.position,
            col.collider.bounds.size.x);

            Vector2 dir = new Vector2(x, 1).normalized;

            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        if(col.gameObject.tag == "BlockCollision"){

            audioBloque.Play();
            count++;
            counter();

        }

         if(col.gameObject.tag == "ToquePared"){

            audioPared.Play();

        }
    }

    void counter(){

        texto.text = "Puntos: " + count;

        int numBloques;

        numBloques = GameObject.FindGameObjectsWithTag("BlockCollision").Length;

        if(numBloques == 1){

            textoFinPartida.text = "!Enhorabuena! :) Ha destruido todos los bloques";

        }

    }

}
