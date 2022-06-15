using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsferaMovement : MonoBehaviour
{
    public GameObject esfera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z <= 100 || transform.position.y <= -10)
        {
            Destroy(gameObject);
        }
    }

    /*void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Piso2" || col.gameObject.name == "Piso" || col.gameObject.name == "DeathWall")
        {
            Destroy(esfera);
        }
    }*/
}
