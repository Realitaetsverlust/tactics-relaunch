using System;
using System.Collections.Generic;
using System.IO;
using Characters.Equipment;
using Characters.Equipment.Accessory;
using Characters.Equipment.Armor;
using Characters.Equipment.Weapons;
using UnityEngine;

namespace Characters.Utils {
    public static class EquipmentFactory {
        private static readonly Dictionary<string, BaseEquipment> EquipmentList = new Dictionary<string, BaseEquipment>(); 
        
        static EquipmentFactory() {
            DirectoryInfo moveDirectory = new DirectoryInfo("Assets/Scripts/Characters/Equipment");

            DirectoryInfo[] firstLevel = moveDirectory.GetDirectories();

            string baseNamespace = "Characters.Equipment.";
            
            foreach(DirectoryInfo equipmentType in firstLevel) {
                string equiptmentTypeNamespace = String.Concat(baseNamespace, equipmentType.Name, ".");
                
                foreach(DirectoryInfo bodyPartsFolder in equipmentType.GetDirectories()) {
                    string bodyPartNamespace = String.Concat(equiptmentTypeNamespace, bodyPartsFolder.Name, ".");

                    foreach(FileInfo equipmentFilePath in bodyPartsFolder.GetFiles("*.cs")) {
                        string equipmentName = String.Concat(bodyPartNamespace, Path.GetFileNameWithoutExtension(equipmentFilePath.Name));
                        
                        EquipmentFactory.EquipmentList.Add(Path.GetFileNameWithoutExtension(equipmentFilePath.Name), Activator.CreateInstance(Type.GetType(equipmentName) ?? throw new Exception(equipmentName)) as BaseEquipment);
                    }
                }
            }
        }

        public static BaseWeapon getWeapon(string name) {
            return EquipmentFactory.EquipmentList[name] as BaseWeapon;
        }
        public static BaseArmor getArmor(string name) {
            return EquipmentFactory.EquipmentList[name] as BaseArmor;
        }
        public static BaseAccessory getAccessory(string name) {
            return EquipmentFactory.EquipmentList[name] as BaseAccessory;
        }
    }
}