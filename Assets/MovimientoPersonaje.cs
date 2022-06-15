using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using System;

public class MovimientoPersonaje : MonoBehaviour
{
    bool HasJump;
    Rigidbody rb;
    float jumpForce = 5;
    public GameObject objeto;
    public Text victoria;
    public bool timer_stop;

    public GameObject ObjectToClone;
    System.Random guido = new System.Random();
    int ary;

    System.Random guido2 = new System.Random();
    int ary2;

    // Start is called before the first frame update
    void Start()
    {
        timer_stop = false;

        HasJump = true;
        rb = GetComponent<Rigidbody>();

        ary = guido.Next(1, 6);
        ary2 = guido2.Next(-13, 13);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Input.GetAxis("Vertical"));

        //transform.Translate(0, 0, 0.1f * Input.GetAxis("Vertical"));

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, 0, 0.1f);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, 0, -0.1f);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, 3, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -3, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space) && HasJump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            HasJump = false;
        }

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "DeathWall" || col.gameObject.name == "Agua" || col.gameObject.name == "AguaGanar" || col.gameObject.tag == "Jero")
       {
            transform.position = new Vector3(4.5f, 0.5f, -13.5f);
            transform.eulerAngles = new Vector3(0,0,0);
       }

        if (col.gameObject.name == "Piso" || col.gameObject.name == "Fuego" || col.gameObject.name == "InvisibleAgua" || col.gameObject.name == "InvisibleFuego" || col.gameObject.name == "Boton" || col.gameObject.name == "Piso2" || col.gameObject.name == "Piso3" || col.gameObject.name == "PisoGanador")
        {
            HasJump = true;
        }

        if (col.gameObject.name == "Boton")
        {
            objeto.SetActive(true);
        }

        if (col.gameObject.name == "FuegoGanar")
        {
            victoria.text = "Ganaste Jugador 2";
            timer_stop = true;
        }

        if (col.gameObject.name == "Piso2" || col.gameObject.name == "Piso3")
        {
            rb.constraints = RigidbodyConstraints.FreezePositionX;
            rb.constraints = RigidbodyConstraints.FreezePositionY;
            rb.constraints = RigidbodyConstraints.FreezePositionZ;
        }

        else
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }

        if (col.gameObject.name == "Piso3")
        {
            Task.Delay(1500);
            for (int i = 0; i <= ary; i++)
            {
                ObjectToClone.transform.position = new Vector3(ary2, 84, 235);
                ary2 = guido2.Next(-13, 13);
                Instantiate(ObjectToClone);
            }

            ary = guido.Next(1, 6);
            ary2 = guido2.Next(-13, 13);
        }
    }
}
