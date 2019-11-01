using System;
using System.Collections.Generic;
using System.Linq;

namespace _8_PetClinics
{
    public class Program
    {
        static List<Pet> pets = new List<Pet>();
        static List<Clinic> clinics = new List<Clinic>();

        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] commandSplit = Console.ReadLine().Split();
                string command = commandSplit[0];

                switch (command)
                {
                    case "Create":
                        if (commandSplit[1] == "Pet")
                        {
                            pets.Add(new Pet(commandSplit[2], int.Parse(commandSplit[3]), commandSplit[4]));
                        }
                        else if(commandSplit[1] == "Clinic")
                        {
                            try
                            {
                                clinics.Add(new Clinic(commandSplit[2],int.Parse(commandSplit[3])));
                            }
                            catch (InvalidOperationException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        break;
                    case "Add":
                        try
                        {
                            Pet pet = GetPet(commandSplit[1]);
                            Clinic clinic = GetClinic(commandSplit[2]);
                            Console.WriteLine(clinic.Add(pet));
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "Release":
                        try
                        {
                            Clinic clinic = GetClinic(commandSplit[1]);
                            Console.WriteLine(clinic.Release());
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "HasEmptyRooms":
                        try
                        {
                            Clinic clinic = GetClinic(commandSplit[1]);
                            Console.WriteLine(clinic.HasEmptyRooms());
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "Print":
                        try
                        {
                            Clinic clinic = GetClinic(commandSplit[1]);
                            if (commandSplit.Length == 3)
                            {
                                Console.WriteLine
                                    (clinic[int.Parse(commandSplit[2]) - 1] != null ?
                                    clinic[int.Parse(commandSplit[2]) - 1].ToString() :
                                    "Room empty");
                            }
                            else
                            {
                                foreach (Pet pet in clinic)
                                {
                                    Console.WriteLine(pet != null ? pet.ToString() : "Room empty"); 
                                }
                            }
                            
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    
                }
            }
        }

        private static Clinic GetClinic(string name)
        {
            Clinic clinic = clinics.SingleOrDefault(c => c.Name == name);
            if (clinic == null)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            return clinic;
        }

        private static Pet GetPet(string name)
        {
            Pet pet = pets.SingleOrDefault(p => p.Name == name);
            if (pet == null)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            return pet;
        }
    }
}
