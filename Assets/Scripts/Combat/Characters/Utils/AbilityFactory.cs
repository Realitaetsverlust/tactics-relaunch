using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Characters.Abilities;
using UnityEngine;

namespace Characters.Utils {
    public static class AbilityFactory {
        private static readonly Dictionary<string, BaseAbility> AbilityList = new Dictionary<string, BaseAbility>(); 
        
        static AbilityFactory() {
            DirectoryInfo moveDirectory = new DirectoryInfo("Assets/Scripts/Combat/Characters/Abilities");

            DirectoryInfo[] firstLevel = moveDirectory.GetDirectories();

            string baseNamespace = "Characters.Abilities.";
            
            foreach(DirectoryInfo classDamageType in firstLevel) {

                string damageTypeNamespace = String.Concat(baseNamespace, classDamageType.Name, ".");
                
                foreach(DirectoryInfo classFolder in classDamageType.GetDirectories()) {
                    
                    string classNamespace = String.Concat(damageTypeNamespace, classFolder.Name, ".");

                    foreach(FileInfo abilityFilePath in classFolder.GetFiles("*.cs")) {
                        string abilityName = String.Concat(classNamespace, Path.GetFileNameWithoutExtension(abilityFilePath.Name));
                        
                        AbilityFactory.AbilityList.Add(Path.GetFileNameWithoutExtension(abilityFilePath.Name), Activator.CreateInstance(Type.GetType(abilityName) ?? throw new Exception(abilityName)) as BaseAbility);
                    }
                }
            }
        }

        public static BaseAbility getAbility(string name) {
            return AbilityFactory.AbilityList[name];
        }
    }
}