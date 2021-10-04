using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ball : MonoBehaviour
{
    public enum TagNames
    {
        bucket,
        ExitDoor,
        DeathZone,
        CollectableItem
    }
    public GameObject asteroidPrefab;
    public float respawnTime = 0.25f;
    private Vector3 screenBounds;
    public float x;
    // Use this for initialization
    void Start()
    {

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(asteroidWave());
    }

 

    private void spawnEnemy()
    {
        x = Random.Range(-5, 5);
        GameObject a = Instantiate(asteroidPrefab) as GameObject;
        a.transform.position = new Vector3(x, 3, 0);
    }
    IEnumerator asteroidWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("bucket"))
        {
            Debug.Log(score.scoreAmount);
            score.scoreAmount += 1;
        }
        if (collision.gameObject.CompareTag("Ball"))
        {
            SceneManager.LoadScene("game over");
        }
        Destroy(this.gameObject);
    }
}
