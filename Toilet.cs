using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Toilet : MonoBehaviour
{
    private SpriteRenderer sr;
    private ToiletManager manager;
    public int toiletIndex; // 手動で設定する番号

    public enum ToiletState
    {
        Normal,
        Player1,
        Player2,
        Blocked
    }

    public ToiletState currentState = ToiletState.Normal;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        manager = FindFirstObjectByType<ToiletManager>();
    }

    private void OnMouseDown()
　{
    if (currentState == ToiletState.Normal)
    {
        manager.SelectToilet(toiletIndex);
    }
    else
    {
        Debug.Log($"{toiletIndex}番のトイレは使用不可です。状態: {currentState}");
    }
　}

    public void ChangeState(ToiletState newState)
    {
        currentState = newState;
        Debug.Log($"{toiletIndex}番トイレの状態変更：{newState}");

        switch (currentState)
        {
            case ToiletState.Normal:
                sr.color = Color.white;
                break;
            case ToiletState.Player1:
                sr.color = Color.red;
                break;
            case ToiletState.Player2:
                sr.color = Color.blue;
                break;
            case ToiletState.Blocked:
                sr.color = Color.gray;
                break;
        }
    }

    public void ResetToilet()
    {
        currentState = ToiletState.Normal;
        sr.color = Color.white;
    }
}