using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class CloudScript : MonoBehaviour
{
    public Sprite CloudTexture;
    public int CloudCount = 5;

    private List<GameObject> _clouds = new List<GameObject>();
    private List<float> _cloudSpeeds = new List<float>(); //yes I know this is a terrible hack, I'm sorry :( 

	// Use this for initialization
	void Start () {
	    for (int i = 0; i < CloudCount; i++)
	    {
	        var cloud = new GameObject();
	        cloud.AddComponent("SpriteRenderer");
	        var s = (SpriteRenderer)cloud.GetComponent("SpriteRenderer");
	        s.sprite = CloudTexture;

            s.transform.position = new Vector3(Random.Range(-10, 10), Random.Range(0, 6), 1f);
            s.transform.localScale = new Vector3(Random.Range(.7f, 1f), Random.Range(.7f, 1f), Random.Range(.7f, 1f));

            _clouds.Add(cloud);
            _cloudSpeeds.Add(Random.Range(.01f, .03f));
	    }
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < CloudCount; i++)
        {
            _clouds[i].transform.position -= new Vector3(_cloudSpeeds[i], 0f, 0f);

            if (_clouds[i].transform.position.x < -10)
            {
                _clouds[i].transform.position = new Vector3(Random.Range(10.5f, 12), Random.Range(0, 6), 1f);
                _clouds[i].transform.localScale = new Vector3(Random.Range(.7f, 1f), Random.Range(.7f, 1f), Random.Range(.7f, 1f));
                _cloudSpeeds[i] = Random.Range(.01f, .03f);
            }
	    }
	}
}
