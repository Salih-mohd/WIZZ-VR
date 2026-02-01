using UnityEngine;

public class SpecialCup : Standard
{
    public Light newlight;

    public override void Interact()
    {
        base.Interact();
        
    }
    public override void Finish()
    {
        
        base.Finish();
        newlight.enabled = true;
        //Debug.Log(" special finish aaney");
    }
}
