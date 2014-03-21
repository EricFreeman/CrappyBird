using Assets;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float JumpForce = 300f;

    public Sprite UpTex;
    public Sprite DownTex;
    public Sprite DeadTex;

    // Update is called once per frame
    void Update()
    {
        if (!DirectorScript.IsGameStarted)
        {
            ResetPlayer();
            return;
        }

        transform.eulerAngles = new Vector3(0, 0, rigidbody.velocity.y * 5);

        if (DirectorScript.IsPlayerDead) return;

        if (InputHelpers.IsKeyDownOrTouch(KeyCode.Space))
            Jump();

        SetTexture();
    }

    public void ResetPlayer()
    {
        transform.position = new Vector3(-5, 1, 0);
        transform.rigidbody.velocity = Vector3.zero;
        transform.eulerAngles = Vector3.zero;
        SetTexture();
    }

    private void SetTexture()
    {
        GetComponent<SpriteRenderer>().sprite = rigidbody.velocity.y > 0 ? DownTex : UpTex;
    }

    public void Jump()
    {
        rigidbody.velocity = Vector3.zero;
        rigidbody.AddForce(Vector3.up * JumpForce);

        var p = (GameObject)Instantiate(Resources.Load("Poop"));
        p.transform.position = transform.position + new Vector3(-.1f, -.1f, 0f);
        p.rigidbody.AddForce(0f, -200f, 0f);

        audio.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (DirectorScript.IsPlayerDead) return;

        var d = GameObject.Find("Director");
        d.GetComponent<DirectorScript>().Die();

        GetComponent<SpriteRenderer>().sprite = DeadTex;
        rigidbody.AddForce(0, -50f, 0);
    }
}
