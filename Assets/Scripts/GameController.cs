using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class GameController : MonoBehaviour
{
    [SerializeField]
    PlayerSpawner playerSpawner;
    [SerializeField]
    EnemySpawner enemySpawner;
    [SerializeField]
    BackgroundSpawner backgroundSpawner;
    [SerializeField]
    Camera mainCamera;

    private List<GameObject> players;
    private List<GameObject> enemies;
    private int score;
    private int difficulty = 0;

    public List<GameObject> Players
    {
        get
        {
            return players;
        }
    }

    public Camera MainCamera
    {
        get
        {
            return mainCamera;
        }
    }

    public int Difficulty
    {
        get
        {
            return difficulty;
        }
        set
        {
            Debug.Log(value);
            difficulty = value;
        }
    }

    private void Start()
    {
        // Application.targetFrameRate = 60;
        // QualitySettings.vSyncCount = 0;
        players = new List<GameObject>();
        enemies = new List<GameObject>();

        createInitialSpawners();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            FailMission();
        }
    }

    public void addEnemy(Enemy e)
    {
        enemies.Add(e.gameObject);
    }

    public void enemyDeath(Enemy e)
    {
        enemies.Remove(e.gameObject);
    }

    public void addPlayer(Player p)
    {
        players.Add(p.gameObject);
    }

    public void playerDeath(Player p)
    {
        players.Remove(p.gameObject);
        mainCamera.GetComponent<GameCamera>().removeTarget(p);
        if (players.Count == 0)
        {
            FailMission();
        }
    }

    public int getScore()
    {
        return score;
    }

    public void addScore(int amount)
    {
        score += amount;
    }

    public void FailMission()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    private void OnGUI()
    {
        int i = 1;
        foreach (GameObject o in players)
        {
            Player p = o.GetComponent<Player>();
            GUI.Label(new Rect(10, i * 30 - 20, 150, 20), "Player " + i + " Health: " + p.Health);
            i++;
        }
        GUI.Label(new Rect(200, 10, 100, 20), "Score: " + score);
    }

    private void createInitialSpawners()
    {
        PlayerSpawner psIns = Instantiate(playerSpawner);
        psIns.initialize(this);
        psIns.addPlayer();
        EnemySpawner enIns = Instantiate(enemySpawner);
        enIns.initialize(this);
        BackgroundSpawner bIns = Instantiate(backgroundSpawner);
        bIns.initialize(this);
    }
}