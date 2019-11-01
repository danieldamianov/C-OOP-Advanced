using P07_InfernoInfinity.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace P07_InfernoInfinity
{
    public class Program
    {
        public static void Main()
        {
            List<IWeapon> weapons = new List<IWeapon>();
            string input;
            while ((input = Console.ReadLine()) != "END")
            {

                string[] args = input.Split(';');
                string command = args[0];
                switch (command)
                {
                    case "Create":
                        string rarity = args[1].Split()[0];
                        string typeOfWeapon = args[1].Split()[1];
                        string name = args[2];
                        string fullNameOfTypeOfWeapon = $"P07_InfernoInfinity.Models.Weapons.{typeOfWeapon}";
                        weapons.Add((IWeapon)Activator.CreateInstance(Type.GetType(fullNameOfTypeOfWeapon), name, rarity));
                        break;
                    case "Add":
                        string weaponName = args[1];
                        int index = int.Parse(args[2]);
                        string clarityOfGem = args[3].Split()[0];
                        string typeOfGem = args[3].Split()[1];
                        string fullTypeOfGem = $"P07_InfernoInfinity.Models.Gems.{typeOfGem}";
                        IWeapon weapon = weapons.Single(w => w.Name == weaponName);                   // check for duplic or unexistance !!!
                        weapon.AddGem(index, (IGem)Activator.CreateInstance(Type.GetType(fullTypeOfGem), clarityOfGem));
                        break;
                    case "Remove":
                        string weapon_name = args[1];
                        int socketIndex = int.Parse(args[2]);
                        IWeapon weaponToRemoveGemFrom = weapons.Single(w => w.Name == weapon_name);  // check for duplic or unexistance !!!
                        weaponToRemoveGemFrom.RemoveGem(socketIndex);
                        break;
                    case "Print":
                        string weapon_name_forPrint = args[1];
                        IWeapon weaponForPrint = weapons.Single(w => w.Name == weapon_name_forPrint);  // check for duplic or unexistance !!!
                        Console.WriteLine(weaponForPrint.ToString());
                        break;
                }

            }
        }
    }
}
