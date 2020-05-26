using System;
using System.Collections.Generic;
using System.IO;
using Characters.Equipment.Weapons;
using UnityEngine;

namespace Characters.Utils {
    public class WeaponFactory {
        public static readonly Dictionary<string, BaseWeapon> WeaponList = new Dictionary<string, BaseWeapon>(); 
        
        static WeaponFactory() {
            DirectoryInfo moveDirectory = new DirectoryInfo("Assets/Scripts/Combat/Characters/Equipment/Weapons");

            DirectoryInfo[] firstLevel = moveDirectory.GetDirectories();

            string baseNamespace = "Characters.Equipment.Weapons.";
            
            foreach(DirectoryInfo weaponClass in firstLevel) { //Ammunition, Magical, Melee, Ranged
                string weaponClassNamespace = String.Concat(baseNamespace, weaponClass.Name, ".");
                
                foreach(DirectoryInfo damageType in weaponClass.GetDirectories()) { //Blunt, Cut, Magic, Stab + everything in ranged (bows, crossbows, etc)
                    string damageTypeNamespace = String.Concat(weaponClassNamespace, damageType.Name, ".");
                    
                    foreach(FileInfo weaponFilePath in damageType.GetFiles("*.cs")) {
                        string weaponName = String.Concat(damageTypeNamespace, Path.GetFileNameWithoutExtension(weaponFilePath.Name));
                            
                        WeaponFactory.WeaponList.Add(Path.GetFileNameWithoutExtension(weaponFilePath.Name), Activator.CreateInstance(Type.GetType(weaponName) ?? throw new Exception(weaponName)) as BaseWeapon);
                    }

                    foreach(DirectoryInfo weaponType in damageType.GetDirectories()) {
                        string weaponTypeNamespace = String.Concat(damageTypeNamespace, weaponType.Name, ".");

                        foreach(FileInfo weaponFilePath in weaponType.GetFiles("*.cs")) {
                            string weaponName = String.Concat(weaponTypeNamespace, Path.GetFileNameWithoutExtension(weaponFilePath.Name));
                            
                            WeaponFactory.WeaponList.Add(Path.GetFileNameWithoutExtension(weaponFilePath.Name), Activator.CreateInstance(Type.GetType(weaponName) ?? throw new Exception(weaponName)) as BaseWeapon);
                        }
                    }
                }
            }
        }
    }
}