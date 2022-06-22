using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public MovimientoPersonaje barraza;
    public MovimientoPersonaje2 barraza2;
    public Text txt_timeTime;
    float customTime;
    float ending;
    bool ciclo = false;

    // Start is called before the first frame update
    void Start()
    {
        customTime = 0;

    }

    // Update is called once per frame
    void Update()
    {
        barraza = FindObjectOfType<MovimientoPersonaje>();
        barraza2 = FindObjectOfType<MovimientoPersonaje2>();

        float time = Time.time;
        Debug.Log(time);
        Debug.Log(ending);


        //txt_timeTime.text = "Tiempo Transcurrido: " +time.ToString() + " Segundos";

        if (barraza.timer_stop && ciclo == false)
        {
            ending = time + 5;
            txt_timeTime.text = txt_timeTime.text;
            ciclo = true;
        }

        if (barraza.timer_stop == false)
        {
            txt_timeTime.text = "Tiempo Transcurrido: " + Mathf.Floor(time).ToString() + " Segundos";
            customTime += Time.deltaTime;
        }

        if (time >= ending)
        {
            barraza.victoria.text = "";
            barraza2.victoria.text = "";
        }
    }
}
