using Assets;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
	
	public float JumpForce = 300f;

    public Sprite UpTex;
    public Sprite DownTex;
    public Sprite DeadTex;

    public bool IsPlaying = true;
	
	// Update is called once per frame
	void Update ()
	{
	    transform.eulerAngles = new Vector3(0, 0, rigidbody.velocity.y * 5);

	    if (DirectorScript.IsPlayerDead || !IsPlaying) return;

        if (InputHelpers.IsKeyDownOrTouch(KeyCode.Space))
        {
			rigidbody.velocity = Vector3.zero;
			rigidbody.AddForce(Vector3.up * JumpForce);

            var p = (GameObject)Instantiate(Resources.Load("Poop"));
		    p.transform.position = transform.position + new Vector3(-.1f, -.1f, 0f);
            p.rigidbody.AddForce(0f, -200f, 0f);

            audio.Play();
		}

	    var spriteRenderer = GetComponent<SpriteRenderer>();
	    if (spriteRenderer != null)
	        spriteRenderer.sprite = rigidbody.velocity.y > 0 ? DownTex : UpTex;
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (DirectorScript.IsPlayerDead) return;

        var d = GameObject.Find("Director");
        d.GetComponent<DirectorScript>().Die();

        var spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
            spriteRenderer.sprite = DeadTex;

        rigidbody.AddForce(0, -50f, 0);
    }
}
