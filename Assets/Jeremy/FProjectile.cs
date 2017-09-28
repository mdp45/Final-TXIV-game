using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class FProjectile : MonoBehaviour {

    public float forceIncrement;
    public float projectileForce = 0f;
    public float maxForce;
    public Rigidbody2D projectile;
    public Transform firingPoint;
    public ForceMode2D forceMode;
    public GameObject TurnManager;
    public GameObject PowerBar;
    Animator anim;
    public AudioClip[] audioClip;
    AudioSource audioSource;

    /// <summary>
    /// Will initialize projectile force to 0, get animator and audio components
    /// </summary>
    void Start () {
        projectileForce = 0f;
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        updatePowerBar();
    }

    /// <summary>
    /// Controls the force of the projectile to be shot, charge while button is held down, 
    /// shoots when button is released. Powerbar will update every frame to match the force of the projectile.
    /// While the button is held down, the projectile force will be checked to make sure it does not exceed the max force stipulated.
    /// If max force has been hit, it will lock the value at max force.
    /// </summary>
    void FixedUpdate()
    {
        if (CrossPlatformInputManager.GetButton("Fire"))
        {
            PlaySound(0);
            anim.SetInteger("State", 2);
            if (projectileForce < maxForce)
            {
                projectileForce += forceIncrement;
                updatePowerBar();
            }
            else
            {
                projectileForce = maxForce;
                updatePowerBar();
            }            
        }
        if (CrossPlatformInputManager.GetButtonUp("Fire"))
        {
            Rigidbody2D instance = Instantiate(projectile, firingPoint.position, Quaternion.identity) as Rigidbody2D;
            instance.AddForce(firingPoint.right * projectileForce, forceMode);
            projectileForce = 0f;
            updatePowerBar();
            TurnManager.GetComponent<TurnManager>().SwitchPlayer();            
        }
    }

    /// <summary>
    /// Updates the powerbar to match the force of the projectile charged.
    /// </summary>
    void updatePowerBar()
    {
        float hp = projectileForce / maxForce;
        if (hp >= 0)
            PowerBar.transform.localScale = new Vector3(hp, PowerBar.transform.localScale.y, PowerBar.transform.localScale.z);
    }

    void PlaySound(int sound)
    {
        audioSource.PlayOneShot(audioClip[sound]);
    }
}
