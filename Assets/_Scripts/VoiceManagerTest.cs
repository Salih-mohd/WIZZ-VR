using System.IO;
using System.Runtime.ExceptionServices;
using UnityEngine;
using Vosk;

public class VoiceManagerTest : MonoBehaviour
{



    //public GameObject fireCube;
    //public GameObject coldSphere;

    public string modelFolderName = "vosk-model-small-en-us-0.15";

    Model model;
    VoskRecognizer recognizer;
    AudioClip micClip;

    const int sampleRate = 16000;
    int lastSamplePosition = 0;



    void Start()
    {
        //string modelPath = Path.Combine(Application.streamingAssetsPath, modelFolderName);
        //model = new Model(modelPath);

        //recognizer = new VoskRecognizer(model, sampleRate);
        //recognizer.SetWords(true);

        //micClip = Microphone.Start(null, true, 1, sampleRate);
        //InvokeRepeating(nameof(ProcessMic), 0.2f, 0.2f);
    }

    public void InitRecognizer()
    {
        if (recognizer != null) return;

        string modelPath = Path.Combine(Application.streamingAssetsPath, modelFolderName);
        model = new Model(modelPath);

        recognizer = new VoskRecognizer(model, sampleRate);
        recognizer.SetWords(true);
        Debug.Log(" initialise recogonizer");
    }

    public void StartListening()
    {
        if (micClip != null) return;

        micClip = Microphone.Start(null, true, 1, sampleRate);
        lastSamplePosition = 0;

        InvokeRepeating(nameof(ProcessMic), 0.2f, 0.2f);

        Debug.Log("Mic STARTED");
    }


    public void StopListening()
    {
        if (micClip == null) return;

        CancelInvoke(nameof(ProcessMic));
        Microphone.End(null);
        micClip = null;

        Debug.Log("Mic STOPPED");
    }





    void ProcessMic()
    {
        int currentPosition = Microphone.GetPosition(null);
        if (currentPosition < lastSamplePosition)
            lastSamplePosition = 0;

        int samplesToRead = currentPosition - lastSamplePosition;
        if (samplesToRead <= 0) return;

        float[] samples = new float[samplesToRead];
        micClip.GetData(samples, lastSamplePosition);
        lastSamplePosition = currentPosition;

        byte[] bytes = new byte[samples.Length * 2];
        for (int i = 0; i < samples.Length; i++)
        {
            short s = (short)(samples[i] * short.MaxValue);
            bytes[i * 2] = (byte)(s & 0xff);
            bytes[i * 2 + 1] = (byte)((s >> 8) & 0xff);
        }

        if (recognizer.AcceptWaveform(bytes, bytes.Length))
        {
            var json = JSON.Parse(recognizer.Result());
            string text = json["text"];

            Debug.Log("Detected: " + text);

            HandleKeyword(text);
        }
    }


    void HandleKeyword(string text)
    {
        if (text.Contains("go"))
        {
            //fireCube.SetActive(false);

            WandCaster.instance.Cast("go");
        }

        if (text.Contains("up"))
        {
            // coldSphere.SetActive(false);
            WandCaster.instance.Cast("up");
        }

        if(text.Contains("fire back"))
        {
            //fireCube.SetActive(true);
        }
        if(text.Contains("cold back"))
        {
            //coldSphere.SetActive(true);
        }
    }


    void OnDestroy()
    {
        recognizer?.Dispose();
        model?.Dispose();
        Microphone.End(null);
    }

















    //public string modelFolderName = "vosk-model-small-en-us-0.15";

    //Model model;
    //VoskRecognizer recognizer;
    //AudioClip micClip;
    //const int sampleRate = 16000;


    //int lastSamplePosition = 0;

    //void Start()
    //{
    //    string modelPath = Path.Combine(Application.streamingAssetsPath, modelFolderName);
    //    model = new Model(modelPath);

    //    recognizer = new VoskRecognizer(model, sampleRate);
    //    recognizer.SetMaxAlternatives(0);
    //    recognizer.SetWords(true);

    //    micClip = Microphone.Start(null, true, 1, sampleRate);
    //    Debug.Log("Mic started: " + Microphone.devices[0]);
    //    InvokeRepeating(nameof(ProcessMic), 0.2f, 0.2f);
    //}

    //void ProcessMic()
    //{
    //    if (micClip == null) return;

    //    int currentPosition = Microphone.GetPosition(null);
    //    if (currentPosition < lastSamplePosition)
    //        lastSamplePosition = 0;

    //    int samplesToRead = currentPosition - lastSamplePosition;
    //    if (samplesToRead <= 0) return;

    //    float[] samples = new float[samplesToRead];
    //    micClip.GetData(samples, lastSamplePosition);

    //    lastSamplePosition = currentPosition;

    //    byte[] bytes = new byte[samples.Length * 2];
    //    for (int i = 0; i < samples.Length; i++)
    //    {
    //        short s = (short)(samples[i] * short.MaxValue);
    //        bytes[i * 2] = (byte)(s & 0xff);
    //        bytes[i * 2 + 1] = (byte)((s >> 8) & 0xff);
    //    }

    //    if (recognizer.AcceptWaveform(bytes, bytes.Length))
    //        Debug.Log("🎤 Final: " + recognizer.Result());
    //    else
    //        Debug.Log("🎧 Partial: " + recognizer.PartialResult());
    //}

    //void OnDestroy()
    //{
    //    recognizer?.Dispose();
    //    model?.Dispose();
    //    Microphone.End(null);
    //}
}
