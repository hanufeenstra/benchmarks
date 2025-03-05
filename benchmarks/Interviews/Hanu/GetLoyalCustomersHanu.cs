using System.Text.Json;
using Benchmarks.Interviews.Shared;

namespace Benchmarks.Interviews.Hanu;

public static class GetLoyalCustomersHanu
{
    public static List<int> GetLoyalCustomers(List<LogEntry> day1, List<LogEntry> day2)
    {
        HashSet<int> loyalCustomers = [];
        var userPageDictionary = new Dictionary<int, HashSet<int>>();
        
        foreach (var day1Entry in day1)
        {
            userPageDictionary.Update(day1Entry.CustomerId, day1Entry.PageId);
        }

        foreach (var day2Entry in day2)
        {
            if (userPageDictionary.TryGetValue(day2Entry.CustomerId, out var pageSet))
            {
                if (pageSet.Count == 2)
                {
                    loyalCustomers.Add(day2Entry.CustomerId);
                    continue; 
                }

                if (pageSet.Count == 1)
                {
                    if (!pageSet.Contains(day2Entry.PageId))
                    {
                        loyalCustomers.Add(day2Entry.CustomerId);
                    }
                }
            }
        }

        return loyalCustomers.ToList();
    }

    private static void Update(this Dictionary<int, HashSet<int>> userPageDictionary, int customerId, int pageId)
    {
        if (userPageDictionary.TryGetValue(customerId, out var pagesSet))
        {
            if (pagesSet.Count >= 2) return;
            
            pagesSet.Add(pageId);
        }
        else
        {
            userPageDictionary.Add(customerId, [pageId]);
        }
    }
}