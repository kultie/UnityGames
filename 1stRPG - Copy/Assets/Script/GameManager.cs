using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GameManager : MonoBehaviour {

	public Question[] questions;
	private static List<Question> unansweredQuestion;

	private Question currentQuestion;
	[SerializeField]
	private Text factText;

	[SerializeField]
	private float timeBetweenQuestion = 1f;

	[SerializeField]
	private Text trueAnswerText;
	[SerializeField]
	private Text falseAnswerText;
	[SerializeField]
	private Animator animator;

	void Start()
	{
		if (unansweredQuestion == null || unansweredQuestion.Count == 0) 
		{
			unansweredQuestion = questions.ToList<Question>();
		}

		SetCurrentQuestion ();
	}

	void SetCurrentQuestion()
	{
		int randomQuestionIndex = Random.Range (0, unansweredQuestion.Count);
		currentQuestion = unansweredQuestion [randomQuestionIndex];
		factText.text = currentQuestion.fact;

		if (currentQuestion.isTrue) {
			trueAnswerText.text = "CORRECT";
			falseAnswerText.text = "WRONG";
		} else {
			trueAnswerText.text="WRONG";
			falseAnswerText.text="CORRECT";
		}
	}

	IEnumerator TransitionToNextQuestion(){
		unansweredQuestion.Remove (currentQuestion);
		yield return new WaitForSeconds (timeBetweenQuestion);

		Application.LoadLevel (1);
	}

	public void UserSelectTrue(){
		animator.SetTrigger ("True");
		if (currentQuestion.isTrue) {
			Debug.Log ("Correct");
		}
		else{
			Debug.Log ("Wrong");
		}
		StartCoroutine (TransitionToNextQuestion ());
	}
	public void UserSelectFalse(){
		animator.SetTrigger ("False");
		if (!currentQuestion.isTrue) {
			Debug.Log ("Correct");
		}
		else{
			Debug.Log ("Wrong");
		}
		StartCoroutine (TransitionToNextQuestion ());
	}
}

