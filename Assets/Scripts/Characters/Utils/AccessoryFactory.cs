using System;
using System.Collections.Generic;
using System.IO;
using Characters.Equipment.Accessory;
using Characters.Equipment.Armor;
using UnityEngine;

namespace Characters.Utils {
    public static class AccessoryFactory {
        public static readonly Dictionary<string, BaseAccessory> accessoryList = new Dictionary<string, BaseAccessory>();

        static AccessoryFactory() {
            DirectoryInfo accessoryDirectory = new DirectoryInfo("Assets/Scripts/Characters/Equipment/Accessory");

            string baseNamespace = "Characters.Equipment.Accessory.";

            foreach(DirectoryInfo bodyPartsFolder in accessoryDirectory.GetDirectories()) {
                string bodyPartNamespace = String.Concat(baseNamespace, bodyPartsFolder.Name, ".");

                foreach(FileInfo equipmentFilePath in bodyPartsFolder.GetFiles("*.cs")) {
                    string equipmentName = String.Concat(bodyPartNamespace, Path.GetFileNameWithoutExtension(equipmentFilePath.Name));

                    AccessoryFactory.accessoryList.Add(Path.GetFileNameWithoutExtension(equipmentFilePath.Name), Activator.CreateInstance(Type.GetType(equipmentName) ?? throw new Exception(equipmentName)) as BaseAccessory);
                }
            }
        }
    }
}