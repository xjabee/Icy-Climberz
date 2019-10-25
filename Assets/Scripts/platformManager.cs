using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformManager : MonoBehaviour
{
    private static platformManager instance;
    public static platformManager Instance
    {
        get
        {
            return instance;
        }
    }
    public Animator platformanim;
    public Animation platformanimation;
    void awake()
    {
        instance = this;
    }
    private Vector3 playerRefPos;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if(playerRefPos.y < 3)
        // {
        //     Vector3 platformRandomizer = new Vector3(Random.Range(-2, 4), 3, 0);
        //     Instantiate(platform, platformRandomizer, Quaternion.identity);
        //     playerRefPos = player.transform.position;
        // }
    }

    private void OnCollisionEnter2D(Collision2D c)
    {
        
    }
}
