var paused = false;
var Skin: GUISkin;

function Update(){
    if (Input.GetKeyDown(KeyCode.Escape)) {
        if (!paused) {
            Time.timeScale = 1;
            paused = true;
        } else {
            Time.timeScale = 1;
            paused = false;
        }
    }
}

function OnGUI() {
    GUI.skin = Skin;
    if (paused) {
        GUILayout.BeginArea(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 200), "Меню", "Window");
        if (GUILayout.Button("Продолжить")) {
            paused = false;
            Time.timeScale = 1;
        }
        if (GUILayout.Button("Рестарт")) {
            Application.LoadLevel("1scene1");
        }
        if (GUILayout.Button("Главное меню")) {
            Application.LoadLevel("menu");
        }
        if (GUILayout.Button("Выход")) {
            Application.Quit();
        }
        GUILayout.EndArea();
    }
}