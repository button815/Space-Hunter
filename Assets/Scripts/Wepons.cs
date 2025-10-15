using UnityEngine;

public class Wepons : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
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
}
