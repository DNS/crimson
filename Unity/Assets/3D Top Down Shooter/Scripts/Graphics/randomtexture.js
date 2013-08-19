var textures:Texture[];
var normalmaps:Texture[];
var havenormals:boolean;

private var index=0;
function Start () {
	//must be the same number of textures than normal maps
	index=Random.Range(0, textures.length);
	renderer.material.SetTexture("_MainTex", textures[index]);
	if(havenormals)
		renderer.material.SetTexture("_BumpMap", normalmaps[index]);
}