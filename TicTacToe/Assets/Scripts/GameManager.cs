using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI[] buttonTextList;
    private string playerSide;

    public GameObject gameOverPanel;
    public TextMeshProUGUI gameOverText;
    private int moveCount;

    public GameObject restartButton;

    private void Awake()
    {
        gameOverPanel.SetActive(false);
        restartButton.SetActive(false);
        SetGameManagerReferenceOnButtons();
        playerSide = "X";
        moveCount = 0;
    }

    void SetGameManagerReferenceOnButtons()
    {
        for (int i = 0; i < buttonTextList.Length; i++)
        {
            buttonTextList[i].GetComponentInParent<GridSpace>().SetGameManagerReference(this);
        }
    }

    public string GetPlayerSide()
    {
        return playerSide;
    }

    public void EndTurn()
    {
        moveCount++;

        if (buttonTextList[0].text == playerSide && buttonTextList[1].text == playerSide && buttonTextList [2].text == playerSide)
        {
            GameOver(playerSide);
        }

        if (buttonTextList[3].text == playerSide && buttonTextList[4].text == playerSide && buttonTextList[5].text == playerSide)
        {
            GameOver(playerSide);
        }

        if (buttonTextList[6].text == playerSide && buttonTextList[7].text == playerSide && buttonTextList[8].text == playerSide)
        {
            GameOver(playerSide);
        }

        if (buttonTextList[0].text == playerSide && buttonTextList[3].text == playerSide && buttonTextList[6].text == playerSide)
        {
            GameOver(playerSide);
        }

        if (buttonTextList[1].text == playerSide && buttonTextList[4].text == playerSide && buttonTextList[7].text == playerSide)
        {
            GameOver(playerSide);
        }

        if (buttonTextList[2].text == playerSide && buttonTextList[5].text == playerSide && buttonTextList[8].text == playerSide)
        {
            GameOver(playerSide);
        }

        if (buttonTextList[0].text == playerSide && buttonTextList[4].text == playerSide && buttonTextList[8].text == playerSide)
        {
            GameOver(playerSide);
        }

        if (buttonTextList[2].text == playerSide && buttonTextList[4].text == playerSide && buttonTextList[6].text == playerSide)
        {
            GameOver(playerSide);
        }

        if (moveCount >=9)
        {
            GameOver("draw");
        }

        ChangeSides();
    }

    void ChangeSides()
    {
        playerSide = (playerSide == "X") ? "O" : "X";
    }

    void GameOver(string winningPlayer)
    {
        SetBoardInteractable(false);

        if (winningPlayer == "draw")
        {
            SetGameOverText("It's a draw!");
        }
        else
        {
            SetGameOverText(playerSide + " Wins!"); 
        }
        restartButton.SetActive(true);
    }

    void SetGameOverText(string value)
    {
        gameOverPanel.SetActive(true);
        gameOverText.text = value;
    }

    public void RestartGame()
    {
        playerSide = "X";
        moveCount = 0;
        gameOverPanel.SetActive(false);

        SetBoardInteractable(true);

        for (int i = 0; i < buttonTextList.Length; i++)
        {
            buttonTextList[i].text = "";
        }

        restartButton.SetActive(false);
    }

    void SetBoardInteractable(bool toggle)
    {
        for (int i = 0; i < buttonTextList.Length; i++)
        {
            buttonTextList[i].GetComponentInParent<Button>().interactable = toggle;
        }
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
