using System;


namespace Time_Management_Console_App
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //Run the todaysTemp method (Weather App Component of the Time Management Application)
            //todaysTemp();

            //Running the Schedule Planner Component
            schedulePlanner();
        }

        //Method for the Schedule Planner Component
        public static void schedulePlanner()
        {
            //Defining an array that can have variable size (dynamic sized array)
            //This array will contain the events that the user will schedule in the planner
            string[] eventHolderArray = new string[] { };

            //Creating a calendar that will appear in the Console.
            //This calendar will help the user see the days of the week based on the month and year they provide

            //Displaying the days of the week in the calendar
            //I think the calendar gives sizes to the array
            int[,] calendar = new int[6, 7];
      

            //Asking the user what year they would like to view
            Console.WriteLine("Enter the year that you would like to schedule the event. Make sure to type it in numbers, like 2022.");
            //Letting the user type in the date (using Console.ReadLine()) and setting that date as an integer (originally a string) using Convert.ToInt32. It will equal the variable named year.
            int year = Convert.ToInt32(Console.ReadLine());

            //Asking the user the month using Console.WriteLine
            Console.WriteLine("Enter the month (make sure to place the number, so the month of May is 5).");
            int month = Convert.ToInt32(Console.ReadLine());



            //1. Create the data table to insert the days of the week. The columns will be the days of the week: https://www.youtube.com/watch?v=xD3HrIKluv8 
            //2. Determine how many days there are in a month and determine the day that the first day of the month falls in (like May 1 and what day it starts at).
            //Use an If/Else statement to determine where it will be placed in the data table (based on which day it falls in)
            //Good website to get information from: https://stackoverflow.com/questions/52416114/creating-calendar-with-array-and-loops-using-c-sharp
            //The number of days in a month will determine how many rows that you have in the data table


            //Setting the date with DateTime() method. More information about DateTime() can be found here: https://www.c-sharpcorner.com/UploadFile/mahesh/working-with-datetime-using-C-Sharp/
            //Inside of the parameter is: year, month and day (starting with day 1 to show the entire month)
            //Displaying the first day of the month with the DateTime structure
            //firstDayOfMonth will display the date for the first day of the month indicated by the user
            DateTime firstDayOfMonth = new DateTime(year, month, 1);
            Console.WriteLine(firstDayOfMonth);


            //DayOfWeek property will display the number that corresponds to the day of the week (0 corresponds to Sunday and Saturday corresponds to the number 6)
            //Using DayOfWeek will return a string, which is why we are converting it to an integer using Convert.ToInt32
            int dayOfWeekFirstDay = Convert.ToInt32(firstDayOfMonth.DayOfWeek);
            Console.WriteLine(dayOfWeekFirstDay);

            //Displaying the month and year in the Consolue using the string.Format() method
            //String.Format Method takes the values of objects and converts them to strings and inserts these strings into the format indicated by the user.
            //In the example below, {0} corresponds to the Month and {1} corresponds to the year
            //date.Month will give the month's number, but not its actual name. This is why date.ToString("MMMM") is used to get the full name of the month
            string monthYear = string.Format("{0} {1}", firstDayOfMonth.ToString("MMMM"), firstDayOfMonth.Year);

            //Displaying the month and year in the calendar
            Console.WriteLine(monthYear);

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
                Console.Write("   " + dayCounter); //This will display a 1 in the line right below "Mon". The "   " corresponds to the spacing below Sun
                dayCounter += 1; //This will increase the dayCounter to 2 (which is the day after the first day of the month).
            } else if (dayOfWeekFirstDay == 2) //This corresponds to the first day of the month being on Tuesday
            {
                Console.Write("   " + "   " + dayCounter); //This will display a 1 in the line right below "Tue". The "   " corresponds to the spacing below Sun and Mon
                dayCounter += 1; //This will increase the dayCounter to 2 (which is the day after the first day of the month).
            } else if (dayOfWeekFirstDay == 3) //This corresponds to the first day of the month being on Wednesday
            {
                Console.Write("   " + "   " + "   " + dayCounter); //This will display a 1 in the line right below "Wed".
                dayCounter += 1; //This will increase the dayCounter to 2 (which is the day after the first day of the month).
            } else if (dayOfWeekFirstDay == 4) //This corresponds to the first day of the month being on Thursday
            {
                Console.Write("   " + "   " + "   " + "   " + dayCounter); //This will display a 1 in the line right below "Thu".
                dayCounter += 1; //This will increase the dayCounter to 2 (which is the day after the first day of the month).
            } else if (dayOfWeekFirstDay == 5) //This corresponds to the first day of the month being on Friday
            {
                Console.Write("   " + "   " + "   " + "   " + "   " + dayCounter); //This will display a 1 in the line right below "Fri".
                dayCounter += 1; //This will increase the dayCounter to 2 (which is the day after the first day of the month).
            } else //This will correspobd when dayOfWeekFirstDay==6 (which coressponds to Saturday)
            {
                Console.Write("   " + "   " + "   " + "   " + "   " + "   " + dayCounter); //This will display a 1 in the line right below "Sat".
                dayCounter += 1; //This will increase the dayCounter to 2 (which is the day after the first day of the month).
            }

            //Counter that will determine the day of the week that the corresponding days will fall under (if Day 1 falls on Sunday (number 0), the second day will be on Monday (position 1)).
            int dayPosition = dayOfWeekFirstDay;

            //When the computer has determined where to place the first day of the month in the calendar, all the following days will follow after the number 1
            //The For loop will continue to run until after it has placed the last day of the month in the calendar.
            for (int i=0; i<lastDayOfMonth -1; i++)
            {

                //Update the comments for lines 133-142

                //Inside of the parameter is: year, month and day (starting with day 1 to show the entire month)
                //Displaying the first day of the month with the DateTime structure
                //firstDayOfMonth will display the date for the first day of the month indicated by the user
                DateTime dayCounterUpdated = new DateTime(year, month, dayCounter);
                //Console.WriteLine(firstDayOfMonth);

                //DayOfWeek property will display the number that corresponds to the day of the week (0 corresponds to Sunday and Saturday corresponds to the number 6)
                //Using DayOfWeek will return a string, which is why we are converting it to an integer using Convert.ToInt32
                int dayOfWeekDayCounter = Convert.ToInt32(dayCounterUpdated.DayOfWeek);
                //Console.WriteLine(dayOfWeekDayCounter);



                //Determining where to place the days of the month in the calendar that will be displayed in the Console.
                //To do this, If/Else If statements will be used to determine the location of the first day of the month in the calendar
                if (dayOfWeekDayCounter == 0) //This corresponds to the day of the month being on Sunday
                {
                    Console.Write(dayCounter); //This will display the number in the line right below "Sun" (this corresponds to the first day of the month).
                    dayCounter += 1; //This will increase the dayCounter to the next day of the month.
                }
                else if (dayOfWeekDayCounter == 1) //This corresponds to the day of the month being on Monday
                {
                    Console.Write("   " + dayCounter); //This will display the number in the line right below "Mon". The "   " corresponds to the spacing below Sun
                    dayCounter += 1; //This will increase the dayCounter to the next day of the month.
                }
                else if (dayOfWeekDayCounter == 2) //This corresponds to the day of the month being on Tuesday
                {
                    Console.Write("   " + dayCounter);
                    //Console.Write("   " + "   " + dayCounter); //This will display the number the line right below "Tue". The "   " corresponds to the spacing below Sun and Mon
                    dayCounter += 1;
                }
                else if (dayOfWeekDayCounter == 3) //This corresponds to the day of the month being on Wednesday
                {
                    Console.Write("   " + dayCounter);
                    //Console.Write("   " + "   " + "   " + dayCounter); //This will display the number in the line right below "Wed".
                    dayCounter += 1;
                }
                else if (dayOfWeekDayCounter == 4) //This corresponds to the day of the month being on Thursday
                {
                    Console.Write("   " + dayCounter);
                    //Console.Write("   " + "   " + "   " + "   " + dayCounter); //This will display the number in the line right below "Thu".
                    dayCounter += 1;
                }
                else if (dayOfWeekDayCounter == 5) //This corresponds to the day of the month being on Friday
                {
                    Console.Write("   " + dayCounter);
                    //Console.Write("   " + "   " + "   " + "   " + "   " + dayCounter); //This will display the number in the line right below "Fri".
                    dayCounter += 1;
                }
                else //This will correspond when dayOfWeekFirstDay==6 (which coressponds to Saturday)
                {
                    Console.Write("   " + dayCounter);
                    //Console.Write("   " + "   " + "   " + "   " + "   " + "   " + dayCounter); //This will display the number in the line right below "Sat".
                    dayCounter += 1;
                    //This will create a new line (a new row) to display the other numbers in the month by using Console.WriteLine("");
                    Console.WriteLine(" ");
                }

                /*Older code

                //Ensuring that the dayPosition is less than or equal to 6 (6 corresponds to Saturday, which is the last day in our calendar's row) by using an If Statement
                if ((dayPosition <=6))
                {
                    dayPosition += 1; //The following days after the first day of the month will be increasing by increments of 1 (so if day 2 is on Monday, day 3 will be on Tuesday).
                } else //if (dayPosition ==7) //Once the dayPosition is equal to 7, the number of the day will go to the next row in the calendar and be below Sunday's column
                {
                    dayPosition = 0;
                    //This will create a new line (a new row) to display the other numbers in the month by using Console.WriteLine("");
                    //Console.WriteLine(dayCounter);
                    //dayCounter += 1;
                }
                

                //Determining where to place the days of the month in the calendar that will be displayed in the Console.
                //To do this, If/Else If statements will be used to determine the location of the first day of the month in the calendar
                if (dayPosition == 0) //This corresponds to the day of the month being on Sunday
                {
                    Console.Write(dayCounter); //This will display the number in the line right below "Sun" (this corresponds to the first day of the month).
                    dayCounter += 1; //This will increase the dayCounter to the next day of the month.
                }
                else if (dayPosition == 1) //This corresponds to the day of the month being on Monday
                {
                    Console.Write("   " + dayCounter); //This will display the number in the line right below "Mon". The "   " corresponds to the spacing below Sun
                    dayCounter += 1; //This will increase the dayCounter to the next day of the month.
                }
                else if (dayPosition == 2) //This corresponds to the day of the month being on Tuesday
                {
                    Console.Write("   " + dayCounter);
                    //Console.Write("   " + "   " + dayCounter); //This will display the number the line right below "Tue". The "   " corresponds to the spacing below Sun and Mon
                    dayCounter += 1; 
                }
                else if (dayPosition == 3) //This corresponds to the day of the month being on Wednesday
                {
                    Console.Write("   " + dayCounter);
                    //Console.Write("   " + "   " + "   " + dayCounter); //This will display the number in the line right below "Wed".
                    dayCounter += 1; 
                }
                else if (dayPosition == 4) //This corresponds to the day of the month being on Thursday
                {
                    Console.Write("   " + dayCounter);
                    //Console.Write("   " + "   " + "   " + "   " + dayCounter); //This will display the number in the line right below "Thu".
                    dayCounter += 1; 
                }
                else if (dayPosition == 5) //This corresponds to the day of the month being on Friday
                {
                    Console.Write("   " + dayCounter);
                    //Console.Write("   " + "   " + "   " + "   " + "   " + dayCounter); //This will display the number in the line right below "Fri".
                    dayCounter += 1; 
                }
                else //This will correspond when dayOfWeekFirstDay==6 (which coressponds to Saturday)
                {
                    Console.Write("   " + dayCounter);
                    //Console.Write("   " + "   " + "   " + "   " + "   " + "   " + dayCounter); //This will display the number in the line right below "Sat".
                    dayCounter += 1;
                    //This will create a new line (a new row) to display the other numbers in the month by using Console.WriteLine("");
                    Console.WriteLine(" ");
                } */

            }

            //Setting the first day of the month to one
            //int firstDay = 1;

            //DayOfWeek property will display the name of the day of the week
            //Using DayOfWeek will return a string, which is why we are converting it to an integer using Convert.ToInt32
            //int dayOfWeek = Convert.ToInt32(date.DayOfWeek);

            //Filling the calendar with values
            /*for (int i=0; i<calendar.GetLength(0); i++)
            {
                for (int j=0; (j< calendar.GetLength(1)) && (firstDay - dayOfWeek +1 <= days); j++)
                {
                    if (i==0 && month > j)
                    {
                        
                        calendar[i, j] = firstDay;
                    } else
                    {
                        calendar[i, j] = firstDay - dayOfWeek + 1;
                        firstDay++;
                    }
                }
            }*/

            //Drawing the calendar in the Console
            /*for (int i=0; i< calendar.GetLength(0); i++)
            {
                for (int j=0; j<calendar.GetLength(1); j++)
                {
                    if (calendar[i,j] > 0)
                    {
                        if (calendar[i,j] <10)
                        {
                            Console.Write(" " + calendar[i, j] + " ");
                        } else
                        {
                            Console.Write(calendar[i, j] + " ");
                        }
                    } else
                    {
                        //Console.Write(firstDay);
                        Console.Write("   ");
                    }
                }
                Console.WriteLine("");
            }*/

        }

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
