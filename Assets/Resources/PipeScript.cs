using UnityEngine;

public class PipeScript : MonoBehaviour {
	
	public float MoveSpeed = .1f;
    public bool IsStopped = false;
	
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (IsStopped) return;

		transform.position += Vector3.left * MoveSpeed;
	}
}
