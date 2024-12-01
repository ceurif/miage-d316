using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameTimerScript : MonoBehaviour
{
    private float timeElapsed = 0f; // Temps écoulé en secondes

    void Update()
    {
        // Augmente le temps écoulé en fonction du temps réel
        timeElapsed += Time.deltaTime;

        // Convertit le temps en minutes et secondes
        int minutes = Mathf.FloorToInt(timeElapsed / 60F);
        int seconds = Mathf.FloorToInt(timeElapsed % 60F);

        // Met à jour le texte de l'UI
        if (GetComponent<TextMeshProUGUI>() != null)
        {
            GetComponent<TextMeshProUGUI>().text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else if (GetComponent<Text>() != null)
        {
            GetComponent<Text>().text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
