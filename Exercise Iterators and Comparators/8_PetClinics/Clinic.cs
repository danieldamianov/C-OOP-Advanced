using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _8_PetClinics
{
    public class Clinic : IEnumerable<Pet>
    {
        Pet[] pets;
        string name;
        int indexOfMiddleRoom;

        public Clinic(string name, int petsCount)
        {
            if (petsCount % 2 == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            this.name = name;
            this.indexOfMiddleRoom = petsCount / 2;
            this.pets = new Pet[petsCount];
        }

        public Pet this[int index] => pets[index];
        public string Name => this.name;

        public bool Add(Pet pet)
        {
            if (this.HasEmptyRooms() == false)
            {
                return false;
            }
            for (int counter = 0; counter <= this.indexOfMiddleRoom; counter++)
            {
                if (this.pets[this.indexOfMiddleRoom - counter] == null)
                {
                    this.pets[this.indexOfMiddleRoom - counter] = pet;
                    break;
                }

                if (this.pets[this.indexOfMiddleRoom + counter] == null)
                {
                    this.pets[this.indexOfMiddleRoom + counter] = pet;
                    break;
                }
            }
            return true;
        }

        public bool Release()
        {
            for (int i = this.indexOfMiddleRoom; i < this.pets.Count(); i++)
            {
                if (this.pets[i] != null)
                {
                    this.pets[i] = null;
                    return true;
                }
            }

            for (int i = 0; i < this.indexOfMiddleRoom; i++)
            {
                if (this.pets[i] != null)
                {
                    this.pets[i] = null;
                    return true;
                }
            }

            return false;
        }

        public bool HasEmptyRooms()
        {
            return this.pets.Any(pet => pet == null);
        }

        public IEnumerator<Pet> GetEnumerator()
        {
            foreach (var pet in this.pets)
            {
                yield return pet;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
