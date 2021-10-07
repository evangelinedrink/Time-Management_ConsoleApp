using System;
using System.Collections; //With this, computer is able to use the ArrayList class and the Queue.
using System.Collections.Generic; //With this, computer is able to create Queues. It is also able to add, remove and insert an object in a List<T>
using System.Timers; //With this, the timer can be used
using System.Diagnostics; //This lets the stopwatch be used in the application



namespace Time_Management_Console_App
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creating the Queue called noteList that will contain all the notes
            //that the user typed in when they were using the Notes function in the Time Management App
            Queue noteList = new Queue();

            //Initializing the variable currentDateTimeString in the Notes method
            string currentDateTimeString = "value";

            //Initializing the variable note
            string note = "value";

            //Initializing the noteDetails Constructor to be a string
            //Constructors always have to be initialized in the Main 
            //If the Constructor has different data types, define it as var
            string NoteDetails = currentDateTimeString + note;

            //Passing in the noteList Queue to the Notes method
            //noteList Queue will store all the notes (and new notes) added to the note list
            Notes(noteList, currentDateTimeString, note, NoteDetails);

            /*Method that will run the Check List Method*/

            //Creating an ArrayList that will hold the check list's elements
            var checkListArray = new ArrayList();

            //Creating an ArrayList that will hold all of items in the check list without
            //having a number for each item on the list (this is going to be a copy of the checkListArray)
            var checkListArrayNoNumbers = new ArrayList();

            //Creating a queue that will contain the numbers next to each item in the check list
            //Since this queue will contain numbers, <int> is needed to let numbers be added to the Queue
            Queue<int> checkListNumbers = new Queue<int>();

            //Variable that will ask if the user would like to create/add an item in the Check List
            string createCheckList = "YES";

            //Using Do/While loop to let the code be read multiple times
            do
            {
                //Asking the user if they would like to open the check list application
                Console.WriteLine("Would you like to open the check list application?");
                //Getting the user's response and making it upper case
                createCheckList = Console.ReadLine().ToUpper();

                //Using an If/Else IF statement to run the CheckList method
                if (createCheckList == "YES")
                {
                    CheckList(checkListArray, checkListArrayNoNumbers);
                }
                else if ((createCheckList != "YES") && (createCheckList != "NO")) //IF the user types in a word that is not YES or NO
                {
                    Console.WriteLine("Please type in \"Yes\" or \"No\"");
                }
            } while (createCheckList != "NO");


            /*Timer App*/
            /*
            //Asking the user what time would they like to set up the timer
            Console.WriteLine("What time would you like to set up the timer to? " +
                "Use this format to type out the time: hours:minutes:seconds");
            //Getting the user's input
            string userTimerValue = Console.ReadLine();
            //Using the Split() method to separate the hours, minutes and seconds
            string[] timerValueString = userTimerValue.Split(":");
            //The Split() method separates all the inputs that are separated by : into an array
            //Converting all the string values in timerValueString into integers using Convert.ToInt32
            //First going to create an array that will hold the integer values. It will have the same length as the timerValueString array
            int[] timerValue = new int[timerValueString.Length];
            //Using For loop to convert string values in timerValueString into integers
            for (int i = 0; i <= timerValueString.Length - 1; i++)
            {
                timerValue[i] = Convert.ToInt32(timerValueString[i]);
            }

            //Running the timer method. Passing in the timerValue array containing the hours, minutes and seconds that 
            //the user would like to set the timer for. 
            TimerApp(timerValue); //Need to create the timer app method
            */

            /*Chronometer (Stopwatch) app that will determine the time that a user takes to do something*/
            //The Chronometer method will run once the user selects the Chronometer from the list
            //Chronometer();

            //Alarm Method
            Alarm();

            //Run the todaysTemp method (Weather App Component of the Time Management Application)
            //todaysTemp();

            //Running the Schedule Planner Component
            //schedulePlanner();

            //Creating a Do/While loop to ask if the user would like to place an event in their event's list
            //Declaring the scheduleAnotherEvent variable that will let this Do/While loop run again when the user types "YES" in the Console
            string scheduleAnotherEvent="NO";

            
            //Creating an ArrayList that will contain all the events placed by the user
            /*var eventsList = new ArrayList();
            do
            {
                //Asking the user if they would like to schedule an event
                Console.WriteLine("Would you like to schedule an event in your event list?");
                //Getting the user's response 
                string scheduleEvent = Console.ReadLine().ToUpper();

                if ((scheduleEvent == "YES") || (scheduleAnotherEvent == "YES"))
                {
                    //Running the Event Creator Method (which creates the events (they are objects) and places the events in a List)
                    eventCreator(eventsList);
                }
                else if ((scheduleEvent != "YES") && (scheduleEvent != "NO")) //&& ensures that if the user types in a value that is neither "YES" or "NO", the Console will display the code within this else/if statement
                {
                    Console.WriteLine("Please answer with a \"Yes\" or a \"No\".");
                }

                //If the user says they do not want to schedule an event, the code in the If block will not run (it will not ask them if they want to schedule another event).
                if (scheduleEvent != "NO")
                {
                    //Asking the user if they would like to schedule another event
                    Console.WriteLine("Would you like to add another event to your event's list?");
                    //Getting the user's response to the questions with Console.ReadLine. Making the answer to upper case with ToUpper()
                    scheduleAnotherEvent = Console.ReadLine().ToUpper();
                    //Ensuring that the user types "Yes" or "No" in the Console to whether they would like to schedule another event by using a While loop to check their response
                    //The code within this While loop will run when both scheduleAnotherEvent is not equal to YES or NO (True && True = True, all other combinations are equal to False). While loop only runs when conditions are True.
                    while ((scheduleAnotherEvent != "YES") && (scheduleAnotherEvent != "NO"))
                    {
                        Console.WriteLine("Please answer the question with a \"Yes\" or a \"No\".\n Would you like to add another event to your event's list?");
                        //Getting the user's response to the questions with Console.ReadLine. Making the answer to upper case with ToUpper()
                        scheduleAnotherEvent = Console.ReadLine().ToUpper();
                    }
                }


            } while (scheduleAnotherEvent == "YES"); //The code within this Do/While loop will run again if the user answers "Yes" to adding another event to their event's list
            */


            //Method to create an event to be placed in the list of events
            static void eventCreator(ArrayList eventsList)
            {
                //For this section of the code, the user will type in the events they would like in their event schedule.
                //The date (year, month and day), time (which will include a time range), and the name of the event (this will be a string) will be stored in the eventsHolderArray (probably needs to be an ArrayList since its size will be changing depending on user input).
                //The date will be passed as a string into DateTime method to determine which day of the week the event will be at. The day of the week will be displayed in the Console with the date like this: May 27, 2022 (Friday)
                //The events will be stored and displayed based on the date from the closest date to the farthest away date (this will probably be done comparing the years, months and then days for each event). Sorting method will need to be done on the eventsHolderArray (which is an ArrayList).
                //The user will be able to see the events and add and delete events. Add() and Remove() methods will be used on the ArrayList. Insert() can be used to insert an element into the ArrayList at a specific position (since the events will be displayed in chonological order, this method might be used).
                //The Console will display the events like this: "Event number" "Date (Month Day, Year (day of week))" "Time range of the event" "Name of the event" "Location of the event" "Description of the event"
                //User will be able to delete events based on the Event Number and will be asked if they are sure they want to delete an event (before actually deleting the event).

                //Asking the user what date they would like to create an event
                //Creating two new rows between the calendar and the question below using "\n\n" and concatenation.
                Console.WriteLine("\n\n" + "What date would you like to create an event for? Make sure to type the year, month and date in numbers. " +
                    "For example if you would like to create an event on May 27, 2022, you would type in the Console: 2022, 5, 27");
                //Getting the user's input with Console.ReadLine(). It will be represented as a string.
                string eventDate = Console.ReadLine();

                //String.Split method is used to take the date that the user would like to create an event for and split each section based on the comma separation
                //The items split up will be placed in an array. The array created to hold the sections that are split up is eventDateArray
                //eventDateArray[0]= year , eventDateArray[1]= month, eventDateArray[2]= day
                string[] eventDateArray = eventDate.Split(",");

                //Converting the string data values in the eventDateArray into int data values that can be used in the DateTime method
                //Converting the year, which was originally a string data type, into an integer data type
                int eventYear = Convert.ToInt32(eventDateArray[0]);
                //Converting the month, which was originally an string data type, into an integer data type
                int eventMonth = Convert.ToInt32(eventDateArray[1]);
                //Converting the day, which was originally an string data type, into an integer data type
                int eventDay = Convert.ToInt32(eventDateArray[2]);


                //Asking the user what time the event starts 
                Console.WriteLine("What time does the event start (make sure to type it in this format:  hour : minutes: am or pm)? Start time: ");
                //Creating the variables that will keep the start time of the event
                string eventStartTime = Console.ReadLine();
                //Splitting the time to have a section for the hour and for minutes
                //Hour= eventStartTimeSplit[0], Minute= eventStartTimeSplit[1], am or pm = eventStartTimeSplit[2]
                string[] eventStartTimeSplit = eventStartTime.Split(":");
                //Converting the hour and minutes into int data types to be used in the DateTime method
                int eventStartHour = Convert.ToInt32(eventStartTimeSplit[0]);
                int eventStartMinInt = Convert.ToInt32(eventStartTimeSplit[1]);
                string eventStartMin = eventStartTimeSplit[1];

                //If the user typed pm after the minutes, need to convert the time to military time that way it can be used in the DateTime method
                //Declaring the variable eventStartAmPm to check if the time needs to be converted to military time (24 hours clock)
                //ToUpper() ensures that whatever the user wrote for am or pm, it will be converted to upper case that way it can be checked within the If statement
                string eventStartAmPm = eventStartTimeSplit[2].ToUpper();
                if ((eventStartAmPm=="PM") && (eventStartHour !=12))  //If the eventStartHour is equal to 12, there is no need to add 12 to it since 12:00 pm is equal to 12:00 in the 24 hours time.
                {
                    //Since the user indicated that the time was in pm (during the afternoon or evening), the event's starting hour needs to be converted to 24 hours time (military time)
                    //To do this, 12 hours has to be added to the eventStartHour variable
                    eventStartHour += 12;
                }

                //Taking the date that the user placed in the Console and using DateTime method to display the date and start time of the event.
                //With the DateTime() method, the information inside of the parenthesis is in this format: year, month, day, hour, minutes, seconds (default to 00 seconds)
                DateTime eventDateTime = new DateTime(eventYear, eventMonth, eventDay, eventStartHour, eventStartMinInt, 00);

                //Testing to see if the DateTime() method works with the user's inputed information
                //Console.WriteLine(eventDateTime);


                //Need to consider the end date and time of the event (the event could take place for multiple days). Need to ask user if the event is on the same day or not.
                //Ask the user if the end time for the is on the same day (if it is, use the same event year, month, day).
                //If the end time is on another day, then the DateTime for the end time of the event will be different.
                //Creating a Do/While Loop that will ask if the event ends on the same day that it starts.
                //If the user types something besides "Yes" or "No" to the question, the code within the Do Loop will continue to prompt them to answer the question.

                //Declaring the error variable that will let this Do/While loop run when the user does not answer the question with a "Yes" or "No" to whether the event ends on the same day that it starts
                string error = "False";

                //Declaring the variables ending event's month, day and year, that way it can be used in the DateTime() method that is outside of the If/Else If/Else statement
                int eventYearEnd = 0;
                int eventMonthEnd = 0;
                int eventDayEnd = 0;

                do
                {
                    //Asking the user if the event ends on the same day. If the event ends on the same day, the event's year, month and day will be the same
                    Console.WriteLine("Does the event end on the same day? Type \"Yes\" if it does, \"No\" if it does not.");
                    //Obtaining the user input to determine if the event ends on the same day or not. ToUpper() ensures that the user's input will be converted to upper case
                    string eventSameDay = Console.ReadLine().ToUpper();

                    //Using an If Statement to run the code below if the user states that the event does not end on the same day that it starts.
                    if (eventSameDay == "NO")
                    {
                        //Asking the user what day the event ends
                        Console.WriteLine("What date does the event end? Make sure to type the year, month and date in numbers. " +
                            "For example if you would like to create an event on May 27, 2022, you would type in the Console: 2022, 5, 27");
                        //Getting the user's input with Console.ReadLine(). It will be represented as a string.
                        string eventDateEnd = Console.ReadLine();

                        //String.Split method is used to take the date that the user would like to create an event for and split each section based on the comma separation
                        //The items split up will be placed in an array. The array created to hold the sections that are split up is eventDateArray
                        //eventDateArray[0]= year , eventDateArray[1]= month, eventDateArray[2]= day
                        string[] eventDateEndArray = eventDateEnd.Split(",");

                        //Converting the string data values in the eventDateArray into int data values that can be used in the DateTime method
                        //Converting the year, which was originally a string data type, into an integer data type
                        eventYearEnd = Convert.ToInt32(eventDateEndArray[0]);
                        //Converting the month, which was originally an string data type, into an integer data type
                        eventMonthEnd = Convert.ToInt32(eventDateEndArray[1]);
                        //Converting the month, which was originally an string data type, into an integer data type
                        eventDayEnd = Convert.ToInt32(eventDateEndArray[2]);

                        //Gets out of the loop because the user answered the question if the event ends on the same day or not
                        error = "False";
                    }
                    else if (eventSameDay == "YES") //If the event ends on the same day that it starts
                    {
                        eventYearEnd = eventYear;
                        eventMonthEnd = eventMonth;
                        eventDayEnd = eventDay;
                        //There is no error, so the loop doesn't need to be repeated again
                        error = "False";
                    }
                    else //If the user does not type Yes or No in the Console, an error message will ask them to type Yes Or No to the question asking if the event ends on the same day
                    {
                        Console.WriteLine("You must answer \"Yes\" or \"No\" to whether or not the event ends on the same day that it starts.");
                        error = "True";
                    }
                } while (error=="True");

                //Asking the user what time the event ends 
                Console.WriteLine("What time does the event end (make sure to type it in this format:  hour : minutes: am or pm)? End time: ");
                //Creating the variables that will keep the ending time of the event
                string eventEndTime = Console.ReadLine();
                //Splitting the time to have a section for the hour and for minutes
                string[] eventEndTimeSplit = eventEndTime.Split(":");
                //Converting the hour and minutes into int data types to be used in the DateTime method
                int eventEndHour= Convert.ToInt32(eventEndTimeSplit[0]);
                int eventEndMinInt = Convert.ToInt32(eventEndTimeSplit[1]);
                string eventEndMin = eventEndTimeSplit[1];


                //If the user typed pm after the minutes, need to convert the time to military time that way it can be used in the DateTime method
                //Declaring the variable eventEndAmPm to check if the time needs to be converted to military time (24 hours clock). eventEndAmPm will either be AM or PM
                //ToUpper() ensures that whatever the user wrote for am or pm, it will be converted to upper case that way it can be checked within the If statement
                string eventEndAmPm = eventEndTimeSplit[2].ToUpper();
                if ((eventEndAmPm == "PM") && (eventEndHour != 12))
                {
                    //Since the user indicated that the time was in pm (during the afternoon or evening), the event's starting hour needs to be converted to 24 hours time (military time)
                    //To do this, 12 hours has to be added to the eventEndHour variable
                    eventEndHour += 12;
                }

                //Taking the end date that the user placed in the Console and using DateTime method to display the end date and time of the event.
                //With the DateTime() method, the information inside of the parenthesis is in this format: year, month, day, hour, minutes, seconds (default to 00 seconds)
                DateTime eventEndDateTime = new DateTime(eventYearEnd, eventMonthEnd, eventDayEnd, eventEndHour, eventEndMinInt, 00);

                //Checking to see if the eventEndDateTime will be displayed in the Console
                //Console.WriteLine(eventEndDateTime);

                //Asking the user the name of the event using Console.WriteLine
                Console.WriteLine("What is the name of the event?");
                //Setting the user input to a variable, eventName, by using Console.ReadLine()
                string eventName = Console.ReadLine();


                //Asking the user the location of the event using Console.WriteLine
                Console.WriteLine("Where will the location of the event take place?");
                //Setting the user input of the event's location to a variable, eventLocation, by using Console.ReadLine()
                string eventLocation = Console.ReadLine();


                //Asking the user the event's description (if any) or notes about the event using Console.WriteLine
                Console.WriteLine("Any descriptions or notes that you'd like to include for this event?");
                //Setting the user input of the event's location to a variable, eventLocation, by using Console.ReadLine()
                string eventDescription = Console.ReadLine();

                //Using the values from DateTime to display the date and times of the event
                //Displaying the event and its details in the console with this layout: "Date (Month Day, Year (day of week))" "Time range of the event" "Name of the event" "Location of the event" "Description of the event"
                //Console.WriteLine and Template Literal is used to display the information about the event. \n creates a new line (line break) for the information
                /*
                Console.WriteLine($"Date and starting time of the event: {eventDateTime} \n" +
                    $"Ending date and time of the event: {eventEndDateTime} \n" +
                    $"Name of the event: {eventName} \n" +
                    $"Location of the event: {eventLocation} \n" +
                    $"Description/Notes about the event: {eventDescription}");
                */


                //The template to create an event will be the same for all events: "Event number" "Date (Month Day, Year (day of week))" "Time range of the event" "Name of the event" "Location of the event" "Description of the event"
                //Since all of the events have the same format, classes can be used as a blueprint for creating the event and objects for each event.  
                //All of the events will be stored in an ArrayList. ArrayLists are able to store objects that can be accessed by an index. Objects in an ArrayList can be searched, sorted and manipulated. 
                //Since the objects are values inputed by the user, it is best to ask the user if they would like to schedule an event. If they say "Yes," then the If Statement's block will run (this block contains the code to place user input into the object).


                /*Creating the Object for each event using the Event Class*/
                //Creating the event object using each variable for the date, time, name, location and details of the event 
                Events eventInformation = new Events(eventDateTime.Year, eventDateTime.Month, eventDateTime.Day, 
                     eventDateTime.Hour, eventStartMin, eventStartAmPm,
                   eventEndDateTime.Year, eventEndDateTime.Month, eventEndDateTime.Day,
                 eventEndDateTime.Hour, eventEndMin, eventEndAmPm,
                  eventName, eventLocation, eventDescription);

                //Displaying the details of the event using the eventDetails method (which is located in the Events Class)
                //Console.WriteLine(eventInformation.displayEvent());

                //Adding the events in the ArrayList titled eventsList. The eventsList ArrayList was passed in as a parameter to be used for the createEvent() method
                eventsList.Add(eventInformation);

                //Asking users if they would like to see the events from the Event's List
                Console.WriteLine("Would you like to see the events in your event list?");
                //Obtaining the user's response to the question above. The user's response will be converted to upper case
                string seeEventList = Console.ReadLine().ToUpper();
                //If the user would like to see the events in the event's list, an If Statement will check this and then display the events in chronological order
                if (seeEventList == "YES")
                {
                    //Telling user how many events are in their event list by using template literal
                    Console.WriteLine($"There are {eventsList.Count} event(s) in your event list. Here are the event(s) in your list: ");

                    //Using a For loop to display the number of the events
                    for(int i=1; i<= eventsList.Count; i++)
                    {                       
                        //The first item in an ArrayList starts with index 0, which is why k is equal to zero for the first event on the list
                        int k = i - 1;

                        //One event should be displayed on the Console per iteration of the For loop
                        //foreach loop is used to display items in an ArrayList. Since the eventsList ArrayList has multiple items in it and we want one event and its description to be shown per iteration
                        //each event has to be in its own ArrayList to display only that event's description.
                        //This is why the oneEvent ArrayList was created to display its content for only one event per For loop iteration.
                        //If the onEvent ArrayList was not created, all of the events and their details will show up per iteration of the For loop.
                        ArrayList oneEvent= new ArrayList() { eventsList[k] };

                        //Displaying the information about the event
                        //Reading the items in the ArrayList
                        //Events is the name of the Class. eventsList is the name of the ArrayList.
                        //items is each individual section that was added to the Arraylist. items.nameOfPassedVariable will display that variable in the Console.
                        foreach (Events items in oneEvent)
                        {
                            Console.WriteLine($"Event #{i} \n" + //Displaying the number of the event on the list
                            $"Date and starting time of the event: {items.eventMonth}/{items.eventDay}/{items.eventYear} at {items.eventStartHour}:{items.eventStartMin} {items.eventStartAmPm}\n" +
                            $"Ending date and time of the event: {items.eventMonthEnd}/{items.eventDayEnd}/{items.eventYearEnd} at {items.eventEndHour}:{items.eventEndMin} {items.eventEndAmPm}\n" +
                            $"Name of the event: {items.eventName} \n" +
                            $"Location of the event: {items.eventLocation} \n" +
                            $"Description/Notes about the event: {items.eventDescription} \n");
                        }
                    }
                }

                //Displaying all the events in the ArrayList containing all the events (named eventsList) to the user in chronological order
                //To determine which event will be displayed first, there will be a comparaison between the year, month and days of the event using If/Else If Statements
                //If the date is the same for both events, their starting time (the hour the event starts) will be compared. If they start at the same hour, their starting time in minutes will be compared.
                //Comparisons will be done using If/Else If Statements


                /*Trying to place the events in a List
                //Placing the events in a List (this List will be named eventsList).
                //This line, List<Events>, will add the objects of the Events class to this list.
                List<Events> eventsList = new List<Events>
                {
                    //new Events {eventInformation }, //All the information for the event's object will be added to the eventsList

                
                    new Events
                    {
                        eventYear=  eventDateTime.Year,
                        eventMonth= eventDateTime.Month,
                        eventDay= eventDateTime.Day,
                        eventStartHour= eventDateTime.Hour,
                        eventStartMin= eventStartMin,
                        eventStartAmPm= eventStartAmPm,

                        eventYearEnd= eventEndDateTime.Year,
                        eventMonthEnd= eventEndDateTime.Month,
                        eventDayEnd= eventEndDateTime.Day,
                        eventEndHour= eventEndDateTime.Hour,
                        eventEndMin= eventEndMin,
                        eventEndAmPm= eventEndAmPm,

                        eventName= eventName,
                        eventLocation= eventLocation,
                        eventDescription= eventDescription,
                    },
                
                }
                */
            }

        }

        //Method for the Schedule Planner Component
        public static void schedulePlanner()
        {
            
            /*Creating a calendar that will appear in the Console.
            This calendar will help the user see the days of the week based on the month and year they provide*/
     
            //Asking the user what year they would like to view
            Console.WriteLine("Enter the year that you would like to schedule the event. Make sure to type it in numbers, like 2022.");
            //Letting the user type in the date (using Console.ReadLine()) and setting that date as an integer (originally a string) using Convert.ToInt32. It will equal the variable named year.
            int year = Convert.ToInt32(Console.ReadLine());

            //Asking the user the month using Console.WriteLine
            Console.WriteLine("Enter the month (make sure to place the number, so the month of May is 5).");
            int month = Convert.ToInt32(Console.ReadLine());


            //Setting the date with DateTime() method. 
            //Inside of the parameter is: year, month and day (starting with day 1 to show the entire month)
            //Displaying the first day of the month with the DateTime structure
            //firstDayOfMonth will display the date for the first day of the month indicated by the user
            DateTime firstDayOfMonth = new DateTime(year, month, 1);
            //Console.WriteLine(firstDayOfMonth);


            //DayOfWeek property will display the number that corresponds to the day of the week (0 corresponds to Sunday and Saturday corresponds to the number 6)
            //Using DayOfWeek will return a string, which is why we are converting it to an integer using Convert.ToInt32
            int dayOfWeekFirstDay = Convert.ToInt32(firstDayOfMonth.DayOfWeek);
            //Console.WriteLine(dayOfWeekFirstDay); //Displaying the number that corresponds to the day of the week for the first day of the month.

            //Displaying the month and year in the Console using the string.Format() method
            //String.Format Method takes the values of objects and converts them to strings and inserts these strings into the format indicated by the user.
            //In the example below, {0} corresponds to the Month and {1} corresponds to the year
            //date.Month will give the month's number, but not its actual name. This is why date.ToString("MMMM") is used to get the full name of the month
            string monthYear = string.Format("{0} {1}", firstDayOfMonth.ToString("MMMM"), firstDayOfMonth.Year);

            //Displaying the month and year in the calendar.
            //Creating another line above the month and year with the "\n" + monthYear
            Console.WriteLine("\n" + monthYear);

            //Creating the days of the week in the calendar
            Console.WriteLine("Sun Mon Tue Wed Thu Fri Sat");

            //Displaying the correct number of days in the calendar for that month
            //DaysInMonth static method returns the number of days in a month
            //lastDayOfMonth will display the last day of the month specified by the user
            int lastDayOfMonth = DateTime.DaysInMonth(year, month);
            //Console.WriteLine(lastDayOfMonth);


            //Positioning the days of the week in the calendar that will be shown in the Console.
            //To do this, need to determine which day of the week (like Sunday or Monday) does the first day of the month is on
            //Use a For loop and a day counter to fill to determine the numbers in the calendar following the first day of the month.
            //Let the day counter stop at the last day of the month.

            //Day Counter that will increase every time the For loop iterates (it is the number that will be filling in the calendar in the Console).
            int dayCounter = 1;

            //Determining where to place the first day of the month in the calendar that will be displayed in the Console.
            //To do this, If/Else If statements will be used to determine the location of the first day of the month in the calendar
            if (dayOfWeekFirstDay == 0) //This corresponds to the first day of the month being on Sunday
            {
                Console.Write(dayCounter); //This will display a 1 in the line right below "Sun" (this corresponds to the first day of the month).
                dayCounter += 1; //This will increase the dayCounter to 2 (which is the day after the first day of the month).
            } else if (dayOfWeekFirstDay==1) //This corresponds to the first day of the month being on Monday
            {
                Console.Write("   " + " " + dayCounter); //This will display a 1 in the line right below "Mon". The "   " corresponds to the spacing below Sun
                dayCounter += 1; //This will increase the dayCounter to 2 (which is the day after the first day of the month).
            } else if (dayOfWeekFirstDay == 2) //This corresponds to the first day of the month being on Tuesday
            {
                Console.Write("   " + "   " + "  " +  dayCounter); //This will display a 1 in the line right below "Tue". 
                dayCounter += 1; //This will increase the dayCounter to 2 (which is the day after the first day of the month).
            } else if (dayOfWeekFirstDay == 3) //This corresponds to the first day of the month being on Wednesday
            {
                Console.Write("   " + "   " + "   " + "   " + dayCounter); //This will display a 1 in the line right below "Wed".
                dayCounter += 1; //This will increase the dayCounter to 2 (which is the day after the first day of the month).
            } else if (dayOfWeekFirstDay == 4) //This corresponds to the first day of the month being on Thursday
            {
                Console.Write("   " + "   " + "   " + "   " + "    " + dayCounter); //This will display a 1 in the line right below "Thu".
                dayCounter += 1; //This will increase the dayCounter to 2 (which is the day after the first day of the month).
            } else if (dayOfWeekFirstDay == 5) //This corresponds to the first day of the month being on Friday
            {
                Console.Write("   " + "   " + "   " + "   " + "   " + "   " + "  " + dayCounter); //This will display a 1 in the line right below "Fri".
                dayCounter += 1; //This will increase the dayCounter to 2 (which is the day after the first day of the month).
            } else //This will correspobd when dayOfWeekFirstDay==6 (which corresponds to Saturday)
            {
                Console.Write("   " + "   " + "   " + "   " + "   " + "   " + "   " + "   " + dayCounter); //This will display a 1 in the line right below "Sat".
                dayCounter += 1; //This will increase the dayCounter to 2 (which is the day after the first day of the month).
            }


            //When the computer has determined where to place the first day of the month in the calendar, all the following days will follow after the number 1
            //The For loop will continue to run until after it has placed the last day of the month in the calendar.
            for (int i=0; i<lastDayOfMonth -1; i++)
            {

                //Update the comments for lines 133-142. dayOfWeekDayCounter should be dayCounterPosition. Line 124 an be deleted since it is no longer used.

                //Inside of the parameter is: year, month and day (starting with day 2 since the first day has been placed in the calendar with the If/Else If statements above)
                //Displaying the day of the month with the DateTime structure
                //dayCounterUpdated will display the date based on the user inputed year, month and whatever the day is based on the dayCounter.
                DateTime dayCounterUpdated = new DateTime(year, month, dayCounter);
                //Console.WriteLine(dayCounterUpdated);

                //DayOfWeek property will display the number that corresponds to the day of the week (0 corresponds to Sunday and Saturday corresponds to the number 6)
                //Using DayOfWeek will return a string, which is why we are converting it to an integer using Convert.ToInt32
                //dayOfWeekDayCounter will display a number between 0 and 6 which corresponds to the day of the day of the week
                int dayOfWeekDayCounter = Convert.ToInt32(dayCounterUpdated.DayOfWeek);
                //Console.WriteLine(dayOfWeekDayCounter);



                //Determining where to place the days of the month in the calendar that will be displayed in the Console.
                //To do this, If/Else If statements will be used to determine the location of the first day of the month in the calendar
                if (dayOfWeekDayCounter == 0) //This corresponds to the day of the month being on Sunday
                {
                    if (dayCounter==2)
                    {
                        Console.WriteLine(""); //Creates a new line/row to place the second day of the month
                    }
                    Console.Write(dayCounter); //This will display the number in the line right below "Sun" (this corresponds to the first day of the month).
                    dayCounter += 1; //This will increase the dayCounter to the next day of the month.
                }
                else if (dayOfWeekDayCounter == 1) //This corresponds to the day of the month being on Monday
                {
                    //Since single digit numbers (from 1 to 9) take up less space than double digit numbers,
                    //more spacing is needed between the numbers in the calendar to ensure that the numbers are below its corresponding day (like Sunday).
                    //If/Else statement will help with creating enough space beteween single digit numbers.
                    //The number 10 is also included because it is right after a single digit number(9) and would need more space to move it right below its corresponding day.   
                    if(dayCounter<=10)
                    {
                        Console.Write("   " + dayCounter);
                    } else
                    {
                        Console.Write("  " + dayCounter); //This will display the number in the line right below "Mon". Double digit numbers take up more space than single digit numbers, thus the spacing between them is smaller.
                    }
                    dayCounter += 1; //This will increase the dayCounter to the next day of the month.
                }
                else if (dayOfWeekDayCounter == 2) //This corresponds to the day of the month being on Tuesday
                {
                    //The day will be displayed as a number in the column titled "Tue".
                    if (dayCounter <= 10)
                    {
                        Console.Write("   " + dayCounter);
                    } 
                    else
                    {
                        Console.Write("  " + dayCounter); 
                    }
                    //This will increase the dayCounter to the next day of the month.
                    dayCounter += 1;
                }
                else if (dayOfWeekDayCounter == 3) //This corresponds to the day of the month being on Wednesday
                {
                    //The day will be displayed as a number in the column titled "Wed".
                    if (dayCounter <= 10)
                    {
                        Console.Write("   " + dayCounter);
                    }
                    else
                    {
                        Console.Write("  " + dayCounter); 
                    }

                    //This will increase the dayCounter to the next day of the month.
                    dayCounter += 1;
                }
                else if (dayOfWeekDayCounter == 4) //This corresponds to the day of the month being on Thursday
                {
                    //The day will be displayed as a number in the column titled "Thu".
                    if (dayCounter <= 10)
                    {
                        Console.Write("   " + dayCounter);
                    }
                    else
                    {
                        Console.Write("  " + dayCounter); 
                    }
                    //This will increase the dayCounter to the next day of the month.
                    dayCounter += 1;
                }
                else if (dayOfWeekDayCounter == 5) //This corresponds to the day of the month being on Friday
                {
                    //The day will be displayed as a number in the column titled "Fri".
                    if (dayCounter <= 10)
                    {
                        Console.Write("   " + dayCounter);
                    }
                    else
                    {
                        Console.Write("  " + dayCounter); 
                    }
                    //This will increase the dayCounter to the next day of the month.
                    dayCounter += 1;
                }
                else //This will correspond when dayOfWeekFirstDay==6 (which corresponds to Saturday)
                {
                    //The day will be displayed as a number in the column titled "Sat".
                    if (dayCounter <= 10)
                    {
                        Console.Write("   " + dayCounter);
                    }
                    else
                    {
                        Console.Write("  " + dayCounter);
                    }
                    //This will increase the dayCounter to the next day of the month.
                    dayCounter += 1;
                    //This will create a new line (a new row) to display the other numbers in the month by using Console.WriteLine("");
                    Console.WriteLine(" ");
                }      
            }
        }

        //Declaring the Events Class 
        public class Events
        {
            //Instance Variables (get means we can get the values for that variable, set means we can change the values for the variable)
            public int eventYear { get; set; } //Year of the event
            public int eventMonth { get; set; } //Month of the event
            public int eventDay { get; set; } //Day of the event
            public int eventStartHour { get; set; }//Starting Hour of the event
            public string eventStartMin { get; set; } //Starting Minute of the event
            public string eventStartAmPm { get; set; }//indicates if the time is in the morning (am) or after noon (pm)

            public int eventYearEnd { get; set; }//Year of the event when it ends
            public int eventMonthEnd { get; set; }//Month of the event when it ends
            public int eventDayEnd { get; set; }//Day of the event when it ends
            public int eventEndHour { get; set; }//Hour the event ends
            public string eventEndMin { get; set; }//Minute when the event ends
            public string eventEndAmPm { get; set; }//indicates if the time is in the morning (am) or after noon (pm)


            public string eventName { get; set; }//Name of the event
            public string eventLocation { get; set; }//Location that the event will be held at
            public string eventDescription { get; set; } //Description of the event

            /*
            //Instance Variables
            public int eventYear; //Year of the event
            public int eventMonth; //Month of the event
            public int eventDay; //Day of the event
            public int eventStartHour; //Starting Hour of the event
            public string eventStartMin; //Starting Minute of the event
            public string eventStartAmPm; //indicates if the time is in the morning (am) or after noon (pm)

            public int eventYearEnd; //Year of the event when it ends
            public int eventMonthEnd; //Month of the event when it ends
            public int eventDayEnd; //Day of the event when it ends
            public int eventEndHour; //Hour the event ends
            public string eventEndMin; //Minute when the event ends
            public string eventEndAmPm; //indicates if the time is in the morning (am) or after noon (pm)


            public string eventName; //Name of the event
            public string eventLocation; //Location that the event will be held at
            public string eventDescription; //Description of the event
            */

            //Class Constructor Declaration with multiple parameters
            public Events(int inputEventYear, int inputEventMonth, int inputEventDay,
                int inputEventStartHour, string inputEventStartMin, string inputEventStartAmPm,
                int inputEventYearEnd, int inputEventMonthEnd, int inputEventDayEnd, int inputEventEndHour, string inputEventEndMin, string inputEventEndAmPm,
                string inputEventName, string inputEventLocation, string inputEventDescription)
            {
                eventYear = inputEventYear;
                eventMonth = inputEventMonth;
                eventDay = inputEventDay;
                eventStartHour = inputEventStartHour;
                eventStartMin = inputEventStartMin;
                eventStartAmPm = inputEventStartAmPm;
                //Converting the time in hours to standard American time (not 24 hours time displaying). 12:00 pm is the same as 12:00 in the 24 hours time.
                if ((eventStartAmPm == "PM") && (eventStartHour !=12))
                {
                    //Since the user indicated that the time was in pm (during the afternoon or evening), the event's starting hour needs to be converted back to AM/PM time (not military time of 24 hours clock)
                    //To do this, 12 hours has to be substracted to the eventStartHour variable
                    eventStartHour -= 12;
                }

                eventYearEnd = inputEventYearEnd;
                eventMonthEnd = inputEventMonthEnd;
                eventDayEnd = inputEventDayEnd;
                eventEndHour = inputEventEndHour;
                eventEndMin = inputEventEndMin;
                eventEndAmPm = inputEventEndAmPm;
                //Converting the time in hours to standard American time (not 24 hours time displaying). 12:00 pm is the same as 12:00 in the 24 hours time.
                if ((eventEndAmPm == "PM") && (eventEndHour !=12))
                {
                    //Since the user indicated that the time was in pm (during the afternoon or evening), the event's ending hour needs to be converted back to AM/PM time (not military time of 24 hours clock)
                    //To do this, 12 hours has to be substracted to the eventEndHour variable
                    eventEndHour -= 12;
                }

                eventName = inputEventName;
                eventLocation = inputEventLocation;
                eventDescription = inputEventDescription;

            }

            //Creating a Method (function) that will display the details of the event in the Console.
            public String displayEvent()
            {
                return (
                    $"Date and starting time of the event: {eventMonth}/{eventDay}/{eventYear} at {eventStartHour}:{eventStartMin} {eventStartAmPm}\n" +
                    $"Ending date and time of the event: {eventMonthEnd}/{eventDayEnd}/{eventYearEnd} at {eventEndHour}:{eventEndMin} {eventEndAmPm}\n" +
                    $"Name of the event: {eventName} \n" +
                    $"Location of the event: {eventLocation} \n" +
                    $"Description/Notes about the event: {eventDescription}"
                    );
            }
          

        }

        //Need to create a class and constructor (to create the object) for the Notes
        //Each note will have the date/time (currentDateTime) and the user's note below it
        public class NoteDetails
        {
            public string noteDateTime { get; set; }
            public string userNote { get; set; }

            //Constructor that will create the objects of the class
            //The Constructor always has the same name as the class
            public NoteDetails(string currentDateTimeString, string note)
            {
                noteDateTime = currentDateTimeString;
                //Console.WriteLine("\n"); //Creating a new line (space) between the date the note was created and the note that the user typed in the console.
                userNote = note;

            }

        }

        //Method to create Notes and Memos in the Time Management App
        //Console.WriteLine will be used to ask the user if they would like to create a new set of notes
        //If they say "Yes", then the Console will ask them to name their notes and then register the date and time that the notes were created (using DateTime() method)
        //The notes will be stored in a Queue (first in, first out)
        //The Console will ask the user if they would like to view their notes. If they say "Yes", then the Console will display their notes starting from the first notes created to the latest notes.
        public static void Notes(Queue noteList, string currentDateTimeString, string note, string NoteDetails) //Passing in the noteList Queue to the Notes method
        {
            //Defining the answerNotes variable (user's input to the question asking them if they would like to create a note, see their notes or quit the notes section
            string answerNotes="value";
            
            //While loop that will ask the user if they would like to create a note or see the notes on their list.
            //If user types "Quit" in the Console, the Notes section will stop running
            while(answerNotes != "QUIT")
            {
                //Asking user if they would like to create a new Note or see their list of notes
                Console.WriteLine("Would you like to create a new note or see your list of notes? Type \"Create\" to create a new note or \"List\" to view the list of notes." +
                    "To exit the Notes section, type \"Quit\".");

                //Obtaining the user's input to the question and making their answer all capital letters with ToUpper();
                answerNotes = Console.ReadLine().ToUpper();


                if (answerNotes == "CREATE")
                {
                    //Placing the current date and time that the note was created using DateTime method
                    //Using DateTime.Now to get the current local date and time that the computer has
                    DateTime currentDateTime = DateTime.Now;
                    //Converting the currentDateTime to a string using ToString() method
                    currentDateTimeString = currentDateTime.ToString();
                    //Displaying the current date and time on the Console.
                    Console.WriteLine(currentDateTime);

                    //Tells user to type their note below
                    Console.WriteLine("Type your note below.");

                    //Gets the users notes and places it in the note variable
                    note = Console.ReadLine();

                    //Creating an Object for the note (the note's object contains the date and the user's note) using the NoteDetails Class
                    var noteInformation = new NoteDetails(currentDateTimeString, note);

                    //Adding the note that the user typed to the Note List (which is a Queue) using Enqueue().
                    //Enqueue only accepts one argument, which is why the date (currentDateTime) and the details of the note (note) were placed as an object in noteInformation
                    noteList.Enqueue(noteInformation);

                    //Might want to place the notes in an arrayList, this will make it easier for the user to delete the notes they don't want
                    //To delete the notes they don't want, the user will type in the note number they don't want
                    //(this means that each note will have a number, need to create a For loop for this).
                    //For the number they type, the index of the note will be "number-1", since the first note will be #1, but its index number will be 0.
                    //Need to do this type of thing for the events list.

                    //All the items in the noteList Queue are objects created by the NoteDetails class
                    //The code below doesn't work, have to find a way to display the notes in the noteList
                    foreach (NoteDetails item in noteList)
                    {
                        Console.WriteLine(item);
                    }

                }
                else if (answerNotes == "LIST")
                {
                    //All the items in the noteList Queue are objects created by the NoteDetails class
                    //The code below doesn't work, have to find a way to display the notes in the noteList
                    foreach (NoteDetails item in noteList)
                    {
                        Console.WriteLine(item);
                    }
                    /*
                    //Asking the user if they would like the Note List to be displayed in the Console.
                    Console.WriteLine("Would you like to see your notes in your list?");
                    //Getting the user's response to the question
                    string seeNotes = Console.ReadLine();
                    */
                } else if (answerNotes=="QUIT")
                {
                    break; //Break will let the computer stop running the code in the While loop (gets out of the While loop).
                }
                else
                {
                    Console.WriteLine("Please state whether you'd like to create a note (type \"Create\"), see the list containing your notes (type \"List\") or leave the Notes section (type \"Quit\").");
                }
            }
            
            
        }

        //Method to create a Check List
        //Console.WriteLine will ask the user if they would like to create a Check List
        //If user answers "Yes", the computer will ask them to write the items for their Check List (the code will be in a Do/While Loop and when the user types in "End", the Console will stop asking them to write items for the Check List).
        //The items in the Check List will be stored either in a List or in an ArrayList. Each item in the Check List will be given an item number (starting at 1, the 1 will be a part of a counter called itemNumberCounter).
        //When refering to that item number, since index number starts at 0, for an item with item number 1, to access its index number, it will be 1 (item number) - 1.
        //Users will be able to view their items in the Check List (computer will ask if they would like to view items in the Check List, if yes, then the items in the Check List will appear by using the foreach loop).
        //After viewing items in the Check List, the Console will ask users if they would like to remove or add items to the list (this will be done with Console.WriteLine).
        //Once items in the Check List are completed, the user can delete completed tasks by typing "Remove" to the question (if they would like to remove item(s) from the list).
        //After typing in "Remove", a new Console.WriteLine will ask what items in the Check List that they would like to remove. The user will have to type in the item number for each item they would like to delete, separating each by commas (using string.Split(",") to separate each item).
        //Remove.At(index number) will be used to delete each item from the List. Remember: First item in the Check List will have item number 1. To refer to its index number, it will be 1 (its item number) - 1
        public static void CheckList(ArrayList checkListArray, ArrayList checkListArrayNoNumbers)
        {
            //Initializing the variable that will get the user's response
            string userAnswer = "CREATE";

            //Using a Do/While Loop to run the code for the check list as long as the user does not type "Quit" in the Console.
            do
            {
                //Asking the user if they would like to create/add/view/delete an item to the check list
                Console.WriteLine("Would you like to create a check list (type \"Create\"), add an item to the check list (type \"Add\"), view an item in the check list (type \"View\"), " +
                    "or delete item(s) from the check list (type \"Delete\"). If you would like to leave the check list section, type \"Quit\".");
                //Getting the user's response. Making the user's response capital letters
                userAnswer = Console.ReadLine().ToUpper();

                //Using If/Else If statement to decide which method will run based on the user's input
                if ((userAnswer == "CREATE"))
                {
                    //Initializing the variable that the user will use to add item's in their check list
                    string userCreate = "ITEM";
                    do
                    {
                        //Prompting the user to write their items in the check list
                        Console.WriteLine("Please type the item to be placed in your check list. When you are done typing an item, hit enter on your keyboard to be asked to type another item to your list. " +
                            "If you are finished creating your check list, type \"Done\".");
                        //Getting the user's response which will decide which code runs
                        userCreate = Console.ReadLine().ToUpper();

                        if((userCreate != "CREATE") && (userCreate != "ADD") && (userCreate != "VIEW") && (userCreate != "DELETE") && (userCreate != "QUIT") && (userCreate != "DONE"))
                        {
                            //Adding the user's item for the check list into the Array List containing the items in the check list
                            checkListArray.Add(userCreate);

                        }

                    } while (userCreate != "DONE");

                } else if (userAnswer == "ADD")
                {
                    //Initializing the variable that the user will use to add item's in their check list
                    string userCreate = "ITEM";
                    do
                    {
                        //Prompting the user to write their items in the check list
                        Console.WriteLine("Add the item(s) to your check list. When you are done typing an item, hit enter on your keyboard to be asked to type another item to your list." +
                            "If you are finished creating your check list, type \"Done\".");
                        //Getting the user's response which will decide which code runs
                        userCreate = Console.ReadLine().ToUpper();

                        if ((userCreate != "CREATE") && (userCreate != "ADD") && (userCreate != "VIEW") && (userCreate != "DELETE") && (userCreate != "QUIT") && (userCreate != "DONE"))
                        {
                            checkListArray.Add(userCreate);
                        }

                    } while (userCreate != "DONE");
                }
                else if (userAnswer == "VIEW")
                {
                    //Counter that will Display the number of each item in the check list
                    int counterItem = 1;
                    //Viewing the items in the ArrayList using foreach
                    foreach (string item in checkListArray)
                    {
                        //What will be displayed in the Console is: itemNumber) Item in the checklist
                        //{0} corresponds to the number for that item in the checklist and {1} corresponds to the item in the check list
                        //The counter to be displayed before the item in the checklist will be increased by 1 every time the foreach loop runs
                        Console.WriteLine("{0}) {1}", counterItem++,item);
                    }
                }
                else if (userAnswer == "DELETE")
                {
                    //Copying the values of the checkListArray to checkListArrayNoNumbers
                    //This will make sure that the copy doesn't contain numbers which can be helpful when user starts deleting items from the check list 
                    for (int i = 0; i < checkListArray.Count - 1; i++)
                    {
                        checkListArrayNoNumbers.Add(checkListArray[i]);
                    }

                    //Counter that will Display the number of each item in the check list
                    int counterItem = 1;
                    //Viewing the items in the ArrayList using foreach
                    foreach (string item in checkListArray)
                    {
                        //What will be displayed in the Console is: itemNumber) Item in the checklist
                        //{0} corresponds to the number for that item in the checklist and {1} corresponds to the item in the check list
                        //The counter to be displayed before the item in the checklist will be increased by 1 every time the foreach loop runs
                        Console.WriteLine("{0}) {1}", counterItem++, item);
                    }

                    //Initializing the variable that the user will type the item that they would like to delete from their check list
                    string deleteItem = "some value";

                    //Using a Do/While loop to make sure that the user can continue deleting items from the list until they type "Stop" in the Console.
                    do
                    {
                        //Asking the user to delete item(s) from their check list
                        Console.WriteLine("Type the item (not the number, just the item's exact wording) that you'd like to delete from your check list. " +
                            "Hit the enter key to delete another item from the list. To stop deleting from the check list, type \"Stop\".");

                        //User's input to the above question. Since the check list has all upper case letters, the user's input also has to be upper case for the Containts() method to verify it is there
                        //This is why ToUpper() method is used.
                        deleteItem = Console.ReadLine().ToUpper();

                        //Checking to see if the item is contained within the check list (checkListArray) by using an If statement
                        //If the item is in the check list, it will then be deleted from the checklist using the Remove() method
                        if (checkListArray.Contains(deleteItem))
                        {
                            checkListArray.Remove(deleteItem);
                        } else
                        {
                            Console.WriteLine("The item that you'd like to delete is not in your check list. Please make sure to type the item that you'd like to delete. " +
                                "To exit deleting items from the check list, type \"Stop\".");
                        }

                    } while (deleteItem != "STOP");

                    //Telling the user that the items that they would like removed from their check list has been removed by using Console.WriteLine()
                    Console.WriteLine("The items that you'd like removed from your check list have been removed from the list. Here is your revised check list: ");

                    //Counter that will Display the number of each item in the check list
                    int counterItem2 = 1;
                    //Viewing the items in the ArrayList using foreach
                    foreach (string item in checkListArray)
                    {
                        //What will be displayed in the Console is: itemNumber) Item in the checklist
                        //{0} corresponds to the number for that item in the checklist and {1} corresponds to the item in the check list
                        //The counter to be displayed before the item in the checklist will be increased by 1 every time the foreach loop runs
                        Console.WriteLine("{0}) {1}", counterItem2++, item);
                    }
                }

            } while (userAnswer != "QUIT");



        }


        //Method to create a Timer
        //Creating a timer with a certain interval (3 second interal= 3000 milliseconds)
        //appTimer= new System.Timers.Timer(3000);
        //Creating an elapsed event for the timer
        //appTimer.Elapsed += OnTimedEvent;
        //appTimer.AutoReset= true;
        //appTimer.Enabled= true;
        //The code below needs to be in the Main component
        //appTimer.Stop();
        //appTimber.Dispose();
        public static void TimerApp(int[] timerValue)
        {
            //Converting the time placed by the user to set the timer in milliseconds
            //Timer in C# uses milliseconds
            int hoursToMillisec = timerValue[0] * 60 * 60 * 1000;
            int minutesToMillisec = timerValue[1] * 60 * 1000;
            int secondsToMillisec = timerValue[2] * 1000;
            //Adding all the milliseconds together
            int totalMilliseconds = hoursToMillisec + minutesToMillisec + secondsToMillisec;

            //Creating the timer
            Timer timer = new Timer(totalMilliseconds);
            timer.Elapsed += OnTimedEvent;
            //This will start the Timer
            timer.Start();

            //When the user types anything in the Console, whatever they type will stop the timer once it has gone off
            Console.ReadLine();
            //This will stop the Timer
            timer.Stop();

            //Console App Timer: https://www.youtube.com/watch?v=2tyKPpoLV94
            //Stopwatch in C#: https://www.youtube.com/watch?v=WbJ1aQwpb1s 
            //Stopwatch: https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.stopwatch?view=net-5.0
            //Timer: https://stackoverflow.com/questions/45258831/c-sharp-timer-console-application
            //Timer in C#: https://docs.microsoft.com/en-us/dotnet/api/system.timers.timer?view=net-5.0


        }

        public static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine($"Time is up! Type anything in the Console and hit the \"Enter\" key to stop the timer.");
        }

        //Variable that will get the user's input to stop the chronometer
        //This variable is placed here so it can be used by all the methods. static makes this variable be used for all the methods
        static string stopChronometer;

        //Creating a Stopwatch that can be used by the user to see how long a task takes
        //This stopwatch is more of a chronometer, which is why this method is called Chronometer
        public static void Chronometer()
        {
            //Creating the new stopwatch
            Stopwatch stopwatch = new Stopwatch();

            //Creating a timer that will display the time when the stopwatch starts
            //Display the time the time that has passed in the Console every second (1000 milliseconds)
            Timer stopwatchDisplay = new Timer(1000);

            //Initializing the variable that gets the user's response
            string chronometerStart;

            //Do/While Loop that will start the chronometer if they type "start"
            do
            {
                //Letting the user know that if they type "start" they will be able to start to the timer.
                Console.WriteLine("Type \"start\" to start the chronometer.");
                //Getting the user's response. ToLower() makes their response lower case so that it can be checked in the Do/While loop
                chronometerStart = Console.ReadLine().ToLower();

                if (chronometerStart == "start")
                {
                    //Begin the stopwatch and starts counting the time
                    stopwatch.Start();

                    //Begin the timer and starts counting the time 
                    //Timer is used to help display the change in time in the chronometer
                      stopwatchDisplay.Elapsed += OnTimedEventForChronometer; //This will let the computer go to the OnTimedEventForChronometer method
                      stopwatchDisplay.Start(); //This will start the timer
                }
                else
                {
                    //Asking the user to type start
                    Console.WriteLine("Please type \"start\" to start the chronometer.");
                }
            } while (chronometerStart != "start"); //This loop will continue to run if the user does not type "start" to start the chronometer

            //Do/While loop is used to let the user know that to quit the chronometer, they have to type "q" and hit the Enter key
            do
            {
                //Letting the user know they can stop the chronometer by typing "q" (which represents quit) in the Console and hitting enter
                Console.WriteLine("To stop the chronometer, type \"q\" in the Console and hit the \"Enter\" key");
                //Letting the user type anything in the Console
                stopChronometer = Console.ReadLine().ToLower();
            } while (stopChronometer != "q");

            //Stopping the chronometer
            stopwatch.Stop();
            //Stopping the stopwatch timer display
            stopwatchDisplay.Stop();

            //Getting the Elapsed stopwatch time as a TimeSpan value 
            //By getting the TimeSpan value, it is easier to display the hours, minutes, seconds and milliseconds. 
            //Milliseconds can be displayed to 2 decimal places
            TimeSpan elapsedChronometerTime = stopwatch.Elapsed;

            //Displaying the final time from the chronometer
            Console.WriteLine("Time elapsed: {0:00}:{1:00}:{2:00}:{3:00}", elapsedChronometerTime.Hours, elapsedChronometerTime.Minutes, elapsedChronometerTime.Seconds, elapsedChronometerTime.Milliseconds / 10);
        }

        //DateTime when the timer/stopwatch starts. Static makes this variable is accessible to all the methods
        static DateTime timeStarted = DateTime.Now;

        public static void OnTimedEventForChronometer(Object source, ElapsedEventArgs e)
        {
            //Getting the time when the stopwatched started and substracting that value from the current time
            //Current time
            DateTime timeNow = DateTime.Now;

            //Using TimeSpan property to see the difference between the current time and the the time when the stopwatch started
            TimeSpan timeDisplay = timeNow - timeStarted;

            //Initializing the elapsedTime variable that will be used for the formatting of how the time will be displayed in the Chronometer
            string elapsedTime;

            //If the user doesn't type "q" to stop the chronometer, the time will continue to be shown in the Console.
            if(stopChronometer !="q")
            {
                //elapsedTime is used for the formatting of the chronometer
                elapsedTime = String.Format("{0:00}:{1:00}:{2:00}:{3:00}", timeDisplay.Hours, timeDisplay.Minutes, timeDisplay.Seconds, timeDisplay.Milliseconds / 10);
                //The \r will help refresh the items being displayed below without creating another new line of time.
                //The console will displayed the time that has passed since the start of the chronometer.
                Console.Write($"\rTime elapsed so far: {elapsedTime}");
            }  
        }

        //Initializing currentTimeDate variable that will contain the DateTime.Now as a global variable
        //currentTimeDate variable will be used in the OnTimedEventForAlarm() method that refreshes DateTime.Now every 5 seconds
        //Since we can't pass in other variables to OnTimedEventForAlarm() method, it is best to initialize currentTimeDate variable as a global variable
        //Time and Date for right now obtained by using DateTime.Now
        static DateTime currentTimeDate = DateTime.Now;

        //Initializing variables
        static int hourDifference;
        static int minutesDifference;
        static int userAlarmHour;
        static int currentHour;
        static int userAlarmMinutes;
        static int currentMinutes;

        //Creating an alarm component in the Time Management Application
        public static void Alarm()
        {
            //Asking the user what time would they like the alarm to go off
            Console.WriteLine("What time would you like to set the alarm? Use this format to set the alarm:\n hour:minutes:am/pm (make sure to separate each item with a colon).");
            //Getting the user's input for what time they would like to set the alarm
            //ToLower() makes sure that pm or am is lower cased
            string settingAlarmString = Console.ReadLine().ToLower();

            //Splitting the hour and minutes using the Split() method
            string[] settingAlarmStringArray = settingAlarmString.Split(":");

            //Creating the array that will keep the hour and minutes as integer data types
            //It will have the same length as the settingAlarmString array minus one because am/pm will not be converted to an integer
            int[] settingAlarmArray = new int[settingAlarmStringArray.Length-1];

            //Using a For loop to convert the settingAlarmStringArray's string values to integer values
            //i<= settingAlarmStringArray.Length-2 because am/pm will not be converted to an integer
            for (int i=0; i<= settingAlarmStringArray.Length-2; i++)
            {
                //Converting the string values for hours and minutes to integers using the Convert.ToInt32() method
                //Placing the integer values to the settingAlarmArray
                settingAlarmArray[i] = Convert.ToInt32(settingAlarmStringArray[i]);
            }

            //If the time is set for pm, the hour will need to be converted to 24 hours clock (military time) since DateTime uses the 24 hours clock
            if (settingAlarmStringArray[2] == "pm")
            {
                //Adding 12 to the hour
                settingAlarmArray[0] += 12;
            }

            //Taking the user's indicated alarm time and comparing it with the the current DateTime.Now's hour and minutes
            //If the user's indicated alarm time minus the current DateTime.Now's hours and minutes are equal to zero, the alarm will go off
            //User's alarm that corresponds to the hour
            userAlarmHour = settingAlarmArray[0];

            //User's alarm that corresponds to the minutes
            userAlarmMinutes = settingAlarmArray[1];
            
             //Time and Date for right now obtained by using DateTime.Now
             DateTime currentTimeDate = DateTime.Now;

             //Using an If statement to compare the alarm time and the current time
             //If the user's alarm input for the hour and minutes is substracted by the current time and the difference is zero, the alarm will go off
             //User's alarm that corresponds to the hour
             userAlarmHour = settingAlarmArray[0];

             //Hour that is for the current time using DateTime.Now
             currentHour = currentTimeDate.Hour;

             //Differences between the hours. Getting the absolute value with Math.Abs()
             hourDifference = Math.Abs(userAlarmHour - currentHour);

             //User's alarm that corresponds to the minutes
             userAlarmMinutes = settingAlarmArray[1];

             //Hour that is for the current time using DateTime.Now
             currentMinutes = currentTimeDate.Minute;

             //Differences between the minutes. Getting the absolute value with Math.Abs()
             minutesDifference = Math.Abs(userAlarmMinutes - currentMinutes);

            //Showing the line with the amount of hours and minutes left
            Console.WriteLine($"The amount of hours: minutes: seconds left until alarm goes off: ");

            //Using a While loop to refresh the DateTime values
            //The || (or) will ensure that While loop will work if one of them is true
            while ((hourDifference != 0) || (minutesDifference != 0))
            {
                //Refreshing the values for DateTime, currentHour and currentMinutes
                currentTimeDate = DateTime.Now;
                currentHour = currentTimeDate.Hour;
                currentMinutes = currentTimeDate.Minute;

                //Differences between the hours. Getting the absolute value with Math.Abs()
                hourDifference = Math.Abs(userAlarmHour - currentHour);

                //Differences between the minutes. Getting the absolute value with Math.Abs()
                minutesDifference = Math.Abs(userAlarmMinutes - currentMinutes);

                //Seconds difference
                int secondsDifference = (60 - currentTimeDate.Second);

                //Showing the user how long it will take until the alarm goes off
                Console.Write($"\r {hourDifference}:{minutesDifference}:{secondsDifference}");
            }

            //Using an If statement to compare the alarm time and the current time
            //If the user's alarm input for the hour and minutes is substracted by the current time and the difference is zero, the alarm will go off
            if ((hourDifference == 0) && (minutesDifference == 0))
            {
                Console.WriteLine("\n"); //Creates an extra space
                Console.WriteLine("Time is up! The alarm is going off!"); //Displays that the alarm is going off.

                //The timer will stop updating DateTime.Now every 5 seconds
                //timerAlarm.Stop();

                //Creates a Beeping noise that beeps 10 times
                for (int i=0; i<10; i++)
                {
                    Console.Beep();
                }    
            }
           
        }


        //Creating a method that will check the time in different time zones throughout the world
        //Information about timezones: https://docs.microsoft.com/en-us/dotnet/api/system.timezoneinfo?view=net-5.0
        //https://docs.microsoft.com/en-us/dotnet/api/system.timezoneinfo.local?redirectedfrom=MSDN&view=net-5.0#System_TimeZoneInfo_Local
        //

        //Pre-conditions for Weather App Component: The input placed by the user has to be converted into integers to be passed through the DateTime method. The variable from the DateTime method will then be called userDate.
        //userDate has to be a string that says what the day of the week is. userDate will be pased into the todaysTemp method.
        public static void todaysTemp()
        {
            //Ask the user what the year is (user input will be determined by the Console.ReadLine())
            Console.WriteLine("What is the year?");
            //User will type today's date in the Console and Console will read what is typed
            string userYear = Console.ReadLine();

            //Edge Statement: If the user places a year that is below 2020 and above 2030, an error message will be shown
            while ((Convert.ToInt32(userYear) <= 2020) || (Convert.ToInt32(userYear) >= 2030)) //Loop will continue if these conditions are met
            {
                //Error Message saying they have to enter a year between 2020 and 2030
                Console.WriteLine("The year you enter has to be between 2020 and 2030. Please enter the correct year.");
                //Ask the user what the year is (user input will be determined by the Console.ReadLine())
                Console.WriteLine("What is the year?");
                //User will type today's date in the Console and Console will read what is typed
                userYear = Console.ReadLine();
            } 


            //Ask the user what month the date is in (user input will be determined by the Console.ReadLine())
            Console.WriteLine("What is the month? Please write it in number form. If it is May, you would type 5.");
            //User will type today's date in the Console and Console will read what is typed
            string userMonth = Console.ReadLine();

            //Edge Statement: If the user places a month that is below 1 and above 12, an error message will be shown
            while ((Convert.ToInt32(userMonth) < 1) || (Convert.ToInt32(userMonth) > 12)) //If the user types in a month below 1 or a month above 12, the statement in the do loop will continue to run.
            {
                //Error Message that tells the user that they have to enter a month between 1 and 12
                Console.WriteLine("The month you enter has to be between 1 (which corresponds to January) and 12 (corresponds to December). Please enter the correct number corresponding to its correct month.");
                //Ask the user what month the date is in (user input will be determined by the Console.ReadLine())
                Console.WriteLine("What is the month? Please write it in number form. If it is May, you would type 5.");
                //User will type today's date in the Console and Console will read what is typed
                userMonth = Console.ReadLine();
            } 


            //Ask the user what the day is (user input will be determined by the Console.ReadLine())
            Console.WriteLine("What is the day? Please type the number of the day.");
            //User will type today's date in the Console and Console will read what is typed
            string userDay = Console.ReadLine();

            //Edge Statement: Depending on the month and the leap years, the number of days in each month will be different. If the user types in a day that is not within that month, an error will appear
            //Months that have 31 days in them are placed in an array (January, March, May, July, August, October and December) 
            //int[] months31Days = { 1, 3, 5, 7, 8, 10, 12 };

            //Month converted to an integer data type
            int userMonthInt = Convert.ToInt32(userMonth);

            //Using and If/Else If loop to go through the unacceptable days in certain months
            //Months that have 31 days in them are placed in an array (January, March, May, July, August, October and December) 
            if ((userMonthInt==1) || (userMonthInt == 3) || (userMonthInt == 5) || (userMonthInt == 7)
                || (userMonthInt == 8) || (userMonthInt == 10) || (userMonthInt == 12))
            {
                //As long as the conditions for the While loop are true, the code inside of the While Loop's body will continue to run.
                while((Convert.ToInt32(userDay)<1) || (Convert.ToInt32(userDay) > 31))
                {
                    //Error Message will appear in the Console if the user types in a day that is below 1 and over 31
                    Console.WriteLine("For the month that you typed in, it has days between 1 and 31. Please type in the correct day.");
                    //Ask the user what the day is (user input will be determined by the Console.ReadLine())
                    Console.WriteLine("What is the day? Please type the number of the day.");
                    //User will type today's date in the Console and Console will read what is typed
                    userDay = Console.ReadLine();
                }
            } else if ((userMonthInt == 4) || (userMonthInt == 6) || (userMonthInt == 9) || (userMonthInt == 11))  //Months that have 30 days in them
            {
                //As long as the conditions for the While loop are true, the code inside of the While Loop's body will continue to run.
                while ((Convert.ToInt32(userDay) < 1) || (Convert.ToInt32(userDay) > 30))
                {
                    //Error Message will appear in the Console if the user types in a day that is below 1 and over 31
                    Console.WriteLine("For the month that you typed in, it has days between 1 and 30. Please type in the correct day.");
                    //Ask the user what the day is (user input will be determined by the Console.ReadLine())
                    Console.WriteLine("What is the day? Please type the number of the day.");
                    //User will type today's date in the Console and Console will read what is typed
                    userDay = Console.ReadLine();
                }
            } else if ((userMonthInt==2) && ((Convert.ToInt32(userYear)==2020) || (Convert.ToInt32(userYear) == 2024) || (Convert.ToInt32(userYear) == 2028))) //February has variable days depending if it is a leap year or not. During a leap year, February has 29 days, not during a leap year it has 28 days.
            {
                //The body of this Else If statement will run for leap years, meaning that February will have 29 days. While statement will be used to show an error if the user types in a day below 1 or over 29
                while ((Convert.ToInt32(userDay) < 1) || (Convert.ToInt32(userDay) > 29))
                {
                    //Error Message will appear in the Console if the user types in a day that is below 1 and over 31
                    Console.WriteLine("The year that you typed in is a Leap Year. This means that February has days between 1 and 29. Please type in the correct day.");
                    //Ask the user what the day is (user input will be determined by the Console.ReadLine())
                    Console.WriteLine("What is the day? Please type the number of the day.");
                    //User will type today's date in the Console and Console will read what is typed
                    userDay = Console.ReadLine();
                }
            }
            else //The body of this else statement will run when it is not a leap year and the month is February.
            {
                //There are only 28 days in February when it is not a leap year. If the user types in a date below 1 and greater than 28, an error message will appear in the Console.
                //While statement will check to ensure that the correct date in February when it is not a leap year has been typed, if not an error message and asking the user to retype the date will appear
                //The body of this Else If statement will run for leap years, meaning that February will have 29 days. While statement will be used to show an error if the user types in a day below 1 or over 29
                while ((Convert.ToInt32(userDay) < 1) || (Convert.ToInt32(userDay) > 28))
                {
                    //Error Message will appear in the Console if the user types in a day that is below 1 and over 31
                    Console.WriteLine("The year that you typed in is not a Leap Year. This means that February has days between 1 and 28. Please type in the correct day.");
                    //Ask the user what the day is (user input will be determined by the Console.ReadLine())
                    Console.WriteLine("What is the day? Please type the number of the day.");
                    //User will type today's date in the Console and Console will read what is typed
                    userDay = Console.ReadLine();
                }
            }

            //Determine the day of the week for the date typed by the user
            //DateTime will get the date and the time (in this case it is specified by the user)
            //DateTime syntax goes by year, month and day
            DateTime dateValue = new DateTime(Convert.ToInt32(userYear), Convert.ToInt32(userMonth), Convert.ToInt32(userDay));
            string userDate = dateValue.ToString("dddd"); //dateValue will determine the full weekday name if the parameter is "dddd". ToString() method will make it a string (before it was an integer)


            //Display what the user has written in the Console
            Console.WriteLine("Today's date is: " + userDate);


            //Temperatures for that area during the week
            //Since an API is not used, static temperatures in an array will contain the temperatures for all days of the week (from Monday through Sunday)
            double[] weekTemps = { 78.2, 80.4, 82.5, 77.6, 73.2, 71.7, 82.3 };

            //Declaring the temperature for that date. This value will be changed depending on the day of the week it is.
            double todayTemp = 0.0;

            //Determining the temperature based on the day of the week. If/Else If statements are used to determine what the temperature is based on the day of the week.
            if (userDate == "Monday")
            {
                todayTemp = weekTemps[0];
            }
            else if (userDate == "Tuesday")
            {
                todayTemp = weekTemps[1];
            }
            else if (userDate == "Wednesday")
            {
                todayTemp = weekTemps[2];
            }
            else if (userDate == "Thursday")
            {
                todayTemp = weekTemps[3];
            }
            else if (userDate == "Friday")
            {
                todayTemp = weekTemps[4];
            }
            else if (userDate == "Saturday")
            {
                todayTemp = weekTemps[5];
            }
            else if (userDate == "Sunday")
            {
                todayTemp = weekTemps[6];
            }

            //Displaying the temperature to the user on the Console. Template literal is used to make it easier to write the code.
            Console.WriteLine($"The temperature for {userDate} is: {todayTemp} degrees F.");
        }

    }
}
