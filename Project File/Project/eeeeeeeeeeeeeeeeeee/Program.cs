using System;
using System.Collections.Generic;


namespace Assignment
{
    class Program
    {
        public static void Main()
        {
            ToolLibrarySystem library = new ToolLibrarySystem();
            MemberCollection users = new MemberCollection();
            //a dummy member used to store the currently logged in member
            Member currentMember = new Member("DUMMY", "OBJECT", "0", "0");
            MainMenu(library, users, currentMember);
        }
 
        public static void MainMenu(ToolLibrarySystem library, MemberCollection users,Member currentMember)
        {
            Console.WriteLine("Welcome to the Tool Library");
            Console.WriteLine("==========Main Menu==========");
            Console.WriteLine("1. Staff Login");
            Console.WriteLine("2. Member Login");
            Console.WriteLine("0. Exit");
            Console.WriteLine("=============================");
            Console.Write("\nPlease make a selection (1-2, or 0 to exit): ");
            string value = Console.ReadLine();
            if (value.Equals("1"))
            {
                VerifyStaff(library, users, currentMember);
            }
            else if (value.Equals("0"))
            {
                Environment.Exit(0);
            }
            else if (value.Equals("2"))
            {
                MemberLogin(library, users, currentMember);
            }
            else
            {
                Console.WriteLine("Invalid selection, choose again");
                MainMenu(library, users, currentMember);
            }
        }

        public static void VerifyStaff(ToolLibrarySystem library, MemberCollection users, Member currentMember)
        {
            Console.Write("Enter staff username: ");
            
            if (Console.ReadLine().Equals("staff"))
            {
                Console.Write("Enter staff password: ");

                if (Console.ReadLine().Equals("today123"))
                {
                    Console.WriteLine("");
                    StaffMenu(library, users, currentMember);
                }
                else
                {
                    Console.WriteLine("Incorrect password, please login again");
                    VerifyStaff(library, users, currentMember);
                }
            }
            else
            {
                Console.WriteLine("Username inccorect please try again");

                VerifyStaff(library, users, currentMember);
            }
        }

        public static void MemberLogin(ToolLibrarySystem library, MemberCollection members, Member currentMember)
        {
            Console.Write("Enter member first name or 0 to exit: ");

            // if username is contained in the bianry search tree
            //create a dummy member object and search for that 

            string username = Console.ReadLine();
            if (username.Equals("0"))
            {
                MainMenu(library, members, currentMember);
            }
            Console.Write("Enter member last name: ");
            string password = Console.ReadLine();
            Console.Write("Enter member PIN: ");
            string pin = Console.ReadLine();

            Member daMember = new Member(username, password, pin);

            if (members.search(daMember))
            {
                Member[] dummyArray = members.toArray();
                for (int i = 0; i < members.Number; i++)
                {
                   // Console.WriteLine(daMember.FirstName);
                   // Console.WriteLine(dummyArray[i].FirstName);

                    if (daMember.FirstName.Equals(dummyArray[i].FirstName) && daMember.LastName.Equals(dummyArray[i].LastName) && 
                        daMember.PIN.Equals(dummyArray[i].PIN))
                    {
                        currentMember = dummyArray[i];
                    }
                    
                }
                Console.Clear();
                MemberMenu(library, members, currentMember);
            }
            else
            {
                Console.WriteLine("could not find user please try again");
                MemberLogin(library, members, currentMember);
            }

        }

        public static void StaffMenu(ToolLibrarySystem library, MemberCollection users, Member currentMember)
        {
            Console.WriteLine("Welcome to the Tool Library");
            Console.WriteLine("==========Staff Menu==========");
            Console.WriteLine("1. Add a new tool");
            Console.WriteLine("2. Add new pieces of an existing tool");
            Console.WriteLine("3. Remove some pieces of a tool");
            Console.WriteLine("4. Register a new member");
            Console.WriteLine("5. Remove a member");
            Console.WriteLine("6. Find the contact number of a member");
            Console.WriteLine("0. Return to main menu");
            Console.WriteLine("==============================");
            Console.Write("\nPlease make a selection (1-6, or 0 to return to main menu): ");
            string input = Console.ReadLine();
            if (input.Equals("0"))
            {
                MainMenu(library, users, currentMember);
            }
            if (input.Equals("1"))
            {
                Console.Clear();
                Console.Write("What is the name of the tool: ");
                string toolName = Console.ReadLine();
                Tool tool = new Tool(toolName, 1, 1, 0);
                library.add(tool);

                StaffMenu(library, users, currentMember);
            }
            if (input.Equals("2"))
            {
                Tool dummyTool = new Tool("dummy", 0, 0, 0);
                library.add(dummyTool, 0);

                StaffMenu(library, users, currentMember);
            }
            if (input.Equals("3"))
            {
                Tool dummyTool = new Tool("dummy", 0, 0, 0);
                library.delete(dummyTool, 0);

                StaffMenu(library, users, currentMember);
            }
            if (input.Equals("4"))
            {
                Console.Write("What is the member's first name: ");
                string firstName = Console.ReadLine();
                Console.Write("What is the member's second name: ");
                string lastName = Console.ReadLine();
                Console.Write("What is the member's phone number: ");
                string number = Console.ReadLine();
                Console.Write("What is the member's pin: ");
                string pin = Console.ReadLine();
                Member newMember = new Member(firstName, lastName, number, pin);
                users.add(newMember);
                library.add(newMember);

                StaffMenu(library, users, currentMember);
            }
            if (input.Equals("5"))
            {
                Member[] hello = users.toArray();
                
                for (int i = 0; i < users.Number; i++)
                {
                    Console.WriteLine(i + ". "+hello[i].ToString());
                }
                Console.Write("Which member do you wish to remove: ");
                string thing = Console.ReadLine();
                int num = int.Parse(thing);
                var tools = hello[num].Tools;
                bool canDelete = true;
                for (int i = 0; i < tools.Length; i++)
                {
                    if (tools[i] != null)
                    {
                        Console.WriteLine("Cannot delete member, they are currently borrowing: " + tools[i].ToString());
                        canDelete = false;
                        break;
                    }
                }
                if (canDelete)
                {
                    library.delete(hello[num]);
                    users.delete(hello[num]);
                }
                Console.Write("Press enter to continue....");
                Console.ReadLine();
                StaffMenu(library, users, currentMember);
            }

            if (input.Equals("6"))
            {
                Console.WriteLine("=========Contact Number Lookup========");
                Console.Write("Members first name: ");
                string first = Console.ReadLine();
                Console.Write("Members second name: ");
                string second = Console.ReadLine();
                Member[] hello = users.toArray();
                for (int i = 0; i < users.Number; i++)
                {
                    if (hello[i].FirstName.Equals(first) && hello[i].LastName.Equals(second))
                    {
                        Console.WriteLine("Members phone number is: " + hello[i].ContactNumber);
                    }
                }
                Console.Write("Press enter to continue...");
                Console.ReadLine();
                StaffMenu(library, users, currentMember);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("invalid choice, please choose again");
                Console.WriteLine("");
                StaffMenu(library, users, currentMember);
            }
        }

        public static void MemberMenu(ToolLibrarySystem library, MemberCollection users, Member currentMember)
        {
            Console.WriteLine("Welcome to the Tool Library");
            Console.WriteLine("currently logged in as: "+currentMember.FirstName +" " +currentMember.LastName);
            Console.WriteLine("==========Member Menu==========");
            Console.WriteLine("1. Display all the tools of a tool type");
            Console.WriteLine("2. Borrow a tool");
            Console.WriteLine("3. Return a tool");
            Console.WriteLine("4. List all the tools that I am renting");
            Console.WriteLine("5. Display top three (3) most frequently rented tools");
            Console.WriteLine("0. Return to main menu");
            Console.WriteLine("===============================");
            Console.Write("\nPlease make a selection (1-5, or 0 to return to main menu): ");
            string choice = Console.ReadLine();
            if (choice.Equals("0"))
            {
                MainMenu(library, users, currentMember);
            }
            if (choice.Equals("1"))
            {
                library.displayTools("doesntMatter");
                Console.WriteLine("press enter to continue....");
                Console.ReadLine();
                MemberMenu(library, users, currentMember);
            }
            if (choice.Equals("2"))
            {
                Tool dummyTool = new Tool("dummy", 0, 0, 0);
                library.borrowTool(currentMember, dummyTool);
                Console.WriteLine("press enter to continue....");
                Console.ReadLine();
            }
            if (choice.Equals("3"))
            {
                Tool dummyTool = new Tool("dummy", 0, 0, 0);
                library.returnTool(currentMember, dummyTool);
            }
            if (choice.Equals("4"))
            {
                Console.Clear();
                library.displayBorrowingTools(currentMember);
                Console.Write("Press enter to continue.....");
                Console.ReadLine();
                MemberMenu(library, users, currentMember);
            }
            if (choice.Equals("5"))
            {
                library.displayTopTHree();
                Console.WriteLine("Press enter to continue....");
                Console.ReadLine();
                Console.Clear();
                MemberMenu(library, users, currentMember);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("invalid choice, please choose again");
                Console.WriteLine("");
                MemberMenu(library, users, currentMember);
            }
        }
    }
}
