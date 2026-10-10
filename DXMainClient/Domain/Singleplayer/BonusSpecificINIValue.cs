using System;

namespace DTAClient.Domain.Singleplayer
{
    public class BonusSpecificINIValue
    {
        public BonusSpecificINIValue()
        {
        }

        public BonusSpecificINIValue(string iniSection, string iniKey, string iniValue)
        {            
            INISection = iniSection;
            INIKey = iniKey;
            INIValue = iniValue;
        }
        
        public string INISection { get; private set; }
        public string INIKey { get; private set; }
        public string INIValue { get; private set; }

        public static BonusSpecificINIValue FromString(string str)
        {
            var parts = str.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length < 3)
                throw new Exception("Invalid BonusSpecificINIValue syntax: " + str);

            string value = parts[2];
            if (parts.Length > 3)
            {
                for (int i = 3; i < parts.Length; i++)
                {
                    value += "," + parts[i];
                }
            }

            return new BonusSpecificINIValue(parts[0], parts[1], value);
        }
    }
}
