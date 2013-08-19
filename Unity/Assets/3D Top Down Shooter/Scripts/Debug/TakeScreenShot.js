private var number=0;
function Update () {
	if(Input.GetKeyDown(KeyCode.Space)){
		Application.CaptureScreenshot("Screenshot"+number+".png");
		number++;
	}
}