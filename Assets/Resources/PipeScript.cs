using UnityEngine;

public class PipeScript : MonoBehaviour {
	
	public float MoveSpeed = .1f;
	
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += Vector3.left * MoveSpeed;
	}
}
