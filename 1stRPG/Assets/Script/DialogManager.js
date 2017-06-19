#pragma strict
import UnityEngine.UI;

var dBox: GameObject;
var dText: Text;
var dialogActive: boolean;
var dialogueLine: String[];
var currentLine: int;
private var player: Controller;

function Start () {
	dBox.SetActive(false);
	player = FindObjectOfType(Controller);
}

function Update () {
	if( dialogActive && Input.GetKeyDown(KeyCode.Space)){
	//dBox.SetActive(false);
	//dialogActive = false;
	currentLine++;
	}
	if(currentLine >= dialogueLine.Length){
	dBox.SetActive(false);
	dialogActive = false;
	currentLine = 0;
	player.canMove = true;
	}
	dText.text = dialogueLine[currentLine];
} 
 //function ShowBox(dialogue: String){
	//dialogActive = true;
	//dBox.SetActive( true);
	//dText.text = dialogue;
	//player.canMove = false;
//}
function ShowDialogue(){
	dialogActive = true;
	dBox.SetActive(true);
	player.canMove = false;
}