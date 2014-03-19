using UnityEngine;

public class PoopScript : MonoBehaviour
{
    public GUIText GuiScore;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "PoopCollider")
        {
            rigidbody.velocity = Vector3.zero;
            DirectorScript.Score++;
            Destroy(collision.collider);
        }
    }

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
