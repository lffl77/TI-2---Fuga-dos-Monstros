using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Pausar();
        }
    }

    void Pausar()
    {
        if(Time.timeScale == 0) {Time.timeScale = 1; Console.WriteLine("Jogo Pausado");}

        else {Time.timeScale = 0; Console.Write("Jogo Despausado");}
    }
}
