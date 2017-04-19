#pragma strict
public var dialogue : String[];
private var dMan : DialogManager;


function Start () {
	dMan = FindObjectOfType(DialogManager);
}

function Update () {

}
function OnTriggerStay2D (other){
		if( dMan.dialogActive == false && Input.GetKeyDown(KeyCode.Space)){
			dMan.dialogueLine = dialogue;
			dMan.currentLine = 0;
			dMan.ShowDialogue();
		}
	}
