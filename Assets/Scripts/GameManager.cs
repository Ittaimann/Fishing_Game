using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {


    private bool paused = false;
    public GameObject pauseMenu;
    public GameObject GameOverPanel, WinPanel, controlsPanel;
    public Text score_text;
    public int score = 0;
    [Header("Spawn objects")]

    public GameObject fish;
    public GameObject bird;
    [Header("Spawn Range x")]
    public float x_range_min;
    public float x_range_max;

    [Header("Spawn Range y for fish")]
    public float fish_y_range_min;
    public float fish_y_range_max;

    [Header("Spawn Range y for bird")]
    public float bird_y_range_min;
    public float bird_y_range_max;
    // Use this for initialization
    void Start () {
        //pauseMenu.SetActive(false);
        StartCoroutine(Spawn_Fish());
        StartCoroutine(Spawn_Birds());
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("score", 0);
	}
    public void end()
    {
        Time.timeScale = 0;
        GameOverPanel.SetActive(true);
    }
    public void win()
    {
        Time.timeScale = 0;
        WinPanel.SetActive(true);
    }

    void Update()
    {
        score_text.text = "Score: " + score;
        if (Input.GetKeyDown(KeyCode.Escape) && !paused)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            paused = true;

        }
        else if (Input.GetKeyDown(KeyCode.Escape) && paused)
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
            paused = false;
        }
    }

    private IEnumerator Spawn_Fish()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(1f, 2f));
            GameObject f;
            int dir = Random.Range(0, 2) == 0 ? 1 : -1;
            if (dir == 1)
            {
                f = Instantiate(fish, new Vector3(x_range_min, Random.Range(fish_y_range_min, fish_y_range_max)), Quaternion.identity);
                f.GetComponent<Fish_Controller>().end_range = x_range_max;
            }
            else
            {
                f = Instantiate(fish, new Vector3(x_range_max, Random.Range(fish_y_range_min, fish_y_range_max)), Quaternion.identity);
                f.GetComponent<Fish_Controller>().end_range = x_range_min;
            }
            f.GetComponent<Fish_Controller>().direction = dir;
        }

    }
    private IEnumerator Spawn_Birds()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1f, 1f));
            GameObject f;
            int dir = Random.Range(0, 2) == 0 ? 1 : -1;
            if (dir == 1)
            {
                f = Instantiate(bird, new Vector3(x_range_min, Random.Range(bird_y_range_min, bird_y_range_max)), Quaternion.identity);
                f.GetComponent<Bird_Controller>().end_range = x_range_max;
            }
            else
            {
                f = Instantiate(bird, new Vector3(x_range_max, Random.Range(bird_y_range_min, bird_y_range_max)), Quaternion.identity);
                f.GetComponent<Bird_Controller>().end_range = x_range_min;
            }
            f.GetComponent<Bird_Controller>().direction = dir;
        }

    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("IttaiTest");
    }

    public void Quit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);

    }

    public void controls()
    {
        controlsPanel.SetActive(true);
    }
}
