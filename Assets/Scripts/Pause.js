var paused = false;

function Update(){
    if (Input.GetKeyDown(KeyCode.Escape)) {
        if (!paused) {
            Time.timeScale = 0;
            paused = true;
        } else {
            Time.timeScale = 1;
            paused = false;
        }
    }
}