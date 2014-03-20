using UnityEngine;

public class PoopScript : MonoBehaviour
{
    public GUIText GuiScore;

    public bool IsStopped = false;
    public Sprite PoopedTex;
    public Sprite FlatPoop;

    private bool _texChanged = false;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "PoopCollider")
        {
            rigidbody.velocity = Vector3.zero;
            DirectorScript.Score++;
            Destroy(collision.collider);

            var pipe = collision.collider.transform.parent.FindChild("BottomPipeSprite");
            if (pipe != null)
                ((SpriteRenderer) pipe.GetComponent("SpriteRenderer")).sprite = PoopedTex;

            audio.Play();
        }

        ((SpriteRenderer) GetComponent("SpriteRenderer")).sprite = FlatPoop;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (IsStopped) return;

	    transform.position += Vector3.left * .1f;

        if (transform.position.x < -10)
            Destroy (gameObject);
	}
}
