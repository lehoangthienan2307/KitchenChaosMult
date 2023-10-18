using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
   

    
    public override void Interact(Player player)
    {
        //there is no kitchen object
        if (!HasKitchenObject())
        {
            //player hold kitchen object
            if(player.HasKitchenObject())
            {
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
        }
        //there is kitchen object
        else
        {
            // check if player carrying kitchen object
            if (player.HasKitchenObject())
            {
                //check if player carrying plate
                if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
                {
                    //player is holding plate
                    if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO()))
                    {
                        GetKitchenObject().DestroySelf();
                    }
                    
                }
                //player carrying smth else not plate
                else
                {
                    if (GetKitchenObject().TryGetPlate(out plateKitchenObject))
                    {
                        if (plateKitchenObject.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO()))
                        {
                            player.GetKitchenObject().DestroySelf();
                        }
                    }
                }
            }
            //player not carrying anything so player pick that object
            else
            {
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }

    
}
