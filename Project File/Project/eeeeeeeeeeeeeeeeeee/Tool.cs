using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment
{
    public class Tool : iTool, IComparable
    {
        private string name;
        private int quantity;
        private int availableQuantity;
        private int noBorrowings;
        private MemberCollection memberBorrowings = new MemberCollection();

        public string Name { get { return name; } set { name = value; } }
        public int Quantity { get { return quantity; } set { quantity = value; } }
        public int AvailableQuantity { get { return availableQuantity; } set { availableQuantity = value; } }
        public int NoBorrowings { get { return noBorrowings; } set { noBorrowings = value; } }
        public MemberCollection GetBorrowers { get { return memberBorrowings; } }
        public Tool(String name, int quantity, int availableQuantity, int noBorrowings)
        {
            this.name = name;
            this.quantity = quantity;
            this.availableQuantity = availableQuantity;
            this.noBorrowings = noBorrowings;
        }

        public void addBorrower(Member aMember)
        {
            if (availableQuantity > 0)
            {
                memberBorrowings.add(aMember);
                availableQuantity--;
                noBorrowings++;
            }
            else
            {
                Console.WriteLine("cannot add borrow as there are not enough available");
            }
        }

        public void deleteBorrower(Member aMember)
        {
            memberBorrowings.delete(aMember);
            availableQuantity++;
        }

        override public string ToString()
        {
            return (name + " " + quantity + " " + availableQuantity);
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Tool otherTool = obj as Tool;

            if (otherTool != null)
            {
                if (this.noBorrowings.CompareTo(otherTool.noBorrowings) < 0)
                {
                    return 1;
                }
                else if (this.noBorrowings.CompareTo(otherTool.NoBorrowings) == 0)
                {
                    return 0;
                }
                else return -1;
            }

            else throw new ArgumentException("something went wrong");
        }
    }
}