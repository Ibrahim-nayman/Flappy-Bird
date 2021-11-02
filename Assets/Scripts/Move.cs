using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        switch (GameManager.Instance.CurrentGameState)
        {
            case GameState.StartGame:
                break;
            case GameState.MainGame:
                Movement();
                break;
            case GameState.LoseGame:
                Destroy(gameObject);
                break;
            case GameState.WinGame:
                break;
        }
    }

    private void Movement()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
