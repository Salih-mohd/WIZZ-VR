using UnityEngine;
using Meta.WitAi.CallbackHandlers;
using Meta.WitAi.Json;

public class VoiceIntentHandler : MonoBehaviour
{
    public void OnWitResponse(WitResponseNode response)
    {
        if (response == null)
        {
            Debug.Log(" Wit Response is NULL");
            return;
        }

        var intents = response["intents"];

        if (intents == null || intents.Count == 0)
        {
            Debug.Log(" No intents detected in Wit response");
            Debug.Log("Full response: " + response.ToString());
            return;
        }

        string intent = intents[0]["name"].Value;

        Debug.Log(" Voice detected intent: " + intent);

        //SpellManager.Instance.HandleIntent(intent);
    }
}
