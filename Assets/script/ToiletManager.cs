using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class ToiletManager : MonoBehaviour
{
    public List<Toilet> toilets = new List<Toilet>();
    public TMP_Text PlayerTurnText;
    public TMP_Text resultText;
    public Button resetButton;

    private int currentPlayer = 1;
    private bool isGameOver = false;

    private void Start()
    {
        resetButton.onClick.AddListener(ResetGame);
        UpdatePlayerTurnText();
    }

    public void SelectToilet(int index)
    {
        if (isGameOver) return;  // ← ゲームオーバーなら何もしない

        toilets[index].ChangeState(currentPlayer == 1 ? Toilet.ToiletState.Player1 : Toilet.ToiletState.Player2);

        // 左右ブロック
        if (index - 1 >= 0)
            toilets[index - 1].ChangeState(Toilet.ToiletState.Blocked);
        if (index + 1 < toilets.Count)
            toilets[index + 1].ChangeState(Toilet.ToiletState.Blocked);

        // 勝敗チェック
        if (CheckGameOver())
        {
            isGameOver = true;
            resultText.text = $"プレイヤー{currentPlayer}の勝ち！";
            if (currentPlayer == 1)
            resultText.color = Color.red;
            else
            resultText.color = Color.blue;
            return;
        }

        // プレイヤー交代
        currentPlayer = (currentPlayer == 1) ? 2 : 1;
        UpdatePlayerTurnText();
    }

    private bool CheckGameOver()
    {
        foreach (var toilet in toilets)
        {
            if (toilet.currentState == Toilet.ToiletState.Normal)
                return false;
        }
        return true;
    }

    private void UpdatePlayerTurnText()
    {
        if (currentPlayer ==1)
        {
            PlayerTurnText.text = $"プレイヤー{currentPlayer}の番";
            PlayerTurnText.color = Color.red;
        }
        else
        {
            PlayerTurnText.text = $"プレイヤー{currentPlayer}の番";
            PlayerTurnText.color = Color.blue;
        }
    }

    public void ResetGame()
    {
        isGameOver = false;
        currentPlayer = 1;

        foreach (var toilet in toilets)
        {
            toilet.ResetToilet();
        }

        resultText.text = "";
        UpdatePlayerTurnText();
    }
}