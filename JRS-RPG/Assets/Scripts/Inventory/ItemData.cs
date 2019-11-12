using UnityEngine;

public static class ItemData
{
    public static Item CreateItem(int itemId)
    {
        string name = "";
        string description = "";
        int amount = 0;
        int value = 0;
        int damage = 0;
        int armour = 0;
        int heal = 0;
        string iconName = "";
        string meshName = "";
        ItemTypes type = ItemTypes.Misc;

        switch (itemId)
        {
            #region Armour 0-99
            case 0:
                name = "Rags";
                description = "";
                amount = 1;
                value = 1;
                damage = 0;
                armour = 1;
                heal = 0;
                iconName = "Armour/Rags";
                meshName = "Armour/Rags";
                type = ItemTypes.Armour;
                break;
            case 1:
                name = "Plate Armour";
                description = "";
                amount = 1;
                value = 100;
                damage = 0;
                armour = 1;
                heal = 0;
                iconName = "Armour/PlateArmour";
                meshName = "Armour/PlateArmour";
                type = ItemTypes.Armour;
                break;
            case 2:
                name = "Horned Helm";
                description = "";
                amount = 1;
                value = 50;
                damage = 0;
                armour = 1;
                heal = 0;
                iconName = "Armour/HornedHelm";
                meshName = "Armour/HornedHelm";
                type = ItemTypes.Armour;
                break;
            #endregion
            #region Weapon 100-199
            case 100:
                name = "Sword";
                description = "";
                amount = 1;
                value = 10;
                damage = 15;
                armour = 0;
                heal = 0;
                iconName = "Weapon/Sword";
                meshName = "Weapon/Sword";
                type = ItemTypes.Weapon;
                break;
            case 101:
                name = "Axe";
                description = "";
                amount = 1;
                value = 12;
                damage = 17;
                armour = 0;
                heal = 0;
                iconName = "Weapon/Axe";
                meshName = "Weapon/Axe";
                type = ItemTypes.Weapon;
                break;
            case 102:
                name = "Bow";
                description = "";
                amount = 1;
                value = 7;
                damage = 10;
                armour = 0;
                heal = 0;
                iconName = "Weapon/Bow";
                meshName = "Weapon/Bow";
                type = ItemTypes.Weapon;
                break;
            #endregion
            #region Potion 200-299
            case 200:
                name = "Health Potion";
                description = "";
                amount = 1;
                value = 50;
                damage = 0;
                armour = 0;
                heal = 10;
                iconName = "Potion/HealthPotion";
                meshName = "Potion/HealthPotion";
                type = ItemTypes.Potion;
                break;
            case 201:
                name = "Mana Potion";
                description = "";
                amount = 1;
                value = 50;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "Potion/ManaPotion";
                meshName = "Potion/ManaPotion";
                type = ItemTypes.Potion;
                break;
            case 202:
                name = "Stamina Potion";
                description = "";
                amount = 1;
                value = 50;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "Potion/StaminaPotion";
                meshName = "Potion/StaminaPotion";
                type = ItemTypes.Potion;
                break;
            #endregion
            #region Food 300-399
            case 300:
                name = "Apple";
                description = "Munchies and Crunchies";
                amount = 1;
                value = 1;
                damage = 0;
                armour = 0;
                heal = 2;
                iconName = "Food/Apple";
                meshName = "Food/Apple";
                type = ItemTypes.Food;
                break;
            case 301:
                name = "Meat";
                description = "Mmmmmmm Yummy";
                amount = 1;
                value = 5;
                damage = 0;
                armour = 0;
                heal = 5;
                iconName = "Food/Meat";
                meshName = "Food/Meat";
                type = ItemTypes.Food;
                break;
            case 302:
                name = "Cheese";
                description = "Cheese Wheel";
                amount = 1;
                value = 5;
                damage = 0;
                armour = 0;
                heal = 5;
                iconName = "Food/Cheese";
                meshName = "Food/Cheese";
                type = ItemTypes.Food;
                break;
            #endregion
            #region Ingredient 400-499
            case 400:
                name = "Egg";
                description = "";
                amount = 1;
                value = 1;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "Ingredient/Egg";
                meshName = "Ingredient/Egg";
                type = ItemTypes.Ingredient;
                break;
            case 401:
                name = "Fish Bone";
                description = "";
                amount = 1;
                value = 1;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "Ingredient/FishBone";
                meshName = "Ingredient/FishBone";
                type = ItemTypes.Ingredient;
                break;
            case 402:
                name = "Tail";
                description = "";
                amount = 1;
                value = 1;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "Ingredient/Tail";
                meshName = "Ingredient/Tail";
                type = ItemTypes.Ingredient;
                break;
            #endregion
            #region Craftable 500-599
            case 500:
                name = "Iron";
                description = "";
                amount = 1;
                value = 1;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "Craftable/Iron";
                meshName = "Craftable/Iron";
                type = ItemTypes.Craftable;
                break;
            case 501:
                name = "Nails";
                description = "";
                amount = 1;
                value = 1;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "Craftable/Nails";
                meshName = "Craftable/Nails";
                type = ItemTypes.Craftable;
                break;
            case 502:
                name = "Oak";
                description = "";
                amount = 1;
                value = 1;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "Craftable/Oak";
                meshName = "Craftable/Oak";
                type = ItemTypes.Craftable;
                break;
            #endregion
            #region Quest 600-699
            case 600:
                name = "";
                description = "";
                amount = 0;
                value = 0;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "";
                meshName = "";
                type = ItemTypes.Misc;
                break;
            #endregion
            #region Misc 700-799
            case 700:
                name = "";
                description = "";
                amount = 0;
                value = 0;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "";
                meshName = "";
                type = ItemTypes.Misc;
                break;
            #endregion
            case 999:
                name = "Gold";
                description = "";
                amount = 1;
                value = 1;
                damage = 0;
                armour = 1;
                heal = 0;
                iconName = "Money/Gold";
                meshName = "Money/Gold";
                type = ItemTypes.Money;
                break;
            default:
                itemId = -1;
                name = "Cabbage";
                description = "";
                amount = 1;
                value = 100;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "Food/Cabbage";
                meshName = "Food/Cabbage";
                type = ItemTypes.Food;
                break;
        }
        Item temp = new Item
        {
            ID = itemId,
            Name = name,
            Description = description,
            Value = value,
            Amount = amount,
            Damage = damage,
            Armour = armour,
            Heal = heal,
            IconName = Resources.Load("Icons/" + iconName) as Texture2D,
            MeshName = Resources.Load("Prefabs/" + meshName) as GameObject,
            ItemType = type
        };
        return temp;
    }
}
