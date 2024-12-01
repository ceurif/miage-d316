using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitGameScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
   {
       // Ajoute automatiquement un événement au bouton auquel ce script est attaché
       GetComponent<Button>().onClick.AddListener(() => QuitGame());
   }

    // Update is called once per frame
    void Update()
    {

    }

    // Cette méthode sera appelée par le bouton
    public void QuitGame()
    {
        #if UNITY_EDITOR
            Debug.Log("Application arrêtée dans l'éditeur Unity");
            UnityEditor.EditorApplication.isPlaying = false; // Arrête l'éditeur Unity
        #else
            Debug.Log("Application quittée");
            Application.Quit(); // Quitte l'application
        #endif
    }
}
