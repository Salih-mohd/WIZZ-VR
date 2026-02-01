using UnityEngine;
using UnityEngine.UI;

public class SpecialJar : Standard
{
    public GameObject image;
    public GameObject WandShowingfx;
    public GameObject wand;
    public override void Interact()
    {
        base.Interact();
        image.SetActive(true);
        

    }
    public override void Finish()
    {
        WandShowingfx.SetActive(true);
        wand.SetActive(true);
        image.SetActive(false);
        base.Finish();

    }
}
