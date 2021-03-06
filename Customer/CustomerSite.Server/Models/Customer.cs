﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace CustomerSite.Server.Models
{
    public class Customer
    {
        #region PRIVATE VARS
        // Recommend to change this to your desired phone regex pattern.
        private const string PHONE_REGEX = @"\d";

        private string _firstName;
        private string _surname;
        private string _telephone;
        private DateTime _dateOfBirth;
        #endregion

        #region PROPERTIES

        public int ID
        {
            get;
            set;
        }
        public string FirstName 
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("FirstName");
                
                _firstName = value;
            }
        }
        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Surname");

                _surname = value;
            }
        }
        public string Telephone
        {
            get
            {
                return _telephone;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Telephone");
                if (!Regex.IsMatch(value, PHONE_REGEX))
                    throw new ArgumentException("Phone number is not valid. Please check input or regex.");

                _telephone = value;
            }
        }
        public DateTime DateOfBirth
        {
            get
            {
                return _dateOfBirth;
            }
            set
            {
                if (value > DateTime.UtcNow)
                    throw new ArgumentException("Birthday must be in the past (UTC).");
                
                _dateOfBirth = value;
            }
        }
        /// <summary>
        /// Generates a unique 3 byte colour code for each display name.
        /// </summary>
        public string Colour
        {
            get
            {
                // TODO This might be better off being client side.
                var displayName = string.Format("{0} {1}", FirstName, Surname);
                var colourNumber = ((uint)(displayName.GetHashCode())) % 16777216; // Range of #000000 > #FFFFFF (16^6)
                var colourBytes = BitConverter.GetBytes(colourNumber).Take(3).ToArray(); // Remove empty byte
                return "#" + BitConverter.ToString(colourBytes.ToArray()).Replace("-", string.Empty);
            }
        }

        #endregion

        public Customer (string firstName, string surname, string telephone, DateTime dateOfBirth)
        {
            FirstName = firstName;
            Surname = surname;
            Telephone = telephone;
            DateOfBirth = dateOfBirth;
        }

        // Required for EF
        private Customer()
        {
        }
    }
}