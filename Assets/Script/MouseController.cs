using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseController : MonoBehaviour {
	private Rigidbody2D rig;
	public float JetForce = 75.0f;
	public float Speed = 3.0f;

	private bool isGrounded = false;
	public bool jetActive = false;
	[HideInInspector]
	private bool isDead = false;

	private Animator anim;
	[HideInInspector]
	public int Coins = 0;

	public ParticleSystem jetPack;
	public LayerMask Ground;
	//音效
	public AudioClip CoinCollectSound;
	public AudioClip LaserSound;
//	private AudioSource FootStep;
//	private AudioSource JetPackSound;


	// Use this for initialization
	void Start () {
		rig = GetComponent<Rigidbody2D>();
		//FootStep = GetComponents<AudioSource>(0);
		//JetPackSound = GetComponents<AudioSource>(1);
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		this.UpdateMouseAnim();
	}

	private void FixedUpdate()
    {
		 jetActive = Input.GetButton("Fire1");
		//Debug.Log(jetActive);
		if(rig)
        {
			if(jetActive)
            {
				rig.AddForce(new Vector2(0, JetForce));
			}
			if (this.isDead)
			{
				rig.velocity = new Vector2(Speed, 0);
			}
			rig.velocity = new Vector2(Speed, rig.velocity.y);
		}
		CheckGroundedStatus();
	 }

    private void OnCollisionEnter2D(Collision2D collision)
    {
		//Debug.Log("Enter");   
    }
	private void OnCollisionStay2D(Collision2D collision)
	{
		//Debug.Log("Stay");
	}
	private void OnCollisionExit2D(Collision2D collision)
	{
		//Debug.Log("Exit");
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		//Debug.Log(collision.gameObject.tag);
		if (collision.gameObject.CompareTag("Coin"))
		{
			 Destroy(collision.gameObject);
			 this.Coins++;
			 AudioSource.PlayClipAtPoint(CoinCollectSound,transform.position);
			
			//collision.gameObject.SetActive(false);
		}
		else if(collision.gameObject.CompareTag("Laser"))
        {	     
			this.isDead = true;
			//Debug.Log("Mouse is dead");
			AudioSource.PlayClipAtPoint(LaserSound, transform.position);
        }                                                                                                                                                                                                                                                                                                                                
        
	}
	//private void OnTriggerStay2D(Collider2D collision)
 //   {
	//	Debug.Log("Trigger Stay");
 //   }
	//private void OnTriggerExit2D(Collider2D collision)
	//{
	//	Debug.Log("Trigger Exit");
	//}
	private void CheckGroundedStatus()    //检测是否落地
    {
		isGrounded = Physics2D.OverlapCircle(transform.Find("GroundCheck").position,0.1f,Ground);
		//Debug.Log(isGrounded);
		if(isGrounded)
        {
			//FootStep.Play();
        }
		ParticleSystem.EmissionModule em = jetPack.emission;
		em.enabled = !isGrounded;
		em.rateOverTime = jetActive ? 300.0f : 75.0f;
    }
	void SoundAdjust()
    {

    }
	void UpdateMouseAnim()
    {
		if(anim)
        {
			anim.SetBool("grounded", isGrounded);
			anim.SetBool("dead", isDead);
			//anim.SetBool("grounded",isGrounded);
			//anim.SetBool("dead", isDead);
            if (isDead)
            {
				anim.SetTrigger("diedonce");
            }
			//anim.SetTrigger("diedonce");
        }
    }
	public void MouseDeadShow()
    {
		Debug.Log("You Lose");
		anim.enabled = false;
    }
}
