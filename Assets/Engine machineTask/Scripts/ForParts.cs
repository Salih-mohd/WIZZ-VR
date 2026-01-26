using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class ForParts : MonoBehaviour
{

    public string partName;
    public GameObject text;
    public string partsImportance;
    public TMP_Text tagName;
    public Transform tagNameTransform;
    public AudioSource audioSource;
    public AudioClip clip;

    public bool isGrabbed;

    public void ChangeText()
    {
        text.GetComponent<TMP_Text>().text = $"You grabbed {partName}. This will do {partsImportance} to the engine";
        isGrabbed = true ;
    }
    public void SettingTagNameActive()
    {
        tagNameTransform.gameObject.SetActive(true);
        audioSource.PlayOneShot(clip); 
    }

    public void SettingTagNameDeactive()
    {
        tagNameTransform.gameObject.SetActive(false);
        isGrabbed = false;
    }

    public void ChangeTag()
    {
        tagName.text = $"{partName}";
    }
    private void Update()
    {
        if (isGrabbed)
        {
            tagNameTransform.position=gameObject.transform.position+Vector3.up*.2f;
        }
    }

    private void LateUpdate()
    {
        if (isGrabbed)
        {
            tagNameTransform.forward=Camera.main.transform.forward;
        }
    }


}
