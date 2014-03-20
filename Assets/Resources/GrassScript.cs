using UnityEngine;
using System.Collections;

public class GrassScript : MonoBehaviour
{
    public bool IsStopped = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (IsStopped) return;

	    transform.position = new Vector3(transform.position.x-.1f, -4f, .5f);

        if(transform.position.x < -10)
            transform.position = new Vector3(10f, -4f, .5f);
	}
}
