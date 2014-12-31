var mainMenuSceneName : String;
var pauseMenuFont : Font;
private var pauseEnabled = false;			

function Start(){
	pauseEnabled = false;
	Time.timeScale = 1;
	AudioListener.volume = 1;
	Screen.showCursor = false;
}

function Update(){

	//check if pause button (escape key) is pressed
	if(Input.GetKeyDown("escape")){
	
		//check if game is already paused		
		if(pauseEnabled == true){
			//unpause the game
			//pauseEnabled = false;
			//Time.timeScale = 1;
			//AudioListener.volume = 1;
			//Screen.showCursor = false;			
		}
		
		//else if game isn't paused, then pause it
		else if(pauseEnabled == false){
			pauseEnabled = true;
			AudioListener.volume = 0;
			Time.timeScale = 0;
			Screen.showCursor = true;
		}
	}
}

private var showGraphicsDropDown = false;

function OnGUI(){

GUI.skin.box.font = pauseMenuFont;
GUI.skin.button.font = pauseMenuFont;

	if(pauseEnabled == true){
		
		//Make a background box
		if(GUI.Button(Rect(Screen.width /2 - 100,Screen.height /2 - 100,250,200), "Pause Menu")){
			//unpause the game
			pauseEnabled = false;
			Time.timeScale = 1;
			AudioListener.volume = 1;
			Screen.showCursor = false;	
		}
		
		//Make Main Menu button
		if(GUI.Button(Rect(Screen.width /2 - 100,Screen.height /2 - 50,250,50), "Main Menu")){
			Application.LoadLevel(mainMenuSceneName);
		}
		
		//Make quit game button
		if (GUI.Button (Rect (Screen.width /2 - 100,Screen.height /2 + 50,250,50), "Quit Game")){
			Application.Quit();
		}
	}
}