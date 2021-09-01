using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TutManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] tutSteps;
    [SerializeField] private TextMeshProUGUI calmDown;
    private int currentStep = 0;
    private string[] stepTexts;
    private bool isTyping = true;
    // Start is called before the first frame update
    void Start()
    {
        stepTexts = new string[tutSteps.Length];
        for (int i = 0; i < tutSteps.Length; i++)
        {
            stepTexts[i] = tutSteps[i].text;
            tutSteps[i].text = "";
        }
        StartCoroutine(TypeWriterEffect(stepTexts[currentStep]));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && !isTyping)
        {
            if (currentStep < tutSteps.Length - 1){
                tutSteps[currentStep].transform.parent.gameObject.SetActive(false);
                currentStep++;
                tutSteps[currentStep].transform.parent.gameObject.SetActive(true);
                StartCoroutine(TypeWriterEffect(stepTexts[currentStep]));
            }
            else{
                SceneManager.LoadScene("GameScene");
            }
            
        }

        if (Input.GetKeyDown(KeyCode.Escape)){
            SceneManager.LoadScene("GameScene");
        }
        
    }

    private IEnumerator TypeWriterEffect(string text)
    {
        isTyping = true;
        foreach (char character in text.ToCharArray())
        {
            tutSteps[currentStep].text += character;
            yield return new WaitForSeconds(0.02f);
        }
        isTyping = false;
    }

    private IEnumerator CalmDown(){
        calmDown.transform.parent.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        calmDown.transform.parent.gameObject.SetActive(false);

    }
}
