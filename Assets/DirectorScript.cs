using System.Linq;
using UnityEngine;
using System.Collections.Generic;

public class DirectorScript : MonoBehaviour {
	
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
		if(PipeList[PipeList.Count - 1].transform.position.x < (10 - Spacing)) {
			CreatePipe();
		}
	    if (PipeList[0].transform.position.x < -10)
	    {
	        Destroy(PipeList[0]);
            PipeList.RemoveAt(0);
	    }

        var p = GameObject.Find("Player");
        if (((PlayerScript)p.GetComponent("PlayerScript")).IsDead && (Input.GetKeyDown(KeyCode.Space) || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)))
	    {
	        StartGame();
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

        foreach(var p in PipeList)
        {
            var s = (PipeScript)p.GetComponent("PipeScript");
            s.IsStopped = true;
        }

        foreach (var p in GameObject.FindObjectsOfType<PoopScript>())
        {
            p.IsStopped = true;
        }
    }

    void StartGame()
    {
        Score = 0;
        var p = GameObject.Find("Player");
        p.transform.position = new Vector3(-5f, 1f, 0f);
        p.rigidbody.velocity = Vector3.zero;
        ((PlayerScript) p.GetComponent("PlayerScript")).IsDead = false;

        while(PipeList.Count > 0)
        {
            Destroy(PipeList[0]);
            PipeList.RemoveAt(0);
        }

        foreach (var poo in FindObjectsOfType<PoopScript>())
        {
            Debug.Log(poo);
            Destroy(poo.gameObject);
        }

        CreatePipe();
    }
}
