using System.Collections;
using UnityEngine;

public class WandCaster : MonoBehaviour
{
    [SerializeField] Transform castPoint;
    [SerializeField] SpellBase currentSpell;
    [SerializeField] SpellManager spellManager;

    bool canCast = true;

    public void Cast(int index)
    {
        Debug.Log("called cast");
        if (castPoint == false || currentSpell == null) return;

        if (spellManager.spells.Count != 0)
        {
            currentSpell = spellManager.spells[index];

            StartCoroutine(CastRoutine());
        }
        else
        {
            Debug.Log("No spells found");
        }

        
    }



    IEnumerator CastRoutine()
    {
        canCast=false;
        currentSpell.Cast(castPoint);
        yield return new WaitForSeconds(2);
        canCast = true;
    }

     
}
