using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clients
{
    public class Client
    {
        private string _firstName;
        private string _lastName;
        private double _weight;
        private double _height;

        public Client()
        {
            FirstName = "aaa";
            LastName = "aaa";
            Weight = 0;
            Height = 0;
        }
        public Client(string firstName, string lastName, double weight, double height)
        {
            FirstName = firstName;
            LastName = lastName;
            Weight = weight;
            Height = height;
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("First name is required. Must not be empty or blank");
                _firstName = value;
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("First name is required. Must not be empty or blank");
                _lastName = value;
            }
        }
        public double Weight
        {
            get { return _weight; }
            set
            {
                if (value < 0.0)
                    throw new ArgumentException("Weight must be a positive value (0 or greater)");
                _weight = value;
            }
        }
        public double Height
        {
            get { return _height; }
            set
            {
                if (value < 0.0)
                    throw new ArgumentException("Weight must be a positive value (0 or greater)");
                _height = value;
            }
        }
        public double BMIScore
        {
            get
            {
                double score = ((Weight / (Height * Height)) * 703);
                return score;
            }
        }
        public string BMIStatus
        {
            get
            {
                if (BMIScore <= 18.4)
                    return "Underweight";
                else if (BMIScore >= 18.5 && BMIScore <= 24.9)
                    return "Normal";
                else if (BMIScore >= 25.0 && BMIScore <= 39.9)
                    return "Overweight";
                else
                    return "Obese";
            }
        }

        public string FullName
        {
            get
            {
                return $"{LastName}, {FirstName}";
            }
        }

    }

}

