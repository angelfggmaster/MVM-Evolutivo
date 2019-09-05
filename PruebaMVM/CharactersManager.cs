using System;
using System.Collections.Generic;
using System.Linq;

namespace PruebaMVM
{
    public class CharactersManager
    {
        static Random rnd = new Random();

        string validCharacters;
        string targetString;
        int lengthTarget;
        double probability;
        int copyRange;

        public CharactersManager()
        {
            validCharacters = new AppSettings().ValidCharacters;
            targetString = new AppSettings().TargetString;
            lengthTarget = new AppSettings().TargetString.Length;
            probability = new AppSettings().Probability;
            copyRange = new AppSettings().CopyRange;
        }


        private string CreateRandomCharacter()
        {
            return validCharacters[rnd.Next(validCharacters.Length)].ToString();
        }

        public int RateString(string testString)
        {
            int rate = 0;
            for (int i = 0; i < targetString.Length; i++)
            {
                if (targetString[i].Equals(testString[i]))
                    rate++;
            }

            return rate;
        }

        public string CreateInitialString()
        {
            string randomString = string.Empty;

            for (int i = 0; i < lengthTarget; i++)
                randomString += CreateRandomCharacter();

            return randomString;
        }

        private string CreateItemGeneration(string initialString)
        {
            Random rndDouble = new Random();
            string itemGeneration = string.Copy(initialString);

            for (int i = 0; i < itemGeneration.Length; i++)
            {
                if (rndDouble.NextDouble() <= probability)
                    itemGeneration = itemGeneration.Remove(i, 1).Insert(i, CreateRandomCharacter());
            }

            return itemGeneration;
        }

        public List<string> CreateGeneration(string initialString)
        {
            List<string> generation = new List<string>();

            for (int i = 0; i < copyRange; i++)
                generation.Add(CreateItemGeneration(initialString));

            return generation;
        }

        public MaxStringValue GetMaxStringValue(List<string> generation)
        {
            MaxStringValue maxStringValue = new MaxStringValue();
            int maxValue = 0;

            foreach (string s in generation)
            {
                int value = RateString(s);
                if (value > maxValue)
                {
                    maxStringValue.Text = s;
                    maxStringValue.Value = value;
                    maxValue = value;
                }
            }

            if (maxStringValue.Text == null)
            {
                maxStringValue.Text = generation.First();
                maxStringValue.Value = 0;
            }

            return maxStringValue;
        }
    }
}
