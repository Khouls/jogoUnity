using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Absorber : MonoBehaviour
{
    public PlayerMovement playermov;
    string objeto;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((objeto  == "PedraPulo") && Input.GetButtonDown("Absorb")) {
            Absorb();
        }
        
    }

    void Absorb()
    {

        Debug.Log("Aprendeu Pulo");
        playermov.LearnJump();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        objeto = collision.name;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        objeto = "";
    }
}
