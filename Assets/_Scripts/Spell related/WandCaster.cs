using System.Collections;
using UnityEngine;

public class WandCaster : MonoBehaviour
{

    public static WandCaster instance;


    [SerializeField] Transform castPoint;
    [SerializeField] SpellBase currentSpell;
    [SerializeField] SpellManager spellManager;

    bool canCast = true;


    private void Awake()
    {
        instance = this;
    }


    public void Cast(string spell)
    {
        Debug.Log("called cast in wand caster");

        //if (castPoint == false || currentSpell == null) return;

        if (spellManager.spells.Count != 0)
        {
            //currentSpell = spellManager.spells[index];
            currentSpell = spellManager.spells[spell];

            StartCoroutine(CastRoutine());
            Debug.Log("called cast routine");
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
