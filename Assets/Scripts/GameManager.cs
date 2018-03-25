using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject GameOverText;
    public GameObject ScoreText;
    public GameObject YouScoredText;

    public System.Random random = new System.Random();

    private bool countScore;

    public float BlockActionDelay;
    public float BlockFallSpeed;
    public float BlockActionRate;
    public float ScoreRate;

    private float timeUntilBlockAction;
    private float timeUntilScore;

    public int BlockFallAmountTop;
    public int BlockFallAmountBottom;
    public int BlocksUntilBottomAwake;
    public int BlockExplodeAmount;
    public int ScoreAmount;

    private int score;

    private List<string> list_t;
    private List<string> list_b;

    void Start()
    {
        CreateBlockList();

        timeUntilBlockAction = BlockActionRate;
        timeUntilScore = ScoreRate;

        countScore = true;
        score = 0;
    }

    void Update()
    {
        //Restarting
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(0);
        }

        //Score
        if (countScore)
        {
            if (timeUntilScore < 0)
            {
                score += ScoreAmount;
                timeUntilScore = ScoreRate;
                ScoreText.GetComponent<Text>().text = "Score: " + score;
            }
        }

        //Block functionality
        if (timeUntilBlockAction < 0)
        {
            DropBlocks(BlockFallAmountTop, 1);
            ExplodeBlocks(BlockExplodeAmount);
            timeUntilBlockAction = BlockActionRate;

            if (BlocksUntilBottomAwake >= list_t.Count)
            {
                DropBlocks(BlockFallAmountBottom, 2);
            }
        }

        timeUntilBlockAction -= Time.deltaTime;
        timeUntilScore -= Time.deltaTime;
    }

    public void GameOver()
    {
        countScore = false;
        GameOverText.SetActive(true);
        YouScoredText.GetComponent<Text>().text = "You scored " + score + " points!";
    }
    private void CreateBlockList()
    {
        list_t = new List<string>();
        list_b = new List<string>();

        for (int i = 1; i < 9; ++i)
        {
            for (int j = 1; j < 9; ++j)
            {
                list_t.Add("Level/Top Plane/" + i + "/" + j);
                list_b.Add("Level/Bottom Plane/" + i + "/" + j);
            }
        }
    }
    private void ExplodeBlocks(int amount)
    {
        int randomIndex;

        for (int i = 0; i < amount; ++i)
        {
            randomIndex = random.Next(list_t.Count);
            GameObject.Find(list_t[randomIndex]).GetComponent<Cube>().Explode(BlockActionDelay);
            list_t.RemoveAt(randomIndex);
        }
    }
    private void DropBlocks(int amount, int plane)
    {
        int randomIndex;

        for (int i = 0; i < amount; ++i)
        {
            if (plane == 1)
            {
                randomIndex = random.Next(list_t.Count);
                GameObject.Find(list_t[randomIndex]).GetComponent<Cube>().Fall(BlockActionDelay, BlockFallSpeed);
                list_t.RemoveAt(randomIndex);
            }
            else if (plane == 2)
            {
                randomIndex = random.Next(list_b.Count);
                GameObject.Find(list_b[randomIndex]).GetComponent<Cube>().Fall(BlockActionDelay, BlockFallSpeed);
                list_b.RemoveAt(randomIndex);
            }
            else
            {
                Debug.LogError("Plane out of range!");
            }
        }
    }
}
