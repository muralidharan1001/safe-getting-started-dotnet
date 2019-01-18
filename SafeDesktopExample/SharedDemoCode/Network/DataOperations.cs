using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SafeApp;
using SafeApp.Utilities;

namespace App.Network
{
    public class MutableDataOperations
    {
        private static Session _session;

        private MDataInfo _mdinfo;

        public static void InitialiseSession(Session session)
        {
            try
            {
                _session = session;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        internal async Task CreateMutableData()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            try
            {
                Console.WriteLine("\nCreating new mutable data");

                // Insert "Create MDataInfo" here

                // Insert "Permission Sets" here
                Console.WriteLine("Mutable data created succesfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.ReadLine();
                Environment.Exit(1);
            }
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        internal async Task AddEntry(string key, string value)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            try
            {
                // Insert "Add entries to mutable data" here
                Console.WriteLine("Entry Added");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        internal async Task<List<MDataEntry>> GetEntries()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            // Insert "MDataEntry list" here
            try
            {
                // Insert "Read mutable data entries" here
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw ex;
            }
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        internal async Task UpdateEntry(string key, string newValue)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            try
            {
                // Insert "Update an entry" here
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        internal async Task DeleteEntry(string key)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            try
            {
                // Insert "Remove an entry" here
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
