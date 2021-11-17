using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Assignment
{
    //this class needs to bring all the other classes together in one place
    public class ToolLibrarySystem : iToolLibrarySystem
    {
        //dictionary that contains all categories and types
        private Dictionary<string, string> toolCatAndType = new Dictionary<string, string>();

        //tool collection array for every category
        private ToolCollection gardeningTools = new ToolCollection();
        private ToolCollection flooringTools = new ToolCollection();
        private ToolCollection fencingTools = new ToolCollection();
        private ToolCollection measuringTools = new ToolCollection();
        private ToolCollection cleaningTools = new ToolCollection();
        private ToolCollection paintingTools = new ToolCollection();
        private ToolCollection electronicTools = new ToolCollection();
        private ToolCollection electricityTools = new ToolCollection();
        private ToolCollection automotiveTools = new ToolCollection();
        private MemberCollection members = new MemberCollection();

        //constructor
        public ToolLibrarySystem()
        {
            toolCatAndType = toolsTypesDict();
        }


        public void displayTopTHree()
        {
            List<Tool> allTools = new List<Tool>();

            allTools = Collate(gardeningTools, allTools);
            allTools = Collate(flooringTools, allTools);
            allTools = Collate(fencingTools, allTools);
            allTools = Collate(measuringTools, allTools);
            allTools = Collate(cleaningTools, allTools);
            allTools = Collate(paintingTools, allTools);
            allTools = Collate(electronicTools, allTools);
            allTools = Collate(electricityTools, allTools);
            allTools = Collate(automotiveTools, allTools);
            
            //implementation of the bubble sort
            bool not_sorted = true;
            while (not_sorted)
            {
                not_sorted = false;
                for (int i = 1; i < allTools.Count; i++)
                {
                    if (allTools[i].NoBorrowings > allTools[i - 1].NoBorrowings)
                    {
                        Tool temp = allTools[i];
                        allTools[i] = allTools[i - 1];
                        allTools[i - 1] = temp;

                        not_sorted = true;
                    }
                }
            }

            if (allTools.Count <= 3)
            {
                for (int i = 0; i < allTools.Count; i++)
                {
                    Console.WriteLine(i + 1 + ". " + allTools[i].Name + " - " + allTools[i].NoBorrowings);
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine(i + 1 + ". " + allTools[i].Name + " - " + allTools[i].NoBorrowings);
                }
            }
        }

        private List<Tool> Collate (ToolCollection toolCollection, List<Tool> tools)
        {
            List<Tool> newTools = tools;
            var happy = toolCollection.toArray();
            //make a method that does this adding and takes a toolcollection object as parameter. simpels
            for (int i = 0; i < happy.Length; i++)
            {
                if (happy[i] != null)
                {
                    newTools.Add(happy[i]);
                }
            }
            return newTools;
        }

   
        //add a member to our member collection
        public void add(Member aMember)
        {
            if (members.search(aMember))
            {
                Console.WriteLine("user already exists");
            }
            else members.add(aMember);

        }
        public void borrowTool(Member aMember, Tool aTool)
        {
            Tool toolToBorrow = getToolToBorrow();

            if (toolToBorrow.AvailableQuantity < 1)
            {
                Console.WriteLine("cannot borrow as there are not enough");
            }
            else
            {
                aMember.addTool(toolToBorrow);
                toolToBorrow.addBorrower(aMember);
            }
        }

        public void returnTool(Member aMember, Tool aTool)
        {
            List<int> options = new List<int>();
            for (int i = 0; i < aMember.Tools.Length; i++)
            {
                if (aMember.Tools[i] != null)
                {
                    options.Add(i);
                    Console.WriteLine(i + ". " +aMember.Tools[i]);
                }
            }
            Console.Write("Which do you wish to return or q to exit: ");

            string choice = Console.ReadLine();
            if (choice.Equals("q"))
            {
                return;
            }
            int eek = int.Parse(choice);
            while (!options.Contains(eek))
            {
                Console.WriteLine("Invalid please try again");
                Console.Write("Which do you wish to return or q to exit: ");
                choice = Console.ReadLine();
                if (choice.Equals("q"))
                {
                    return;
                }
                eek = int.Parse(choice);
                
            }

            if (options.Contains(eek))
            {//implement returning method and logic here
                Tool thing = toolToReturn(aMember.Tools[eek]);
                aMember.deleteTool(thing);
                thing.deleteBorrower(aMember);
                Console.WriteLine("you are no longer borrowing: " + thing.Name);
            }
           
            
            
            Console.ReadLine();
        }
        //method used by the return tool. Returns the tool the user wants to return 
        private Tool toolToReturn (string lookingFor)
        {

            var happy = gardeningTools.toArray();
            for (int i = 0; i < happy.Length; i++)
            {
                if (happy[i]!=null)
                {
                    if (happy[i].Name.Equals(lookingFor))
                    {
                        return happy[i];
                    }
                }
            }
            happy = flooringTools.toArray();
            for (int i = 0; i < happy.Length; i++)
            {
                if (happy[i] != null)
                {
                    if (happy[i].Name.Equals(lookingFor))
                    {
                        return happy[i];
                    }
                }
            }
            happy = fencingTools.toArray();
            for (int i = 0; i < happy.Length; i++)
            {
                if (happy[i] != null)
                {
                    if (happy[i].Name.Equals(lookingFor))
                    {
                        return happy[i];
                    }
                }
            }
            happy = measuringTools.toArray();
            for (int i = 0; i < happy.Length; i++)
            {
                if (happy[i] != null)
                {
                    if (happy[i].Name.Equals(lookingFor))
                    {
                        return happy[i];
                    }
                }
            }
            happy = cleaningTools.toArray();
            for (int i = 0; i < happy.Length; i++)
            {
                if (happy[i] != null)
                {
                    if (happy[i].Name.Equals(lookingFor))
                    {
                        return happy[i];
                    }
                }
            }

            happy = paintingTools.toArray();
            for (int i = 0; i < happy.Length; i++)
            {
                if (happy[i] != null)
                {
                    if (happy[i].Name.Equals(lookingFor))
                    {
                        return happy[i];
                    }
                }
            }
            happy = electronicTools.toArray();
            for (int i = 0; i < happy.Length; i++)
            {
                if (happy[i] != null)
                {
                    if (happy[i].Name.Equals(lookingFor))
                    {
                        return happy[i];
                    }
                }
            }
            happy = electricityTools.toArray();
            for (int i = 0; i < happy.Length; i++)
            {
                if (happy[i] != null)
                {
                    if (happy[i].Name.Equals(lookingFor))
                    {
                        return happy[i];
                    }
                }
            }
            happy = automotiveTools.toArray();
            for (int i = 0; i < happy.Length; i++)
            {
                if (happy[i] != null)
                {
                    if (happy[i].Name.Equals(lookingFor))
                    {
                        return happy[i];
                    }
                }
            }

            return happy[0];
        }

        //not implemented, havent needed to delete a tool
        public void delete(Tool aTool)
        {
            throw new NotImplementedException();
        }

       
        //remove a member from our collection
        public void delete(Member aMember)
        {
            members.delete(aMember);
        }

        public void displayBorrowingTools(Member aMember)
        {
            for (int i = 0; i < aMember.Tools.Length; i++)
            {
                if (aMember.Tools[i] != null)
                {
                    Console.WriteLine(aMember.Tools[i]);
                }
            }
        }

        public void displayTools(string aToolType)
        {
            Console.Clear();
            string type = "";
            printCats();
            Console.Write("Which category does this belong in (1-9): ");
            string choice = Console.ReadLine();
            if (choice.Equals("1"))
            { //if choice is gardening tools
                PrintCat(toolCatAndType, "Gardening Tool");
                string choice1 = Console.ReadLine();
                if (choice1.Equals("1")) type = "LineTrimmers";
                else if (choice1.Equals("2")) type = "LawnMowers";
                else if (choice1.Equals("3")) type = "GardenHandTools";
                else if (choice1.Equals("4")) type = "WheelBarrows";
                else if (choice1.Equals("5")) type = "GardenPowerTools";
                PrintThing(type, gardeningTools);
            }
            else if (choice.Equals("2"))
            { //if choice is flooring tools
                PrintCat(toolCatAndType, "Flooring Tool");
                string choice1 = Console.ReadLine();
                if (choice1.Equals("1")) type = "Scrapers";
                else if (choice1.Equals("2")) type = "FloorLasers";
                else if (choice1.Equals("3")) type = "FloorLevellingTools";
                else if (choice1.Equals("4")) type = "FloorLevellingMaterials";
                else if (choice1.Equals("5")) type = "FloorHandTools";
                else if (choice1.Equals("6")) type = "TilingTools";
                PrintThing(type, flooringTools);
            }
            if (choice.Equals("3"))
            { //if choice is Fencing tools
                PrintCat(toolCatAndType, "Fencing Tool");
                string choice1 = Console.ReadLine();
                if (choice1.Equals("1")) type = "FenceHandTools";
                else if (choice1.Equals("2")) type = "ElectricFencing";
                else if (choice1.Equals("3")) type = "SteelFencingTools";
                else if (choice1.Equals("4")) type = "PowerTools";
                else if (choice1.Equals("5")) type = "FencingAccessories";
                PrintThing(type, fencingTools);
            }
            if (choice.Equals("4"))
            { //if choice is measuring tools
                PrintCat(toolCatAndType, "Measuring Tool");
                string choice1 = Console.ReadLine();
                if (choice1.Equals("1")) type = "DistanceTools";
                else if (choice1.Equals("2")) type = "LaserMeasurer";
                else if (choice1.Equals("3")) type = "MeasuringJugs";
                else if (choice1.Equals("4")) type = "TempHumidityTools";
                else if (choice1.Equals("5")) type = "LevellingTools";
                else if (choice1.Equals("6")) type = "Markers";
                PrintThing(type, measuringTools);

            }
            if (choice.Equals("5"))
            { //if choice is cleaning tools
                PrintCat(toolCatAndType, "Cleaning Tool");
                string choice1 = Console.ReadLine();
                if (choice1.Equals("1")) type = "Draining";
                else if (choice1.Equals("2")) type = "CarCleaning";
                else if (choice1.Equals("3")) type = "Vacuum";
                else if (choice1.Equals("4")) type = "PressureCleaners";
                else if (choice1.Equals("5")) type = "PoolCleaning";
                else if (choice1.Equals("6")) type = "FloorCleaning";
                PrintThing(type, cleaningTools);
            }
            if (choice.Equals("6"))
            { //if choice is painting tools
                PrintCat(toolCatAndType, "Painting Tool");
                string choice1 = Console.ReadLine();
                if (choice1.Equals("1")) type = "SandingTools";
                else if (choice1.Equals("2")) type = "Brushes";
                else if (choice1.Equals("3")) type = "Rollers";
                else if (choice1.Equals("4")) type = "PaintRemovalTools";
                else if (choice1.Equals("5")) type = "PaintScrapers";
                else if (choice1.Equals("6")) type = "Sprayers";
                PrintThing(type, paintingTools);
            }
            if (choice.Equals("7"))
            { //if choice is electronic tools
                PrintCat(toolCatAndType, "Electronic Tool");
                string choice1 = Console.ReadLine();
                if (choice1.Equals("1")) type = "VoltageTester";
                else if (choice1.Equals("2")) type = "Oscilloscopes";
                else if (choice1.Equals("3")) type = "ThermalImaging";
                else if (choice1.Equals("4")) type = "DataTestTool";
                else if (choice1.Equals("5")) type = "InsulationTesters";
                PrintThing(type, electricityTools);
            }
            if (choice.Equals("8"))
            { //if choice is electricity tools
                PrintCat(toolCatAndType, "Electricity Tool");
                string choice1 = Console.ReadLine();
                if (choice1.Equals("1")) type = "TestEquipment";
                else if (choice1.Equals("2")) type = "SafetyEquipment";
                else if (choice1.Equals("3")) type = "BasicHandTools";
                else if (choice1.Equals("4")) type = "CircuitProtection";
                else if (choice1.Equals("5")) type = "CableTools";
                PrintThing(type, electricityTools);
            }
            if (choice.Equals("9"))
            { //if choice is Automotive tools
                PrintCat(toolCatAndType, "Automotive Tool");
                string choice1 = Console.ReadLine();
                if (choice1.Equals("1")) type = "Jacks";
                else if (choice1.Equals("2")) type = "AirCompressors";
                else if (choice1.Equals("3")) type = "BatteryChargers";
                else if (choice1.Equals("4")) type = "SocketTools";
                else if (choice1.Equals("5")) type = "Braking";
                else if (choice1.Equals("6")) type = "Drivetrain";
                PrintThing(type, electricityTools);
            }
            
        }

        private void PrintThing(string type, ToolCollection toolArray)
        {
            Tool[] array = toolArray.toArray();
            Console.Clear();
            Console.WriteLine("Name                               Total Quantity                          Available");
            for (int m = 0; m < toolArray.Number; m++)
            {
                if (array[m].Name.Contains(type))
                {
                    Console.WriteLine(m + ". " + array[m].Name + "\t\t\t" + array[m].Quantity + "\t\t\t\t\t" + array[m].AvailableQuantity);
                }
            }
        }
        public string[] listTools(Member aMember)
        {
            string[] name = aMember.Tools;
            return name;
        }

        //print all the tool categories 
        private void printCats()
        {
            int i = 1;
            //print the tool types and ask which tool type they wish to add to
            foreach (KeyValuePair<string, string> item in toolCatAndType)
            {
                if (!item.Key.Any(char.IsDigit))
                {
                    Console.WriteLine(i + ". " + item.Key);
                    i++;
                }
            }
        }

        //method utilised by the borrow method. Returns the tool the user wants to borrow
        private Tool getToolToBorrow()
        {//only works for gardening tools
            Console.Clear();
            string type = "";
            printCats();
            Console.Write("Which category does this belong in (1-9): ");
            string choice = Console.ReadLine();
            if (choice.Equals("1"))
            { //if choice is gardening tools
                PrintCat(toolCatAndType, "Gardening Tool");
                Tool[] thing = gardeningTools.toArray();
                string choice1 = Console.ReadLine();
                if (choice1.Equals("1")) type = "LineTrimmers";
                else if (choice1.Equals("2")) type = "LawnMowers";
                else if (choice1.Equals("3")) type = "GardenHandTools";
                else if (choice1.Equals("4")) type = "WheelBarrows";
                else if (choice1.Equals("5")) type = "GardenPowerTools";
                Console.Clear();
                PrintArray(gardeningTools, type);
                string choice2 = Console.ReadLine();
                int index = int.Parse(choice2);
                Console.WriteLine("You are borrowing: " + thing[index].Name);
                Console.WriteLine();
                return thing[index];
            }
            if (choice.Equals("2"))
            { //if choice is flooring tools
                PrintCat(toolCatAndType, "Flooring Tool");
                Tool[] thing = flooringTools.toArray();
                string choice1 = Console.ReadLine();
                if (choice1.Equals("1")) type = "Scrapers";
                else if (choice1.Equals("2")) type = "FloorLasers";
                else if (choice1.Equals("3")) type = "FloorLevellingTools";
                else if (choice1.Equals("4")) type = "FloorLevellingMaterials";
                else if (choice1.Equals("5")) type = "FloorHandTools";
                else if (choice1.Equals("6")) type = "TilingTools";
                Console.Clear();
                PrintArray(flooringTools, type);
                string choice2 = Console.ReadLine();
                int index = int.Parse(choice2);
                Console.WriteLine("You are borrowing: " + thing[index].Name);
                Console.WriteLine();
                return thing[index];
            }
            if (choice.Equals("3"))
            { //if choice is fencing tools
                PrintCat(toolCatAndType, "Fencing Tool");
                Tool[] thing = fencingTools.toArray();
                string choice1 = Console.ReadLine();
                if (choice1.Equals("1")) type = "FenceHandTools";
                else if (choice1.Equals("2")) type = "ElectricFencing";
                else if (choice1.Equals("3")) type = "SteelFencingTools";
                else if (choice1.Equals("4")) type = "PowerTools";
                else if (choice1.Equals("5")) type = "FencingAccessories";
                Console.Clear();
                PrintArray(fencingTools, type);
                string choice2 = Console.ReadLine();
                int index = int.Parse(choice2);
                Console.WriteLine("You are borrowing: " + thing[index].Name);
                Console.WriteLine();
                return thing[index];
            }
            if (choice.Equals("4"))
            { //if choice is gardening tools
                PrintCat(toolCatAndType, "Measuring Tool");
                Tool[] thing = measuringTools.toArray();
                string choice1 = Console.ReadLine();
                if (choice1.Equals("1")) type = "DistanceTools";
                else if (choice1.Equals("2")) type = "LaserMeasurer";
                else if (choice1.Equals("3")) type = "MeasuringJugs";
                else if (choice1.Equals("4")) type = "TempHumidityTools";
                else if (choice1.Equals("5")) type = "LevellingTools";
                else if (choice1.Equals("6")) type = "Markers";
                Console.Clear();
                PrintArray(measuringTools, type);
                string choice2 = Console.ReadLine();
                int index = int.Parse(choice2);
                Console.WriteLine("You are borrowing: " + thing[index].Name);
                Console.WriteLine();
                return thing[index];
            }
            if (choice.Equals("5"))
            { //if choice is cleaniong tools
                PrintCat(toolCatAndType, "Cleaning Tool");
                Tool[] thing = cleaningTools.toArray();
                string choice1 = Console.ReadLine();
                if (choice1.Equals("1")) type = "Draining";
                else if (choice1.Equals("2")) type = "CarCleaning";
                else if (choice1.Equals("3")) type = "Vacuum";
                else if (choice1.Equals("4")) type = "PressureCleaners";
                else if (choice1.Equals("5")) type = "PoolCleaning";
                else if (choice1.Equals("6")) type = "FloorCleaning";
                Console.Clear();
                PrintArray(cleaningTools, type);
                string choice2 = Console.ReadLine();
                int index = int.Parse(choice2);
                Console.WriteLine("You are borrowing: " + thing[index].Name);
                Console.WriteLine();
                return thing[index];
            }
            if (choice.Equals("6"))
            { //if choice is gardening tools
                PrintCat(toolCatAndType, "Painting Tool");
                Tool[] thing = paintingTools.toArray();
                string choice1 = Console.ReadLine();
                if (choice1.Equals("1")) type = "SandingTools";
                else if (choice1.Equals("2")) type = "Brushes";
                else if (choice1.Equals("3")) type = "Rollers";
                else if (choice1.Equals("4")) type = "PaintRemovalTools";
                else if (choice1.Equals("5")) type = "PaintScrapers";
                else if (choice1.Equals("6")) type = "Sprayers";
                Console.Clear();
                PrintArray(paintingTools, type);
                string choice2 = Console.ReadLine();
                int index = int.Parse(choice2);
                Console.WriteLine("You are borrowing: " + thing[index].Name);
                Console.WriteLine();
                return thing[index];
            }
            if (choice.Equals("7"))
            { //if choice is gardening tools
                PrintCat(toolCatAndType, "Electronic Tool");
                Tool[] thing = electronicTools.toArray();
                string choice1 = Console.ReadLine();
                if (choice1.Equals("1")) type = "VoltageTester";
                else if (choice1.Equals("2")) type = "Oscilloscopes";
                else if (choice1.Equals("3")) type = "ThermalImaging";
                else if (choice1.Equals("4")) type = "DataTestTool";
                else if (choice1.Equals("5")) type = "InsulationTesters";
                Console.Clear();
                PrintArray(electronicTools, type);
                string choice2 = Console.ReadLine();
                int index = int.Parse(choice2);
                Console.WriteLine("You are borrowing: " + thing[index].Name);
                Console.WriteLine();
                return thing[index];
            }
            if (choice.Equals("8"))
            { //if choice is electricity tools
                PrintCat(toolCatAndType, "Electricity Tool");
                Tool[] thing = electricityTools.toArray();
                string choice1 = Console.ReadLine();
                if (choice1.Equals("1")) type = "TestEquipment";
                else if (choice1.Equals("2")) type = "SafetyEquipment";
                else if (choice1.Equals("3")) type = "BasicHandTools";
                else if (choice1.Equals("4")) type = "CircuitProtection";
                else if (choice1.Equals("5")) type = "CableTools";
                Console.Clear();
                PrintArray(electricityTools, type);
                string choice2 = Console.ReadLine();
                int index = int.Parse(choice2);
                Console.WriteLine("You are borrowing: " + thing[index].Name);
                Console.WriteLine();
                return thing[index];
            }
            if (choice.Equals("9"))
            { //if choice is gardening tools
                PrintCat(toolCatAndType, "Automotive Tool");
                Tool[] thing = automotiveTools.toArray();
                string choice1 = Console.ReadLine();
                if (choice1.Equals("1")) type = "Jacks";
                else if (choice1.Equals("2")) type = "AirCompressors";
                else if (choice1.Equals("3")) type = "BatteryChargers";
                else if (choice1.Equals("4")) type = "SocketTools";
                else if (choice1.Equals("5")) type = "Braking";
                else if (choice1.Equals("6")) type = "Drivetrain";
                Console.Clear();
                PrintArray(automotiveTools, type);
                string choice2 = Console.ReadLine();
                int index = int.Parse(choice2);
                Console.WriteLine("You are borrowing: " + thing[index].Name);
                Console.WriteLine();
                return thing[index];
            }



            Tool we = new Tool("yikes", 0, 0 ,0);
            return we;
        }

        private void  PrintArray(ToolCollection toolCollection, string type)
        {
            Tool[] array = toolCollection.toArray();
            Console.Clear();
            for (int m = 0; m < toolCollection.Number; m++)
            {
                if (array[m].Name.Contains(type))
                {
                    Console.WriteLine(m + ". " + array[m].Name);
                }
            }

            Console.Write("Please select corresponding number: ");
        }
        public void delete(Tool bTool, int quantity)
        {
            Console.Clear();
            string type = "";
            int i = 1;
            //print the tool types and ask which tool type they wish to add to
            foreach (KeyValuePair<string, string> item in toolCatAndType)
            {
                if (!item.Key.Any(char.IsDigit))
                {
                    Console.WriteLine(i + ". " + item.Key);
                    i++;
                }
            }
            Console.Write("Which category does this belong in (1-9): ");
            string choice = Console.ReadLine();
            if (choice.Equals("1"))
            { //if choice is gardening tools

                PrintCat(toolCatAndType, "Gardening Tool");

                Tool[] thing = gardeningTools.toArray();
                string choice1 = Console.ReadLine();
                if (choice1.Equals("1")) type = "LineTrimmers";
                else if (choice1.Equals("2")) type = "LawnMowers";
                else if (choice1.Equals("3")) type = "GardenHandTools";
                else if (choice1.Equals("4")) type = "WheelBarrows";
                else if (choice1.Equals("5")) type = "GardenPowerTools";
                PrintArray(gardeningTools, type);
                string choice2 = Console.ReadLine();
                int index = int.Parse(choice2);
                Console.Clear();
                Console.WriteLine("you are removing from: " + thing[index].Name);
                Console.WriteLine("it currently has: " + thing[index].Quantity);
                Console.Write("how many would you like to remove: ");
                string baba = Console.ReadLine();
                int quant = int.Parse(baba);
                Decrement(thing[index], quant);
            }
            else if (choice.Equals("2"))
            { //if choice is flooring tools
                PrintCat(toolCatAndType, "Flooring Tool");
                string choice1 = Console.ReadLine();
                if (choice1.Equals("1")) type = "Scrapers";
                else if (choice1.Equals("2")) type = "FloorLasers";
                else if (choice1.Equals("3")) type = "FloorLevellingTools";
                else if (choice1.Equals("4")) type = "FloorLevellingMaterials";
                else if (choice1.Equals("5")) type = "FloorHandTools";
                else if (choice1.Equals("6")) type = "TilingTools";

                PrintArray(flooringTools, type);
                string choice2 = Console.ReadLine();
                int index = int.Parse(choice2);
                Tool[] thing = flooringTools.toArray();
                Console.Clear();
                Console.WriteLine("you are adding to:  " + thing[index].Name);
                Console.WriteLine("it currently has: " + thing[index].Quantity);
                Console.Write("how many would you like to add: ");
                string baba = Console.ReadLine();
                int quant = int.Parse(baba);
                Decrement(thing[index], quant);
            }
            if (choice.Equals("3"))
            { //if choice is Fencing tools
                PrintCat(toolCatAndType, "Fencing Tool");
                string choice1 = Console.ReadLine();
                if (choice1.Equals("1")) type = "FenceHandTools";
                else if (choice1.Equals("2")) type = "ElectricFencing";
                else if (choice1.Equals("3")) type = "SteelFencingTools";
                else if (choice1.Equals("4")) type = "PowerTools";
                else if (choice1.Equals("5")) type = "FencingAccessories";
                PrintArray(fencingTools, type);
                string choice2 = Console.ReadLine();
                int index = int.Parse(choice2);
                Tool[] thing = fencingTools.toArray();
                Console.Clear();
                Console.WriteLine("you are adding to:  " + thing[index].Name);
                Console.WriteLine("it currently has: " + thing[index].Quantity);
                Console.Write("how many would you like to add: ");
                string baba = Console.ReadLine();
                int quant = int.Parse(baba);
                Decrement(thing[index], quant);
            }
            if (choice.Equals("4"))
            { //if choice is measuring tools
                PrintCat(toolCatAndType, "Measuring Tool");
                string choice1 = Console.ReadLine();
                if (choice1.Equals("1")) type = "DistanceTools";
                else if (choice1.Equals("2")) type = "LaserMeasurer";
                else if (choice1.Equals("3")) type = "MeasuringJugs";
                else if (choice1.Equals("4")) type = "TempHumidityTools";
                else if (choice1.Equals("5")) type = "LevellingTools";
                else if (choice1.Equals("6")) type = "Markers";
                PrintArray(measuringTools, type);
                string choice2 = Console.ReadLine();
                int index = int.Parse(choice2);
                Tool[] thing = measuringTools.toArray();
                Console.Clear();
                Console.WriteLine("you are adding to:  " + thing[index].Name);
                Console.WriteLine("it currently has: " + thing[index].Quantity);
                Console.Write("how many would you like to add: ");
                string baba = Console.ReadLine();
                int quant = int.Parse(baba);
                Decrement(thing[index], quant);
            }
            if (choice.Equals("5"))
            { //if choice is cleaning tools
                PrintCat(toolCatAndType, "Cleaning Tool");
                string choice1 = Console.ReadLine();
                if (choice1.Equals("1")) type = "Draining";
                else if (choice1.Equals("2")) type = "CarCleaning";
                else if (choice1.Equals("3")) type = "Vacuum";
                else if (choice1.Equals("4")) type = "PressureCleaners";
                else if (choice1.Equals("5")) type = "PoolCleaning";
                else if (choice1.Equals("6")) type = "FloorCleaning";
                PrintArray(cleaningTools, type);
                string choice2 = Console.ReadLine();
                int index = int.Parse(choice2);
                Tool[] thing = cleaningTools.toArray();
                Console.Clear();
                Console.WriteLine("you are adding to:  " + thing[index].Name);
                Console.WriteLine("it currently has: " + thing[index].Quantity);
                Console.Write("how many would you like to add: ");
                string baba = Console.ReadLine();
                int quant = int.Parse(baba);
                Decrement(thing[index], quant);
            }
            if (choice.Equals("6"))
            { //if choice is painting tools
                PrintCat(toolCatAndType, "Painting Tool");
                string choice1 = Console.ReadLine();
                if (choice1.Equals("1")) type = "SandingTools";
                else if (choice1.Equals("2")) type = "Brushes";
                else if (choice1.Equals("3")) type = "Rollers";
                else if (choice1.Equals("4")) type = "PaintRemovalTools";
                else if (choice1.Equals("5")) type = "PaintScrapers";
                else if (choice1.Equals("6")) type = "Sprayers";
                PrintArray(paintingTools, type);
                string choice2 = Console.ReadLine();
                int index = int.Parse(choice2);
                Tool[] thing = paintingTools.toArray();
                Console.Clear();
                Console.WriteLine("you are adding to:  " + thing[index].Name);
                Console.WriteLine("it currently has: " + thing[index].Quantity);
                Console.Write("how many would you like to add: ");
                string baba = Console.ReadLine();
                int quant = int.Parse(baba);
                Decrement(thing[index], quant);
            }
            if (choice.Equals("7"))
            { //if choice is electronic tools
                PrintCat(toolCatAndType, "Electronic Tool");
                string choice1 = Console.ReadLine();
                if (choice1.Equals("1")) type = "VoltageTester";
                else if (choice1.Equals("2")) type = "Oscilloscopes";
                else if (choice1.Equals("3")) type = "ThermalImaging";
                else if (choice1.Equals("4")) type = "DataTestTool";
                else if (choice1.Equals("5")) type = "InsulationTesters";
                PrintArray(electronicTools, type);
                string choice2 = Console.ReadLine();
                int index = int.Parse(choice2);
                Tool[] thing = electronicTools.toArray();
                Console.Clear();
                Console.WriteLine("you are adding to:  " + thing[index].Name);
                Console.WriteLine("it currently has: " + thing[index].Quantity);
                Console.Write("how many would you like to add: ");
                string baba = Console.ReadLine();
                int quant = int.Parse(baba);
                Decrement(thing[index], quant);
            }
            if (choice.Equals("8"))
            { //if choice is electricity tools
                PrintCat(toolCatAndType, "Electricity Tool");
                string choice1 = Console.ReadLine();
                if (choice1.Equals("1")) type = "TestEquipment";
                else if (choice1.Equals("2")) type = "SafetyEquipment";
                else if (choice1.Equals("3")) type = "BasicHandTools";
                else if (choice1.Equals("4")) type = "CircuitProtection";
                else if (choice1.Equals("5")) type = "CableTools";
                PrintArray(electricityTools, type);
                string choice2 = Console.ReadLine();
                int index = int.Parse(choice2);
                Tool[] thing = electricityTools.toArray();
                Console.Clear();
                Console.WriteLine("you are adding to:  " + thing[index].Name);
                Console.WriteLine("it currently has: " + thing[index].Quantity);
                Console.Write("how many would you like to add: ");
                string baba = Console.ReadLine();
                int quant = int.Parse(baba);
                Decrement(thing[index], quant);
            }
            if (choice.Equals("9"))
            { //if choice is Automotive tools
                PrintCat(toolCatAndType, "Automotive Tool");
                string choice1 = Console.ReadLine();
                if (choice1.Equals("1"))
                {//if choice is line trimmer
                    type = "Jacks";
                }
                else if (choice1.Equals("2")) type = "AirCompressors";
                else if (choice1.Equals("3")) type = "BatteryChargers";
                else if (choice1.Equals("4")) type = "SocketTools";
                else if (choice1.Equals("5")) type = "Braking";
                else if (choice1.Equals("6")) type = "Drivetrain";
                PrintArray(automotiveTools, type);
                string choice2 = Console.ReadLine();
                int index = int.Parse(choice2);
                Tool[] thing = automotiveTools.toArray();
                Console.Clear();
                Console.WriteLine("you are adding to:  " + thing[index].Name);
                Console.WriteLine("it currently has: " + thing[index].Quantity);
                Console.Write("how many would you like to add: ");
                string baba = Console.ReadLine();
                int quant = int.Parse(baba);
                Decrement(thing[index], quant);
            }


        }

        public void add(Tool bTool, int quantity)
        {
            
            Console.Clear();
            int i = 1;
            //print the tool types and ask which tool type they wish to add to
            foreach (KeyValuePair<string, string> item in toolCatAndType)
            {
                if (!item.Key.Any(char.IsDigit))
                {
                    Console.WriteLine(i + ". " + item.Key);
                    i++;
                }
            }
            Console.Write("Which category does this belong in (1-9): ");
            string choice = Console.ReadLine();
            if (choice.Equals("1"))
            { //if choice is gardening tools
                string type = "";
                int ii = 1;
                int j = 1;
                foreach (KeyValuePair<string, string> item in toolCatAndType)
                {
                    if (item.Key.Contains("Gardening Tool"))
                    {
                        Console.WriteLine(ii + ". " + item.Value);
                        ii++;
                        j++;
                    }
                }
                j--;
                Console.Write("Which type does this belong to (1-" + j + "): ");
                Tool[] thing = gardeningTools.toArray();
                string choice1 = Console.ReadLine();
                if (choice1.Equals("1"))
                {//if choice is line trimmer
                    type = "LineTrimmers";
                }
                else if (choice1.Equals("2"))
                {//if choice is etc...
                    type = "LawnMowers";
                }
                else if (choice1.Equals("3"))
                {
                    type = "GardenHandTools";
                }
                else if (choice1.Equals("4"))
                {
                    type = "WheelBarrows";
                }
                else if (choice1.Equals("5"))
                {
                    type = "GardenPowerTools";
                }
                Tool[] array = gardeningTools.toArray();
                Console.Clear();
                for (int m = 0; m < gardeningTools.Number; m++)
                {
                    if (array[m].Name.Contains(type))
                    {
                        Console.WriteLine(m + ". " + array[m].Name);
                    }
                }
                Console.Write("Please select corresponding number: ");
                string choice2 = Console.ReadLine();
                int index = int.Parse(choice2);
                Console.Clear();
                Console.WriteLine("you are adding to:  " + thing[index].Name);
                Console.WriteLine("it currently has: " + thing[index ].Quantity);
                Console.Write("how many would you like to add: ");
                string baba = Console.ReadLine();
                int quant = int.Parse(baba);
                Increment(thing[index], quant);
            }
            else if (choice.Equals("2"))
            { //if choice is flooring tools
                string type = "";
                int ii = 1;
                int j = 1;
                foreach (KeyValuePair<string, string> item in toolCatAndType)
                {
                    if (item.Key.Contains("Flooring Tool"))
                    {
                        Console.WriteLine(ii + ". " + item.Value);
                        ii++;
                        j++;
                    }
                }
                j--;
                Console.Write("Which type does this belong to (1-" + j + "): ");
                string choice1 = Console.ReadLine();
                if (choice1.Equals("1"))
                {//if choice is line trimmer
                    type = "Scrapers";
                }
                else if (choice1.Equals("2"))
                {//if choice is etc...
                    type = "FloorLasers";
                }
                else if (choice1.Equals("3"))
                {
                    type = "FloorLevellingTools";
                }
                else if (choice1.Equals("4"))
                {
                    type = "FloorLevellingMaterials";
                }
                else if (choice1.Equals("5"))
                {
                    type = "FloorHandTools";
                }
                else if (choice1.Equals("6"))
                {
                    type = "TilingTools";
                }
                Tool[] array = flooringTools.toArray();
                Console.Clear();
                for (int m = 0; m < flooringTools.Number; m++)
                {
                    if (array[m].Name.Contains(type))
                    {
                        Console.WriteLine(m + ". " + array[m].Name);
                    }
                }
                Console.Write("Please select corresponding number: ");
                string choice2 = Console.ReadLine();
                int index = int.Parse(choice2);
                Tool[] thing = flooringTools.toArray();
                Console.Clear();
                Console.WriteLine("you are adding to:  " + thing[index].Name);
                Console.WriteLine("it currently has: " + thing[index].Quantity);
                Console.Write("how many would you like to add: ");
                string baba = Console.ReadLine();
                int quant = int.Parse(baba);
                Increment(thing[index], quant);
            }
            if (choice.Equals("3"))
            { //if choice is Fencing tools
                string type = "";
                int ii = 1;
                int j = 1;
                foreach (KeyValuePair<string, string> item in toolCatAndType)
                {
                    if (item.Key.Contains("Fencing Tool"))
                    {
                        Console.WriteLine(ii + ". " + item.Value);
                        ii++;
                        j++;
                    }
                }
                j--;
                Console.Write("Which type does this belong to (1-" + j + "): ");
                string choice1 = Console.ReadLine();
                if (choice1.Equals("1"))
                {//if choice is line trimmer
                    type = "FenceHandTools";
                }
                else if (choice1.Equals("2"))
                {//if choice is etc...
                    type = "ElectricFencing";
                }
                else if (choice1.Equals("3"))
                {
                    type = "SteelFencingTools";
                }
                else if (choice1.Equals("4"))
                {
                    type = "PowerTools";
                }
                else if (choice1.Equals("5"))
                {
                    type = "FencingAccessories";
                }

                Tool[] array = fencingTools.toArray();
                Console.Clear();
                for (int m = 0; m < fencingTools.Number; m++)
                {
                    if (array[m].Name.Contains(type))
                    {
                        Console.WriteLine(m + ". " + array[m].Name);
                    }
                }
                Console.Write("Please select corresponding number: ");
                string choice2 = Console.ReadLine();
                int index = int.Parse(choice2);
                Tool[] thing = fencingTools.toArray();
                Console.Clear();
                Console.WriteLine("you are adding to:  " + thing[index].Name);
                Console.WriteLine("it currently has: " + thing[index].Quantity);
                Console.Write("how many would you like to add: ");
                string baba = Console.ReadLine();
                int quant = int.Parse(baba);
                Increment(thing[index], quant);
            }
            if (choice.Equals("4"))
            { //if choice is measuring tools
                string type = "";
                int ii = 1;
                int j = 1;
                foreach (KeyValuePair<string, string> item in toolCatAndType)
                {
                    if (item.Key.Contains("Measuring Tool"))
                    {
                        Console.WriteLine(ii + ". " + item.Value);
                        ii++;
                        j++;
                    }
                }
                j--;
                Console.Write("Which type does this belong to (1-" + j + "): ");
                string choice1 = Console.ReadLine();
                if (choice1.Equals("1"))
                {//if choice is line trimmer
                    type = "DistanceTools";
                }
                else if (choice1.Equals("2"))
                {//if choice is etc...
                    type = "LaserMeasurer";
                }
                else if (choice1.Equals("3"))
                {
                    type = "MeasuringJugs";
                }
                else if (choice1.Equals("4"))
                {
                    type = "TempHumidityTools";
                }
                else if (choice1.Equals("5"))
                {
                    type = "LevellingTools";
                }
                else if (choice1.Equals("6"))
                {
                    type = "Markers";
                }
                Tool[] array = measuringTools.toArray();
                Console.Clear();
                for (int m = 0; m < measuringTools.Number; m++)
                {
                    if (array[m].Name.Contains(type))
                    {
                        Console.WriteLine(m + ". " + array[m].Name);
                    }
                }
                Console.Write("Please select corresponding number: ");
                string choice2 = Console.ReadLine();
                int index = int.Parse(choice2);
                Tool[] thing = measuringTools.toArray();
                Console.Clear();
                Console.WriteLine("you are adding to:  " + thing[index].Name);
                Console.WriteLine("it currently has: " + thing[index].Quantity);
                Console.Write("how many would you like to add: ");
                string baba = Console.ReadLine();
                int quant = int.Parse(baba);
                Increment(thing[index], quant);
            }
            if (choice.Equals("5"))
            { //if choice is cleaning tools
                string type = "";
                int ii = 1;
                int j = 1;
                foreach (KeyValuePair<string, string> item in toolCatAndType)
                {
                    if (item.Key.Contains("Cleaning Tool"))
                    {
                        Console.WriteLine(ii + ". " + item.Value);
                        ii++;
                        j++;
                    }
                }
                j--;
                Console.Write("Which type does this belong to (1-" + j + "): ");
                string choice1 = Console.ReadLine();
                if (choice1.Equals("1"))
                {//if choice is line trimmer
                    type = "Draining";
                }
                else if (choice1.Equals("2"))
                {//if choice is etc...
                    type = "CarCleaning";
                }
                else if (choice1.Equals("3"))
                {
                    type = "Vacuum";
                }
                else if (choice1.Equals("4"))
                {
                    type = "PressureCleaners";
                }
                else if (choice1.Equals("5"))
                {
                    type = "PoolCleaning";
                }
                else if (choice1.Equals("6"))
                {
                    type = "FloorCleaning";
                }
               
                Tool[] array = cleaningTools.toArray();
                Console.Clear();
                for (int m = 0; m < cleaningTools.Number; m++)
                {
                    if (array[m].Name.Contains(type))
                    {
                        Console.WriteLine(m + ". " + array[m].Name);
                        
                    }
                }
                
                Console.Write("Please select corresponding number: ");
                string choice2 = Console.ReadLine();
                int index = int.Parse(choice2);
                Tool[] thing = cleaningTools.toArray();
                Console.Clear();
                Console.WriteLine("you are adding to:  " + thing[index].Name);
                Console.WriteLine("it currently has: " + thing[index].Quantity);
                Console.Write("how many would you like to add: ");
                string baba = Console.ReadLine();
                int quant = int.Parse(baba);
                Increment(thing[index], quant);
            }
            if (choice.Equals("6"))
            { //if choice is painting tools
                string type = "";
                int ii = 1;
                int j = 1;
                foreach (KeyValuePair<string, string> item in toolCatAndType)
                {
                    if (item.Key.Contains("Painting Tool"))
                    {
                        Console.WriteLine(ii + ". " + item.Value);
                        ii++;
                        j++;
                    }
                }
                j--;
                Console.Write("Which type does this belong to (1-" + j + "): ");
                string choice1 = Console.ReadLine();
                if (choice1.Equals("1"))
                {//if choice is line trimmer
                    type = "SandingTools";
                }
                else if (choice1.Equals("2"))
                {//if choice is etc...
                    type = "Brushes";
                }
                else if (choice1.Equals("3"))
                {
                    type = "Rollers";
                }
                else if (choice1.Equals("4"))
                {
                    type = "PaintRemovalTools";
                }
                else if (choice1.Equals("5"))
                {
                    type = "PaintScrapers";
                }
                else if (choice1.Equals("6"))
                {
                    type = "Sprayers";
                }
                
                Tool[] array = paintingTools.toArray();
                Console.Clear();
                for (int m = 0; m < paintingTools.Number; m++)
                {
                    if (array[m].Name.Contains(type))
                    {
                        Console.WriteLine(m + ". " + array[m].Name);
                        
                    }
                }
                
                Console.Write("Please select corresponding number: ");
                string choice2 = Console.ReadLine();
                int index = int.Parse(choice2);
                Tool[] thing = paintingTools.toArray();
                Console.Clear();
                Console.WriteLine("you are adding to:  " + thing[index].Name);
                Console.WriteLine("it currently has: " + thing[index].Quantity);
                Console.Write("how many would you like to add: ");
                string baba = Console.ReadLine();
                int quant = int.Parse(baba);
                Increment(thing[index], quant);
            }
            if (choice.Equals("7"))
            { //if choice is electronic tools
                string type = "";
                int ii = 1;
                int j = 1;
                foreach (KeyValuePair<string, string> item in toolCatAndType)
                {
                    if (item.Key.Contains("Electronic Tool"))
                    {
                        Console.WriteLine(ii + ". " + item.Value);
                        ii++;
                        j++;
                    }
                }
                j--;
                Console.Write("Which type does this belong to (1-" + j + "): ");
                string choice1 = Console.ReadLine();
                if (choice1.Equals("1"))
                {//if choice is line trimmer
                    type = "VoltageTester";
                }
                else if (choice1.Equals("2"))
                {//if choice is etc...
                    type = "Oscilloscopes";
                }
                else if (choice1.Equals("3"))
                {
                    type = "ThermalImaging";
                }
                else if (choice1.Equals("4"))
                {
                    type = "DataTestTool";
                }
                else if (choice1.Equals("5"))
                {
                    type = "InsulationTesters";
                }
              
               
                Tool[] array = electronicTools.toArray();
                Console.Clear();
                for (int m = 0; m < electronicTools.Number; m++)
                {
                    if (array[m].Name.Contains(type))
                    {
                        Console.WriteLine(m + ". " + array[m].Name);
                        
                    }
                }
               
                Console.Write("Please select corresponding number: ");
                string choice2 = Console.ReadLine();
                int index = int.Parse(choice2);
                Tool[] thing = electronicTools.toArray();
                Console.Clear();
                Console.WriteLine("you are adding to:  " + thing[index].Name);
                Console.WriteLine("it currently has: " + thing[index].Quantity);
                Console.Write("how many would you like to add: ");
                string baba = Console.ReadLine();
                int quant = int.Parse(baba);
                Increment(thing[index], quant);
            }
            if (choice.Equals("8"))
            { //if choice is electricity tools
                string type = "";
                int ii = 1;
                int j = 1;
                foreach (KeyValuePair<string, string> item in toolCatAndType)
                {
                    if (item.Key.Contains("Electricity Tool"))
                    {
                        Console.WriteLine(ii + ". " + item.Value);
                        ii++;
                        j++;
                    }
                }
                j--;
                Console.Write("Which type does this belong to (1-" + j + "): ");
                string choice1 = Console.ReadLine();
                if (choice1.Equals("1"))
                {//if choice is line trimmer
                    type = "TestEquipment";
                }
                else if (choice1.Equals("2"))
                {//if choice is etc...
                    type = "SafetyEquipment";
                }
                else if (choice1.Equals("3"))
                {
                    type = "BasicHandTools";
                }
                else if (choice1.Equals("4"))
                {
                    type = "CircuitProtection";
                }
                else if (choice1.Equals("5"))
                {
                    type = "CableTools";
                }
               
                Tool[] array = electricityTools.toArray();
                Console.Clear();
                for (int m = 0; m < electricityTools.Number; m++)
                {
                    if (array[m].Name.Contains(type))
                    {
                        Console.WriteLine(m + ". " + array[m].Name);
                        
                    }
                }
                
                Console.Write("Please select corresponding number: ");
                string choice2 = Console.ReadLine();
                int index = int.Parse(choice2);
                Tool[] thing = electricityTools.toArray();
                Console.Clear();
                Console.WriteLine("you are adding to:  " + thing[index].Name);
                Console.WriteLine("it currently has: " + thing[index].Quantity);
                Console.Write("how many would you like to add: ");
                string baba = Console.ReadLine();
                int quant = int.Parse(baba);
                Increment(thing[index], quant);
            }
            if (choice.Equals("9"))
            { //if choice is Automotive tools
                string type = "";
                int ii = 1;
                int j = 1;
                foreach (KeyValuePair<string, string> item in toolCatAndType)
                {
                    if (item.Key.Contains("Automotive Tool"))
                    {
                        Console.WriteLine(ii + ". " + item.Value);
                        ii++;
                        j++;
                    }
                }
                j--;
                Console.Write("Which type does this belong to (1-" + j + "): ");
                string choice1 = Console.ReadLine();
                if (choice1.Equals("1"))
                {//if choice is line trimmer
                    type = "Jacks";
                }
                else if (choice1.Equals("2"))
                {//if choice is etc...
                    type = "AirCompressors";
                }
                else if (choice1.Equals("3"))
                {
                    type = "BatteryChargers";
                }
                else if (choice1.Equals("4"))
                {
                    type = "SocketTools";
                }
                else if (choice1.Equals("5"))
                {
                    type = "Braking";
                }
                else if (choice1.Equals("6"))
                {
                    type = "Drivetrain";
                }
                
                Tool[] array = automotiveTools.toArray();
                Console.Clear();
                for (int m = 0; m < automotiveTools.Number; m++)
                {
                    if (array[m].Name.Contains(type))
                    {
                        Console.WriteLine(m + ". " + array[m].Name);
                        
                    }
                }
                
                Console.Write("Please select corresponding number: ");
                string choice2 = Console.ReadLine();
                int index = int.Parse(choice2);
                Tool[] thing = automotiveTools.toArray();
                Console.Clear();
                Console.WriteLine("you are adding to:  " + thing[index].Name);
                Console.WriteLine("it currently has: " + thing[index].Quantity);
                Console.Write("how many would you like to add: ");
                string baba = Console.ReadLine();
                int quant = int.Parse(baba);
                Increment(thing[index], quant);
            }

        }

        private void AddTool(string toolType, Tool aTool, ToolCollection toolCat)
        {
            string eee = toolType + " " + aTool.Name;
            Tool newey = new Tool(eee, 1, 1, 0);
            Console.Clear();
            Console.WriteLine("Added " + aTool.Name + " to: " + toolType);
            Console.WriteLine("");
            toolCat.add(newey);
        }

        private void PrintCat(Dictionary<string, string> toolCatAndType, string toolCat)
        {
            int ii = 1;
            int j = 1;
            foreach (KeyValuePair<string, string> item in toolCatAndType)
            {
                if (item.Key.Contains(toolCat))
                {
                    Console.WriteLine(ii + ". " + item.Value);
                    ii++;
                    j++;
                }
            }
            Console.Write("Which type does this belong to (1-" + j + "): ");
        }
        public void add(Tool aTool)
        {
            int i = 1;
            //print the tool types and ask which tool type they wish to add to
            foreach (KeyValuePair<string, string> item in toolCatAndType)
            {
                if (!item.Key.Any(char.IsDigit))
                {

                    Console.WriteLine(i + ". " + item.Key);
                    i++;
                }
            }
            Console.Write("Which category does this belong in (1-9): ");
            string choice = Console.ReadLine();
            //if choice is gardening tools
            if (choice.Equals("1"))
            {
                PrintCat(toolCatAndType, "Gardening Tool");    
                string choice1 = Console.ReadLine();
                if (choice1.Equals("1")) AddTool("LineTrimmers", aTool, gardeningTools);
                if (choice1.Equals("2")) AddTool("LawnMowers", aTool, gardeningTools);
                if (choice1.Equals("3")) AddTool("GardenHandTools", aTool, gardeningTools);
                if (choice1.Equals("4")) AddTool("WheelBarrows", aTool, gardeningTools);
                if (choice1.Equals("5")) AddTool("GardenPowerTools", aTool, gardeningTools);
            }
            if (choice.Equals("2"))
            {
                PrintCat(toolCatAndType, "Flooring Tool");
                string choice1 = Console.ReadLine();
                if (choice1.Equals("1")) AddTool("Scrapers", aTool, flooringTools);
                if (choice1.Equals("2")) AddTool("FloorLasers", aTool, flooringTools);
                if (choice1.Equals("3")) AddTool("FloorLevellingTools", aTool, flooringTools);
                if (choice1.Equals("4")) AddTool("FloorLevellingMaterials", aTool, flooringTools);
                if (choice1.Equals("5")) AddTool("FloorHandTools", aTool, flooringTools);
                if (choice1.Equals("6")) AddTool("TilingTools", aTool, flooringTools);
            }
            if (choice.Equals("3"))
            {
                PrintCat(toolCatAndType, "Fencing Tool");
                string choice1 = Console.ReadLine();
                if (choice1.Equals("1")) AddTool("FenceHandTools", aTool, fencingTools);
                if (choice1.Equals("2")) AddTool("ElectricFencing", aTool, fencingTools);
                if (choice1.Equals("3")) AddTool("SteelFencingTools", aTool, fencingTools);
                if (choice1.Equals("4")) AddTool("PowerTools", aTool, fencingTools);
                if (choice1.Equals("5")) AddTool("FencingAccessories", aTool, fencingTools);
            }
            if (choice.Equals("4"))
            {
                PrintCat(toolCatAndType, "Measuring Tool");
                string choice1 = Console.ReadLine();
                if (choice1.Equals("1")) AddTool("DistanceTools", aTool, measuringTools);
                if (choice1.Equals("2")) AddTool("LaserMeasurer", aTool, measuringTools);
                if (choice1.Equals("3")) AddTool("MeasuringJugs", aTool, measuringTools);
                if (choice1.Equals("4")) AddTool("TempHumidityTools", aTool, measuringTools);
                if (choice1.Equals("5")) AddTool("LevellingTools", aTool, measuringTools);
                if (choice1.Equals("6")) AddTool("Markers", aTool, measuringTools);
            }
            if (choice.Equals("5"))
            {
                PrintCat(toolCatAndType, "Cleaning Tool");
                string choice1 = Console.ReadLine();
                if (choice1.Equals("1")) AddTool("Draining", aTool, cleaningTools);
                if (choice1.Equals("2")) AddTool("CarCleaning", aTool, cleaningTools);
                if (choice1.Equals("3")) AddTool("Vacuum", aTool, cleaningTools);
                if (choice1.Equals("4")) AddTool("PressureCleaners", aTool, cleaningTools);
                if (choice1.Equals("5")) AddTool("PoolCleaning", aTool, cleaningTools);
                if (choice1.Equals("6")) AddTool("FloorCleaning", aTool, cleaningTools);
            }
            if (choice.Equals("6"))
            {
                PrintCat(toolCatAndType, "Painting Tool");
                string choice1 = Console.ReadLine();
                if (choice1.Equals("1")) AddTool("SandingTools", aTool, paintingTools);
                if (choice1.Equals("2")) AddTool("Brushes", aTool, paintingTools);
                if (choice1.Equals("3")) AddTool("Rollers", aTool, paintingTools);
                if (choice1.Equals("4")) AddTool("PaintRemovalTools", aTool, paintingTools);
                if (choice1.Equals("5")) AddTool("PaintScrapers", aTool, paintingTools);
                if (choice1.Equals("6")) AddTool("Sprayers", aTool, paintingTools);
            }
            if (choice.Equals("7"))
            {
                PrintCat(toolCatAndType, "Electronic Tool");
                string choice1 = Console.ReadLine();
                if (choice1.Equals("1")) AddTool("VoltageTester", aTool, electronicTools);
                if (choice1.Equals("2")) AddTool("Oscilloscopes", aTool, electronicTools);
                if (choice1.Equals("3")) AddTool("ThermalImaging", aTool, electronicTools);
                if (choice1.Equals("4")) AddTool("DataTestTool", aTool, electronicTools);
                if (choice1.Equals("5")) AddTool("InsulationTesters", aTool, electronicTools);
            }
            if (choice.Equals("8"))
            {
                PrintCat(toolCatAndType, "Electricity Tool");
                string choice1 = Console.ReadLine();
                if (choice1.Equals("1")) AddTool("TestEquipment", aTool, electricityTools);
                if (choice1.Equals("2")) AddTool("SafetyEquipment", aTool, electricityTools);
                if (choice1.Equals("3")) AddTool("BasicHandTools", aTool, electricityTools);
                if (choice1.Equals("4")) AddTool("CircuitProtection", aTool, electricityTools);
                if (choice1.Equals("5")) AddTool("CableTools", aTool, electricityTools);
            }
            if (choice.Equals("9"))
            {
                PrintCat(toolCatAndType, "Automotive Tool");
                string choice1 = Console.ReadLine();
                if (choice1.Equals("1")) AddTool("Jacks", aTool, automotiveTools);
                if (choice1.Equals("2")) AddTool("AirCompressors", aTool, automotiveTools);
                if (choice1.Equals("3")) AddTool("BatteryChargers", aTool, automotiveTools);
                if (choice1.Equals("4")) AddTool("SocketTools", aTool, automotiveTools);
                if (choice1.Equals("5")) AddTool("Braking", aTool, automotiveTools);
                if (choice1.Equals("6")) AddTool("Drivetrain", aTool, automotiveTools);
            }
        }

        //private method that assists the add quantity method
        private void Increment(Tool aTool, int quantity)
        {
            Console.WriteLine("successfully added: (" + quantity + ") to: " + aTool.Name);

            if (gardeningTools.search(aTool) || flooringTools.search(aTool) || fencingTools.search(aTool) ||measuringTools.search(aTool) || cleaningTools.search(aTool)
                || paintingTools.search(aTool)|| electronicTools.search(aTool) || electricityTools.search(aTool) || automotiveTools.search(aTool))
            {
                aTool.Quantity += quantity;
                aTool.AvailableQuantity += quantity;
            }
        }

        //private method to help with removing quantity
        private void Decrement(Tool aTool, int quantity)
        {
            if (gardeningTools.search(aTool) && (aTool.Quantity - quantity) > 0 && (aTool.AvailableQuantity - quantity) > 0)
            {
                aTool.Quantity -= quantity;
                aTool.AvailableQuantity -= quantity;
                Console.WriteLine("successfully removed: (" + quantity + ") from: " + aTool.Name);
            }

        }
        private Dictionary<string, string> toolsTypesDict()
        {
            Dictionary<string, string> toolTypesInCategory = new Dictionary<string, string>();

            toolTypesInCategory.Add("Gardening Tools", "Line Trimmer");
            toolTypesInCategory.Add("Gardening Tools1", "Lawn Mower");
            toolTypesInCategory.Add("Gardening Tools2", "Hand Tools");
            toolTypesInCategory.Add("Gardening Tools3", "Wheelbarrows");
            toolTypesInCategory.Add("Gardening Tool4s", "Garden Power Tools");
            toolTypesInCategory.Add("Flooring Tools", "Scrapers");
            toolTypesInCategory.Add("Flooring Tools1", "Floor Lasers");
            toolTypesInCategory.Add("Flooring Tools2", "Floor Levelling Tools");
            toolTypesInCategory.Add("Flooring Tools3", "Floor Levelling Materials");
            toolTypesInCategory.Add("Flooring Tools4", "Floor Hand Tools");
            toolTypesInCategory.Add("Flooring Tools5", "Tiling Tools");
            toolTypesInCategory.Add("Fencing Tools", "Hand Tools");
            toolTypesInCategory.Add("Fencing Tools1", "Electric Fencing");
            toolTypesInCategory.Add("Fencing Tools2", "Steel Fencing Tools");
            toolTypesInCategory.Add("Fencing Tools3", "Power Tools");
            toolTypesInCategory.Add("Fencing Tools4", "Fencing Accessories");
            toolTypesInCategory.Add("Measuring Tools", "Distance Tools");
            toolTypesInCategory.Add("Measuring Tools1", "Laser Measurer");
            toolTypesInCategory.Add("Measuring Tools2", "Temperature & Humidity Tools");
            toolTypesInCategory.Add("Measuring Tools3", "Levelling Tools");
            toolTypesInCategory.Add("Measuring Tools4", "Markers");
            toolTypesInCategory.Add("Cleaning Tools", "Draining");
            toolTypesInCategory.Add("Cleaning Tools1", "Car Cleaning");
            toolTypesInCategory.Add("Cleaning Tools2", "Vacuum");
            toolTypesInCategory.Add("Cleaning Tools3", "Pressure Cleaners");
            toolTypesInCategory.Add("Cleaning Tools4", "Pool Cleaning");
            toolTypesInCategory.Add("Cleaning Tools5", "Floor Cleaning");
            toolTypesInCategory.Add("Painting Tools", "Sanding Tools");
            toolTypesInCategory.Add("Painting Tools1", "Brushes");
            toolTypesInCategory.Add("Painting Tools2", "Rollers");
            toolTypesInCategory.Add("Painting Tools3", "Paint Removal Tools");
            toolTypesInCategory.Add("Painting Tools4", "Paint Scrapers");
            toolTypesInCategory.Add("Painting Tools5", "Sprayers");
            toolTypesInCategory.Add("Electronic Tools", "Voltage Testers");
            toolTypesInCategory.Add("Electronic Tools1", "Oscilloscopes");
            toolTypesInCategory.Add("Electronic Tools2", "Thermal Imaging");
            toolTypesInCategory.Add("Electronic Tools3", "Data Test Tool");
            toolTypesInCategory.Add("Electronic Tools4", "Insulation Testers");
            toolTypesInCategory.Add("Electricity Tools", "Test Equipment");
            toolTypesInCategory.Add("Electricity Tools1", "Safety Equipment");
            toolTypesInCategory.Add("Electricity Tools2", "Basic Hand Tools");
            toolTypesInCategory.Add("Electricity Tools3", "Circuit Protection");
            toolTypesInCategory.Add("Electricity Tools4", "Cable Tools");
            toolTypesInCategory.Add("Automotive Tools", "Jacks");
            toolTypesInCategory.Add("Automotive Tools1", "Air Compressors");
            toolTypesInCategory.Add("Automotive Tools2", "Battery Chargers");
            toolTypesInCategory.Add("Automotive Tools3", "Socket Tools");
            toolTypesInCategory.Add("Automotive Tools4", "Braking");
            toolTypesInCategory.Add("Automotive Tools5", "Drivetrain");

            return toolTypesInCategory;
        }

    }
}