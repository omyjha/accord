﻿// Accord Math Library
// The Accord.NET Framework
// http://accord.googlecode.com
//
// Copyright © César Souza, 2009-2013
// cesarsouza at gmail.com
//
//    This library is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 2.1 of the License, or (at your option) any later version.
//
//    This library is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public
//    License along with this library; if not, write to the Free Software
//    Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
//

namespace Accord.Math.Comparers
{
    using System.Collections.Generic;

    /// <summary>
    ///   Elementwise comparer for integer arrays.
    /// </summary>
    /// 
    public class IntegerArrayComparer : IEqualityComparer<int[]>
    {

        /// <summary>
        ///   Determines whether two instances are equal.
        /// </summary>
        /// 
        /// <param name="x">The first object to compare.</param>
        /// <param name="y">The second object to compare.</param>
        /// <returns>
        ///   <c>true</c> if the specified object is equal to the other; otherwise, <c>false</c>.
        /// </returns>
        ///   
        public bool Equals(int[] x, int[] y)
        {
            for (int i = 0; i < x.Length; i++)
                if (x[i] != y[i])
                    return false;
            return true;
        }

        /// <summary>
        ///   Returns a hash code for a given instance.
        /// </summary>
        /// 
        /// <param name="obj">The instance.</param>
        /// 
        /// <returns>
        ///   A hash code for the instance instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        /// 
        public int GetHashCode(int[] obj)
        {
            unchecked
            {
                int hash = 17;
                for (int i = 0; i < obj.Length; i++)
                    hash = hash * 23 + obj[i].GetHashCode();
                return hash;
            }
        }

    }
}
