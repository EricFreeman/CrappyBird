using System.Collections.Generic;
<<<<<<< HEAD
using System.Runtime.Remoting.Messaging;
using Assets.Resources;
using UnityEngine;

=======
using UnityEngine;

>>>>>>> 1ede5b6d803e200446f1a109dbb24052500fdfdc
public class CloudScript : MonoBehaviour
{
    public Sprite CloudTexture;
    public Sprite BuildingTexture;

    public int CloudCount = 5;
    public int BuildingCount = 3;

    private List<BackgroundObject> _objs = new List<BackgroundObject>();

	// Use this for initialization
	void Start () {
	    for (int i = 0; i < CloudCount; i++)
	    {
<<<<<<< HEAD
            _objs.Add(BackgroundObject.Create(CloudTexture, 0f, 6f, .01f, .03f, .9f, .7f));
	    }
=======
	        var cloud = new GameObject();
	        cloud.AddComponent<SpriteRenderer>();
	        var s = cloud.GetComponent<SpriteRenderer>();
	        s.sprite = CloudTexture;
>>>>>>> 1ede5b6d803e200446f1a109dbb24052500fdfdc

	    for (int i = 0; i < BuildingCount; i++)
	    {
	        _objs.Add(BackgroundObject.Create(BuildingTexture, -.85f, -.85f, .005f, .01f, .8f));
	    }
	}
	
	// Update is called once per frame
	void Update () {
        foreach (var obj in _objs)
	    {
	        obj.Update();
	    }
	}
}
