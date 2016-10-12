using System.Collections.Generic;
using Assets.Scripts.Utility.Tuple;
using UnityEngine;

namespace Assets.Scripts.Utility.RangeDictionary
{
    /// <summary>
    /// Range dictionary with long values
    /// </summary>
    /// <typeparam name="TKey">
    /// Key to store in dictionary
    /// </typeparam>
    public class LongRangeDictionary <TKey> : RangeDictionary<TKey, long>
    {
        /// <summary>
        /// Get all data in the dictionary split into a list of tuples of ranges and their corresponding
        /// list of values. Splits into evenly spaced ranges in order to fit in the given number of sets
        /// </summary>
        /// <param name="n">
        /// Number of range sets to split data into
        /// </param>
        /// <returns>
        /// List of n tuples of ranges paired with lists of values in the range
        /// </returns>
        public List<Tuple<Range<long>, List<TKey>>> GetAllDataInNRanges(int n)
        {
            List<Tuple<Range<long>, List<TKey>>> ranges = new List<Tuple<Range<long>, List<TKey>>>();
            if (Count == 0) return ranges;
            long max = GetMaxValue();
            long min = GetMinValue();
            long increment = Mathf.CeilToInt((float)(max - min) / n);

            for (long i = min; i < max; i += increment)
            {
                Range<long> range = new Range<long>(i, i + increment);
                Tuple<Range<long>, List<TKey>> rangeList = new Tuple<Range<long>, List<TKey>>(
                    range, GetInRangeExclusiveTop(range));

                ranges.Add(rangeList);
            }
            return ranges;
        }

    }
}