using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdJump : MonoBehaviour
{
    public float velocity = 1f;

    public Rigidbody2D rb2D;

    public GameObject deathScreen;

    public Animator animator;
    
    void Update()
    {
        switch (GameManager.Instance.CurrentGameState)
        {
            case GameState.StartGame:
                rb2D.constraints = RigidbodyConstraints2D.FreezeAll;
                Starting();
                break;
            case GameState.MainGame:
                rb2D.constraints = RigidbodyConstraints2D.None;
                Jump();
                break;
            case GameState.LoseGame:
                break;
            case GameState.WinGame:
                break;
            default:
                break;
        }
    }

    private void Starting()
    {
        transform.position = transform.up * Mathf.PingPong(Time.time, 0.5f);
        if (Input.GetMouseButtonDown(0))
        {
            GameManager.Instance.CurrentGameState = GameState.MainGame;
        }
    }

    private void Jump()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb2D.velocity = Vector2.up * velocity;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "ScoreArea")
        {
            GameManager.Instance.UpdateScore();
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("DeathArea"))
        {
            StartCoroutine(LoseGameCooldown());
        }

      
    }

    private IEnumerator LoseGameCooldown()
    {
        GameManager.Instance.CurrentGameState = GameState.LoseGame;
        yield return new WaitForSeconds(0.7f);
        animator.enabled = false;
        deathScreen.SetActive(true);
    }
}
