# CAB301-Assignment
A command line tool borrowing and lending system with member functionality and implementation of bubble sort algorithm to determine 3 most borrowed tools


Introduction 
This is a report relating to the Tool Library assignment and its functionalities. The project has been 
implemented fully and has full functionality although it sometimes lacks error checking and as a 
result will occasionally crash should an unexpected entry come its way. There were no changes 
made to the given interfaces other than the recommended change to make each of the return types 
from iTool to Tool etc. Some of the code is a little poorly written and is poorly commented. 
This report will detail largely the algorithm used to display the top 3 most borrowed tools and an 
analysis of this algorithm. 

Algorithm design - Bubble Sort

Algorithm analysis 
To begin the algorithm, the tools from 9 ToolCollection arrays are collated into one List<Tool> for 
easier comparison. It is then sorted in descending order utilising a bubblesort algorithm. This algorithm works by passing 
through the entire array, swapping items that are in the correct order until it no longer has to. 
Referenced from the CAB301 lectures – Week 4 
We can see that ultimately, the bubble sort algorithm that was implemented has a time complexity 
of 𝑂(𝑛ଶ). 
The inner loop of this implementation of the bubble sort will occur equal to 𝑖 to 𝑛 times which is a 
time complexity of 𝑂(𝑛). Inside this loop contains several checks and assignments which are all 
𝑂(1). The outermost loop will occur as many times as necessary which equates to 𝑂(𝑛). Since the 
two loops are nested inside each other, the overall time complexity comes out to 𝑂(𝑛ଶ)

Running the project in visual studio should be relatively straight forward. Simply run the .sln file
