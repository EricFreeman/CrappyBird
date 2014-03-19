using UnityEngine;

public class PlayerScript : MonoBehaviour {
	
	public float JumpForce = 300f;

    public Sprite UpTex;
    public Sprite DownTex;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
			rigidbody.velocity = Vector3.zero;
			rigidbody.AddForce(Vector3.up * JumpForce);

            var p = (GameObject)Instantiate(Resources.Load("Poop"));
		    p.transform.position = transform.position + new Vector3(-.1f, -.1f, 0f);
            p.rigidbody.AddForce(0f, -200f, 0f);
		}

	    var spriteRenderer = GetComponent("SpriteRenderer") as SpriteRenderer;
	    if (spriteRenderer != null)
	        spriteRenderer.sprite = rigidbody.velocity.y > 0 ? DownTex : UpTex;

	    transform.eulerAngles = new Vector3(0, 0, rigidbody.velocity.y * 5);
	}
}
