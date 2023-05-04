using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //text score UI

public class GameManager : MonoBehaviour
{

    public GameObject obstacle;
    public Transform spawnPoint;
    int score = 0;
public TextMeshProUGUI scoreText;
public GameObject playButton;
public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    // GameStart();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

IEnumerator SpawnObstacles()
{

    while (true)
    {

float waitTime = Random.Range(0.5f,2f);  //generate random wiatitme btwn o.2-2

yield return new WaitForSeconds(waitTime);

Instantiate(obstacle, spawnPoint.position, Quaternion.identity);
    }
}

void ScoreUp()
{
    score++;
    scoreText.text = score.ToString();
}

public void GameStart() //handles the whole game
{
 player.SetActive(true);
 playButton.SetActive(false);   

StartCoroutine("SpawnObstacles");

InvokeRepeating("ScoreUp", 2f, 1f); //after 2sec  then after 1sec
}
}
