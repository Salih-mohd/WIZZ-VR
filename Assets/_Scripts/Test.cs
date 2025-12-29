using Meta.WitAi;
using Meta.WitAi.Configuration;
using Meta.WitAi.Json;
using Oculus.Voice;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test : MonoBehaviour
{
    public AppVoiceExperience voice;

    void Start()
    {
        Debug.Log("Sending TEXT request to Wit");

        voice.Activate("go fire spell");
    }

    public void OnWitResponse(WitResponseNode response)
    {
        Debug.Log("RAW TEXT RESPONSE:\n" + response.ToString());
    }
}
