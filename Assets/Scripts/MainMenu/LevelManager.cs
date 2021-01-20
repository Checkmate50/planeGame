using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    protected int difficulty;

    public int Difficulty
    {
        set
        {
            difficulty = value;
        }
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        DontDestroyOnLoad(this);
    }

    protected void OnEnable()
    {
        SceneManager.sceneLoaded += onSceneLoaded;
    }

    protected void onSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MainMenu")
        {
            LevelManager[] lm = Resources.FindObjectsOfTypeAll(typeof(LevelManager)) as LevelManager[];
            for (int i = 0; i < lm.Length; i++)
            {
                if (i < lm.Length - 1)
                    Destroy(lm[i].gameObject);
                // Have to also change the dropdown menu, seems like a pain
                // So deal with that later
                //else if (difficulty > 0)
                //    lm[i].Difficulty = difficulty;
            }
        }
        else
        {
            GameController gc = FindObjectOfType(typeof(GameController)) as GameController;
            Debug.Log(gc);
            Debug.Log(difficulty);
            gc.Difficulty = difficulty;
        }
    }

    protected void OnDisable()
    {
        SceneManager.sceneLoaded -= onSceneLoaded;
    }
}
