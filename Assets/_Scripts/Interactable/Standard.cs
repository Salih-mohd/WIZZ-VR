using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Standard : XRBaseInteractable, IInteractable
{
    [Header("our part")]
    public AudioSource audioSource;
    public AudioClip clipLaugh;
    public AudioClip clipDestroy;
    public Animator animator;
    public GameObject fxPrefab;
    public virtual void Interact()
    {

         

        animator.enabled = true;
        audioSource.PlayOneShot(clipLaugh);
         
        //audioSource.PlayOneShot(clip);
        //animator.
        // special if any
    }

    public virtual void Finish()
    {
        audioSource.PlayOneShot(clipDestroy);
        Instantiate(fxPrefab,this.transform.position,Quaternion.identity);
        Debug.Log("instantiated prefab");
        this.gameObject.SetActive(false);
        
    }
    
}
