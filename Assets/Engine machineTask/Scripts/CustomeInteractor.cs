using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class CustomeInteractor : XRDirectInteractor
{
    bool isSelected;
    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        base.OnHoverEntered(args);

        Rigidbody rb = args.interactableObject.transform.GetComponent<Rigidbody>();
        var animator = args.interactableObject.transform.GetComponent<Animator>();
        

        if (rb != null)
        {
            rb.constraints = RigidbodyConstraints.None;
        }
        if (animator != null)
            animator.enabled = true;
    }
    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        base.OnHoverExited(args);

        if (isSelected)
            return;

        Rigidbody rb = args.interactableObject.transform.GetComponent<Rigidbody>();
        var animator = args.interactableObject.transform.GetComponent<Animator>();
        if (animator != null)
            animator.enabled = false;

        if (rb != null)
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        isSelected = true;
        var partsScript = args.interactableObject.transform.GetComponent<ForParts>();
        if (partsScript != null)
        {
            partsScript.ChangeText();
            partsScript.SettingTagNameActive();
            partsScript.ChangeTag();
        }

    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        var animator = args.interactableObject.transform.GetComponent<Animator>();
        if (animator != null)
            animator.enabled = false;
        Invoke("SetIsSelectedFalse", 2);
        var neig = args.interactableObject.transform.GetComponent<neighbour>();
        var rb= neig.GetComponent<Rigidbody>();
        var partsScript = args.interactableObject.transform.GetComponent<ForParts>();
        foreach(var a in neig.neighbours)
        {
            if (a != null)
            {
                a.GetComponent<BoxCollider>().enabled = true;
            }
        }

        rb.useGravity = true;
        rb.constraints=RigidbodyConstraints.None;
        partsScript.SettingTagNameDeactive();
    }

    private void SetIsSelectedFalse()
    {
        isSelected = false;
    }
}
