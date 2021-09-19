using System;
using System.Collections; //With this, computer is able to use the ArrayList class
using System.Collections.Generic; //With this, computer is able to add, remove and insert an object in a List<T>
using System.Timers; //With this, the timer can be used


namespace Time_Management_Console_App
{
    class Program
    {
        static void Main(string[] args)
        {

            //Run the todaysTemp method (Weather App Component of the Time Management Application)
            //todaysTemp();

            //Running the Schedule Planner Component
            //schedulePlanner();

            //Creating a Do/While loop to ask if the user would like to place an event in their event's list

            //Declaring the scheduleAnotherEvent variable that will let this Do/While loop run again when the user types "YES" in the Console
            string scheduleAnotherEvent="NO";

            //Asking the user if they would like to schedule an event
            Console.WriteLine("Would you like to schedule an event in your event list?");
            //Getting the user's response 
            string scheduleEvent = Console.ReadLine().ToUpper();

            do
            {
                if ((scheduleEvent == "YES") || (scheduleAnotherEvent == "YES"))
                {
                    //Running the Event Creator Method (which creates the events (they are objects) and places the events in a List)
                    eventCreator();
                }
                else if ((scheduleEvent != "YES") || (scheduleEvent != "NO"))
                {
                    Console.WriteLine("Please answer with a \"Yes\" or a \"No\".");
                }

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

            } while (scheduleAnotherEvent == "YES"); //The code within this Do/While loop will run again if the user answers "Yes" to adding another event to their event's list
            


            //Method to create an event to be placed in the list of events
            static void eventCreator()
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
                if (eventStartAmPm=="PM")
                {
                    //Since the user indicated that the time was in pm (during the afternoon or evening), the event's starting hour needs to be converted to 24 hours time (military time)
                    //To do this, 12 hours has to be added to the eventStartHour variable
                    eventStartHour += 12;
                }
                
                //If the user types in 1:00 where 00 corresponds to the minutes, the value for eventStartMin is equal to one zero.
                //We want to display the two zeroes in the Console when showing the time of the event, which is why 00 are added to eventStartMin by using the If loop.
                /*if(eventStartMin==0)
                {
                    eventStartMin = 00;
                }
                */
                Console.WriteLine($"Results of eventStartMin: {eventStartMin}");

                //Taking the date that the user placed in the Console and using DateTime method to display the date and start time of the event.
                //With the DateTime() method, the information inside of the parenthesis is in this format: year, month, day, hour, minutes, seconds (default to 00 seconds)
                DateTime eventDateTime = new DateTime(eventYear, eventMonth, eventDay, eventStartHour, eventStartMinInt, 00);

                //Testing to see if the DateTime() method works with the user's inputed information
                Console.WriteLine(eventDateTime);


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
                if (eventEndAmPm == "PM")
                {
                    //Since the user indicated that the time was in pm (during the afternoon or evening), the event's starting hour needs to be converted to 24 hours time (military time)
                    //To do this, 12 hours has to be added to the eventEndHour variable
                    eventEndHour += 12;
                }

                //Taking the end date that the user placed in the Console and using DateTime method to display the end date and time of the event.
                //With the DateTime() method, the information inside of the parenthesis is in this format: year, month, day, hour, minutes, seconds (default to 00 seconds)
                DateTime eventEndDateTime = new DateTime(eventYearEnd, eventMonthEnd, eventDayEnd, eventEndHour, eventEndMinInt, 00);

                //Checking to see if the eventEndDateTime will be displayed in the Console
                Console.WriteLine(eventEndDateTime);

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

                //Creating an ArrayList that will contain all the events placed by the user
                var eventsList = new ArrayList();

                //Adding the events in the ArrayList
                eventsList.Add(eventInformation);

                //Reading the items in the List
                //Events is the name of the Class. eventsList is the name of the ArrayList.
                //items is each individual section that was added to the Arraylist. items.nameOfPassedVariable will display that variable in the Console.
                foreach(Events items in eventsList)
                {
                    Console.WriteLine($"Date and starting time of the event: {items.eventMonth}/{items.eventDay}/{items.eventYear} at {items.eventStartHour}:{items.eventStartMin} {items.eventStartAmPm}\n" +
                    $"Ending date and time of the event: {items.eventMonthEnd}/{items.eventDayEnd}/{items.eventYearEnd} at {items.eventEndHour}:{items.eventEndMin} {items.eventEndAmPm}\n" +
                    $"Name of the event: {items.eventName} \n" +
                    $"Location of the event: {items.eventLocation} \n" +
                    $"Description/Notes about the event: {items.eventDescription} \n");
                }

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
                //Converting the time in hours to standard American time (not 24 hours time displaying)
                if (eventStartAmPm == "PM")
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
                //Converting the time in hours to standard American time (not 24 hours time displaying)
                if (eventEndAmPm == "PM")
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

        //Method to create Notes and Memos in the Time Management App
        //Console.WriteLine will be used to ask the user if they would like to create a new set of notes
        //If they say "Yes", then the Console will ask them to name their notes and then register the date and time that the notes were created (using DateTime() method)
        //The notes will be stored in a Queue (first in, first out)
        //The Console will ask the user if they would like to view their notes. If they say "Yes", then the Console will display their notes starting from the first notes created to the latest notes.

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
