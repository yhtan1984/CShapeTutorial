using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Codility.Lesson.Lesson1_BinaryGap;
using Codility.Lesson.Lesson2_CyclicRotation;
using Codility.Lesson.Lesson2_OddOccurencesInArray;
using Codility.Lesson.Lesson3_FrogJmp;
using Codility.Lesson.Lesson3_PermMissingElement;
using Codility.Lesson.Lesson3_TapeEquilibrium;
using Codility.Lesson.Lesson4_MissingInteger;
using Codility.Lesson.Lesson4_FrogRiverOne;
using Codility.Lesson.Lesson4_PermCheck;
using Codility.Lesson.Lesson4_MaxCounters;
//using Codility.Lesson.Lesson1_BinaryGap;
//using Codility.Lesson.Lesson1_BinaryGap;
//using Codility.Lesson.Lesson1_BinaryGap;
//using Codility.Lesson.Lesson1_BinaryGap;
//using Codility.Lesson.Lesson1_BinaryGap;
//using Codility.Lesson.Lesson1_BinaryGap;
//using Codility.Lesson.Lesson1_BinaryGap;
//using Codility.Lesson.Lesson1_BinaryGap;
//using Codility.Lesson.Lesson1_BinaryGap;
//using Codility.Lesson.Lesson1_BinaryGap;


namespace System
{
    public static class RandomFactory { 
    
        private static Random r = new Random();
        
        private static int SeedMax = Int32.MaxValue;
        private static int SeedMin = 1;

        //private StaticRandom() { }

        public static int getInt_SinglePositive(int? tail = null, int? head = null)
        {
            SeedMin = (tail.HasValue) ? tail.Value : SeedMin;
            SeedMax = (head.HasValue) ? head.Value : SeedMax;

            return r.Next(SeedMin, SeedMax);
        }
    }

}

namespace Codility
{
    abstract class SolutionClass
    {
        public SolutionClass()
        {
            execute();
        }

        public abstract void execute();
    }

    public enum EnumSolution
    {
        Lesson1_BinaryGap,
        Lesson2_CyclicRotation,
        Lesson2_OddOccurencesInArray,
        Lesson3_FrogJmp,
        Lesson3_PermMissingElement,
        Lesson3_TapeEquilibrium,
        Lesson4_MissingInteger,
        Lesson4_FrogRiverOne,
        Lesson4_PermCheck,
        Lesson4_MaxCounters,

    }

    public class SolutionController
    {
        public SolutionController() { }

        public Object execute(EnumSolution solution)
        {
            switch (solution)
            {
                case EnumSolution.Lesson1_BinaryGap: return new Lesson1_BinaryGap();
                case EnumSolution.Lesson2_CyclicRotation: return new Lesson2_CyclicRotation();
                case EnumSolution.Lesson2_OddOccurencesInArray: return new Lesson2_OddOccurencesInArray();
                case EnumSolution.Lesson3_FrogJmp: return new Lesson3_FrogJmp();
                case EnumSolution.Lesson3_PermMissingElement: return new Lesson3_PermMissingElement();
                case EnumSolution.Lesson3_TapeEquilibrium: return new Lesson3_TapeEquilibrium();
                case EnumSolution.Lesson4_MissingInteger: return new Lesson4_MissingInteger();
                case EnumSolution.Lesson4_FrogRiverOne: return new Lesson4_FrogRiverOne();
                case EnumSolution.Lesson4_PermCheck: return new Lesson4_PermCheck();
                case EnumSolution.Lesson4_MaxCounters: return new Lesson4_MaxCounters();
                //case EnumSolution.Lesson1_BinaryGap: return new Lesson1_BinaryGap();
                //case EnumSolution.Lesson1_BinaryGap: return new Lesson1_BinaryGap();
                //case EnumSolution.Lesson1_BinaryGap: return new Lesson1_BinaryGap();
                //case EnumSolution.Lesson1_BinaryGap: return new Lesson1_BinaryGap();
                //case EnumSolution.Lesson1_BinaryGap: return new Lesson1_BinaryGap();
                //case EnumSolution.Lesson1_BinaryGap: return new Lesson1_BinaryGap();
                //case EnumSolution.Lesson1_BinaryGap: return new Lesson1_BinaryGap();
                //case EnumSolution.Lesson1_BinaryGap: return new Lesson1_BinaryGap();
                //case EnumSolution.Lesson1_BinaryGap: return new Lesson1_BinaryGap();
                //case EnumSolution.Lesson1_BinaryGap: return new Lesson1_BinaryGap();
                //case EnumSolution.Lesson1_BinaryGap: return new Lesson1_BinaryGap();

                default: return "";
            }
        }
    }
}
