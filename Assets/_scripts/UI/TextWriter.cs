using System;
using System.Collections;
using DefaultNamespace;
using TMPro;
using UnityEngine;

public class TextWriter : MonoBehaviour, ISceneLoad
{
    [SerializeField, Range(0, 10)] private float timeBetweenWord;
    [SerializeField] private TextMeshProUGUI textContainer;
    [SerializeField] private GameObject master;
    private TextInGame _textScriptable;
    private Coroutine _cWriting;

    public static TextWriter SingleInstance;

    private void Awake()
    {
        Debug.Log("VAR");
        OnSceneLoadEvent.AddNotifier(this);
        if (SingleInstance == null)
        {
            SingleInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Space)) return;

        if (_cWriting == null)
        {
            DisableText();
        }
        else
        {
            StopCoroutine(_cWriting);
            _cWriting = null;
            textContainer.text = _textScriptable.text;
        }
    }


    IEnumerator WriteText()
    {
        textContainer.text = "";

        var counter = 0;
        while (counter < _textScriptable.text.Length)
        {
            textContainer.text = String.Concat(textContainer.text, _textScriptable.text[counter]);
            yield return new WaitForSecondsRealtime(timeBetweenWord);
            counter++;
        }

        textContainer.text = _textScriptable.text;

        _cWriting = null;
    }

    public void StartWriting(TextInGame text)
    {
        _textScriptable = text;
        ActivateText();
    }

    private void ActivateText()
    {
        master.gameObject.SetActive(true);
        if (_textScriptable != null)
        {
            try
            {
                _cWriting = StartCoroutine(WriteText());
                Time.timeScale = 0;
            }
            catch (NullReferenceException e)
            {
                DisableText();
                Console.WriteLine($"{e.Message} No text attached");
            }
        }
        else
            DisableText();
    }


    private void DisableText()
    {
        Time.timeScale = 1;
        master.SetActive(false);
    }

    public void NotifySceneLoad()
    {
        DisableText();
        StopAllCoroutines();
        _cWriting = null;
    }
}