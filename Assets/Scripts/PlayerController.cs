﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Basic Player Script//
//controls: 
//A, D, Left, Right to move
//Left Alt to attack
//Space to jump
//Z is to see dead animation

public class PlayerController : MonoBehaviour 
{

	//variable for how fast player runs//
	private float speed = 5f;
	public bool isAttack;
	public bool isReturn;

	private bool facingRight = true;
	private Animator anim;
	bool grounded = false;//接地判定
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;//レイヤーマスク

	//variable for how high player jumps//
	[SerializeField]
	private float jumpForce = 300f;

	public Rigidbody2D rb { get; set; }

	bool dead = false;
	bool attack = false;
	bool jump = false;
	int jump_count = 0; //jump回数の初期化

	bool isDamage;
	[SerializeField] PlayerHP playerhp;

	/// <summary>Audio設定</summary>
	[Header("AudioSourceをアタッチ"),SerializeField] private AudioSource _audio;//コンポーネント
	[Header("BGMファイルからattackBGMを入れる"),SerializeField] private AudioClip _attackSound;//BGM
	[Header("BGMファイルからdamageBGMを入れる"), SerializeField] private AudioClip _damageSound;//BGM
	[Header("BGMファイルからjumpBGMを入れる"), SerializeField] private AudioClip _jumpSound;//BGM


	void Start () 
	{
		GetComponent<Rigidbody2D>().freezeRotation = true;
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponentInChildren<Animator>();
	}

	void Update()
	{
		HandleInput ();
		isDamage = playerhp._debugMode;
		if(isDamage)
        {
			Play(_damageSound, 0.5f);
		}
	}

	//movement//
	void FixedUpdate ()
	{
		//接地判定を取得　接地していればgroundedはtrueになる
		grounded = Physics2D.OverlapCircle (groundCheck.position/*OverlapCircleのPosition*/, 
											groundRadius/*半径*/, whatIsGround/*レイヤーマスク*/);
		//接地していれば、アニメーション"Ground"をtrueにする。
		anim.SetBool ("Ground", grounded);

		//移動処理
		float horizontal = Input.GetAxis("Horizontal");

		if (!isAttack)
        {
			if (!dead && !attack && !jump)
			{
				anim.SetFloat("vSpeed", rb.velocity.y);
				anim.SetFloat("Speed", Mathf.Abs(horizontal));
				rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
			}
			if (horizontal > 0 && !facingRight && !dead && !attack && !jump)
			{
				Flip(horizontal);
				isReturn = false;
			}

			else if (horizontal < 0 && facingRight && !dead && !attack && !jump)
			{
				Flip(horizontal);
				isReturn = true;
			}
		}
        else
        {

        }
		
	}

	//attack and jump//
	private void HandleInput()
	{
		//攻撃アニメーション、サウンド
		//　↓左shiftキーを押したとき　　　 ↓死んでない　↓地面に立っている
		if (Input.GetButtonDown ("Fire1") && !dead && grounded && !jump) 
			                                                      //↑ジャンプしてない
		{
			//attack = true;
			anim.SetFloat("Speed", 0);
			anim.SetTrigger ("Attack");
			//isAttack = true;
			Play(_attackSound, 0.2f);
		}

		//ジャンプ処理
		if (Input.GetKeyDown(KeyCode.Space))//スペースキーが押されたフレームのみ実行する
		{
			//接地状態かつ死んでいない状態であればジャンプできる。
			//またはジャンプカウントが1未満の時でもジャンプできる。
			if ((grounded && !dead) || jump_count < 1)
			{
				jump = true;
				Debug.Log(grounded);
				rb.AddForce(new Vector2(0, jumpForce));
				jump_count++;
				Play(_jumpSound, 0.2f);
			}
		}

		//スペースキーが押されておらず、非接地状態では以下の処理が行われる
		else if (!grounded)
        {
			anim.SetFloat("Speed", 0);//run animation をオフにする
			anim.SetBool("Jump", true);//jump animation をオンにする
			anim.SetBool("Ground", false);
		}

		//スペースキーが押されておらず、接地状態では以下の処理が行われる
		else if (grounded)
		{
			anim.SetBool("Jump", false);//jump animation をオフにする
			anim.SetBool("Ground", true);
			jump = false;
			jump_count = 0;//ジャンプカウントをリセットする
		}

        //dead animation for testing//
        //テスト用(死亡時)       ↓'Z'を押したら倒れる
        if (Input.GetKeyDown(KeyCode.Z))
		{
			if (!dead)
			{
				anim.SetBool("Dead", true);
				anim.SetFloat("Speed", 0);
				dead = true;
			}
			else
			{
				anim.SetBool("Dead", false);
				dead = false;
			}
		}

	}
		
	private void Flip (float horizontal)
	{
		    
			facingRight = !facingRight;
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
	}

	private void IsAttackFalse()
    {
		isAttack = false;
    }

	public void Jump()
    {

    }

	private void Play(AudioClip audioClip, float volume)
	{
		_audio.clip = audioClip;
		_audio.volume = volume;
		_audio.Play();
	}
}
