using UnityEngine;

public class FlySpell : SpellBase
{
    public override void Cast(Transform castPoint)
    {
        Debug.Log("casted fly spell");
        if(Physics.Raycast(castPoint.position, castPoint.forward,out RaycastHit hit, 50f))
        {
            if(hit.collider != null)
            {
                var rb=hit.collider.gameObject.GetComponent<Rigidbody>();
                rb.AddForce((Vector3.forward+Vector3.up)*2f,ForceMode.Impulse);
                Debug.Log("force added");
            }
        }
        

        
    }
}
