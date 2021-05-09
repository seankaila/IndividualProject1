# IndividualProject: Hero App

## Brief 
This project was inteded to demonstrate the knowledge from the first four weeks of training with QA. To do this I was tasked to create a CRUD application using C# & ASP.NET, testing the application though unit testing & deploying the application using a CL server and Azure App Service. All supported using project management tools for example: A Kanban Board. 

## Architecture

### Database ERD
![image](https://user-images.githubusercontent.com/82107182/117579398-94c97a80-b0ea-11eb-8779-b41587489208.png)
This is my database structure that was implamented to the project. As you can see the data base consits of two tables (Hero Table & Team Table). These tables have a one to many relationship meaning, a team can have many heros but a hero can only have one team associated with it. These tables are linked with their respected Primary and forigen keys and each element in the table has their respected data type added next to it.

Highlighted in Red was a third table that was deemed out of scope due to time constriates. 

### Use Case Diagram 
![image](https://user-images.githubusercontent.com/82107182/117580073-ede6dd80-b0ed-11eb-8b72-b597fe9aa6a2.png)
This use Case diagram demonstrates what the end user would do with the curd application i have made. The end user will have the ability to add, edit, delete and view a team within the application. The users will also be able to view all the heroes within a team. The user will also have the ability to add, edit, delete and view all the heores within the app. Additionally they will have the ability to exted the Heros details allowing them to view all the details associated with that hero. This helped me diagram helped me develop the Epics, User stories and Tasks in the project management section. 

## Project Management 

### Kanban Board
![image](https://user-images.githubusercontent.com/82107182/117580875-ed504600-b0f1-11eb-9d72-7ce3dbb680e4.png)
To track and understand the progress of my project i used trello to create a Kanban Board. This board was split up into seven different sections. 

- Epics: These are high level catagories each User story referes to. 
- User Stories: These are derived from the Epics, detailing what a user whats to do and why they want to do that action. 
- Tasks in progress: These contain low level tasks needed for a user story / epic to be deemed completed. 
- Tasks completed: Tasks that are completed. 
- Issues: Issues within the project that need attention
- Issues resolved: Backlog of previous issues that are no logger a problem. 
- Out of scope: Epics and user stories that were deemed out of scope dude to the duration of the project being too small. 

Link to KanbanBoard: https://trello.com/b/MPUDF12C/individual-project-hero-app
### Risk Management
![image](https://user-images.githubusercontent.com/82107182/117587838-c73d9c80-b117-11eb-8264-d8f7b4bb3a0c.png)
A simple risk assesement was preformed during the project. Each risk was described and evaluated along with a rating to understand the serverity of the risk. To expand upon this i did provided an update to each risk checking to see if they changed in anyway. 


## Testing
This section details what unit tests were done and the code coverage report. 
![image](https://user-images.githubusercontent.com/82107182/117582993-b92e5280-b0fc-11eb-9385-f087246fb099.png)
Using the AAA (Arrange, Act, Assert) testing patten, a total of 15 unit tests were created for this project. I testing multiple controllers which did different operations for the CRUD application a range of tests were also included. For example: adding a team without a logo vs adding a team with a logo. 

### Code Coverage Report
![image](https://user-images.githubusercontent.com/82107182/117583114-525d6900-b0fd-11eb-8b7c-3205b38b70f5.png)
From the screen shot above we can see the overall coverage of the application to be 14.1%. Although this is very low, we do have to take into account that code that wasnt inteded to be covered in this report was covered. For example: Views & database migrations etc. This resulted in a very low score. 
![image](https://user-images.githubusercontent.com/82107182/117583262-21c9ff00-b0fe-11eb-8771-091b533ee9fd.png)
As we can see from the image above we can see the controllers that contained the most import logic were tested. Each controller having an avarage score of 70%. Although this is a good result, the rests lack results for the edit funcions within the application. This is because i couldnt understand how to mock the data correctly for edting purposes and therefore i couldnt create good tests that would accuretly repreent how sound the overall edit feature was. 
![image](https://user-images.githubusercontent.com/82107182/117583446-1aefbc00-b0ff-11eb-8400-940fe067c5fa.png)
The example above shows the edit feature for the Hero Controller not being implemented. Therefore the resulting coverage goes from 100% to 63% because one function wasnt tested.

## Git, Continuous Integration (Pipeline) and best practices.

### Version Control / Feature Branch model
![image](https://user-images.githubusercontent.com/82107182/117585436-504dd700-b10a-11eb-8eef-a43dd31f2c34.png)
During the duration of the project i was using a feature branch model to manage the version control aspect of the project. As you can see I used a three branch system to do this. These branches were: Main, dev and feature. I had multiple feature branches that were used when adding a new feature to the application. Once a feature was complete, It was then merged with the dev branch. Once a group of features were mreged to the dev branch that were free from error, i would then merge the dev branch to the main. This main acted as a live version of my product. Only containing code which was fully functional / bug free. 

### CL Pipeline 
![image](https://user-images.githubusercontent.com/82107182/117585662-7a53c900-b10b-11eb-915b-936a59761341.png)
A CL pipeline was sucessfully impleneted with the project however, when displaying the webapp on the browser, i was greeted with a simple "hey .net developer message". instead of my application. This was a problem that i and many others fanced including the instructors. Given more time, we may have been able to solve this issue. However i was able to deploy the app service without the CI pipline though Visual studios publish option. 

### Best practices
This project was developed using a wide range of best practices. For example: documenting code with simple in line comments. This was done so that people outside the project could really understand how certain functions / operations worked, if they were ever to take the project off my hand and expand uppon it.

![image](https://user-images.githubusercontent.com/82107182/117585933-277b1100-b10d-11eb-81da-83753a2ae739.png)
![image](https://user-images.githubusercontent.com/82107182/117585936-319d0f80-b10d-11eb-91cc-88cb61356ebd.png)

Another example could be seen with the addition to a git ignore as well. My git ignore didnt include certain files that contained passwords and test results. So that People who shouldnt seen important documents wouldnt be able to. The images above show a red circle next to files and folders indicating they are never being pushed to github. 


