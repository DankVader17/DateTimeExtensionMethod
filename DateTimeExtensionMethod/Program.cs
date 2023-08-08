using System;
using DateTimeExtension;

namespace DateTimeExtension {

    public static class MyDateTimeExtension {
        private static System.DayOfWeek[] week = {DayOfWeek.Sunday, DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday};

        private static System.DayOfWeek[] GetWeekend(System.DayOfWeek[] weekdays) {
            System.DayOfWeek[] weekend = (week.Except(weekdays)).ToArray();
            return weekend;
        }
        
        private static bool IsWeekend(System.DayOfWeek day, System.DayOfWeek[] weekend) {
            for(int i = 0; i < weekend.Length; i++) {
                if(weekend[i] == day) {
                    return true;
                }
            }
            return false;
        }

        private static bool IsHoliday(DateTime date, DateTime[] holidays) {
            for(int i = 0; i < holidays.Length; i++) {
                if(holidays[i] == date) {
                    return true;
                }
            }
            return false;
        }
        
        public static DateTime GetNextBusinessDay(int numBusinessDays, DateTime[] holidays, System.DayOfWeek[] weekdays) {
            DateTime today = DateTime.UtcNow.Date;
            DateTime date = today.AddDays(numBusinessDays);


            while(IsWeekend(date.DayOfWeek, GetWeekend(weekdays)) || IsHoliday(date, holidays)) {
                date = date.AddDays(1);
            }
            return date;
        }
    }
}

class HelloWorld {

    public static void Main() {
        System.DayOfWeek[] weekDay= {DayOfWeek.Sunday, DayOfWeek.Monday, DayOfWeek.Wednesday, DayOfWeek.Thursday};
        DateTime[] holidays = new DateTime[] {
            new DateTime(2023, 8, 16),
            new DateTime(2023, 8, 28),
            new DateTime(2023, 9, 1),
            new DateTime(2024, 1, 1)
        };

        DateTime example = MyDateTimeExtension.GetNextBusinessDay(20, holidays, weekDay);
        Console.WriteLine("The next business day is: " + example);
    }
        
}