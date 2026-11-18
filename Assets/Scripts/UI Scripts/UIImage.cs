using UnityEngine;
using UnityEngine.UI;

public class UIImage : MediatorUI
{
    public void ImageSet(BasePokemon User, bool isFront)
    {
        Texture2D image;
        if (isFront == true)
        {
            image = Resources.Load<Texture2D>(User.GetFrontString());
        }
        else
        {
            image = Resources.Load<Texture2D>(User.GetRearString());
        }

        gameObject.GetComponent<Image>().overrideSprite = Sprite.Create(image, 
            new Rect(0, 0, image.width, image.height), 
            new Vector2(image.width / 2, image.height / 2));

    }
}
