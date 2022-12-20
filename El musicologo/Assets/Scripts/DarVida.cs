using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarVida : MonoBehaviour
{

    VidaPlayer playerVida;
    public float damageTime;
    float currentDamageTime;
    // Start is called before the first frame update
    void Start()
    {

        playerVida= GameObject.FindWithTag("Player").GetComponent<VidaPlayer>();
    }

    private void OnTriggerStay (Collider other)
    {
        if (other.tag == "Player")
        {
            currentDamageTime+= Time.deltaTime;
            if (currentDamageTime>damageTime)
            {
                VidaPlayer.vida += cantidad;
                currentDamageTime = 0.0f;
            }
        }
    }
}
