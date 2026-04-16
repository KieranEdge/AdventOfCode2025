using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5.Services
{
    public static class RangeConcatenator
    {
        public static List<List<long>> MergeRanges(
        List<List<long>> ranges,
        bool mergeTouching = true)
        {
            if (ranges is null) throw new ArgumentNullException(nameof(ranges));
            Console.WriteLine(ranges.Count);

            // Normalise + validate + convert
            var ordered = ranges
                .Select(r =>
                {
                    if (r is null || r.Count != 2)
                        throw new ArgumentException("Each range must be a list of exactly two values [start,end].");

                    long a = r[0];
                    long b = r[1];
                    return a <= b ? (Start: a, End: b) : (Start: b, End: a);
                })
                .OrderBy(x => x.Start)
                .ThenBy(x => x.End)
                .ToList();

            if (ordered.Count == 0) return new List<List<long>>();

            var merged = new List<(long Start, long End)>();
            var (curStart, curEnd) = ordered[0];

            foreach (var (start, end) in ordered.Skip(1))
            {
                // overlap or touching?
                bool shouldMerge = mergeTouching
                    ? start <= curEnd + 1
                    : start <= curEnd;

                if (shouldMerge)
                {
                    // extend current range
                    if (end > curEnd) curEnd = end;
                }
                else
                {
                    // commit current and start new
                    merged.Add((curStart, curEnd));
                    curStart = start;
                    curEnd = end;
                }
            }

            merged.Add((curStart, curEnd));

            // Convert back to List<List<long>>
            return merged.Select(x => new List<long> { x.Start, x.End }).ToList();
        }
       
        public static List<List<long>> MergeStartEndLists(
            List<List<long>> ranges,
            bool mergeTouching = true)
        {
            if (ranges is null) throw new ArgumentNullException(nameof(ranges));
            if (ranges.Count != 2) throw new ArgumentException("Expected exactly two lists: [starts, ends].");

            var starts = ranges[0] ?? throw new ArgumentException("Starts list is null.");
            var ends = ranges[1] ?? throw new ArgumentException("Ends list is null.");

            if (starts.Count != ends.Count)
                throw new ArgumentException($"Starts and ends must be the same length. Got {starts.Count} and {ends.Count}.");

            if (starts.Count == 0)
                return new List<List<long>> { new List<long>(), new List<long>() };

            // Zip into (start,end), normalise, sort
            var ordered = Enumerable.Range(0, starts.Count)
                .Select(i =>
                {
                    long a = starts[i];
                    long b = ends[i];
                    return a <= b ? (Start: a, End: b) : (Start: b, End: a);
                })
                .OrderBy(r => r.Start)
                .ThenBy(r => r.End)
                .ToList();

            // Merge
            var merged = new List<(long Start, long End)>();
            var (curStart, curEnd) = ordered[0];

            foreach (var (start, end) in ordered.Skip(1))
            {
                bool shouldMerge = mergeTouching
                    ? TouchOrOverlap(start, curEnd)
                    : start <= curEnd;

                if (shouldMerge)
                {
                    if (end > curEnd) curEnd = end;
                }
                else
                {
                    merged.Add((curStart, curEnd));
                    curStart = start;
                    curEnd = end;
                }
            }
            merged.Add((curStart, curEnd));

            // Unzip back to [starts, ends]
            return new List<List<long>>
    {
        merged.Select(x => x.Start).ToList(),
        merged.Select(x => x.End).ToList()
    };
        }

        // Overflow-safe "start <= curEnd + 1"
        private static bool TouchOrOverlap(long nextStart, long currentEnd)
        {
            if (nextStart <= currentEnd) return true;
            if (currentEnd == long.MaxValue) return false;
            return nextStart == currentEnd + 1;
        }
    }
}
