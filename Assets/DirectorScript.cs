using Assets;
using UnityEngine;
using System.Collections.Generic;

public class DirectorScript : MonoBehaviour
{
    public static bool IsPlayerDead = false;
    public static float MoveSpeed = .1f;
    public static Vector3 MoveVector = Vector3.left*MoveSpeed;

	List<GameObject> PipeList = new List<GameObject>();
	
	public int Spacing = 6;

    private static int _score = 0;
    public static int Score
    {
        get { return _score; }
        set
        {
            _score = value;
            GameObject.Find("ScoreText").guiText.text = "Score: " + _score;
            SetHighScore();
        }
    }

    public static int HighScore
    {
        set { GameObject.Find("HighScoreText").guiText.text = "High Score: " + value; }
    }
	
	// Use this for initialization
	void Start () {
        StartGame();
	}
	
	// Update is called once per frame
	void Update () {
		if(PipeList[PipeList.Count - 1].transform.position.x < (10 - Spacing))
			CreatePipe();

	    if (PipeList[0].transform.position.x < -10)
	    {
	        Destroy(PipeList[0]);
            PipeList.RemoveAt(0);
	    }

        if (IsPlayerDead && InputHelpers.IsKeyDownOrTouch(KeyCode.Space))
	        StartGame();
	}
	
	void CreatePipe() {
		var p = (GameObject)Instantiate(Resources.Load ("Pipe"));
		p.transform.position += new Vector3(10, Random.Range(-2.5f, 2.5f), 0);
		PipeList.Add(p);	
	}

    public void Die()
    {
        audio.Play();
        IsPlayerDead = true;
    }

    private static void SetHighScore()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            if (PlayerPrefs.GetInt("HighScore") < Score)
                PlayerPrefs.SetInt("HighScore", Score);
        }
        else
            PlayerPrefs.SetInt("HighScore", Score);

        HighScore = PlayerPrefs.GetInt("HighScore");
    }

    void StartGame()
    {
        Score = 0;
        var p = GameObject.Find("Player");
        p.transform.position = new Vector3(-5f, 1f, 0f);
        p.rigidbody.velocity = Vector3.zero;
        IsPlayerDead = false;

        while(PipeList.Count > 0)
        {
            Destroy(PipeList[0]);
            PipeList.RemoveAt(0);
        }

        foreach (var poo in FindObjectsOfType<PoopScript>())
            Destroy(poo.gameObject);

        CreatePipe();
    }
}
