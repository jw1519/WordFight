using UnityEngine;

public class ShieldDecorator : BaseAbilityDecorator
{
    GameObject shieldObject;
    public int shieldValue = 0;
    public ShieldDecorator(GameObject player) : base(player) { }

    public override void Apply(GameObject player)
    {
        base.Apply(player); // Log application
        if (shieldObject == null)
        {
            // make object
            shieldObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            shieldObject.transform.SetParent(player.transform);
            shieldObject.transform.localScale = new Vector2(2,1.5f);
            shieldObject.transform.localPosition = Vector3.zero;
            //set material
            SetMaterialTransparent(shieldObject.GetComponent<Renderer>().material);


        }
    }
    public override void Remove(GameObject player)
    {
        base.Remove(player);
        if (shieldObject != null)
        {
            Object.Destroy(shieldObject);
            shieldObject = null;
            player.GetComponent<Player>().defence = 0;
        }
    }
    void SetMaterialTransparent(Material mat)
    {        
        // Change the rendering mode to Transparent
        mat.SetFloat("_Mode", 3); // 3 = Transparent
        mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        mat.SetInt("_ZWrite", 0);
        mat.DisableKeyword("_ALPHATEST_ON");
        mat.EnableKeyword("_ALPHABLEND_ON"); mat.DisableKeyword("_ALPHAPREMULTIPLY_ON"); mat.renderQueue = 3000;
        // Adjust the alpha value for transparency
        Color color = mat.color; color.a = 0.5f;
        //0 = fully transparent, 1 = fully opaque 
        mat.color = color;
    }
}
