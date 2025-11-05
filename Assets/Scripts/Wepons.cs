using System;
using System.Collections;
using UnityEngine;

public class Wepons : MonoBehaviour
{
    public ParticleSystem muzzleflash;
    public AudioSource gunfire;
    public float fireRate;
    void Start()
    {
        
    }
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) )
        {
          
            StartCoroutine(FireFlash(fireRate));
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
            {
                Debug.Log(hit.collider.name);
                if(hit.collider.tag == "Enemy")
                {
                    hit.collider.gameObject.GetComponent<Enemyhealth>().Takedamage(1);
                }
            }
        }
        
    }

    private IEnumerator FireFlash(float duration)
    {
        muzzleflash.Play();
        gunfire.PlayOneShot(gunfire.clip);
        yield return new WaitForSeconds( duration);
        muzzleflash.Stop();
    }
}
