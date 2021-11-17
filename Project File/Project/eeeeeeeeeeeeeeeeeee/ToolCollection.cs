using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment
{//this is just to be used for telling how many of something has been borrows basically
    public class ToolCollection : iToolCollection
    {
        private Tool[] tools;
        private int numTools;

        public int Number { get { return numTools; } }

        public ToolCollection()
        {
            //im not sure what the size should be 
            tools = new Tool[1000];
            numTools = 0;
        }

        public void add(Tool aTool)
        {
            tools[numTools] = aTool;
            numTools++;
        }

        public void delete(Tool aTool)
        {
            int i = 0;
            while ((i < numTools) && (tools[i].Name.CompareTo(aTool.Name) != 0))
                i++;
            if (i == numTools)
                Console.WriteLine("The tool does not exist!");
            else
            {
                for (int j = i + 1; j < numTools; j++)
                    tools[j - 1] = tools[j];
                numTools--;
                Console.WriteLine("Tool was deleted");
            }
        }

        public bool search(Tool aTool)
        {
            for (int i = 0; i < numTools; i++)
            {
                if (tools[i].Name == aTool.Name)
                {
                    return true;
                }
            }
            return false;
        }

        public Tool[] toArray()
        {
            return tools;
        }

       
    }
}
