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
		CreatePipe();
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
	}
	
	void CreatePipe() {
		var p = (GameObject)Instantiate(Resources.Load ("Pipe"));
		p.transform.position += new Vector3(10, Random.Range(-2.5f, 2.5f), 0);
		PipeList.Add(p);	
	}
}
