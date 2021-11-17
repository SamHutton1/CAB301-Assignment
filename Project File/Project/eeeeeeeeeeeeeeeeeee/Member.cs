using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment
{
    public class Member : iMember, IComparable
    {
        private string firstName;
        private string lastName;
        private string contactNumber;
        private string pin;
        private string[] borrowedTools = new string[3];
        public string FirstName { get { return firstName; } set { firstName = value; } }
        public string LastName { get { return lastName; } set { lastName = value; }}
        public string ContactNumber { get { return contactNumber; } set { contactNumber = value; } }
        public string PIN { get { return pin; } set { pin = value; } }

        public string[] Tools { get { return borrowedTools; } }
        public Member(String firstName, String lastName, String contactNumber, String pin)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.contactNumber = contactNumber;
            this.pin= pin;
        }
        //new constructor without the contact number so you can compare object created when they enter a username password and pin
        public Member(String firstName, String lastName, String pin)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.pin = pin;
        }

        public void addTool(Tool aTool)
        {
            //cannot borrow if you already ahve 3 tools
            if (borrowedTools[2] != null)
            {
                Console.WriteLine("you cannot borrow more than 3 tools");
            }
            else
            {
                for (int i = 0; i < borrowedTools.Length; i++)
                {
                    if (borrowedTools[i] == null)
                    {
                        borrowedTools[i] = aTool.Name;
                        break;
                    }
                }
            }
        }

        public void deleteTool(Tool aTool)
        {
            for (int i = 0; i < borrowedTools.Length; i++)
            {
                if (borrowedTools[i]!=null)
                {
                    if (borrowedTools[i].Equals(aTool.Name))
                    {
                        borrowedTools[i] = null;
                        break;
                    }
                }
                
            }
        }

        override public string ToString()
        {
            return (firstName + ", " + lastName + ", " + contactNumber + ", " + pin);
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            //needs to search for pin number 
            Member otherMember = obj as Member;

            if (otherMember != null)
            {
                if (this.firstName.CompareTo(otherMember.firstName) < 0)
                {
                    return -1;
                }
                else if (this.lastName.CompareTo(otherMember.lastName) == 0)
                {
                    return this.pin.CompareTo(otherMember.pin);
                }
                else
                {
                    return 1;
                }
            }
            else
                throw new ArgumentException("Object is not a Member");
        }
    }
}
