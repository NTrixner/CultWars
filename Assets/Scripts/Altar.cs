using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altar : MonoBehaviour
{
    [SerializeField]
    private List<SpriteRenderer> Relics;

    [SerializeField]
    private SpriteRenderer BigRelic;

    [SerializeField]
    private int currentRelic;

    [SerializeField]
    Collider2D collider;


    [SerializeField] AudioSource audio;
    [SerializeField] AudioClip relicSecuredSound;

    void Start()
    {
        int i = 1;
        while(i <= Relics.Count)
        {
            Relics[i-1].enabled = i < currentRelic;
            i++;
        }
        BigRelic.enabled = false;
    }

    public void GotRelic()
    {
        currentRelic++;
        Relics[currentRelic-1].enabled = true;
        if (currentRelic >= Relics.Count)
        {
            BigRelic.enabled = true;
            Debug.Log("You've won the Game!");
            //[TODO] Win condition met! 
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController controller;
        if(collision.collider.TryGetComponent<PlayerController> (out controller))
        {
            if(controller.HasRelic())
            {
                GotRelic();
                audio.PlayOneShot(relicSecuredSound);
                controller.RemoveRelic();
            }
        }
    }
}
