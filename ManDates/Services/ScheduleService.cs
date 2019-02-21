using ManDates.Models;
using ManDates.Models.Entities;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ManDates.Services
{
    public class ScheduleService
    {
        public IEnumerable<WeekSchedule> GenerateAgenda(IEnumerable<Member> members)
        {
            var workingMembers = members.ToList();
            if (workingMembers.Count() % 2 != 0)
                workingMembers.Add(new Member
                {
                    FirstName = "-",
                    LastName = "-"
                });

            var combinations = GetUniqueCombinations(workingMembers);

            var result = new List<WeekSchedule>();
            var remaining = combinations.Where(c => !result.SelectMany(r => r.Pairs).Contains(c));

            while (remaining.Any())
            {
                var pairs = new List<Tuple<Member, Member>>();
                remaining.ForEach(r =>
                {
                    var presentMembers = pairs.Select(p => p.Item1).Union(pairs.Select(p => p.Item2));
                    if (!presentMembers.Contains(r.Item1) && !presentMembers.Contains(r.Item2))
                        pairs.Add(r);
                });

                result.Add(new WeekSchedule
                {
                    Week = result.Count() + 1,
                    Pairs = pairs.ToList()
                });
            }

            return result;
        }

        public IEnumerable<Tuple<T, T>> GetUniqueCombinations<T>(IEnumerable<T> source) where T : class
        {
            var results = new List<Tuple<T, T>>();
            source.ToList().ForEach(s =>
            {
                results.AddRange(pool().Select(p => new Tuple<T, T>(s, p)));
            });
            return results.Where(r => r.Item1 != r.Item2);

            IEnumerable<T> done() => results.Select(r => r.Item1);
            IEnumerable<T> pool() => source.Where(r => !done().Contains(r));
        }
    }
}
