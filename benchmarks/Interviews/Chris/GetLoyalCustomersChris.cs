using Benchmarks.Interviews.Shared;

namespace Benchmarks.Interviews.Chris;

public static class GetLoyalCustomersChris
{
    public static List<int> GetLoyalCustomers(List<LogEntry> day1, List<LogEntry> day2)
    {
        List<int> loyalCustomerIds = [];

        var combinedDays = day1;
        combinedDays.AddRange(day2);

        foreach (var (left, _) in combinedDays)
        {
            var rightValues = combinedDays
                .Where(x => x.CustomerId == left)
                .Select(x => x.PageId)
                .Distinct();

            if (rightValues.Count() > 1)
            {
                loyalCustomerIds.Add(left);
            }
        }

        loyalCustomerIds = [.. loyalCustomerIds.Distinct()];

        return loyalCustomerIds;
    }
}