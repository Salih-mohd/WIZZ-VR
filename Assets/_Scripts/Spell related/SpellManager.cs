using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour
{
    public List<SpellBase> spells=new List<SpellBase>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Spell"))
        {

            Debug.Log("added spell");
            spells.Add(other.gameObject.GetComponent<SpellBase>());
        }
    }
}
