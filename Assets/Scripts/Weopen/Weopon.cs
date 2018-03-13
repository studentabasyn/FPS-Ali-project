using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weopon : MonoBehaviour {

    // Use this for initialization

    private Animator anim;

    public float range= 100f;   //Maximum range of the weapon
    public int bulletsPerMag = 30;  //Bulletes per each magazine 
    public int bulletLeft = 200;    //Total bulletes we have

    public int currentBullets;  //Current bullets in our magazine

    public float fireRate = 0.1f;   //Deley between each shoot 

    public Transform shootpoint;    //The point which the bullets leaves the muzzle

    float fireTimer;    //time counter for the deley

    //Use this for initilization
	void Start () {

        anim = GetComponent<Animator>();
        currentBullets = bulletsPerMag;

	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButton("Fire1"))
        {
            Fire(); //Execute the fire funtion if press left Mouse button
        }

        if (fireTimer < fireRate)
        {
            fireTimer += Time.deltaTime;    //Add into timer counter
        }

	}

    private void FixedUpdate()
    {
        AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);

        if (info.IsName ("Fire")) anim.SetBool("Fire", false);
        
    }

    private void Fire()
    {
        if (fireTimer < fireRate) return;
        
        RaycastHit hit;

        if (Physics.Raycast(shootpoint.position, shootpoint.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name + "Found!"); 
        }

        anim.CrossFadeInFixedTime("Fire", 0.01f); //play the fire animation
        //anim.SetBool("Fire", true);
  
        currentBullets--; 
        fireTimer = 0.0f; // Reset Fire Timer
    }
}
