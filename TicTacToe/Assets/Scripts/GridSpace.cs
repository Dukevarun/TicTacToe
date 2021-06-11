using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour
{
    public Button button;
    public TextMeshProUGUI buttonText;

    private GameManager gameManager;

    public void SetSpace()
    {
        if (gameManager.playerMove == true)
        {
            buttonText.text = gameManager.GetPlayerSide();
            button.interactable = false;
            gameManager.EndTurn(); 
        }
    }

    public void SetGameManagerReference(GameManager manager)
    {
        gameManager = manager;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
