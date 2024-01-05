﻿namespace SportStyleOasis.Common
{
    public static class EntityValidationConstants
    {
        public static class ApplicationUser
        {
            public const int FirstNameMinLength = 3;
            public const int FirstNameMaxLength = 50;

            public const int LastNameMinLength = 5;
            public const int LastNameMaxLength = 50;

            public const int PasswordMinLength = 6;
            public const int PasswordMaxLenght = 100;

            public const int PhoneNumberMinLenght = 10;
            public const int PhoneNumberMaxLenght = 10;
        }

        public static class Clothes
        {
            public const int ClothesNameMinLength = 3;
            public const int ClothesNameMaxLength = 50;

            public const int DescriptionMinLength = 15;
            public const int DescriptionMaxLength = 100;

            public const int MinColorLength = 3;
            public const int MaxColorLength = 50;

            public const string MinClothePrice = "1"; 
            public const string MaxClothePrice = "999";
        }

        public static class ProteinPowder
        {
            public const int ProteinPowderNameMinLength = 3;
            public const int ProteinPowderNameMaxLength = 50;

            public const int ProteinPowderTasteMinLength = 5;
            public const int ProteinPowderTasteMaxLength = 20;

            public const string MinProteinPowderPrice = "1";
            public const string MaxProteinPowderPrice = "300";

            public const string MinProteinPowderWeight = "1";
            public const string MaxProteinPowderWeight = "3000";
        }
    }
}