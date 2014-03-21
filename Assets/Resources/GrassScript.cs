using UnityEngine;

public class GrassScript : MonoBehaviour
{
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (DirectorScript.IsPlayerDead) return;

	    transform.position += DirectorScript.MoveVector;

        if(transform.position.x < -10)
            transform.position = new Vector3(10f, -4f, .5f);
	}
}
