using Assets;
using UnityEngine;
using System.Collections.Generic;

public class DirectorScript : MonoBehaviour
{
    public static bool IsGameStarted = false;
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
        }
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

	    if (InputHelpers.IsKeyDownOrTouch(KeyCode.Space))
	    {
	        if (IsPlayerDead)
	            StartGame();
	        else if (!IsGameStarted)
	        {
	            IsGameStarted = true;
	            GameObject.Find("Player").GetComponent<PlayerScript>().Jump();
                ShowTapMessage(false);
	        }
	    }
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
        ShowTapMessage(true);
    }

    void StartGame()
    {
        Score = 0;
        GameObject.Find("Player").GetComponent<PlayerScript>().ResetPlayer();
        IsPlayerDead = false;
        IsGameStarted = false;

        while(PipeList.Count > 0)
        {
            Destroy(PipeList[0]);
            PipeList.RemoveAt(0);
        }

        foreach (var poo in FindObjectsOfType<PoopScript>())
            Destroy(poo.gameObject);

        CreatePipe();
    }

    private static void ShowTapMessage(bool show)
    {
        GameObject.Find("TapToStart").guiText.enabled = show;
    }
}
