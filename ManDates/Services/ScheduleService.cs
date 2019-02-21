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
        private Member placeholderMember => new Member
        {
            FirstName = "-",
            LastName = "-"
        };

        public IEnumerable<WeekSchedule> GenerateAgenda(IEnumerable<Member> members, int seed)
        {
            var combinations = GetUniqueCombinations(members);

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

                var added = pairs.Select(p => p.Item1).Union(pairs.Select(p => p.Item2));
                var leftovers = members.Where(m => !added.Contains(m));
                pairs.AddRange(leftovers.Select(l => new Tuple<Member, Member>(l, placeholderMember)));

                result.Add(new WeekSchedule
                {
                    Week = result.Count() + 1,
                    Pairs = pairs.ToList()
                });
            }

            // shuffle
            var rnd = new Random(seed);
            var weeks = Enumerable.Range(1, result.Count()).OrderBy(e => rnd.Next());

            return result.Zip(weeks, (s, w) => new WeekSchedule
            {
                Week = w,
                Pairs = s.Pairs
            });
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
