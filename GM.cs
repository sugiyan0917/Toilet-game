using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text resultText; // CanvasにTextを置いてセット

    public void GameOver(int winner)
    {
        resultText.text = "Player " + winner + " の勝ち！";
        if(winner == 1)
        {
            resultText.color = Color.red;
        }
        else if (winner == 2)
        {
            resultText.color = Color.blue;
        }
        Debug.Log("Player " + winner + " の勝ち！");
    }
}