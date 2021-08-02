using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Player
{
    public Image playerPanel;
    public TextMeshProUGUI playerText;
    public Button playerButton;
}

[System.Serializable]
public class PlayerColour
{
    public Color panelColour;
    public Color textColour;
}


public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI[] buttonTextList;

    private string playerSide;
    //private string computerSide;
    //public bool playerMove;
    //public float delay;
    //private int gridValue;

    public GameObject gameOverPanel;
    public TextMeshProUGUI gameOverText;
    private int moveCount;

    public GameObject restartButton;

    public Player playerX;
    public Player playerO;
    public PlayerColour activePlayerColour;
    public PlayerColour inactivePlayerColour;
    public GameObject startInfo;

    private void Awake()
    {
        gameOverPanel.SetActive(false);
        restartButton.SetActive(false);
        SetGameManagerReferenceOnButtons();
        //playerMove = true;
        moveCount = 0;
    }

    void SetGameManagerReferenceOnButtons()
    {
        for (int i = 0; i < buttonTextList.Length; i++)
        {
            buttonTextList[i].GetComponentInParent<GridSpace>().SetGameManagerReference(this);
        }
    }

    public void SetStartingSide(string startingSide)
    {
        playerSide = startingSide;
        if (playerSide == "X")
        {
            //computerSide = "O";
            SetPlayerColour(playerX, playerO);
        }
        else
        {
            //computerSide = "X";
            SetPlayerColour(playerO, playerX);
        }
        StartGame();
    }

    void StartGame()
    {
        SetBoardInteractable(true);
        SetPlayerButtons(false);
        startInfo.SetActive(false);
    }

    public string GetPlayerSide()
    {
        return playerSide;
    }

    //public string GetComputerSide()
    //{
    //    return computerSide;
    //}

    public void EndTurn()
    {
        moveCount++;

        if (buttonTextList[0].text == playerSide && buttonTextList[1].text == playerSide && buttonTextList[2].text == playerSide)
        {
            GameOver(playerSide);
        }

        else if (buttonTextList[3].text == playerSide && buttonTextList[4].text == playerSide && buttonTextList[5].text == playerSide)
        {
            GameOver(playerSide);
        }

        else if (buttonTextList[6].text == playerSide && buttonTextList[7].text == playerSide && buttonTextList[8].text == playerSide)
        {
            GameOver(playerSide);
        }

        else if (buttonTextList[0].text == playerSide && buttonTextList[3].text == playerSide && buttonTextList[6].text == playerSide)
        {
            GameOver(playerSide);
        }

        else if (buttonTextList[1].text == playerSide && buttonTextList[4].text == playerSide && buttonTextList[7].text == playerSide)
        {
            GameOver(playerSide);
        }

        else if (buttonTextList[2].text == playerSide && buttonTextList[5].text == playerSide && buttonTextList[8].text == playerSide)
        {
            GameOver(playerSide);
        }

        else if (buttonTextList[0].text == playerSide && buttonTextList[4].text == playerSide && buttonTextList[8].text == playerSide)
        {
            GameOver(playerSide);
        }

        else if (buttonTextList[2].text == playerSide && buttonTextList[4].text == playerSide && buttonTextList[6].text == playerSide)
        {
            GameOver(playerSide);
        }

        //else if (buttonTextList[0].text == playerSide && buttonTextList[1].text == playerSide && buttonTextList[2].text == playerSide)
        //{
        //    GameOver(computerSide);
        //}

        //else if (buttonTextList[3].text == playerSide && buttonTextList[4].text == playerSide && buttonTextList[5].text == playerSide)
        //{
        //    GameOver(computerSide);
        //}

        //else if (buttonTextList[6].text == playerSide && buttonTextList[7].text == playerSide && buttonTextList[8].text == playerSide)
        //{
        //    GameOver(computerSide);
        //}

        //else if (buttonTextList[0].text == playerSide && buttonTextList[3].text == playerSide && buttonTextList[6].text == playerSide)
        //{
        //    GameOver(computerSide);
        //}

        //else if (buttonTextList[1].text == playerSide && buttonTextList[4].text == playerSide && buttonTextList[7].text == playerSide)
        //{
        //    GameOver(computerSide);
        //}

        //else if (buttonTextList[2].text == playerSide && buttonTextList[5].text == playerSide && buttonTextList[8].text == playerSide)
        //{
        //    GameOver(computerSide);
        //}

        //else if (buttonTextList[0].text == playerSide && buttonTextList[4].text == playerSide && buttonTextList[8].text == playerSide)
        //{
        //    GameOver(computerSide);
        //}

        //else if (buttonTextList[2].text == playerSide && buttonTextList[4].text == playerSide && buttonTextList[6].text == playerSide)
        //{
        //    GameOver(computerSide);
        //}

        else if (moveCount >= 9)
        {
            GameOver("draw");
        }

        else
        {
            ChangeSides();
            //delay = 10;
        }
    }

    void SetPlayerColour(Player newPlayer, Player oldPlayer)
    {
        newPlayer.playerPanel.color = activePlayerColour.panelColour;
        newPlayer.playerText.color = activePlayerColour.textColour;
        oldPlayer.playerPanel.color = inactivePlayerColour.panelColour;
        oldPlayer.playerText.color = inactivePlayerColour.textColour;
    }

    void ChangeSides()
    {
        playerSide = (playerSide == "X") ? "O" : "X";
        //playerMove = (playerMove) ? false : true;

        //if (playerMove)
        if (playerSide == "X")
        {
            SetPlayerColour(playerX, playerO);
        }
        else
        {
            SetPlayerColour(playerO, playerX);
        }
    }

    void GameOver(string winningPlayer)
    {
        SetBoardInteractable(false);

        if (winningPlayer == "draw")
        {
            SetGameOverText("It's a draw!");
            SetPlayerColoursInactive();
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
        moveCount = 0;
        gameOverPanel.SetActive(false);
        SetPlayerButtons(true);
        SetPlayerColoursInactive();
        startInfo.SetActive(true);
        //playerMove = true;
        //delay = 10;

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

    void SetPlayerButtons(bool toggle)
    {
        playerX.playerButton.interactable = toggle;
        playerO.playerButton.interactable = toggle;
    }

    void SetPlayerColoursInactive()
    {
        playerX.playerPanel.color = inactivePlayerColour.panelColour;
        playerX.playerText.color = inactivePlayerColour.textColour;
        playerO.playerPanel.color = inactivePlayerColour.panelColour;
        playerO.playerText.color = inactivePlayerColour.textColour;
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (playerMove == false)
    //    {
    //        delay += delay * Time.deltaTime;
    //        if (delay >= 100)
    //        {
    //            gridValue = Random.Range(0, 8);
    //            if (buttonTextList[gridValue].GetComponentInParent<Button>().interactable == true)
    //            {
    //                buttonTextList[gridValue].text = GetComputerSide();
    //                buttonTextList[gridValue].GetComponentInParent<Button>().interactable = false;
    //                EndTurn();
    //            }
    //        }
    //    }
    //}
}
