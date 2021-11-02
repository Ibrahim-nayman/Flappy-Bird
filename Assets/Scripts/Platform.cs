using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Animator animator;

    private void Update()
    {
        switch (GameManager.Instance.CurrentGameState)
        {
            case GameState.StartGame:
                animator.enabled = false;
                break;
            case GameState.MainGame:
                animator.enabled = true;
                break;
            case GameState.LoseGame:
                animator.enabled = false;
                break;
            case GameState.WinGame:
                break;
            default:
                break;
        }
    }
}
