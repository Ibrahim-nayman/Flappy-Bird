using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public BirdJump birdScript;

    public GameObject borular;

    public float time;

    public bool isGameStarted;

    private void Update()
    {
        switch (GameManager.Instance.CurrentGameState)
        {
            case GameState.StartGame:
                break;
            case GameState.MainGame:
                StartCoroutine(SpawnObject(time));
                break;
            case GameState.LoseGame:
                break;
            case GameState.WinGame:
                break;
        }
    }

    public IEnumerator SpawnObject(float time)
    {
        if (!isGameStarted)
        {
            isGameStarted = true;

            Instantiate(borular, new Vector3(1, Random.Range(0, 0.5f), 0), Quaternion.identity);

            yield return new WaitForSeconds(time);
            isGameStarted = false;
        }
    }
}
