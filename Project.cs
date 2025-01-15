using System;
using System.Timers;

namespace ConsoleApp13
{
    /// <summary>
    /// Main program for managing a countdown timer and stopwatch.
    /// </summary>
    internal class Program
    {
        private static Timer countdownTimer;
        private static int remainingTime;

        /// <summary>
        /// Starts a countdown timer based on user input.
        /// </summary>
        private static void StartCountdownTimer()
        {
            countdownTimer = new Timer(1000); // 1-second intervals
            countdownTimer.Elapsed += OnTimerElapsed;
            countdownTimer.AutoReset = true;
            countdownTimer.Start();

            Console.WriteLine("Countdown timer started. Press any key to stop the timer...");
            Console.ReadKey();
            countdownTimer.Stop();
        }

        /// <summary>
        /// Event handler for countdown timer ticks, updating the remaining time.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Elapsed event arguments.</param>
        private static void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (remainingTime > 0)
            {
                Console.Clear();
                Console.WriteLine($"Time remaining: {remainingTime} seconds");
                remainingTime--;
            }
            else
            {
                countdownTimer.Stop();
                Console.Clear();
                Console.WriteLine("Time's up! Timer stopped. Press any key to continue...");
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Starts a stopwatch and displays elapsed time until stopped by the user.
        /// </summary>
        private static void StartStopwatch()
        {
            Console.WriteLine("Stopwatch started. Press any key to stop...");
            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            Console.ReadKey();
            stopwatch.Stop();

            Console.Clear();
            Console.WriteLine($"Stopwatch stopped. Elapsed time: {stopwatch.Elapsed}");
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }

        /// <summary>
        /// Entry point of the program. Provides a menu to access the countdown timer and stopwatch.
        /// </summary>
        /// <param name="args">Command-line arguments (not used).</param>
        private static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Countdown Timer");
                Console.WriteLine("2. Stopwatch");
                Console.WriteLine("3. Exit");
                Console.Write("Select an option: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            Console.Write("Enter the number of seconds for the countdown: ");
                            while (!int.TryParse(Console.ReadLine(), out remainingTime) || remainingTime <= 0)
                            {
                                Console.WriteLine("Please enter a valid number greater than 0.");
                            }
                            StartCountdownTimer();
                            break;

                        case 2:
                            Console.Clear();
                            StartStopwatch();
                            break;

                        case 3:
                            Console.Clear();
                            Console.WriteLine("Exiting program... Press any key to close.");
                            Console.ReadKey();
                            return;

                        default:
                            Console.WriteLine("Invalid option. Press any key to try again...");
                            Console.ReadKey();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Press any key to try again...");
                    Console.ReadKey();
                }
            }
        }
    }
}
