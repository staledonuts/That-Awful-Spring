using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip turnPage, chooseAnswer;
    [SerializeField] private string sceneToLoad;
    [SerializeField] private TMP_Text question;
    [SerializeField] private TMP_Text answer1;
    [SerializeField] private TMP_Text answer2;
    [SerializeField] private TMP_Text answer3;

    [SerializeField] private Question[] questions;
    [SerializeField] private TMP_Text finalScore;
    [SerializeField] private GameObject finalScoreHolder;
    private int currentQuestion;
    public int correctAnswers;
    private bool _loadingScene;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        newQuestion(0);
    }

    public void newQuestion(int guess)
    {
        if(currentQuestion != 0)
        {
            if(guess == questions[currentQuestion - 1].correctAnswer)
            {
                correctAnswers++;
            }
        }
        audioSource.PlayOneShot(chooseAnswer, 1F);
        if(currentQuestion >= questions.Length)
        {
            if(!_loadingScene)
            {
                finalScoreHolder.SetActive(true);
                finalScore.text = $"Correct: {correctAnswers} / {questions.Length}";
                _loadingScene = true;
                StartCoroutine(LoadScene());
            }
            return;
        }
        else
        {
            audioSource.PlayOneShot(turnPage, 1F);
            question.text = questions[currentQuestion].question;
            answer1.text = $"a) {questions[currentQuestion].answer1}";
            answer2.text = $"b) {questions[currentQuestion].answer2}";
            answer3.text = $"c) {questions[currentQuestion].answer3}";
            
            GameObject myEventSystem = GameObject.Find("EventSystem");
            myEventSystem .GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
        }
        currentQuestion++;
    }

    private IEnumerator LoadScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);
        asyncLoad.allowSceneActivation = false;

        while (asyncLoad.progress < 0.9F)
        {
            yield return null;
        }
        yield return new WaitForSeconds(4);
        Transitions.current.FadeOut();
        yield return new WaitForSeconds(2);
        asyncLoad.allowSceneActivation = true;
    }
}


[System.Serializable]
class Question
{
    public string question;
    public string answer1;
    public string answer2;
    public string answer3;
    public int correctAnswer;
}
