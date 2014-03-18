using UnityEngine;

public class PoopScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	    transform.position += Vector3.left * .1f;

        if (transform.position.x < -10)
            Destroy (gameObject);
	}
}
