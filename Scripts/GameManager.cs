using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class GameManager : MonoBehaviour
{

    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI completeText;

    public Button restartButton;
    public GameObject startScreen;
    public PlayerInput playerInput;

    //from spawner
    public List<GameObject> objectOptions;
    public Terrain terrain;
    public int numberOfObjects = 20;
    public float objHeight;

    private int numberOfCollectible1, numberOfCollectible5;
    private int numberOfApple;

    void Start()
    {
        score = 0;

        for (int i = 0; i < numberOfObjects; i++) {
            float randomX = Random.Range(0, terrain.terrainData.size.x / 2) + terrain.terrainData.size.x / 4;
            float randomZ = Random.Range(0, terrain.terrainData.size.z / 2) + terrain.terrainData.size.z / 4;

            float height = terrain.GetComponent<Terrain>().SampleHeight(new Vector3(randomX, 0, randomZ));

            Vector3 spawnPosition = new Vector3(randomX, height + objHeight, randomZ);

            int index = Random.Range(0, objectOptions.Count);
            GameObject temp = Instantiate(objectOptions[index], spawnPosition, Quaternion.identity);

            if (temp.tag == "Apple") {
                numberOfApple++;
            } else if (temp.tag == "Collectible1")
                numberOfCollectible1++;
            else numberOfCollectible5++;
        }


    }

    void Update()
    {
        if (score < 0) {
            GameOver();
        }


        if (score > numberOfCollectible1 + numberOfCollectible5 * 5 - numberOfApple * 2) {
            LevelComplete();
        }
    }

    public void UpdateScore(int scoreToAdd) {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver() {
        gameOverText.gameObject.SetActive(true);

        playerInput.GetComponent<PlayerInput>().enabled = false;
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame() {
        SceneManager.LoadScene("MyFantasyTown");
    }

    public void StartGame() {
        startScreen.gameObject.SetActive(false);
        playerInput.GetComponent<PlayerInput>().enabled = true;
        scoreText.gameObject.SetActive(true);
        //Debug.Log("input: " + playerInput.actions);

    }

    public void ShowMenu() {
        SceneManager.LoadScene("MenuScene");
    }

    public void LevelComplete() {
        completeText.gameObject.SetActive(true);
        playerInput.GetComponent<PlayerInput>().enabled = false;
    }
}
