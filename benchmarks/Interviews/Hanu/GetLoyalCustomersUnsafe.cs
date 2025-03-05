using System.Runtime.InteropServices;
using Benchmarks.Interviews.Shared;

namespace Benchmarks.Interviews.Hanu;

public static class GetLoyalCustomersUnsafe
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
                } 
                else if (pageSet.Count == 1 && !pageSet.Contains(day2Entry.PageId))
                {
                    loyalCustomers.Add(day2Entry.CustomerId);
                }
            }
        }

        return loyalCustomers.ToList();
    }

    private static void Update(this Dictionary<int, HashSet<int>> userPageDictionary, int customerId, int pageId)
    {
        ref var val = ref CollectionsMarshal.GetValueRefOrAddDefault(userPageDictionary, customerId, out var exists);

        if (exists)
        {
            if (val!.Count >= 2) return;

            val.Add(pageId);
        }
        else
        {
            val = [pageId];
        }

    }
}