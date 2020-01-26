using System;
using System.Collections.Generic;
using System.IO;
using Characters.Equipment.Armor;

namespace Characters.Utils {
    public class ArmorFactory {
        public static readonly Dictionary<string, BaseArmor> armorList = new Dictionary<string, BaseArmor>();

        static ArmorFactory() {
            DirectoryInfo armorDirectory = new DirectoryInfo("Assets/Scripts/Characters/Equipment/Armor");

            string baseNamespace = "Characters.Equipment.Armor.";

            foreach(DirectoryInfo bodyPartsFolder in armorDirectory.GetDirectories()) {
                string bodyPartNamespace = String.Concat(baseNamespace, bodyPartsFolder.Name, ".");

                foreach(FileInfo equipmentFilePath in bodyPartsFolder.GetFiles("*.cs")) {
                    string equipmentName = String.Concat(bodyPartNamespace, Path.GetFileNameWithoutExtension(equipmentFilePath.Name));

                    ArmorFactory.armorList.Add(Path.GetFileNameWithoutExtension(equipmentFilePath.Name), Activator.CreateInstance(Type.GetType(equipmentName) ?? throw new Exception(equipmentName)) as BaseArmor);
                }
            }
        }
    }
}